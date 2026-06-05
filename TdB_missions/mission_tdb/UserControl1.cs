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

        // Couleurs thème spatial Stargate
        private static readonly Color CouleurBordure  = Color.FromArgb(255, 30, 110, 220);
        private static readonly Color CouleurTitre    = Color.FromArgb(255, 255, 255, 255);
        private static readonly Color CouleurTexte    = Color.FromArgb(255, 200, 220, 255);
        private static readonly Color CouleurBtnFond  = Color.FromArgb(255, 20, 80, 180);
        private static readonly Color CouleurBtnHover = Color.FromArgb(255, 40, 130, 255);
        private static readonly Color CouleurBtnBord  = Color.FromArgb(255, 80, 160, 255);

        // Couleurs états
        private static readonly Color CouleurAVenir   = Color.FromArgb(255, 30, 120, 200);  // bleu
        private static readonly Color CouleurEnCours  = Color.FromArgb(255, 20, 160, 80);   // vert
        private static readonly Color CouleurTermine  = Color.FromArgb(255, 120, 120, 120); // gris

        public UserControl1()
        {
            InitializeComponent();
            if (!DesignMode) AppliquerStyle();
        }

        // Constructeur complet avec toutes les infos
        public UserControl1(string nom_mission, string date_dep, string date_fin,
                            string nom_chef, string image_path,
                            string budget = "", string date_dep_raw = "", string date_fin_raw = "")
        {
            InitializeComponent();

            label1.Text = "Mission " + nom_mission;
            label2.Text = "Départ : " + date_dep;
            label3.Text = "Retour : " + date_fin;
            label4.Text = "Chef : " + nom_chef;

            // Calcul nb jours
            if (DateTime.TryParse(date_dep_raw, out DateTime dep) &&
                DateTime.TryParse(date_fin_raw, out DateTime fin))
            {
                int nbJours = (int)(fin - dep).TotalDays;
                label5.Text = "Durée : " + nbJours + " jour" + (nbJours > 1 ? "s" : "");

                // État de la mission
                DateTime today = DateTime.Today;
                if (today < dep)
                {
                    label7.Text      = "À venir";
                    label7.BackColor = CouleurAVenir;
                }
                else if (today >= dep && today <= fin)
                {
                    label7.Text      = "En cours";
                    label7.BackColor = CouleurEnCours;
                }
                else
                {
                    label7.Text      = "Terminée";
                    label7.BackColor = CouleurTermine;
                }
            }
            else
            {
                label5.Text      = "";
                label7.Text      = "Inconnu";
                label7.BackColor = CouleurTermine;
            }

            // Budget
            label6.Text = string.IsNullOrEmpty(budget) ? "Budget : N/A" : "Budget : " + budget + " €";

            try { pictureBox1.Image = Image.FromFile(image_path); } catch { }

            AppliquerStyle();
        }

        private void AppliquerStyle()
        {
            if (!DesignMode)
            {
                this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
                this.BackColor   = Color.Transparent;
                this.BorderStyle = BorderStyle.None;
            }

            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode  = PictureBoxSizeMode.Zoom;

            // Titre
            label1.ForeColor = CouleurTitre;
            label1.Font      = new Font("Impact", 14F);
            label1.BackColor = Color.Transparent;

            // Infos
            foreach (var lbl in new[] { label2, label3, label4, label5, label6 })
            {
                lbl.ForeColor = CouleurTexte;
                lbl.Font      = new Font("Impact", 11F);
                lbl.BackColor = Color.Transparent;
            }

            // Badge état
            label7.ForeColor = Color.White;
            label7.Font      = new Font("Impact", 11F);

            // Bouton
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor        = CouleurBtnBord;
            button1.FlatAppearance.BorderSize         = 1;
            button1.FlatAppearance.MouseOverBackColor = CouleurBtnHover;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 10, 60, 150);
            button1.BackColor = CouleurBtnFond;
            button1.ForeColor = Color.White;
            button1.Font      = new Font("Impact", 11F);
            button1.Cursor    = Cursors.Hand;
            button1.Text      = "+ d'infos";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (DesignMode) { base.OnPaint(e); return; }

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (SolidBrush fondBrush = new SolidBrush(Color.FromArgb(200, 10, 18, 38)))
                g.FillRectangle(fondBrush, rect);

            using (SolidBrush accentBrush = new SolidBrush(CouleurBordure))
                g.FillRectangle(accentBrush, new Rectangle(0, 0, 4, this.Height));

            using (Pen borderPen = new Pen(Color.FromArgb(100, 30, 110, 220), 1))
                g.DrawRectangle(borderPen, rect);

            using (Pen linePen = new Pen(Color.FromArgb(80, 60, 140, 255), 1))
                g.DrawLine(linePen, 12, 45, this.Width - 12, 45);

            base.OnPaint(e);
        }

        // Dessin arrondi du badge état
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control == label7)
            {
                label7.Paint += (s, pe) =>
                {
                    pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (SolidBrush b = new SolidBrush(label7.BackColor))
                    {
                        var r = new System.Drawing.Drawing2D.GraphicsPath();
                        int radius = 8;
                        r.AddArc(0, 0, radius, radius, 180, 90);
                        r.AddArc(label7.Width - radius, 0, radius, radius, 270, 90);
                        r.AddArc(label7.Width - radius, label7.Height - radius, radius, radius, 0, 90);
                        r.AddArc(0, label7.Height - radius, radius, radius, 90, 90);
                        r.CloseFigure();
                        pe.Graphics.FillPath(b, r);
                    }
                    TextRenderer.DrawText(pe.Graphics, label7.Text, label7.Font,
                        label7.ClientRectangle, Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                };
                label7.BackColor = label7.BackColor; // force repaint
            }
        }

        public string getNomPlanete()        { return this.NomPlanete; }
        public void   setNomPlanete(string np) { this.NomPlanete = np; }
        public int    getNumeroMission()     { return this.NumeroMission; }
        public void   setNumeroMission(int nm) { this.NumeroMission = nm; }
        public Button getBoutton()           { return this.button1; }

        private void label4_Click(object sender, EventArgs e) { }
        private void UserControl1_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            OuvrirFormulaire?.Invoke(this, EventArgs.Empty);
        }
    }
}
