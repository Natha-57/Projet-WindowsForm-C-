using System;
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
        private FlowLayoutPanel flowPlanetes;

        public Form_Planetes()
        {
            InitializeComponent();
        }

        // ======================================================================
        // CHARGEMENT
        // ======================================================================

        private void Form1_Load(object sender, EventArgs e)
        {
            // FlowLayoutPanel pour les cartes planètes
            flowPlanetes = new FlowLayoutPanel();
            flowPlanetes.Location = new Point(12, 80);
            flowPlanetes.Size = new Size(this.ClientSize.Width - 24,
                                                   this.ClientSize.Height - 90);
            flowPlanetes.FlowDirection = FlowDirection.LeftToRight;
            flowPlanetes.WrapContents = true;
            flowPlanetes.AutoScroll = true;
            flowPlanetes.AutoSize = false;
            flowPlanetes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                       | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(flowPlanetes);

            ChargerDonnees();
            AfficherCartes();
        }

        // ======================================================================
        // CHARGEMENT EN MODE CONNECTÉ
        // ======================================================================

        private void ChargerDonnees()
        {
            // Planètes
            string sqlPlanetes = @"
                SELECT nom, temperature, gravite, dataBazON
                FROM Planete
                ORDER BY nom";

            // Espèces par planète avec pourcentage
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

            // Missions par planète
            string sqlMissions = @"
                SELECT nomPlanete, COUNT(*) AS nbMissions
                FROM Mission
                GROUP BY nomPlanete";

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
                MessageBox.Show(
                    $"Impossible de charger la base :\n\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================================
        // AFFICHAGE DES CARTES (mode déconnecté)
        // ======================================================================

        private void AfficherCartes()
        {
            if (_ds.Tables["Planetes"] == null) return;

            flowPlanetes.SuspendLayout();
            flowPlanetes.Controls.Clear();

            foreach (DataRow row in _ds.Tables["Planetes"].Rows)
                flowPlanetes.Controls.Add(CreerCartePlanete(row));

            flowPlanetes.ResumeLayout();
        }

        // ======================================================================
        // CRÉATION D'UNE CARTE DE PLANÈTE
        // ======================================================================

        private Panel CreerCartePlanete(DataRow row)
        {
            string nomPlanete = row["nom"].ToString();
            bool databaz = row["dataBazON"] != DBNull.Value && Convert.ToInt32(row["dataBazON"]) == 1;

            // --- Carte ---
            Panel carte = new Panel();
            carte.Size = new Size(200, 260);
            carte.Margin = new Padding(8);
            carte.BackColor = Color.White;
            carte.Cursor = Cursors.Hand;
            carte.Tag = row;
            carte.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(
                    new Pen(Color.FromArgb(180, 190, 210), 1),
                    1, 1, carte.Width - 3, carte.Height - 3);
            };

            // --- Image planète ---
            PictureBox img = new PictureBox();
            img.Size = new Size(140, 140);
            img.Location = new Point(30, 10);
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.BackColor = Color.White;

            string cheminImg = Path.Combine(_cheminImages, "Logo - " + nomPlanete + ".png");
            if (File.Exists(cheminImg))
                img.Image = Image.FromFile(cheminImg);
            else
            {
                img.BackColor = Color.FromArgb(200, 210, 230);
                img.Paint += (s, e) =>
                {
                    using (Font f = new Font("Trebuchet MS", 10F, FontStyle.Bold))
                    using (StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    })
                    {
                        e.Graphics.DrawString(nomPlanete, f, Brushes.White,
                            new RectangleF(0, 0, img.Width, img.Height), sf);
                    }
                };
            }

            // --- Nom ---
            Label lblNom = new Label();
            lblNom.Text = nomPlanete;
            lblNom.Font = new Font("Trebuchet MS", 11F, FontStyle.Bold);
            lblNom.ForeColor = Color.FromArgb(20, 40, 80);
            lblNom.TextAlign = ContentAlignment.MiddleCenter;
            lblNom.Location = new Point(0, 153);
            lblNom.Size = new Size(200, 24);
            lblNom.AutoSize = false;

            // --- Température ---
            Label lblTemp = new Label();
            lblTemp.Text = $"🌡  {row["temperature"]}°";
            lblTemp.Font = new Font("Trebuchet MS", 9F);
            lblTemp.ForeColor = Color.FromArgb(80, 90, 110);
            lblTemp.TextAlign = ContentAlignment.MiddleCenter;
            lblTemp.Location = new Point(0, 178);
            lblTemp.Size = new Size(200, 18);
            lblTemp.AutoSize = false;

            // --- Gravité ---
            Label lblGrav = new Label();
            lblGrav.Text = $"Gravité : {row["gravite"]} G";
            lblGrav.Font = new Font("Trebuchet MS", 9F);
            lblGrav.ForeColor = Color.FromArgb(80, 90, 110);
            lblGrav.TextAlign = ContentAlignment.MiddleCenter;
            lblGrav.Location = new Point(0, 197);
            lblGrav.Size = new Size(200, 18);
            lblGrav.AutoSize = false;

            // --- DataBaz ---
            Label lblDatabaz = new Label();
            lblDatabaz.Text = databaz ? "Présence de Databaz" : "Pas de Databaz";
            lblDatabaz.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold);
            lblDatabaz.ForeColor = databaz ? Color.FromArgb(0, 128, 0) : Color.FromArgb(180, 0, 0);
            lblDatabaz.TextAlign = ContentAlignment.MiddleCenter;
            lblDatabaz.Location = new Point(0, 216);
            lblDatabaz.Size = new Size(200, 18);
            lblDatabaz.AutoSize = false;

            // --- Missions ---
            DataRow[] missions = _ds.Tables["MissionsPlanete"].Select(
                $"nomPlanete = '{nomPlanete}'");
            int nbMissions = missions.Length > 0 ? Convert.ToInt32(missions[0]["nbMissions"]) : 0;

            Label lblMissions = new Label();
            lblMissions.Text = nbMissions > 0
                                    ? $"{nbMissions} mission(s) effectuée(s)"
                                    : "Aucune mission";
            lblMissions.Font = new Font("Trebuchet MS", 8F, FontStyle.Italic);
            lblMissions.ForeColor = Color.FromArgb(110, 120, 140);
            lblMissions.TextAlign = ContentAlignment.MiddleCenter;
            lblMissions.Location = new Point(0, 236);
            lblMissions.Size = new Size(200, 18);
            lblMissions.AutoSize = false;

            carte.Controls.AddRange(new Control[] {
                img, lblNom, lblTemp, lblGrav, lblDatabaz, lblMissions });

            // Hover
            carte.MouseEnter += (s, e) => carte.BackColor = Color.FromArgb(235, 242, 255);
            carte.MouseLeave += (s, e) => carte.BackColor = Color.White;

            // Clic → détail
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
            bool databaz = row["dataBazON"] != DBNull.Value && Convert.ToInt32(row["dataBazON"]) == 1;

            // Espèces de cette planète
            DataRow[] especes = _ds.Tables["EspecesPlanete"].Select(
                $"nomPlanete = '{nomPlanete}'");

            // Missions
            DataRow[] missions = _ds.Tables["MissionsPlanete"].Select(
                $"nomPlanete = '{nomPlanete}'");
            int nbMissions = missions.Length > 0 ? Convert.ToInt32(missions[0]["nbMissions"]) : 0;

            // Construction du message
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Planète : {nomPlanete}");
            sb.AppendLine($"Température : {row["temperature"]}°");
            sb.AppendLine($"Gravité : {row["gravite"]}");
            sb.AppendLine($"DataBaz : {(databaz ? "Présent" : "Absent")}");
            sb.AppendLine($"Missions effectuées : {nbMissions}");
            sb.AppendLine();

            if (especes.Length > 0)
            {
                sb.AppendLine("Espèces présentes :");
                foreach (DataRow esp in especes)
                    sb.AppendLine($"  • {esp["nomEspece"]} ({esp["type"]}) — {esp["pourcentage"]}%");
            }
            else
            {
                sb.AppendLine("Aucune espèce répertoriée.");
            }

            MessageBox.Show(sb.ToString(),
                $"Informations — {nomPlanete}",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}