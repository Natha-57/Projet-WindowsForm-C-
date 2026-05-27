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
using mission_tdb;
namespace TdB_Missions
{
    public partial class Form1 : Form
    { 

        public Form1()
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
           // MessageBox.Show("Tables chargées : \n" + MesDatas.DsGlobal.Tables.Count);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int axeX = 25;
            int axeY = 20;
            int i = 0;
            

            foreach (DataRow row in MesDatas.DsGlobal.Tables["mission"].Rows)
            {
                try
                {
                    string filtre = "matricule = '" + row[5].ToString() + "'";
               
                    DataRow[] dr = MesDatas.DsGlobal.Tables["membre"].Select(filtre);
                    DataRow d = dr[0];
                    UserControl1 uc = new UserControl1((row[0].ToString() + row[1].ToString()), row[3].ToString(), row[4].ToString(), d[1].ToString() +" "+ d[2].ToString(), "../../../../Images App/Planètes/Logo - " + row[0]+".png");
                    uc.Location = new Point(axeX, axeY + i);
                    this.Controls.Add(uc);
                    i += 225;
                }
                catch (NullReferenceException err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void btCreerMission_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAuthentification formAuth = new FormAuthentification();
            formAuth.ShowDialog();
            this.Close();
        }
    }
}
