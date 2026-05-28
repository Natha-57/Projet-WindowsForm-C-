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

            pbJdB.SizeMode = PictureBoxSizeMode.CenterImage;
            pbJdB.SizeMode = PictureBoxSizeMode.Zoom;
            pbJdB.Image = System.Drawing.Image.FromFile("..\\..\\..\\..\\Images App\\Icones diverses\\jdb.png");

            pbHome.SizeMode = PictureBoxSizeMode.CenterImage;
            pbHome.SizeMode = PictureBoxSizeMode.Zoom;
            pbHome.Image = System.Drawing.Image.FromFile("..\\..\\..\\..\\Images App\\Icones diverses\\home.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("../../../../Images_App/Logo Star Gate.ico");
        }

        private void ChargerMission()
        {
            string cheminPhoto = $"..\\..\\..\\..\\Images App\\Planètes\\Logo - {this.nomPlanete}.png";
            if (File.Exists(cheminPhoto))
            {
                pbPlanete.Image = Image.FromFile(cheminPhoto);
                pbPlanete.SizeMode = PictureBoxSizeMode.Zoom;
            }

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

                    int budget = Convert.ToInt32(reader["budget"]);
                    lblBudget.Text = budget + " €";

                    string sqlSolde = @"SELECT COALESCE(SUM(montant), 0) 
                        FROM Depense 
                        WHERE nomPlanete    = @planete 
                        AND   numeroMission = @numero";
                    SQLiteCommand cmdSolde = new SQLiteCommand(sqlSolde, this.cx);
                    cmdSolde.Parameters.AddWithValue("@planete", this.nomPlanete);
                    cmdSolde.Parameters.AddWithValue("@numero", this.numeroMission);
                    int totalDepenses = Convert.ToInt32(cmdSolde.ExecuteScalar());

                    lblSoldeApresDepenses.Text = (budget - totalDepenses) + " €";
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
            SELECT m.nom, m.prenom,
                   CASE WHEN mil.matriculeMembre IS NOT NULL 
                        THEN mil.grade
                        ELSE c.Specialite
                   END AS type
            FROM Composer comp
            JOIN Membre m ON m.matricule = comp.matriculeMembre
            LEFT JOIN Militaire mil ON mil.matriculeMembre = m.matricule
            LEFT JOIN Civil c ON c.matriculeMembre = m.matricule
            WHERE comp.nomPlanete = @planete
            AND comp.numeroMission = @numero";

                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@numero", this.numeroMission);
                SQLiteDataReader reader = cmd.ExecuteReader();

                flpMembres.Controls.Clear();

                while (reader.Read())
                {
                    string type = reader["type"].ToString();

                    Panel pnl = new Panel
                    {
                        Width = 80,
                        Height = 100,
                        Margin = new Padding(5)
                    };

                    PictureBox pb = new PictureBox
                    {
                        Width = 60,
                        Height = 60,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(10, 5)
                    };

                    string cheminPhoto = $"..\\..\\..\\..\\Images App\\Membres\\Logo - {type}.png";
                    if (File.Exists(cheminPhoto))
                        pb.Image = Image.FromFile(cheminPhoto);

                    Label lbl = new Label
                    {
                        Text = reader["nom"] + "\n" + reader["prenom"],
                        Width = 80,
                        Height = 35,
                        Location = new Point(0, 65),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 7)
                    };

                    pnl.Controls.Add(pb);
                    pnl.Controls.Add(lbl);
                    flpMembres.Controls.Add(pnl);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur membres : " + ex.Message);
            }
        }



        private void pbJdB_Click(object sender, EventArgs e)
        {
            
            FormJdB f2 = new FormJdB(this.nomPlanete, this.numeroMission);
            f2.ShowDialog();
        }

        private void lblSoldeApresDepenses_Click(object sender, EventArgs e)
        {

        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}


