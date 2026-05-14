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
                string chaine = "Data Source=..\\..\\Stargate.db";
                SQLiteConnection cx = new SQLiteConnection(chaine);
                cx.Open();

                string sql = "SELECT mdp FROM Admin WHERE login = @login";
                SQLiteCommand cmd = new SQLiteCommand(sql, cx);
                cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                string mdp = cmd.ExecuteScalar()?.ToString();

                if (mdp != null && BCrypt.Net.BCrypt.Verify(txtMdp.Text, mdp))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect.", "Accès refusé",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMdp.Clear();
                }

                cx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }
}
