using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Volet_4___Races_Aliens
{
    public partial class FormDetail : Form
    {
        private readonly string _cheminImages;
        private readonly string _cheminImagesPlanetes;

        public FormDetail(DataRow row, string cheminImages, string cheminImagesPlanetes)
        {
            InitializeComponent();
            _cheminImages = cheminImages;
            _cheminImagesPlanetes = cheminImagesPlanetes;
            InitialiserFormulaire(row);
        }

        private void InitialiserFormulaire(DataRow row)
        {
            string typeRace = row["type"].ToString();
            bool allie = typeRace == "Alliée";
            bool ennemi = typeRace == "Ennemie";

            Color couleurType = allie ? Color.FromArgb(0, 150, 70)
                              : ennemi ? Color.FromArgb(190, 30, 30)
                                       : Color.FromArgb(120, 130, 150);

            // ── Titre fenêtre ──────────────────────────────────────────────────
            this.Text = $"Détails sur {row["nom"]}";

            // ── En-tête coloré ─────────────────────────────────────────────────
            Panel entete = new Panel();
            entete.Dock = DockStyle.Top;
            entete.Height = 55;
            entete.BackColor = couleurType;

            Label lblTitre = new Label();
            lblTitre.Text = $"{row["nom"]}  —  {typeRace}";
            lblTitre.Font = new Font("Trebuchet MS", 15F, FontStyle.Bold);
            lblTitre.ForeColor = Color.White;
            lblTitre.Dock = DockStyle.Fill;
            lblTitre.TextAlign = ContentAlignment.MiddleCenter;
            entete.Controls.Add(lblTitre);
            this.Controls.Add(entete);
            entete.BringToFront();

            // ── Image espèce (pictureBox1 du designer) ─────────────────────────
            string cheminImg = Path.Combine(_cheminImages, row["nom"].ToString() + ".png");
            if (File.Exists(cheminImg))
                pictureBox1.Image = Image.FromFile(cheminImg);
            pictureBox1.BackColor = Color.WhiteSmoke;

            // Label nom sous l'image espèce
            Label lblNomEspece = new Label();
            lblNomEspece.Text = row["nom"].ToString();
            lblNomEspece.Font = new Font("Trebuchet MS", 9.5F, FontStyle.Italic);
            lblNomEspece.ForeColor = Color.Gray;
            lblNomEspece.TextAlign = ContentAlignment.MiddleCenter;
            lblNomEspece.Location = new Point(20, 190);
            lblNomEspece.Size = new Size(120, 20);
            this.Controls.Add(lblNomEspece);

            // ── Infos texte ────────────────────────────────────────────────────
            Panel pnlInfos = new Panel();
            pnlInfos.Location = new Point(160, 65);
            pnlInfos.Size = new Size(200, 320);
            pnlInfos.BackColor = Color.White;
            this.Controls.Add(pnlInfos);

            string planetes = row["planetes"].ToString();

            int y = 0;
            AjouterInfo(pnlInfos, "Couleur", row["couleur"].ToString(), ref y);
            AjouterInfo(pnlInfos, "Planète(s)", planetes, ref y);

            if (allie)
            {
                AjouterInfo(pnlInfos, "1er contact", row["datePremierContact"].ToString(), ref y);
                AjouterInfo(pnlInfos, "Bienveillance", NiveauLabel(row["degreBienveillance"].ToString()), ref y);
                AjouterInfo(pnlInfos, "Instrument", row["instrumentMusique"].ToString(), ref y);
            }
            else if (ennemi)
            {
                AjouterInfo(pnlInfos, "Arme", row["typeArme"].ToString(), ref y);
                AjouterInfo(pnlInfos, "Agressivité", NiveauLabel(row["degreAgressivite"].ToString()), ref y);
            }

            // ── Images planètes (de haut en bas, à droite) ────────────────────────
            string[] listePlanetes = planetes == "Origine inconnue"
                                     ? new string[0]
                                     : planetes.Split(',').Select(p => p.Trim()).ToArray();

            int yPlanete = 75;
            foreach (string planete in listePlanetes)
            {
                PictureBox imgP = new PictureBox();
                imgP.Size = new Size(70, 70);
                imgP.Location = new Point(360, yPlanete);
                imgP.SizeMode = PictureBoxSizeMode.Zoom;
                imgP.BackColor = Color.WhiteSmoke;

                string cheminP = Path.Combine(_cheminImagesPlanetes, "Logo - " + planete + ".png");
                if (File.Exists(cheminP))
                    imgP.Image = Image.FromFile(cheminP);
                else
                {
                    imgP.BackColor = Color.FromArgb(220, 220, 220);
                    Label lblManquante = new Label();
                    lblManquante.Text = "?";
                    lblManquante.Font = new Font("Trebuchet MS", 20F, FontStyle.Bold);
                    lblManquante.ForeColor = Color.Gray;
                    lblManquante.TextAlign = ContentAlignment.MiddleCenter;
                    lblManquante.Dock = DockStyle.Fill;
                    imgP.Controls.Add(lblManquante);
                }

                Label lblP = new Label();
                lblP.Text = planete;
                lblP.Font = new Font("Trebuchet MS", 8.5F, FontStyle.Italic);
                lblP.ForeColor = Color.Gray;
                lblP.TextAlign = ContentAlignment.MiddleLeft;
                lblP.Location = new Point(438, yPlanete + 22);
                lblP.Size = new Size(200, 20);

                this.Controls.Add(imgP);
                this.Controls.Add(lblP);

                yPlanete += 85;
            }

            // ── Style bouton Fermer (du designer) ──────────────────────────────
            button_fermer.BackColor = couleurType;
            button_fermer.ForeColor = Color.White;
            button_fermer.FlatStyle = FlatStyle.Flat;
            button_fermer.FlatAppearance.BorderSize = 0;
        }

        private void AjouterInfo(Panel parent, string cle, string valeur, ref int y)
        {
            Label lblCle = new Label();
            lblCle.Text = cle + " :";
            lblCle.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            lblCle.ForeColor = Color.FromArgb(80, 90, 110);
            lblCle.Location = new Point(0, y);
            lblCle.Size = new Size(200, 18);
            parent.Controls.Add(lblCle);
            y += 20;

            Label lblVal = new Label();
            lblVal.Text = string.IsNullOrEmpty(valeur) ? "—" : valeur;
            lblVal.Font = new Font("Trebuchet MS", 10F);
            lblVal.ForeColor = Color.FromArgb(20, 30, 60);
            lblVal.Location = new Point(0, y);
            lblVal.Size = new Size(200, 30);
            parent.Controls.Add(lblVal);
            y += 36;
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

        private void button_fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}