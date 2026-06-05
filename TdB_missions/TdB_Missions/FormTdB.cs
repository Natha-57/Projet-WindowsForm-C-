using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2__Creation_De_Mission;
using _3_Visualisation_et_MAJ_missions;
using mission_tdb;
using Volet_4___Races_Aliens;

namespace TdB_Missions
{
    public partial class FormTdB : Form
    {
        private static readonly Color CouleurSurvol = Color.FromArgb(224, 238, 249);
        private static readonly Color CouleurNormale = Color.White;

        public FormTdB()
        {
            InitializeComponent();
            if (!DesignMode)
                ChargerDonneesBDD();
        }

        private void ChargerDonneesBDD()
        {
            SQLiteConnection conn = Connexion.Connec;
            if (conn == null || conn.State != ConnectionState.Open)
            {
                MessageBox.Show("Impossible d'ouvrir la connexion à la base de données.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable schemaTable = conn.GetSchema("Tables");
                foreach (DataRow row in schemaTable.Rows)
                {
                    string nomTable = row[2].ToString();
                    string sql = "SELECT * FROM " + nomTable;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                    if (MesDatas.DsGlobal.Tables.Contains(nomTable))
                        MesDatas.DsGlobal.Tables[nomTable].Clear();
                    da.Fill(MesDatas.DsGlobal, nomTable);
                }
            }
            catch (SQLiteException err)
            {
                MessageBox.Show("Erreur lors du chargement des données :\n" + err.Message, "Erreur SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            this.BackgroundImage = Image.FromFile("../../../../Images_App/Fond étoilé - Planètes.png");
            this.pictureBox5.Image = Image.FromFile("../../../../Images_App/Icones diverses/Logo Coop.png");
            this.pictureBox2.Image = Image.FromFile("../../../../Images_App/Icones diverses/1_Logo Planètes Infos.png");
            this.pictureBox4.Image = Image.FromFile("../../../../Images_App/Icones diverses/2_Logo Info Alien.png");
            this.pictureBox6.Image = Image.FromFile("../../../../Images_App/Texte Stargate TDB.png");
            this.pictureBox3.Image = Image.FromFile("../../../../Images_App/Logo Star Gate.png");
            this.pictureBox1.Image = Image.FromFile("../../../../Images_App/Icones diverses/3_Logo +.png");
            this.Icon = new Icon("../../../../Images_App/Logo Star Gate.ico");

            InitPictureBox();
            InitFiltres();
            ChargerMissions();
        }

        // ─────────────────────────────────────────────
        //  FILTRES
        // ─────────────────────────────────────────────

        private bool FiltresParDefaut()
        {
            return textBox1.Text.Trim() == ""
                && comboBox1.SelectedIndex == 0
                && comboBox2.SelectedIndex == 0
                && comboBox4.SelectedIndex == 0
                && comboBox5.SelectedIndex == 0
                && textBox3.Text.Trim() == ""
                && textBox2.Text.Trim() == "";
        }

        private void MettreAJourBoutons()
        {
            bool parDefaut = FiltresParDefaut();

            button_chercher.Enabled = !parDefaut;
            button_chercher.FlatStyle = FlatStyle.Flat;
            button_chercher.BackColor = parDefaut
                ? Color.FromArgb(180, 180, 180)
                : Color.FromArgb(128, 255, 128);
            button_chercher.ForeColor = parDefaut ? Color.FromArgb(120, 120, 120) : Color.Black;
            button_chercher.FlatAppearance.BorderColor = parDefaut
                ? Color.FromArgb(150, 150, 150)
                : Color.FromArgb(80, 200, 80);

            button_reset.Enabled = !parDefaut;
            button_reset.FlatStyle = FlatStyle.Flat;
            button_reset.BackColor = parDefaut
                ? Color.FromArgb(180, 180, 180)
                : Color.White;
            button_reset.ForeColor = parDefaut ? Color.FromArgb(120, 120, 120) : Color.Black;
            button_reset.FlatAppearance.BorderColor = parDefaut
                ? Color.FromArgb(150, 150, 150)
                : Color.FromArgb(200, 200, 200);
        }

        private void InitFiltres()
        {
            // comboBox1 — Planète
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Toutes");
            if (MesDatas.DsGlobal.Tables.Contains("planete"))
            {
                foreach (DataRow row in MesDatas.DsGlobal.Tables["planete"].Rows)
                    comboBox1.Items.Add(row[0].ToString());
            }
            comboBox1.SelectedIndex = 0;

            // comboBox2 — État
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new[] { "Tous", "À venir", "En cours", "Terminée" });
            comboBox2.SelectedIndex = 0;

            // comboBox4 — Opérateur budget (vide par défaut)
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(new[] { "", "<", "≤", "=", "≥", ">" });
            comboBox4.SelectedIndex = 0;

            // comboBox5 — Opérateur durée (vide par défaut)
            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(new[] { "", "<", "≤", "=", "≥", ">" });
            comboBox5.SelectedIndex = 0;

            // Entrée dans textBox1 → recherche
            textBox1.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    ev.SuppressKeyPress = true;
                    AppliquerFiltres();
                    button_chercher.Enabled = false;
                }
            };

            // Mise à jour des boutons à chaque changement
            textBox1.TextChanged += (s, ev) => MettreAJourBoutons();
            textBox3.TextChanged += (s, ev) => MettreAJourBoutons();
            textBox2.TextChanged += (s, ev) => MettreAJourBoutons();

            comboBox4.SelectedIndexChanged += (s, ev) => MettreAJourBoutons();
            comboBox5.SelectedIndexChanged += (s, ev) => MettreAJourBoutons();

            // Recherche auto sur sélection planète / état
            comboBox1.SelectedIndexChanged += (s, ev) => { MettreAJourBoutons(); AppliquerFiltres(); };
            comboBox2.SelectedIndexChanged += (s, ev) => { MettreAJourBoutons(); AppliquerFiltres(); };

            // Bouton chercher — grisé après clic
            button_chercher.Click += (s, ev) =>
            {
                AppliquerFiltres();
                button_chercher.Enabled = false;
            };

            // Bouton reset
            button_reset.Click += (s, ev) => ResetFiltres();

            // État initial
            MettreAJourBoutons();
        }

        private void ResetFiltres()
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            textBox3.Text = "";
            textBox2.Text = "";
            panel1.Controls.Clear();
            ChargerMissions();
            MettreAJourBoutons();
        }

        private void AppliquerFiltres()
        {
            panel1.Controls.Clear();

            if (!MesDatas.DsGlobal.Tables.Contains("mission") ||
                !MesDatas.DsGlobal.Tables.Contains("membre")) return;

            string rechercheChef = textBox1.Text.Trim().ToLower();
            string planeteSelectionnee = comboBox1.SelectedIndex > 0 ? comboBox1.SelectedItem.ToString() : "";
            string etatSelectionne = comboBox2.SelectedIndex > 0 ? comboBox2.SelectedItem.ToString() : "";
            string opBudget = comboBox4.SelectedItem?.ToString() ?? "";
            string opDuree = comboBox5.SelectedItem?.ToString() ?? "";
            int.TryParse(textBox3.Text.Trim(), out int valBudget);
            int.TryParse(textBox2.Text.Trim(), out int valDuree);
            bool filtrerBudget = !string.IsNullOrEmpty(opBudget) && !string.IsNullOrEmpty(textBox3.Text.Trim());
            bool filtrerDuree = !string.IsNullOrEmpty(opDuree) && !string.IsNullOrEmpty(textBox2.Text.Trim());

            int marge = 20;
            int espY = 15;
            int ucHauteur = 215;
            int ucLargeur = panel1.ClientSize.Width - marge * 2 - SystemInformation.VerticalScrollBarWidth;
            int y = marge;
            int count = 0;

            foreach (DataRow row in MesDatas.DsGlobal.Tables["mission"].Rows)
            {
                try
                {
                    // ── Filtre planète ──
                    if (!string.IsNullOrEmpty(planeteSelectionnee) &&
                        row[0].ToString() != planeteSelectionnee) continue;

                    string matricule = row[5].ToString();
                    DataRow[] dr = MesDatas.DsGlobal.Tables["membre"].Select("matricule = '" + matricule + "'");
                    if (dr.Length == 0) continue;

                    DataRow d = dr[0];
                    string nomChef = d[1].ToString() + " " + d[2].ToString();

                    // ── Filtre texte libre chef ──
                    if (!string.IsNullOrEmpty(rechercheChef) &&
                        !nomChef.ToLower().Contains(rechercheChef)) continue;

                    // ── Filtre état ──
                    if (!string.IsNullOrEmpty(etatSelectionne))
                    {
                        string etat = CalculerEtat(row[3].ToString(), row[4].ToString());
                        if (etat != etatSelectionne) continue;
                    }

                    // ── Filtre budget ──
                    if (filtrerBudget && int.TryParse(row[8].ToString(), out int budget))
                    {
                        if (!CompareValeur(budget, opBudget, valBudget)) continue;
                    }

                    // ── Filtre durée ──
                    if (filtrerDuree &&
                        DateTime.TryParse(row[3].ToString(), out DateTime dep) &&
                        DateTime.TryParse(row[4].ToString(), out DateTime fin))
                    {
                        int nbJours = (int)(fin - dep).TotalDays;
                        if (!CompareValeur(nbJours, opDuree, valDuree)) continue;
                    }

                    // ── Mission retenue → afficher ──
                    UserControl1 uc = new UserControl1(
                        (row[0].ToString() + row[1].ToString()),
                        row[3].ToString(), row[4].ToString(),
                        nomChef,
                        "../../../../Images_App/Planètes/Logo - " + row[0] + ".png",
                        row[8].ToString(),
                        row[3].ToString(),
                        row[4].ToString()
                    );
                    uc.setNomPlanete(row[0].ToString());
                    uc.setNumeroMission(Convert.ToInt32(row[1]));
                    uc.Size = new Size(ucLargeur, ucHauteur);
                    uc.Location = new Point(marge, y);
                    uc.OuvrirFormulaire += UserControl1_OuvrirFormulaire;
                    panel1.Controls.Add(uc);
                    y += ucHauteur + espY;
                    count++;
                }
                catch { }
            }

            label4.Text = count + " mission(s) trouvée(s)";
        }

        private string CalculerEtat(string dateDep, string dateRetour)
        {
            if (!DateTime.TryParse(dateDep, out DateTime dep) ||
                !DateTime.TryParse(dateRetour, out DateTime fin))
                return "Inconnu";

            DateTime today = DateTime.Today;
            if (today < dep) return "À venir";
            if (today <= fin) return "En cours";
            return "Terminée";
        }

        private bool CompareValeur(int valeur, string op, int reference)
        {
            switch (op)
            {
                case "<": return valeur < reference;
                case "≤": return valeur <= reference;
                case "=": return valeur == reference;
                case "≥": return valeur >= reference;
                case ">": return valeur > reference;
                default: return true;
            }
        }

        // ─────────────────────────────────────────────
        //  CHARGEMENT INITIAL
        // ─────────────────────────────────────────────

        private void LierImageBouton(PictureBox pb, Button btn, EventHandler clickHandler)
        {
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Cursor = Cursors.Hand;
            pb.BackColor = CouleurNormale;

            int pbH = pb.Height;
            int pbW = btn.Width - 20;
            pb.Size = new Size(pbW, pbH);
            pb.Location = new Point(
                btn.Left + (btn.Width - pbW) / 2,
                btn.Bottom - pbH - 8
            );

            Timer leaveTimer = new Timer { Interval = 15 };
            leaveTimer.Tick += (s, ev) =>
            {
                leaveTimer.Stop();
                bool surBtn = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position));
                bool surPb = pb.ClientRectangle.Contains(pb.PointToClient(Cursor.Position));
                if (!surBtn && !surPb)
                {
                    pb.BackColor = CouleurNormale;
                    btn.BackColor = CouleurNormale;
                }
            };

            btn.MouseEnter += (s, ev) => { leaveTimer.Stop(); pb.BackColor = CouleurSurvol; btn.BackColor = CouleurSurvol; };
            btn.MouseLeave += (s, ev) => leaveTimer.Start();
            pb.MouseEnter += (s, ev) => { leaveTimer.Stop(); pb.BackColor = CouleurSurvol; btn.BackColor = CouleurSurvol; };
            pb.MouseLeave += (s, ev) => leaveTimer.Start();

            pb.Click += clickHandler;
        }

        private void InitPictureBox()
        {
            LierImageBouton(pictureBox1, btCreerMission, (s, ev) => btCreerMission_Click(s, ev));
            LierImageBouton(pictureBox4, btInfoAlien, (s, ev) => button1_Click(s, ev));
            LierImageBouton(pictureBox2, btInfoPlanete, (s, ev) => btInfoPlanete_Click(s, ev));
            LierImageBouton(pictureBox5, button1, (s, ev) => button1_Click_1(s, ev));
        }

        private void ChargerMissions()
        {
            panel1.Visible = true;
            panel1.BringToFront();
            panel1.AutoScroll = true;

            if (!MesDatas.DsGlobal.Tables.Contains("mission"))
            {
                MessageBox.Show("La table 'mission' est introuvable dans la base de données.", "Données manquantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!MesDatas.DsGlobal.Tables.Contains("membre"))
            {
                MessageBox.Show("La table 'membre' est introuvable dans la base de données.", "Données manquantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int marge = 20;
            int espY = 15;
            int ucHauteur = 215;
            int ucLargeur = panel1.ClientSize.Width - marge * 2 - SystemInformation.VerticalScrollBarWidth;
            int y = marge;
            int count = 0;

            foreach (DataRow row in MesDatas.DsGlobal.Tables["mission"].Rows)
            {
                try
                {
                    string filtre = "matricule = '" + row[5].ToString() + "'";
                    DataRow[] dr = MesDatas.DsGlobal.Tables["membre"].Select(filtre);
                    if (dr.Length == 0) continue;

                    DataRow d = dr[0];

                    UserControl1 uc = new UserControl1(
                        (row[0].ToString() + row[1].ToString()),
                        row[3].ToString(), row[4].ToString(),
                        d[1].ToString() + " " + d[2].ToString(),
                        "../../../../Images_App/Planètes/Logo - " + row[0] + ".png",
                        row[8].ToString(),
                        row[3].ToString(),
                        row[4].ToString()
                    );
                    uc.setNomPlanete(row[0].ToString());
                    uc.setNumeroMission(Convert.ToInt32(row[1]));
                    uc.Size = new Size(ucLargeur, ucHauteur);
                    uc.Location = new Point(marge, y);
                    uc.OuvrirFormulaire += UserControl1_OuvrirFormulaire;
                    panel1.Controls.Add(uc);
                    y += ucHauteur + espY;
                    count++;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Erreur lors du chargement d'une mission :\n" + err.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            label4.Text = count + " mission(s) trouvée(s)";
        }

        private void UserControl1_OuvrirFormulaire(object sender, EventArgs e)
        {
            UserControl1 uc = (UserControl1)sender;
            FormResumeMission f = new FormResumeMission(uc.getNomPlanete(), uc.getNumeroMission());
            f.Show();
        }

        private void btCreerMission_Click(object sender, EventArgs e)
        {
            FormAuthentification formAuth = new FormAuthentification();
            if (formAuth.ShowDialog() == DialogResult.OK)
                Rafraichir();
        }

        public void Rafraichir()
        {
            try
            {
                SQLiteConnection conn = Connexion.Connec;
                if (conn == null || conn.State != ConnectionState.Open)
                {
                    MessageBox.Show("Connexion à la base de données perdue.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable schemaTable = conn.GetSchema("Tables");
                foreach (DataRow row in schemaTable.Rows)
                {
                    string nomTable = row[2].ToString();
                    string sql = "SELECT * FROM " + nomTable;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                    if (MesDatas.DsGlobal.Tables.Contains(nomTable))
                        MesDatas.DsGlobal.Tables[nomTable].Clear();
                    da.Fill(MesDatas.DsGlobal, nomTable);
                }
            }
            catch (SQLiteException err) { MessageBox.Show(err.Message); }

            panel1.Controls.Clear();
            ChargerMissions();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Aliens f = new Form_Aliens();
            f.Show();
        }

        private void btInfoPlanete_Click(object sender, EventArgs e)
        {
            Form_Planetes f = new Form_Planetes();
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormStat f = new FormStat();
            f.ShowDialog();
        }
    }
}