using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace _3_Visualisation_et_MAJ_missions
{
    public partial class FormResumeMission : Form
    {
        private SQLiteConnection cx;
        private string nomPlanete;
        private int numeroMission;
        public FormResumeMission()
        {
            InitializeComponent();
            this.nomPlanete = nomPlanete;
            this.numeroMission = numeroMission;

            string chaine = "Data Source=..\\..\\..\\..\\Fichiers Moodle\\Stargate.db";
            this.cx = new SQLiteConnection(chaine);
            this.cx.Open();

           // ChargerMission(nomPlanete, numeroMission);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btJournalDeBoard_Click(object sender, EventArgs e)
        {
            FormJdB f2 = new FormJdB();
            f2.ShowDialog();
            
        }



    }
}


// a mettre dans le volet 1 :
// FormFicheMission fiche = new FormFicheMission("Mars", 1);
// fiche.ShowDialog();