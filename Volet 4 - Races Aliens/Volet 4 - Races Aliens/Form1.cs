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

        private void Form1_Load(object sender, EventArgs e)
        {
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

            flowRaces = new FlowLayoutPanel();
            flowRaces.Location = new Point(12, 200);
            flowRaces.Location = new Point(12, 270);
            flowRaces.Size = new Size(this.ClientSize.Width - 24, this.ClientSize.Height - 280);
            flowRaces.FlowDirection = FlowDirection.LeftToRight;
            flowRaces.WrapContents = true;
            flowRaces.AutoSize = false;
            flowRaces.AutoScroll = true;
            flowRaces.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                    | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(flowRaces);

            button_chercher.Click += (s, ev) => AppliquerFiltres();
            button_reset.Click += BtnReset_Click;

            ChargerDonnees();
            AppliquerFiltres();
        }

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
        }

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
            carte.Size = new Size(160, 212);
            carte.Margin = new Padding(5);
            carte.BackColor = Color.White;
            carte.Cursor = Cursors.Hand;
            carte.Tag = row;
            carte.Paint += (s, e) => e.Graphics.DrawRectangle(
                                  new Pen(bordure, 2), 1, 1,
                                  carte.Width - 3, carte.Height - 3);

            // --- Panel image ---
            Panel pnlImg = new Panel();
            pnlImg.Size = new Size(130, 110);
            pnlImg.Location = new Point(15, 20);
            pnlImg.BackColor = Color.White;
            pnlImg.BorderStyle = BorderStyle.None;

            PictureBox img = new PictureBox();
            img.Size = new Size(130, 110);
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
                    using (Font f = new Font("Trebuchet MS", 14F, FontStyle.Bold))
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
            badge.Font = new Font("Trebuchet MS", 7.5F, FontStyle.Bold);
            badge.ForeColor = Color.White;
            badge.BackColor = bordure;
            badge.TextAlign = ContentAlignment.MiddleCenter;
            badge.Location = new Point(0, 0);
            badge.Size = new Size(65, 18);
            badge.AutoSize = false;

            // --- Nom ---
            Label lblNom = new Label();
            lblNom.Text = row["nom"].ToString();
            lblNom.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            lblNom.ForeColor = Color.FromArgb(20, 40, 80);
            lblNom.TextAlign = ContentAlignment.MiddleCenter;
            lblNom.Location = new Point(0, 133);
            lblNom.Size = new Size(160, 22);
            lblNom.AutoSize = false;

            // --- Couleur ---
            Label lblCouleur = new Label();
            lblCouleur.Text = row["couleur"].ToString();
            lblCouleur.Font = new Font("Trebuchet MS", 9F);
            lblCouleur.ForeColor = Color.FromArgb(90, 100, 120);
            lblCouleur.TextAlign = ContentAlignment.MiddleCenter;
            lblCouleur.Location = new Point(0, 157);
            lblCouleur.Size = new Size(160, 18);
            lblCouleur.AutoSize = false;

            // --- Planètes ---
            Label lblPlanete = new Label();
            lblPlanete.Text = row["planetes"].ToString();
            lblPlanete.Font = new Font("Trebuchet MS", 8.5F, FontStyle.Italic);
            lblPlanete.ForeColor = Color.FromArgb(110, 120, 140);
            lblPlanete.TextAlign = ContentAlignment.TopCenter;
            lblPlanete.Location = new Point(0, 177);
            lblPlanete.Size = new Size(160, 30);
            lblPlanete.AutoSize = false;

            carte.Controls.AddRange(new Control[] {
        pnlImg, badge, lblNom, lblCouleur, lblPlanete });

            // Hover
            carte.MouseEnter += (s, e) => carte.BackColor = Color.FromArgb(235, 242, 255);
            carte.MouseLeave += (s, e) => carte.BackColor = Color.White;

            // Clic → détail sur tous les contrôles de la carte
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

        private void AfficherDetail(DataRow row)
        {
            using (FormDetail fd = new FormDetail(row, _cheminImages, _cheminImagesPlanetes))
                fd.ShowDialog(this);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            AppliquerFiltres();
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

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button_chercher_Click(object sender, EventArgs e) { AppliquerFiltres(); }

        private void button_retour_Click(object sender, EventArgs e)
        {

        }
    }
}