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
            this.pictureBox5.Image = Image.FromFile("../../../../Images_App/Icones diverses/Logo Stat.png");
            this.pictureBox2.Image = Image.FromFile("../../../../Images_App/Icones diverses/1_Logo Planètes Infos.png");
            this.pictureBox4.Image = Image.FromFile("../../../../Images_App/Icones diverses/2_Logo Info Alien.png");
            this.pictureBox6.Image = Image.FromFile("../../../../Images_App/Texte Stargate TDB.png");
            this.pictureBox3.Image = Image.FromFile("../../../../Images_App/Logo Star Gate.png");
            this.pictureBox1.Image = Image.FromFile("../../../../Images_App/Icones diverses/3_Logo +.png");
            this.Icon = new Icon("Logo Star Gate.ico");
            InitPictureBox();
            ChargerMissions();
        }

        // Lie un PictureBox à un Button :
        //  - centre l'image horizontalement et la colle en bas du bouton
        //  - curseur Hand sur les deux
        //  - survol de l'un ou l'autre → fond bleu sur les deux
        //  - clic sur l'image → déclenche le handler du bouton
        private void LierImageBouton(PictureBox pb, Button btn, EventHandler clickHandler)
        {
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Cursor = Cursors.Hand;
            pb.BackColor = CouleurNormale;

            // Taille : largeur du bouton moins marges, hauteur fixe
            int pbH = pb.Height; // on garde la hauteur définie dans le designer
            int pbW = btn.Width - 20;
            pb.Size = new Size(pbW, pbH);

            // Centré horizontalement, collé en bas du bouton (marge 8px)
            pb.Location = new Point(
                btn.Left + (btn.Width - pbW) / 2,
                btn.Bottom - pbH - 8
            );

            // Survol bouton → bleu image
            btn.MouseEnter += (s, ev) => pb.BackColor = CouleurSurvol;
            btn.MouseLeave += (s, ev) =>
            {
                if (!pb.ClientRectangle.Contains(pb.PointToClient(Cursor.Position)))
                    pb.BackColor = CouleurNormale;
            };

            // Survol image → bleu image + redessine le bouton
            pb.MouseEnter += (s, ev) =>
            {
                pb.BackColor = CouleurSurvol;
                btn.Invalidate();
            };
            pb.MouseLeave += (s, ev) =>
            {
                if (!btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)))
                    pb.BackColor = CouleurNormale;
                btn.Invalidate();
            };

            // Clic image = clic bouton
            pb.Click += clickHandler;
        }

        private void InitPictureBox()
        {
            // pictureBox1 ↔ btCreerMission
            LierImageBouton(pictureBox1, btCreerMission, (s, ev) => btCreerMission_Click(s, ev));

            // pictureBox4 ↔ btInfoAlien
            LierImageBouton(pictureBox4, btInfoAlien, (s, ev) => button1_Click(s, ev));

            // pictureBox2 ↔ btInfoPlanete
            LierImageBouton(pictureBox2, btInfoPlanete, (s, ev) => btInfoPlanete_Click(s, ev));

            // pictureBox5 ↔ button1 (Statistiques)
            LierImageBouton(pictureBox5, button1, (s, ev) => button1_Click(s, ev));

            // pictureBox3 et pictureBox6 sont des éléments décoratifs (logo + bandeau)
            // → on ne les touche pas
        }

        private void ChargerMissions()
        {
            panel1.Location = new Point(312, 96);
            panel1.Size = new Size(1200, 824);
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

            // Grille 2 colonnes adaptée à la largeur du panel (1097px)
            int colonnes = 1;
            int ucLargeur = 1060; // quasi toute la largeur du panel
            int ucHauteur = 215;
            int espX = 25;
            int espY = 20;
            int debutX = 20;
            int debutY = 15;
            int col = 0, ligne = 0;

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
                        "ImagesPlanetes/Logo - " + row[0] + ".png"
                    );
                    uc.setNomPlanete(row[0].ToString());
                    uc.setNumeroMission(Convert.ToInt32(row[1]));
                    uc.Location = new Point(
                        debutX + col * (ucLargeur + espX),
                        debutY + ligne * (ucHauteur + espY)
                    );
                    uc.OuvrirFormulaire += UserControl1_OuvrirFormulaire;
                    panel1.Controls.Add(uc);

                    col++;
                    if (col >= colonnes) { col = 0; ligne++; }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Erreur lors du chargement d'une mission :\n" + err.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            catch (SQLiteException err)
            {
                MessageBox.Show(err.Message);
            }

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
    }
}