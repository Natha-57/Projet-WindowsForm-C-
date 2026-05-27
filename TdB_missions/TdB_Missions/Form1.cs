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
                MessageBox.Show(liste + "\n" + MesDatas.DsGlobal.Tables.Count.ToString() + " tables");
            }
            catch (SQLiteException err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int axeX = 25;
            int axeY = 20;
            int i = 0;
            string filtre = "MesDatas.DsGlobal.Tables[\"membre\"].Rows[1]";
            

            foreach (DataRow row in MesDatas.DsGlobal.Tables["mission"].Rows)
            {
                try
                {
                    DataRow[] dr = MesDatas.DsGlobal.Tables["membres"].Select("matricule =" + row[5].ToString());
                    DataRow d = dr[0];

                    UserControl1 uc = new UserControl1((row[0].ToString() + row[1].ToString()), row[3].ToString(), row[4].ToString(), MesDatas.DsGlobal.Tables["membre"].Rows[2].ToString(), row[5].ToString());
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
    }
}
