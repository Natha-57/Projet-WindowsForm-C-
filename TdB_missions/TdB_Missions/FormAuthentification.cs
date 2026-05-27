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

namespace _2__Creation_De_Mission
{
    public partial class FormAuthentification : Form
    {
        public FormAuthentification()
        {
            InitializeComponent();
            this.Resize += FormAuthentification_Resize;           // abonnement à l'événement
            FormAuthentification_Resize(this, EventArgs.Empty);  // centrage immédiat au démarrage
        }

        private void btValider_Click(object sender, EventArgs e)
        {
            try
            {
                string chaine = "Data Source=..\\..\\..\\..\\Fichiers Moodle\\Stargate.db";
                using (SQLiteConnection cx = new SQLiteConnection(chaine))
                {
                    cx.Open();
                    string sql = "SELECT mdp FROM Admin WHERE login = @login";
                    SQLiteCommand cmd = new SQLiteCommand(sql, cx);
                    cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                    string mdp = cmd.ExecuteScalar()?.ToString();

                    if (mdp != null)
                    {
                        string mdpCorrige = mdp.Replace("$2y$", "$2a$");
                        if (BCrypt.Net.BCrypt.Verify(txtMdp.Text, mdpCorrige))
                        {
                            this.DialogResult = DialogResult.OK; 
                            this.Hide();
                            FormCreationMission formCreationMission = new FormCreationMission();
                            formCreationMission.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Login ou mot de passe incorrect.", "Accès refusé",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMdp.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login introuvable.", "Accès refusé",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormAuthentification_Resize(object sender, EventArgs e)
        {
            label1.Left = (groupBox1.Width - label1.Width) / 2;
            label4.Left = (groupBox1.Width - label4.Width) / 2;
        }

        private void btRetour_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void FormAuthentification_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
