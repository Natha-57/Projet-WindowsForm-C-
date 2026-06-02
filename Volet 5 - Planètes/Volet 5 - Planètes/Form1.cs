using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Volet_4___Races_Aliens
{
    public partial class Form_Planetes : Form
    {
        private readonly string _cheminBD =
            System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Stargate.db");

        private readonly string _cheminImages =
            System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ImagesPlanetes");

        private DataSet _ds = new DataSet();
        private FlowLayoutPanelDB flowPlanetes;
        private Dictionary<string, Image> _cacheImages = new Dictionary<string, Image>();

        // ── Polices statiques ──────────────────────────────────────────────────
        private static readonly Font _fontNom = new Font("Trebuchet MS", 15F, FontStyle.Bold);
        private static readonly Font _fontTemp = new Font("Trebuchet MS", 12F);
        private static readonly Font _fontDatabaz = new Font("Trebuchet MS", 12F, FontStyle.Bold);
        private static readonly Font _fontMissions = new Font("Trebuchet MS", 11F, FontStyle.Italic);
        private static readonly Font _fontFallback = new Font("Trebuchet MS", 12F, FontStyle.Bold);

        // ── Pen statique ───────────────────────────────────────────────────────
        private static readonly Pen _penBordure = new Pen(Color.FromArgb(180, 190, 210), 1);

        // ── Sous-classes double-bufferisées ────────────────────────────────────
        private class FlowLayoutPanelDB : FlowLayoutPanel
        {
            public FlowLayoutPanelDB() { this.DoubleBuffered = true; }
        }
        private class PanelDB : Panel
        {
            public PanelDB() { this.DoubleBuffered = true; }
        }

        public Form_Planetes()
        {
            InitializeComponent();
        }

        // ── Cache images ───────────────────────────────────────────────────────
        private Image ChargerImage(string chemin)
        {
            if (_cacheImages.ContainsKey(chemin))
                return _cacheImages[chemin];
            if (File.Exists(chemin))
            {
                Image img = Image.FromFile(chemin);
                _cacheImages[chemin] = img;
                return img;
            }
            return null;
        }

        // ── Vérifie si les filtres sont par défaut ─────────────────────────────
        private bool FiltresParDefaut()
        {
            bool tempParDefaut = comboBox1.SelectedIndex == 0 &&
                                 string.IsNullOrWhiteSpace(textBox2.Text);
            bool gravParDefaut = comboBox4.SelectedIndex == 0 &&
                                 string.IsNullOrWhiteSpace(textBox3.Text);
            bool opTempSansVal = comboBox1.SelectedIndex != 0 &&
                                 string.IsNullOrWhiteSpace(textBox2.Text);
            bool opGravSansVal = comboBox4.SelectedIndex != 0 &&
                                 string.IsNullOrWhiteSpace(textBox3.Text);

            return string.IsNullOrWhiteSpace(textBox1.Text)
                && (tempParDefaut || opTempSansVal)
                && (gravParDefaut || opGravSansVal)
                && comboBox2.SelectedIndex == 0
                && comboBox3.SelectedIndex == 0;
        }

        // ── Met à jour l'état des boutons ──────────────────────────────────────
        private void MettreAJourBoutons()
        {
            bool actif = !FiltresParDefaut();

            button_chercher.Enabled = actif;
            button_chercher.Cursor = actif ? Cursors.Hand : Cursors.Default;
            button_chercher.FlatStyle = actif ? FlatStyle.Standard : FlatStyle.Flat;
            button_chercher.BackColor = actif
                ? Color.FromArgb(128, 255, 128)
                : Color.FromArgb(180, 180, 180);
            button_chercher.ForeColor = actif ? Color.Black : Color.FromArgb(120, 120, 120);
            button_chercher.FlatAppearance.BorderSize = actif ? 1 : 0;

            button_reset.Enabled = actif;
            button_reset.Cursor = actif ? Cursors.Hand : Cursors.Default;
            button_reset.FlatStyle = actif ? FlatStyle.Standard : FlatStyle.Flat;
            button_reset.BackColor = actif ? Color.White : Color.FromArgb(200, 200, 200);
            button_reset.ForeColor = actif ? Color.Black : Color.FromArgb(150, 150, 150);
            button_reset.FlatAppearance.BorderSize = actif ? 1 : 0;
        }

        // ======================================================================
        // CHARGEMENT
        // ======================================================================

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            comboBox1.Items.AddRange(new object[] { "", "=", "<", "<=", ">", ">=" });
            comboBox1.SelectedIndex = 0;

            comboBox4.Items.AddRange(new object[] { "", "=", "<", "<=", ">", ">=" });
            comboBox4.SelectedIndex = 0;

            comboBox3.Items.AddRange(new object[] {
                "(tous)", "Présence de Databaz", "Pas de Databaz" });
            comboBox3.SelectedIndex = 0;

            comboBox2.Items.AddRange(new object[] {
                "(tous)", "Avec missions", "Sans mission" });
            comboBox2.SelectedIndex = 0;

            textBox1.TextChanged += (s, ev) => MettreAJourBoutons();
            textBox2.TextChanged += (s, ev) => MettreAJourBoutons();
            textBox3.TextChanged += (s, ev) => MettreAJourBoutons();
            comboBox1.SelectedIndexChanged += (s, ev) => MettreAJourBoutons();
            comboBox2.SelectedIndexChanged += (s, ev) => MettreAJourBoutons();
            comboBox3.SelectedIndexChanged += (s, ev) => MettreAJourBoutons();
            comboBox4.SelectedIndexChanged += (s, ev) => MettreAJourBoutons();

            textBox1.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter) { AfficherCartes(); ev.SuppressKeyPress = true; }
            };
            textBox2.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter) { AfficherCartes(); ev.SuppressKeyPress = true; }
            };
            textBox3.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter) { AfficherCartes(); ev.SuppressKeyPress = true; }
            };

            button_chercher.Click += (s, ev) => AfficherCartes();
            button_reset.Click += (s, ev) =>
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
                AfficherCartes();
                MettreAJourBoutons();
            };

            label4.ForeColor = Color.White;
            label4.BackColor = Color.Transparent;
            label4.Size = new Size(300, 28);

            flowPlanetes = new FlowLayoutPanelDB();
            flowPlanetes.Location = new Point(399, 148);
            flowPlanetes.Size = new Size(this.ClientSize.Width - 411,
                                                   this.ClientSize.Height - 158);
            flowPlanetes.FlowDirection = FlowDirection.LeftToRight;
            flowPlanetes.WrapContents = true;
            flowPlanetes.AutoScroll = true;
            flowPlanetes.AutoSize = false;
            flowPlanetes.BackColor = Color.Transparent;
            flowPlanetes.Padding = new Padding(8);
            flowPlanetes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                       | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(flowPlanetes);
            flowPlanetes.BringToFront();

            ChargerDonnees();
            PrechargerImages();
            AfficherCartes();

            label4.BringToFront();
            MettreAJourBoutons();
        }

        // ======================================================================
        // PRÉCHARGEMENT DES IMAGES
        // ======================================================================

        private void PrechargerImages()
        {
            if (_ds.Tables["Planetes"] == null) return;
            foreach (DataRow row in _ds.Tables["Planetes"].Rows)
            {
                string chemin = Path.Combine(_cheminImages,
                                             "Logo - " + row["nom"].ToString() + ".png");
                ChargerImage(chemin);
            }
        }

        // ======================================================================
        // CHARGEMENT EN MODE CONNECTÉ
        // ======================================================================

        private void ChargerDonnees()
        {
            string sqlPlanetes = @"
                SELECT nom,
                       COALESCE(temperature, 0) AS temperature,
                       COALESCE(gravite, 0)     AS gravite,
                       dataBazON
                FROM Planete ORDER BY nom";

            string sqlEspeces = @"
                SELECT h.nomPlanete, e.nom AS nomEspece, e.couleur,
                       h.pourcentage,
                       CASE
                           WHEN a.idEspece IS NOT NULL THEN 'Alliée'
                           WHEN en.idEspece IS NOT NULL THEN 'Ennemie'
                           ELSE 'Inconnue'
                       END AS type
                FROM Habiter h
                JOIN Espece e ON h.idEspece = e.id
                LEFT JOIN Allie  a  ON e.id = a.idEspece
                LEFT JOIN Ennemi en ON e.id = en.idEspece
                ORDER BY h.nomPlanete, h.pourcentage DESC";

            string sqlMissions = @"
                SELECT nomPlanete, COUNT(*) AS nbMissions
                FROM Mission GROUP BY nomPlanete";

            try
            {
                using (var conn = new SQLiteConnection(
                    $"Data Source={_cheminBD};Version=3;"))
                {
                    conn.Open();

                    _ds.Tables.Add("Planetes");
                    using (var da = new SQLiteDataAdapter(sqlPlanetes, conn))
                        da.Fill(_ds.Tables["Planetes"]);

                    _ds.Tables.Add("EspecesPlanete");
                    using (var da = new SQLiteDataAdapter(sqlEspeces, conn))
                        da.Fill(_ds.Tables["EspecesPlanete"]);

                    _ds.Tables.Add("MissionsPlanete");
                    using (var da = new SQLiteDataAdapter(sqlMissions, conn))
                        da.Fill(_ds.Tables["MissionsPlanete"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible de charger la base :\n\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================================
        // FILTRAGE ET AFFICHAGE (mode déconnecté)
        // ======================================================================

        private void AfficherCartes()
        {
            if (_ds.Tables["Planetes"] == null) return;

            string nom = textBox1.Text.Trim().ToLower();
            string opTemp = comboBox1.SelectedItem?.ToString() ?? "";
            string valTempStr = textBox2.Text.Trim();
            string opGrav = comboBox4.SelectedItem?.ToString() ?? "";
            string valGravStr = textBox3.Text.Trim();
            string databaz = comboBox3.SelectedItem?.ToString() ?? "(tous)";
            string missions = comboBox2.SelectedItem?.ToString() ?? "(tous)";

            double valTemp = 0, valGrav = 0;
            bool hasTemp = !string.IsNullOrEmpty(opTemp) &&
                           double.TryParse(valTempStr.Replace(".", ","), out valTemp);
            bool hasGrav = !string.IsNullOrEmpty(opGrav) &&
                           double.TryParse(valGravStr.Replace(".", ","), out valGrav);

            var lignes = _ds.Tables["Planetes"].AsEnumerable().Where(r =>
            {
                bool okNom = string.IsNullOrEmpty(nom) ||
                             r["nom"].ToString().ToLower().Contains(nom);

                bool okTemp = true;
                if (hasTemp && double.TryParse(r["temperature"].ToString()
                        .Replace(".", ","), out double temp))
                {
                    okTemp = opTemp == "<" ? temp < valTemp :
                             opTemp == "<=" ? temp <= valTemp :
                             opTemp == ">" ? temp > valTemp :
                             opTemp == ">=" ? temp >= valTemp :
                                              temp == valTemp;
                }

                bool okGrav = true;
                if (hasGrav && double.TryParse(r["gravite"].ToString()
                        .Replace(".", ","), out double grav))
                {
                    okGrav = opGrav == "<" ? grav < valGrav :
                             opGrav == "<=" ? grav <= valGrav :
                             opGrav == ">" ? grav > valGrav :
                             opGrav == ">=" ? grav >= valGrav :
                                              grav == valGrav;
                }

                bool hasDatabaz = r["dataBazON"] != DBNull.Value &&
                                  Convert.ToInt32(r["dataBazON"]) == 1;
                bool okDatabaz = databaz == "(tous)" ||
                                  (databaz == "Présence de Databaz" && hasDatabaz) ||
                                  (databaz == "Pas de Databaz" && !hasDatabaz);

                DataRow[] miss = _ds.Tables["MissionsPlanete"].Select(
                    $"nomPlanete = '{r["nom"]}'");
                int nb = miss.Length > 0 ? Convert.ToInt32(miss[0]["nbMissions"]) : 0;
                bool okMissions = missions == "(tous)" ||
                                  (missions == "Avec missions" && nb > 0) ||
                                  (missions == "Sans mission" && nb == 0);

                return okNom && okTemp && okGrav && okDatabaz && okMissions;
            }).ToList();

            flowPlanetes.SuspendLayout();
            flowPlanetes.Controls.Clear();

            foreach (DataRow row in lignes.Select(l => l))
                flowPlanetes.Controls.Add(CreerCartePlanete(row));

            flowPlanetes.ResumeLayout();

            label4.Text = $"{lignes.Count} planète(s) trouvée(s)";
        }

        // ======================================================================
        // CRÉATION D'UNE CARTE DE PLANÈTE
        // ======================================================================

        private Panel CreerCartePlanete(DataRow row)
        {
            string nomPlanete = row["nom"].ToString();
            bool databaz = row["dataBazON"] != DBNull.Value &&
                                Convert.ToInt32(row["dataBazON"]) == 1;

            PanelDB carte = new PanelDB();
            carte.Size = new Size(250, 320);
            carte.Margin = new Padding(10);
            carte.BackColor = Color.White;
            carte.Cursor = Cursors.Hand;
            carte.Tag = row;
            carte.Paint += (s, e) => e.Graphics.DrawRectangle(
                                  _penBordure, 1, 1,
                                  carte.Width - 3, carte.Height - 3);

            PictureBox img = new PictureBox();
            img.Size = new Size(180, 165);
            img.Location = new Point(30, 10);
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.BackColor = Color.White;

            string cheminImg = Path.Combine(_cheminImages, "Logo - " + nomPlanete + ".png");
            Image imgCache = ChargerImage(cheminImg);
            if (imgCache != null)
                img.Image = imgCache;
            else
            {
                img.BackColor = Color.FromArgb(200, 210, 230);
                img.Paint += (s, e) =>
                {
                    using (StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    })
                    {
                        e.Graphics.DrawString(nomPlanete, _fontFallback, Brushes.White,
                            new RectangleF(0, 0, img.Width, img.Height), sf);
                    }
                };
            }

            Label lblNom = new Label();
            lblNom.Text = nomPlanete;
            lblNom.Font = _fontNom;
            lblNom.ForeColor = Color.FromArgb(20, 40, 80);
            lblNom.TextAlign = ContentAlignment.MiddleCenter;
            lblNom.Location = new Point(0, 178);
            lblNom.Size = new Size(230, 26);
            lblNom.AutoSize = false;

            Label lblTemp = new Label();
            lblTemp.Text = $"🌡  {row["temperature"]}°";
            lblTemp.Font = _fontTemp;
            lblTemp.ForeColor = Color.FromArgb(80, 90, 110);
            lblTemp.TextAlign = ContentAlignment.MiddleCenter;
            lblTemp.Location = new Point(5, 207);
            lblTemp.Size = new Size(230, 20);
            lblTemp.AutoSize = false;

            Label lblGrav = new Label();
            lblGrav.Text = $"Gravité : {row["gravite"]} G";
            lblGrav.Font = _fontTemp;
            lblGrav.ForeColor = Color.FromArgb(80, 90, 110);
            lblGrav.TextAlign = ContentAlignment.MiddleCenter;
            lblGrav.Location = new Point(5, 228);
            lblGrav.Size = new Size(230, 20);
            lblGrav.AutoSize = false;

            Label lblDatabaz = new Label();
            lblDatabaz.Text = databaz ? "Présence de Databaz" : "Pas de Databaz";
            lblDatabaz.Font = _fontDatabaz;
            lblDatabaz.ForeColor = databaz
                                   ? Color.FromArgb(0, 128, 0)
                                   : Color.FromArgb(180, 0, 0);
            lblDatabaz.TextAlign = ContentAlignment.MiddleCenter;
            lblDatabaz.Location = new Point(05, 249);
            lblDatabaz.Size = new Size(230, 20);
            lblDatabaz.AutoSize = false;

            DataRow[] missions = _ds.Tables["MissionsPlanete"].Select(
                $"nomPlanete = '{nomPlanete}'");
            int nbMissions = missions.Length > 0
                             ? Convert.ToInt32(missions[0]["nbMissions"]) : 0;

            Label lblMissions = new Label();
            lblMissions.Text = nbMissions > 0
                                    ? $"{nbMissions} mission(s) effectuée(s)"
                                    : "Aucune mission";
            lblMissions.Font = _fontMissions;
            lblMissions.ForeColor = Color.FromArgb(110, 120, 140);
            lblMissions.TextAlign = ContentAlignment.MiddleCenter;
            lblMissions.Location = new Point(5, 272);
            lblMissions.Size = new Size(230, 22);
            lblMissions.AutoSize = false;

            carte.Controls.AddRange(new Control[] {
                img, lblNom, lblTemp, lblGrav, lblDatabaz, lblMissions });

            Action colorerHover = () =>
            {
                carte.BackColor = Color.FromArgb(235, 242, 255);
                img.BackColor = Color.FromArgb(235, 242, 255);
                lblNom.BackColor = Color.FromArgb(235, 242, 255);
                lblTemp.BackColor = Color.FromArgb(235, 242, 255);
                lblGrav.BackColor = Color.FromArgb(235, 242, 255);
                lblDatabaz.BackColor = Color.FromArgb(235, 242, 255);
                lblMissions.BackColor = Color.FromArgb(235, 242, 255);
            };
            Action colorerNormal = () =>
            {
                carte.BackColor = Color.White;
                img.BackColor = Color.White;
                lblNom.BackColor = Color.White;
                lblTemp.BackColor = Color.White;
                lblGrav.BackColor = Color.White;
                lblDatabaz.BackColor = Color.White;
                lblMissions.BackColor = Color.White;
            };

            carte.MouseEnter += (s, e) => colorerHover();
            img.MouseEnter += (s, e) => colorerHover();
            lblNom.MouseEnter += (s, e) => colorerHover();
            lblTemp.MouseEnter += (s, e) => colorerHover();
            lblGrav.MouseEnter += (s, e) => colorerHover();
            lblDatabaz.MouseEnter += (s, e) => colorerHover();
            lblMissions.MouseEnter += (s, e) => colorerHover();

            carte.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };
            img.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };
            lblNom.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };
            lblTemp.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };
            lblGrav.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };
            lblDatabaz.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };
            lblMissions.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };

            EventHandler clic = (s, e) => AfficherDetail(row);
            carte.Click += clic;
            img.Click += clic;
            lblNom.Click += clic;
            lblTemp.Click += clic;
            lblGrav.Click += clic;
            lblDatabaz.Click += clic;
            lblMissions.Click += clic;

            return carte;
        }

        // ======================================================================
        // DÉTAIL AU CLIC
        // ======================================================================

        private void AfficherDetail(DataRow row)
        {
            string nomPlanete = row["nom"].ToString();

            DataRow[] especes = _ds.Tables["EspecesPlanete"].Select(
                $"nomPlanete = '{nomPlanete}'");
            DataRow[] missions = _ds.Tables["MissionsPlanete"].Select(
                $"nomPlanete = '{nomPlanete}'");
            int nbMissions = missions.Length > 0
                             ? Convert.ToInt32(missions[0]["nbMissions"]) : 0;

            using (FormDetails fd = new FormDetails(row, _cheminImages, especes, nbMissions))
                fd.ShowDialog(this);
        }

        private void label2_Click(object sender, EventArgs e) { }
    }
}