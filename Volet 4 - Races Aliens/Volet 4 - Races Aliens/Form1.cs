using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Volet_4___Races_Aliens
{
    public partial class Form_Aliens : Form
    {
        private readonly string _cheminBD =
            System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Stargate.db");

        private readonly string _cheminImages =
            System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Images");

        private readonly string _cheminImagesPlanetes =
            System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ImagesPlanetes");

        private DataSet _ds = new DataSet();
        private FlowLayoutPanel flowRaces;

        public Form_Aliens()
        {
            InitializeComponent();
        }

        // ── Centrage texte dans les ComboBox ──────────────────────────────────
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();

            ComboBox cb = (ComboBox)sender;
            string texte = cb.Items[e.Index].ToString();

            using (StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            using (SolidBrush brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(texte, e.Font, brush, e.Bounds, sf);
            }
            e.DrawFocusRectangle();
        }

        // ── Vérifie si tous les filtres sont à leur valeur par défaut ─────────
        private bool FiltresParDefaut()
        {
            return string.IsNullOrWhiteSpace(textBox1.Text)
                && comboBox1.SelectedIndex == 0
                && comboBox2.SelectedIndex == 0
                && comboBox3.SelectedIndex == 0;
        }

        // ── Active ou désactive les boutons selon l'état des filtres ──────────
        private void MettreAJourBoutons()
        {
            bool actif = !FiltresParDefaut();

            button_chercher.Enabled = actif;
            button_reset.Enabled = actif;
            button_chercher.Cursor = actif ? Cursors.Hand : Cursors.Default;
            button_reset.Cursor = actif ? Cursors.Hand : Cursors.Default;
            button_chercher.FlatStyle = actif ? FlatStyle.Standard : FlatStyle.Flat;
            button_chercher.BackColor = actif ? Color.FromArgb(128, 255, 128) : Color.DarkGray;
            button_reset.FlatStyle = actif ? FlatStyle.Standard : FlatStyle.Flat;
            button_reset.BackColor = actif ? Color.White : Color.DarkGray;
        }

        // ======================================================================
        // CHARGEMENT
        // ======================================================================

        private void Form1_Load(object sender, EventArgs e)
        {
            // ── ComboBox ───────────────────────────────────────────────────────
            comboBox1.Items.AddRange(new object[] {
                "(Toutes)", "Bleu", "Gris", "Marron",
                "Orange", "Pourpre", "Rose", "Vert", "Violet" });
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(new object[] {
                "(Tous)", "Alliée", "Ennemie", "Inconnue" });
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.AddRange(new object[] {
                "(Toutes)", "Aina", "Aurae", "Jupiter", "Kobaia",
                "La 9ème planète", "Malaria", "Mars", "Mercure", "Muh",
                "Neptune", "Saturne", "Sckxyss", "Setna", "Sohia",
                "Terre", "Uranus", "Vénus", "Origine inconnue" });
            comboBox3.SelectedIndex = 0;

            // Agrandir la hauteur des items des ComboBox + centrage
            comboBox1.ItemHeight = 30;
            comboBox2.ItemHeight = 30;
            comboBox3.ItemHeight = 30;
            comboBox1.IntegralHeight = false;
            comboBox2.IntegralHeight = false;
            comboBox3.IntegralHeight = false;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox3.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DrawItem += ComboBox_DrawItem;
            comboBox2.DrawItem += ComboBox_DrawItem;
            comboBox3.DrawItem += ComboBox_DrawItem;

            // ── Entrée → recherche ─────────────────────────────────────────────
            textBox1.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    AppliquerFiltres();
                    ev.SuppressKeyPress = true;
                }
            };

            // ── FlowLayoutPanel à droite du panel de filtres ───────────────────
            flowRaces = new FlowLayoutPanel();
            flowRaces.Location = new Point(290, 144);
            flowRaces.Size = new Size(this.ClientSize.Width - 302,
                                               this.ClientSize.Height - 154);
            flowRaces.FlowDirection = FlowDirection.LeftToRight;
            flowRaces.WrapContents = true;
            flowRaces.AutoSize = false;
            flowRaces.AutoScroll = true;
            flowRaces.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                    | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(flowRaces);

            button_chercher.Click += (s, ev) => AppliquerFiltres();
            button_reset.Click += BtnReset_Click;

            // Brancher la mise à jour des boutons sur chaque filtre
            textBox1.TextChanged += (s, ev) => MettreAJourBoutons();
            comboBox1.SelectedIndexChanged += (s, ev) => MettreAJourBoutons();
            comboBox2.SelectedIndexChanged += (s, ev) => MettreAJourBoutons();
            comboBox3.SelectedIndexChanged += (s, ev) => MettreAJourBoutons();

            button_chercher.Cursor = Cursors.Hand;
            button_reset.Cursor = Cursors.Hand;
            button_retour.Cursor = Cursors.Hand;

            ChargerDonnees();
            AppliquerFiltres();

            // État initial (désactivé au démarrage)
            MettreAJourBoutons();
        }

        // ======================================================================
        // CHARGEMENT EN MODE CONNECTÉ
        // ======================================================================

        private void ChargerDonnees()
        {
            string sql = @"
                SELECT
                    e.id,
                    e.nom,
                    e.couleur,
                    CASE
                        WHEN a.idEspece IS NOT NULL THEN 'Alliée'
                        WHEN en.idEspece IS NOT NULL THEN 'Ennemie'
                        ELSE 'Inconnue'
                    END AS type,
                    COALESCE(a.datePremierContact, '') AS datePremierContact,
                    COALESCE(a.degreBienveillance, '') AS degreBienveillance,
                    COALESCE(a.instrumentMusique, '') AS instrumentMusique,
                    COALESCE(en.typeArme, '') AS typeArme,
                    COALESCE(en.degreAgressivite, '') AS degreAgressivite,
                    COALESCE(
                        (SELECT GROUP_CONCAT(h.nomPlanete, ', ')
                         FROM Habiter h WHERE h.idEspece = e.id),
                        'Origine inconnue'
                    ) AS planetes
                FROM Espece e
                LEFT JOIN Allie  a  ON e.id = a.idEspece
                LEFT JOIN Ennemi en ON e.id = en.idEspece
                ORDER BY e.nom";

            try
            {
                using (var conn = new SQLiteConnection(
                    $"Data Source={_cheminBD};Version=3;"))
                {
                    conn.Open();
                    _ds.Tables.Add("Races");
                    using (var da = new SQLiteDataAdapter(sql, conn))
                        da.Fill(_ds.Tables["Races"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Impossible de charger la base :\n\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================================
        // FILTRAGE (mode déconnecté)
        // ======================================================================

        private void AppliquerFiltres()
        {
            if (_ds.Tables["Races"] == null) return;

            string nom = textBox1.Text.Trim().ToLower();
            string couleur = comboBox1.SelectedItem?.ToString() ?? "(Toutes)";
            string type = comboBox2.SelectedItem?.ToString() ?? "(Tous)";
            string planete = comboBox3.SelectedItem?.ToString() ?? "(Toutes)";

            var lignes = _ds.Tables["Races"].AsEnumerable().Where(r =>
            {
                bool okNom = string.IsNullOrEmpty(nom) ||
                                 r["nom"].ToString().ToLower().Contains(nom);
                bool okCouleur = couleur == "(Toutes)" ||
                                 r["couleur"].ToString() == couleur;
                bool okType = type == "(Tous)" ||
                                 r["type"].ToString() == type;
                bool okPlanete = planete == "(Toutes)" ||
                                 (planete == "Origine inconnue" &&
                                  r["planetes"].ToString() == "Origine inconnue") ||
                                 r["planetes"].ToString().Contains(planete);
                return okNom && okCouleur && okType && okPlanete;
            }).ToList();

            flowRaces.SuspendLayout();
            flowRaces.Controls.Clear();

            foreach (var row in lignes)
                flowRaces.Controls.Add(CreerCarteRace(row));

            flowRaces.ResumeLayout();

            label4.Text = $"{lignes.Count} espèce(s) trouvée(s)";
            label4.TextAlign = ContentAlignment.MiddleCenter;
        }

        // ======================================================================
        // CRÉATION D'UNE CARTE
        // ======================================================================

        private Panel CreerCarteRace(DataRow row)
        {
            string typeRace = row["type"].ToString();
            bool allie = typeRace == "Alliée";
            bool ennemi = typeRace == "Ennemie";

            Color bordure = allie ? Color.FromArgb(0, 150, 70)
                          : ennemi ? Color.FromArgb(190, 30, 30)
                                   : Color.FromArgb(120, 130, 150);

            // --- Carte ---
            Panel carte = new Panel();
            carte.Size = new Size(200, 270);
            carte.Margin = new Padding(7);
            carte.BackColor = Color.White;
            carte.Cursor = Cursors.Hand;
            carte.Tag = row;
            carte.Paint += (s, e) => e.Graphics.DrawRectangle(
                                  new Pen(bordure, 2), 1, 1,
                                  carte.Width - 3, carte.Height - 3);

            // --- Panel image ---
            Panel pnlImg = new Panel();
            pnlImg.Size = new Size(165, 145);
            pnlImg.Location = new Point(17, 22);
            pnlImg.BackColor = Color.White;
            pnlImg.BorderStyle = BorderStyle.None;

            PictureBox img = new PictureBox();
            img.Size = new Size(165, 145);
            img.Location = new Point(0, 0);
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.BackColor = Color.White;

            string cheminImg = System.IO.Path.Combine(
                                   _cheminImages,
                                   row["nom"].ToString() + ".png");

            if (System.IO.File.Exists(cheminImg))
            {
                img.Image = Image.FromFile(cheminImg);
            }
            else
            {
                img.BackColor = CouleurEspece(row["couleur"].ToString());
                string initTxt = row["nom"].ToString().Length >= 2
                                 ? row["nom"].ToString().Substring(0, 2).ToUpper()
                                 : row["nom"].ToString().ToUpper();
                img.Paint += (s, e) =>
                {
                    using (Font f = new Font("Trebuchet MS", 18F, FontStyle.Bold))
                    using (StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    })
                    {
                        e.Graphics.DrawString(initTxt, f, Brushes.White,
                            new RectangleF(0, 0, img.Width, img.Height), sf);
                    }
                };
            }
            pnlImg.Controls.Add(img);

            // --- Badge type ---
            Label badge = new Label();
            badge.Text = allie ? "ALLIÉE" : ennemi ? "ENNEMIE" : "?";
            badge.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold);
            badge.ForeColor = Color.White;
            badge.BackColor = bordure;
            badge.TextAlign = ContentAlignment.MiddleCenter;
            badge.Location = new Point(0, 0);
            badge.Size = new Size(80, 22);
            badge.AutoSize = false;

            // --- Nom ---
            Label lblNom = new Label();
            lblNom.Text = row["nom"].ToString();
            lblNom.Font = new Font("Trebuchet MS", 14F, FontStyle.Bold);
            lblNom.ForeColor = Color.FromArgb(20, 40, 80);
            lblNom.TextAlign = ContentAlignment.MiddleCenter;
            lblNom.Location = new Point(5, 170);
            lblNom.Size = new Size(190, 26);
            lblNom.AutoSize = false;

            // --- Couleur ---
            Label lblCouleur = new Label();
            lblCouleur.Text = row["couleur"].ToString();
            lblCouleur.Font = new Font("Trebuchet MS", 12F);
            lblCouleur.ForeColor = Color.FromArgb(90, 100, 120);
            lblCouleur.TextAlign = ContentAlignment.MiddleCenter;
            lblCouleur.Location = new Point(5, 197);
            lblCouleur.Size = new Size(190, 22);
            lblCouleur.AutoSize = false;

            // --- Planètes ---
            Label lblPlanete = new Label();
            lblPlanete.Text = row["planetes"].ToString();
            lblPlanete.Font = new Font("Trebuchet MS", 11F, FontStyle.Italic);
            lblPlanete.ForeColor = Color.FromArgb(110, 120, 140);
            lblPlanete.TextAlign = ContentAlignment.TopCenter;
            lblPlanete.Location = new Point(5, 220);
            lblPlanete.Size = new Size(190, 44);
            lblPlanete.AutoSize = false;

            carte.Controls.AddRange(new Control[] {
                pnlImg, badge, lblNom, lblCouleur, lblPlanete });

            // ── Hover ──────────────────────────────────────────────────────────
            Action colorerHover = () =>
            {
                carte.BackColor = Color.FromArgb(235, 242, 255);
                pnlImg.BackColor = Color.FromArgb(235, 242, 255);
                img.BackColor = Color.FromArgb(235, 242, 255);
                lblNom.BackColor = Color.FromArgb(235, 242, 255);
                lblCouleur.BackColor = Color.FromArgb(235, 242, 255);
                lblPlanete.BackColor = Color.FromArgb(235, 242, 255);
            };
            Action colorerNormal = () =>
            {
                carte.BackColor = Color.White;
                pnlImg.BackColor = Color.White;
                img.BackColor = Color.White;
                lblNom.BackColor = Color.White;
                lblCouleur.BackColor = Color.White;
                lblPlanete.BackColor = Color.White;
            };

            carte.MouseEnter += (s, e) => colorerHover();
            pnlImg.MouseEnter += (s, e) => colorerHover();
            img.MouseEnter += (s, e) => colorerHover();
            lblNom.MouseEnter += (s, e) => colorerHover();
            lblCouleur.MouseEnter += (s, e) => colorerHover();
            lblPlanete.MouseEnter += (s, e) => colorerHover();
            badge.MouseEnter += (s, e) => colorerHover();

            carte.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };
            pnlImg.MouseLeave += (s, e) => {
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
            lblCouleur.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };
            lblPlanete.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };
            badge.MouseLeave += (s, e) => {
                if (!carte.ClientRectangle.Contains(carte.PointToClient(Cursor.Position)))
                    colorerNormal();
            };

            // ── Clic → détail ──────────────────────────────────────────────────
            EventHandler clic = (s, e) => AfficherDetail(row);
            carte.Click += clic;
            pnlImg.Click += clic;
            img.Click += clic;
            lblNom.Click += clic;
            lblCouleur.Click += clic;
            lblPlanete.Click += clic;
            badge.Click += clic;

            return carte;
        }

        // ======================================================================
        // DÉTAIL AU CLIC
        // ======================================================================

        private void AfficherDetail(DataRow row)
        {
            using (FormDetail fd = new FormDetail(row, _cheminImages, _cheminImagesPlanetes))
                fd.ShowDialog(this);
        }

        // ======================================================================
        // UTILITAIRES
        // ======================================================================

        private void BtnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            AppliquerFiltres();
            MettreAJourBoutons();
        }

        private Color CouleurEspece(string couleur)
        {
            switch (couleur)
            {
                case "Bleu": return Color.FromArgb(40, 100, 200);
                case "Gris": return Color.FromArgb(120, 130, 145);
                case "Marron": return Color.FromArgb(130, 80, 40);
                case "Orange": return Color.FromArgb(220, 120, 20);
                case "Pourpre": return Color.FromArgb(130, 0, 130);
                case "Rose": return Color.FromArgb(210, 80, 130);
                case "Vert": return Color.FromArgb(30, 140, 70);
                case "Violet": return Color.FromArgb(100, 60, 180);
                default: return Color.FromArgb(100, 110, 130);
            }
        }

        private string NiveauLabel(string code)
        {
            switch (code)
            {
                case "A": return "A — Très élevé";
                case "B": return "B — Élevé";
                case "C": return "C — Moyen";
                case "D": return "D — Faible";
                case "E": return "E — Très faible";
                case "F": return "F — Minimal";
                default: return code;
            }
        }

        // Événements Designer
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button_chercher_Click(object sender, EventArgs e) { AppliquerFiltres(); }
        private void button_retour_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
    }
}