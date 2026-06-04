using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace mission_tdb
{
    public partial class UserControl1 : UserControl
    {
        public event EventHandler OuvrirFormulaire;
        private string NomPlanete;
        private int NumeroMission;

        // Couleurs du thème spatial Stargate
        private static readonly Color CouleurFond = Color.FromArgb(245, 18, 28, 48);   // bleu nuit très sombre
        private static readonly Color CouleurBordure = Color.FromArgb(255, 30, 110, 220);  // bleu Stargate vif
        private static readonly Color CouleurTitre = Color.FromArgb(255, 255, 255, 255); // blanc pur
        private static readonly Color CouleurTexte = Color.FromArgb(255, 200, 220, 255); // bleu clair
        private static readonly Color CouleurBtnFond = Color.FromArgb(255, 20, 80, 180);   // bleu bouton
        private static readonly Color CouleurBtnHover = Color.FromArgb(255, 40, 130, 255);  // bleu hover
        private static readonly Color CouleurBtnBord = Color.FromArgb(255, 80, 160, 255);  // bord bouton

        public UserControl1()
        {
            InitializeComponent();
            AppliquerStyle();
        }

        public UserControl1(string nom_mission, string date_dep, string date_fin, string nom_chef, string image_path)
        {
            InitializeComponent();
            label1.Text = "Mission " + nom_mission;
            label2.Text = "Départ : " + date_dep;
            label3.Text = "Retour : " + date_fin;
            label4.Text = "Chef de mission : " + nom_chef;
            try { pictureBox1.Image = Image.FromFile(image_path); } catch { }
            AppliquerStyle();
        }

        private void AppliquerStyle()
        {
            // Fond transparent pour dessiner nous-mêmes
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;

            // PictureBox
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Label titre (nom mission)
            label1.ForeColor = CouleurTitre;
            label1.Font = new Font("Impact", 14F, FontStyle.Regular);
            label1.BackColor = Color.Transparent;

            // Labels infos
            foreach (var lbl in new[] { label2, label3, label4 })
            {
                lbl.ForeColor = CouleurTexte;
                lbl.Font = new Font("Impact", 11F, FontStyle.Regular);
                lbl.BackColor = Color.Transparent;
            }

            // Bouton "+" style Stargate
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = CouleurBtnBord;
            button1.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.MouseOverBackColor = CouleurBtnHover;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 10, 60, 150);
            button1.BackColor = CouleurBtnFond;
            button1.ForeColor = Color.White;
            button1.Font = new Font("Impact", 11F, FontStyle.Regular);
            button1.Cursor = Cursors.Hand;
            button1.Text = "+ d'infos";
        }

        // Dessin personnalisé de la carte
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // Fond semi-transparent bleu nuit
            using (SolidBrush fondBrush = new SolidBrush(Color.FromArgb(200, 10, 18, 38)))
                g.FillRectangle(fondBrush, rect);

            // Bordure latérale gauche (accent bleu vif, 4px)
            using (SolidBrush accentBrush = new SolidBrush(CouleurBordure))
                g.FillRectangle(accentBrush, new Rectangle(0, 0, 4, this.Height));

            // Bordure extérieure fine bleue
            using (Pen borderPen = new Pen(Color.FromArgb(100, 30, 110, 220), 1))
                g.DrawRectangle(borderPen, rect);

            // Ligne séparatrice sous le titre
            using (Pen linePen = new Pen(Color.FromArgb(80, 60, 140, 255), 1))
                g.DrawLine(linePen, 12, 50, this.Width - 12, 50);

            base.OnPaint(e);
        }

        public string getNomPlanete() { return this.NomPlanete; }
        public void setNomPlanete(string np) { this.NomPlanete = np; }
        public int getNumeroMission() { return this.NumeroMission; }
        public void setNumeroMission(int nm) { this.NumeroMission = nm; }
        public Button getBoutton() { return this.button1; }

        private void label4_Click(object sender, EventArgs e) { }
        private void UserControl1_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            OuvrirFormulaire?.Invoke(this, EventArgs.Empty);
        }
    }
}