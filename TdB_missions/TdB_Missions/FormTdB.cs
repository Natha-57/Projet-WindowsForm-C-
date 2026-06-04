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
                    // Évite les doublons si la table existe déjà dans le DataSet
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
            this.Icon = new Icon("Logo Star Gate.ico");
            InitPictureBox();
            ChargerMissions();
        }

        private void InitPictureBox()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Size = new Size(btCreerMission.Width - 10, 40);
            pictureBox1.Location = new Point(
                btCreerMission.Left + (btCreerMission.Width - pictureBox1.Width) / 2,
                btCreerMission.Top + btCreerMission.Height - pictureBox1.Height - 40
            );

            btCreerMission.MouseEnter += (s, ev) => pictureBox1.BackColor = Color.FromArgb(224, 238, 249);
            btCreerMission.MouseLeave += (s, ev) => pictureBox1.BackColor = Color.White;

            pictureBox1.MouseEnter += (s, ev) => {
                pictureBox1.BackColor = Color.FromArgb(224, 238, 249);
                typeof(Button).GetMethod("OnMouseEnter",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.Invoke(btCreerMission, new object[] { EventArgs.Empty });
            };
            pictureBox1.MouseLeave += (s, ev) => {
                pictureBox1.BackColor = Color.White;
                typeof(Button).GetMethod("OnMouseLeave",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.Invoke(btCreerMission, new object[] { EventArgs.Empty });
            };

            pictureBox1.Click += (s, ev) => btCreerMission_Click(s, ev);
        }

        private void ChargerMissions()
        {
            panel1.Location = new Point(312, 11);
            panel1.Size = new Size(1015, 612);
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

            int axeX = 25, axeY = 20, i = 0;
            foreach (DataRow row in MesDatas.DsGlobal.Tables["mission"].Rows)
            {
                try
                {
                    string filtre = "matricule = '" + row[5].ToString() + "'";
                    DataRow[] dr = MesDatas.DsGlobal.Tables["membre"].Select(filtre);

                    if (dr.Length == 0)
                    {
                        MessageBox.Show("Aucun membre trouvé pour le matricule : " + row[5].ToString(), "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    DataRow d = dr[0];

                    UserControl1 uc = new UserControl1(
                        (row[0].ToString() + row[1].ToString()),
                        row[3].ToString(), row[4].ToString(),
                        d[1].ToString() + " " + d[2].ToString(),
                        "ImagesPlanetes/Logo - " + row[0] + ".png"
                    );
                    uc.setNomPlanete(row[0].ToString());
                    uc.setNumeroMission(Convert.ToInt32(row[1]));
                    uc.Location = new Point(axeX, axeY + i);
                    uc.OuvrirFormulaire += UserControl1_OuvrirFormulaire;
                    panel1.Controls.Add(uc);
                    i += 225;
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
            {
                Rafraichir();
            }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

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