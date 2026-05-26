using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _3_Visualisation_et_MAJ_missions
{
    public partial class Form2 : Form
    {
        private SQLiteConnection cx;
        private string planete;
        private int num;
        public Form2()
        {
            InitializeComponent();
            string chaine = "Data Source=..\\..\\..\\..\\Fichiers Moodle\\Stargate.db";
            this.cx = new SQLiteConnection(chaine);
            this.cx.Open();

            ChargerDepenses();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pbHome.SizeMode = PictureBoxSizeMode.CenterImage;
            pbHome.SizeMode = PictureBoxSizeMode.Zoom;
            pbHome.Image = System.Drawing.Image.FromFile("sae_2.4\\Images App\\Icones diverses\\home.png");

            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void ChargerDepenses()
        {
            string query = @"SELECT d.id        AS N°,
                          d.dateD     AS Date,
                          d.motif     AS Motif,
                          d.montant   AS Montant,
                          td.libelle  AS [Type dépense]
                   FROM   Depense d
                   JOIN   TypeDepense td ON td.id = d.idTypeDepense
                   WHERE  d.nomPlanete    = @planete
                   AND    d.numeroMission = @num
                   ORDER  BY d.dateD"; 

            using (SQLiteCommand cmd = new SQLiteCommand(query, cx))
            {
                cmd.Parameters.AddWithValue("@planete", planete);
                cmd.Parameters.AddWithValue("@num", num);

                DataTable dt = new DataTable();
                new SQLiteDataAdapter(cmd).Fill(dt);
                dgvDepenses.DataSource = dt;

                string sqlTotal = @"SELECT COALESCE(SUM(montant), 0) 
                        FROM   Depense 
                        WHERE  nomPlanete    = @planete 
                        AND    numeroMission = @num";
                SQLiteCommand cmdTotal = new SQLiteCommand(sqlTotal, this.cx);
                cmdTotal.Parameters.AddWithValue("@planete", planete);
                cmdTotal.Parameters.AddWithValue("@num", num);
                lblDepenses.Text = $"Total des dépenses : {cmdTotal.ExecuteScalar()} €";

            }
        }

        private void dgvDepenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
