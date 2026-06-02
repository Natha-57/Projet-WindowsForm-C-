using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Volet_4___Races_Aliens
{
    public partial class FormDetails : Form
    {
        private readonly string _cheminImages;
        private readonly DataTable _especes;
        private readonly int _nbMissions;

        public FormDetails(DataRow row, string cheminImages,
                           DataRow[] especes, int nbMissions)
        {
            InitializeComponent();
            _cheminImages = cheminImages;
            _especes = especes.Length > 0
                            ? especes[0].Table.Clone()
                            : new DataTable();
            foreach (DataRow r in especes)
                _especes.ImportRow(r);
            _nbMissions = nbMissions;
            InitialiserFormulaire(row);
        }

        private void InitialiserFormulaire(DataRow row)
        {
            string nomPlanete = row["nom"].ToString();
            bool databaz = row["dataBazON"] != DBNull.Value &&
                                Convert.ToInt32(row["dataBazON"]) == 1;

            this.Text = $"Détails — {nomPlanete}";
            this.BackColor = Color.White;

            // ── En-tête ────────────────────────────────────────────────────────
            Panel entete = new Panel();
            entete.Dock = DockStyle.Top;
            entete.Height = 55;
            entete.BackColor = Color.FromArgb(20, 60, 120);

            Label lblTitre = new Label();
            lblTitre.Text = nomPlanete;
            lblTitre.Font = new Font("Trebuchet MS", 16F, FontStyle.Bold);
            lblTitre.ForeColor = Color.White;
            lblTitre.Dock = DockStyle.Fill;
            lblTitre.TextAlign = ContentAlignment.MiddleCenter;
            entete.Controls.Add(lblTitre);
            this.Controls.Add(entete);
            entete.BringToFront();

            // ── Image planète ──────────────────────────────────────────────────
            PictureBox img = new PictureBox();
            img.Size = new Size(160, 160);
            img.Location = new Point(20, 70);
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.BackColor = Color.WhiteSmoke;

            string cheminImg = Path.Combine(_cheminImages,
                                            "Logo - " + nomPlanete + ".png");
            if (File.Exists(cheminImg))
                img.Image = Image.FromFile(cheminImg);
            this.Controls.Add(img);

            // ── Infos principales ──────────────────────────────────────────────
            Panel pnlInfos = new Panel();
            pnlInfos.Location = new Point(200, 70);
            pnlInfos.Size = new Size(360, 280);
            pnlInfos.BackColor = Color.White;
            this.Controls.Add(pnlInfos);

            int y = 0;
            AjouterInfo(pnlInfos, "Température", $"{row["temperature"]}°", ref y);
            AjouterInfo(pnlInfos, "Gravité", $"{row["gravite"]} G", ref y);
            AjouterInfo(pnlInfos, "DataBaz", databaz ? "Présent" : "Absent", ref y);
            AjouterInfo(pnlInfos, "Mission(s)", $"{_nbMissions} mission(s)", ref y);

            // Colorer la valeur DataBaz (index 5 = 3ème valeur)
            if (pnlInfos.Controls.Count >= 6)
            {
                var lblDataVal = pnlInfos.Controls[5] as Label;
                if (lblDataVal != null)
                    lblDataVal.ForeColor = databaz
                        ? Color.FromArgb(0, 128, 0)
                        : Color.FromArgb(180, 0, 0);
            }

            // ── Titre Espèces ──────────────────────────────────────────────────
            Label lblEspTitre = new Label();
            lblEspTitre.Text = "Espèces présentes :";
            lblEspTitre.Font = new Font("Trebuchet MS", 13F, FontStyle.Bold);
            lblEspTitre.ForeColor = Color.FromArgb(20, 40, 80);
            lblEspTitre.Location = new Point(20, 320);
            lblEspTitre.Size = new Size(560, 26);
            lblEspTitre.AutoSize = false;
            this.Controls.Add(lblEspTitre);

            if (_especes.Rows.Count == 0)
            {
                Label lblAucune = new Label();
                lblAucune.Text = "Aucune espèce répertoriée.";
                lblAucune.Font = new Font("Trebuchet MS", 12F, FontStyle.Italic);
                lblAucune.ForeColor = Color.Gray;
                lblAucune.Location = new Point(20, 350);
                lblAucune.Size = new Size(560, 24);
                this.Controls.Add(lblAucune);
            }
            else
            {
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(20, 350);
                dgv.Size = new Size(560, 150);
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.None;
                dgv.Font = new Font("Trebuchet MS", 11F);
                dgv.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Trebuchet MS", 11F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 60, 120);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                dgv.Columns.Add("nomEspece", "Espèce");
                dgv.Columns.Add("type", "Type");
                dgv.Columns.Add("pourcentage", "Présence (%)");

                foreach (DataRow esp in _especes.Rows)
                {
                    int idx = dgv.Rows.Add(
                        esp["nomEspece"].ToString(),
                        esp["type"].ToString(),
                        esp["pourcentage"].ToString() + "%");

                    Color c = esp["type"].ToString() == "Alliée"
                              ? Color.FromArgb(220, 255, 220)
                              : esp["type"].ToString() == "Ennemie"
                              ? Color.FromArgb(255, 220, 220)
                              : Color.FromArgb(240, 240, 240);
                    dgv.Rows[idx].DefaultCellStyle.BackColor = c;
                }

                this.Controls.Add(dgv);
            }

            // ── Bouton Fermer ──────────────────────────────────────────────────
            button_fermer.BackColor = Color.FromArgb(20, 60, 120);
            button_fermer.ForeColor = Color.White;
            button_fermer.FlatStyle = FlatStyle.Flat;
            button_fermer.FlatAppearance.BorderSize = 0;
            button_fermer.Cursor = Cursors.Hand;
            button_fermer.Click += (s, e) => this.Close();
        }

        private void AjouterInfo(Panel parent, string cle, string valeur, ref int y)
        {
            Label lblCle = new Label();
            lblCle.Text = cle + " :";
            lblCle.Font = new Font("Trebuchet MS", 14F, FontStyle.Bold);
            lblCle.ForeColor = Color.FromArgb(80, 90, 110);
            lblCle.Location = new Point(0, y);
            lblCle.Size = new Size(360, 20);
            lblCle.AutoSize = false;
            parent.Controls.Add(lblCle);
            y += 22;

            Label lblVal = new Label();
            lblVal.Text = string.IsNullOrEmpty(valeur) ? "—" : valeur;
            lblVal.Font = new Font("Trebuchet MS", 13F);
            lblVal.ForeColor = Color.FromArgb(20, 30, 60);
            lblVal.Location = new Point(0, y);
            lblVal.Size = new Size(360, 24);
            lblVal.AutoSize = false;
            parent.Controls.Add(lblVal);
            y += 40;
        }

        private void FormDetails_Load(object sender, EventArgs e)
        {

        }
    }
}