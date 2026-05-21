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
    }
}
