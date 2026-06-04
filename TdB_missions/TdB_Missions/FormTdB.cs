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

            try
            {
                string sql;
                DataTable schemaTable = Connexion.Connec.GetSchema("Tables");
                string liste = "";
                foreach (DataRow row in schemaTable.Rows)
                {
                    string nomTable = row[2].ToString();
                    sql = "SELECT * FROM " + nomTable;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, Connexion.Connec);
                    da.Fill(MesDatas.DsGlobal, nomTable);
                    liste = liste + nomTable + "\n";
                }
            }
            catch (SQLiteException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Logo Star Gate.ico");

            // --- PictureBox en bas au centre de btCreerMission ---
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Size = new Size(btCreerMission.Width - 20, 40);
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

            // --- Chargement des missions ---
            if (!MesDatas.DsGlobal.Tables.Contains("mission")) return;

            int axeX = 25, axeY = 20, i = 0;
            foreach (DataRow row in MesDatas.DsGlobal.Tables["mission"].Rows)
            {
                try
                {
                    string filtre = "matricule = '" + row[5].ToString() + "'";
                    DataRow[] dr = MesDatas.DsGlobal.Tables["membre"].Select(filtre);
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
                catch (NullReferenceException err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void UserControl1_OuvrirFormulaire(object sender, EventArgs e)
        {
            UserControl1 uc = (UserControl1)sender;

            FormResumeMission f =
                new FormResumeMission(uc.getNomPlanete(), uc.getNumeroMission());

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
            this.Controls.Clear();
            Form1_Load(null, null);
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
