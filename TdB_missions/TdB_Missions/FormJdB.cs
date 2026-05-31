using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TdB_Missions;
using static System.Net.Mime.MediaTypeNames;

namespace _3_Visualisation_et_MAJ_missions
{
    public partial class FormJdB : Form
    {
        private SQLiteConnection cx;
        private string planete;
        private int num;
        private DataTable dtEvenements;
        private int indexEvenement = 0;
        public FormJdB(string planete, int num)
        {
            InitializeComponent();
            this.planete = planete;
            this.num = num;

            Connexion.FermerConnexion();
            this.cx = Connexion.Connec;

            ChargerDepenses();
            ChargerContacts();
            ChargerEvenements();
        

            pbHome.SizeMode = PictureBoxSizeMode.CenterImage;
            pbHome.SizeMode = PictureBoxSizeMode.Zoom;
            pbHome.Image = System.Drawing.Image.FromFile("..\\..\\..\\..\\Images App\\Icones diverses\\home.png"); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }

        private void ChargerDepenses()
        {
            string query = @"SELECT 
                          d.id        AS N°,
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

        private void ChargerContacts()
        {
            string query = @"SELECT
                            c.dateC          AS Date,
                            c.sommeVersee    AS Somme,
                            c.appreciation   AS Appréciation,
                            i.nomCode        AS Informateur,
                            e.nom            AS Espèce
                     FROM   Contact c
                     JOIN   Informateur i ON i.nomCode  = c.nomCodeInformateur
                     JOIN   Espece      e ON e.id       = i.idEspeceEnnemi
                     WHERE  c.nomPlanete    = @planete
                     AND    c.numeroMission = @num
                     ORDER  BY date(c.dateC)";

            SQLiteCommand cmd = new SQLiteCommand(query, this.cx);
            cmd.Parameters.AddWithValue("@planete", this.planete);
            cmd.Parameters.AddWithValue("@num", this.num);

            DataTable dt = new DataTable();
            new SQLiteDataAdapter(cmd).Fill(dt);
            dgvContacts.DataSource = dt;

            string sqlTotal = @"SELECT COALESCE(SUM(sommeVersee), 0) 
                        FROM   Contact 
                        WHERE  nomPlanete    = @planete 
                        AND    numeroMission = @num";
            SQLiteCommand cmdTotal = new SQLiteCommand(sqlTotal, this.cx);
            cmdTotal.Parameters.AddWithValue("@planete", this.planete);
            cmdTotal.Parameters.AddWithValue("@num", this.num);
            lblSommesVersées.Text = $"Total des sommes versées : {cmdTotal.ExecuteScalar()} €";
        }

        private void ChargerEvenements()
        {
            string sql = @"SELECT dateJ, commentaires 
                   FROM   JournalDeBord
                   WHERE  nomPlanete    = @planete 
                   AND    numero = @num
                   ORDER  BY date(dateJ)";

            SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
            cmd.Parameters.AddWithValue("@planete", this.planete);
            cmd.Parameters.AddWithValue("@num", this.num);

            dtEvenements = new DataTable();
            new SQLiteDataAdapter(cmd).Fill(dtEvenements);

            indexEvenement = 0;
            AfficherEvenement();
        }

        private void AfficherEvenement()
        {
            if (dtEvenements.Rows.Count == 0)
            {
                lblDateEvenement.Text = "Aucun événement";
                lblEvenement.Text = "";
                lblCompteurPages.Text = "0 / 0";
                return;
            }

            DataRow row = dtEvenements.Rows[indexEvenement];
            lblDateEvenement.Text = Convert.ToDateTime(row["dateJ"]).ToString("dd/MM/yyyy");
            lblEvenement.Text = row["commentaires"].ToString();
            lblCompteurPages.Text = $"{indexEvenement + 1} / {dtEvenements.Rows.Count}";
        }

        private void btToutDebut_Click(object sender, EventArgs e)
        {
            indexEvenement = 0;
            AfficherEvenement();
        }

        private void btRevenir1foisEnArriere_Click(object sender, EventArgs e)
        {
            if (indexEvenement > 0)
                indexEvenement--;
            AfficherEvenement();
        }

        private void btSuivant_Click(object sender, EventArgs e)
        {
            if (indexEvenement < dtEvenements.Rows.Count - 1)
                indexEvenement++;
            AfficherEvenement();
        }

        private void btAllerToutAlaFin_Click(object sender, EventArgs e)
        {
            indexEvenement = dtEvenements.Rows.Count - 1;
            AfficherEvenement();
        }
    

        private void dgvDepenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FormJdB_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("../../../../Images_App/Logo Star Gate.ico");
        }

        private void lblEvenement_Click(object sender, EventArgs e)
        {

        }
    }
}
