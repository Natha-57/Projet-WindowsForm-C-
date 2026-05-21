using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Visualisation_et_MAJ_missions
{
    public partial class Form1 : Form
    {
        private SQLiteConnection cx;
        private string nomPlanete;
        private int numeroMission;
        public Form1()
        {
            InitializeComponent();
            this.nomPlanete = nomPlanete;
            this.numeroMission = numeroMission;

            string chaine = "Data Source=..\\..\\Stargate.db";
            this.cx = new SQLiteConnection(chaine);
            this.cx.Open();

            ChargerMission(nomPlanete, numeroMission);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


// a mettre dans le volet 1 :
// FormFicheMission fiche = new FormFicheMission("Mars", 1);
// fiche.ShowDialog();