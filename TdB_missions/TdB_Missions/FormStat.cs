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

namespace TdB_Missions
{
    public partial class FormStat : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        public FormStat()
        {
            

            InitializeComponent();
        }

        private void FormStat_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Logo Star Gate.ico");
            try
            {
                
                string sql = "SELECT * from membre order by prenom";
                new SQLiteDataAdapter(sql, Connexion.Connec).Fill(dt);
                this.comboBox1.DataSource = dt;
                this.comboBox1.DisplayMember = "prenom";
                this.comboBox1.ValueMember = "matricule";
           
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement informateurs : " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select matricule, nom, prenom FROM Membre where matricule IN (SELECT matriculeMembre from Composer where nomPlanete IN (Select nomPlanete from Composer where matriculeMembre = '" + this.comboBox1.SelectedValue + "') AND numeroMission IN (SELECT numeroMission from Composer where matriculeMembre = '" + this.comboBox1.SelectedValue + "'))";
            dt1.Clear();
            new SQLiteDataAdapter(sql, Connexion.Connec).Fill(dt1);
            this.dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
