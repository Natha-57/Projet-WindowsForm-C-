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
using TdB_Missions;

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

            //string chaine = "Data Source=Stargate.db";
            this.cx = Connexion.Connec;
            try
            {
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

            pbDepense.SizeMode = PictureBoxSizeMode.CenterImage;
            pbDepense.SizeMode = PictureBoxSizeMode.Zoom;
            pbDepense.Image = System.Drawing.Image.FromFile("..\\..\\..\\..\\Images App\\Icones diverses\\depense.png");

            pbEvenement.SizeMode = PictureBoxSizeMode.CenterImage;
            pbEvenement.SizeMode = PictureBoxSizeMode.Zoom;
            pbEvenement.Image = System.Drawing.Image.FromFile("..\\..\\..\\..\\Images App\\Icones diverses\\event.png");

            pbContact.SizeMode = PictureBoxSizeMode.CenterImage;
            pbContact.SizeMode = PictureBoxSizeMode.Zoom;
            pbContact.Image = System.Drawing.Image.FromFile("..\\..\\..\\..\\Images App\\Icones diverses\\contact.png");
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

        private void txtNouvelleDepense_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void pbContact_Click(object sender, EventArgs e)
        {

            if (grpNouvelEvenement.Visible || grpNouvelleDepense.Visible)
            {
                grpNouvelEvenement.Hide();
                grpNouvelleDepense.Hide();
                grpNouveauContact.Show();
            }
            else
                grpNouveauContact.Show();



            ChargerMembresSimplifie();


        }

        private void pbDepense_Click(object sender, EventArgs e)
        {
            if (grpNouvelEvenement.Visible || grpNouveauContact.Visible)
            {
                grpNouvelEvenement.Hide();
                grpNouveauContact.Hide();
                grpNouvelleDepense.Show();
            }
            else
                grpNouvelleDepense.Show();


            ChargerMembresSimplifie();

        }

        private void pbEvenement_Click(object sender, EventArgs e)
        {
            if (grpNouveauContact.Visible || grpNouvelleDepense.Visible)
            {
                grpNouveauContact.Hide();
                grpNouvelleDepense.Hide();
                grpNouvelEvenement.Show();
            }
            else
                grpNouvelEvenement.Show();

            ChargerMembresSimplifie();

        }

        private void ChargerMembresSimplifie()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT m.matricule,
                             m.nom || ' ' || m.prenom AS affichage
                             FROM   Membre m
                             ORDER  BY m.nom, m.prenom";
                new SQLiteDataAdapter(sql, this.cx).Fill(dt);
                cboMembre3.DataSource = dt;
                cboMembre3.DisplayMember = "affichage";
                cboMembre3.ValueMember = "matricule";

                cboMembre2.DataSource = dt;
                cboMembre2.DisplayMember = "affichage";
                cboMembre2.ValueMember = "matricule";

                cboMembre1.DataSource = dt;
                cboMembre1.DisplayMember = "affichage";
                cboMembre1.ValueMember = "matricule";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement membres  : " + ex.Message);
            }
        }

        private void txtNouvelleDepense_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNouvelEvenement_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNouveauContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btAnnulerNouvelleDepense_Click(object sender, EventArgs e)
        {
            grpNouvelleDepense.Hide();
        }

        private void btAnnulerNouvelEvenement_Click(object sender, EventArgs e)
        {
            grpNouvelEvenement.Hide();
        }

        private void btAnnulerNouveauContact_Click(object sender, EventArgs e)
        {
            grpNouveauContact.Hide();
        }

        private void btAjoutNouvelEvenement_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCommentaireEvenement.Text))
            {
                MessageBox.Show("Veuillez saisir un commentaire.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"INSERT INTO JournalDeBord (nomPlanete, numero, dateJ, commentaires)
                       VALUES (@planete, @num, @date, @commentaire)";
                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@num", this.numeroMission);
                cmd.Parameters.AddWithValue("@date", dtpNouvelEvenement.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@commentaire", txtCommentaireEvenement.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Événement ajouté !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                grpNouvelEvenement.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void btAjoutNouveauContact_Click(object sender, EventArgs e)
        {
            if (cboMembre3.SelectedItem == null || string.IsNullOrEmpty(txtNouveauContact.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"INSERT INTO Contact 
                           (nomPlanete, numeroMission, dateC, sommeVersee, appreciation, nomCodeInformateur)
                       VALUES 
                           (@planete, @num, @date, @somme, @appreciation, @informateur)";
                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@num", this.numeroMission);
                cmd.Parameters.AddWithValue("@date", dtpNouveauContact.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@somme", Convert.ToInt32(txtNouveauContact.Text));
                cmd.Parameters.AddWithValue("@appreciation", txtCommentaireContact.Text.Trim());
                cmd.Parameters.AddWithValue("@informateur", cboMembre3.SelectedValue.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Contact ajouté !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                grpNouveauContact.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void btAjoutNouvelleDepense_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCommentaireDepense.Text) || string.IsNullOrEmpty(txtNouvelleDepense.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"INSERT INTO Depense 
                           (nomPlanete, numeroMission, dateD, montant, motif, idTypeDepense)
                       VALUES 
                           (@planete, @num, @date, @montant, @motif, @type)";
                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@num", this.numeroMission);
                cmd.Parameters.AddWithValue("@date", dtpNouvelleDepense.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@montant", Convert.ToInt32(txtNouvelleDepense.Text));
                cmd.Parameters.AddWithValue("@motif", txtCommentaireDepense.Text.Trim());
                cmd.Parameters.AddWithValue("@type", cboMembre1.SelectedValue);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Dépense ajoutée !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                grpNouvelleDepense.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }

}


