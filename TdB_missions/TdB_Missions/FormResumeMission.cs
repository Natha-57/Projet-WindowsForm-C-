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
        public FormResumeMission(string nomPlanete, int numeroMission)
        {
            InitializeComponent();
            this.nomPlanete = nomPlanete;
            this.numeroMission = numeroMission;

            string chaine = "Data Source=Stargate.db";
            this.cx = new SQLiteConnection(chaine);
            try
            {
                this.cx.Open();

                ChargerMission();
                ChargerObjectifs();
                ChargerMembres();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ChargerMission()
        {
            try
            {
                string sql = @"
                SELECT mission.dateDepart,
                       mission.dateRetour,
                       mission.feuilleDeRoute,
                       mission.budget,
                       membre.nom || ' ' || membre.prenom AS chef
                FROM Mission mission
                JOIN Membre membre
                    ON mission.matriculeChef = membre.matricule
                WHERE mission.nomPlanete = @planete
                AND mission.numero = @numero";

                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);

                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@numero", this.numeroMission);

                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblNomMission.Text = this.nomPlanete + " - " + this.numeroMission;

                    lblDateDepart.Text =
                        Convert.ToDateTime(reader["dateDepart"]).ToShortDateString();

                    lblDateRetour.Text =
                        Convert.ToDateTime(reader["dateRetour"]).ToShortDateString();

                   txtFeuilleRoute.Text =
                       reader["feuilleDeRoute"].ToString();

                    lblBudget.Text =
                        reader["budget"].ToString() + " €";

                    lblSoldeApresDepenses.Text =
                        reader["budget"].ToString() + " €";

                  //  lblChefMission.Text =
                    //    reader["chef"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur mission : " + ex.Message);
            }
        }

        private void ChargerObjectifs()
        {
            try
            {
                string sql = @"
                SELECT espece.nom,
                       objectifcapture.objectif
                FROM ObjectifCapture objectifcapture
                JOIN Espece espece
                    ON espece.id = objectifcapture.idEspeceEnnemi
                WHERE objectifcapture.nomPlanete = @planete
                AND objectifcapture.numeroMission = @numero";

                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);

                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@numero", this.numeroMission);

                SQLiteDataReader reader = cmd.ExecuteReader();

              lstObjectifs.Items.Clear();

              while (reader.Read())
                {
                    string ligne =
                        reader["nom"].ToString()
                        + " -> "
                        + reader["objectif"].ToString()
                        + " capture(s)";

                    lstObjectifs.Items.Add(ligne);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur objectifs : " + ex.Message);
            }
        }

        private void ChargerMembres()
        {
            try
            {
                string sql = @"
                SELECT membre.nom,
                       membre.prenom
                FROM Composer
                JOIN Membre membre
                    ON membre.matricule = Composer.matriculeMembre
                WHERE Composer.nomPlanete = @planete
                AND Composer.numeroMission = @numero";

                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);

                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@numero", this.numeroMission);

                SQLiteDataReader reader = cmd.ExecuteReader();

             lstMembres.Items.Clear();

                while (reader.Read())
                {
                    string membre =
                        reader["nom"].ToString()
                        + " "
                        + reader["prenom"].ToString();

                    lstMembres.Items.Add(membre);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur membres : " + ex.Message);
            }
        }

        private void btJournalDeBoard_Click(object sender, EventArgs e)
        {
            FormJdB f2 = new FormJdB();
            f2.ShowDialog();
        }
    }

}


