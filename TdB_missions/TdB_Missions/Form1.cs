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
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
            try
            {
                string a = "Data Source=Stargate.db";
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

        }
    }
}
