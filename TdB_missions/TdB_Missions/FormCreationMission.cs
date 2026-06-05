using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using BCrypt.Net;
using System.IO;
using TdB_Missions;

namespace _2__Creation_De_Mission
{
    public partial class FormCreationMission : Form
    {

        private SQLiteConnection cx;
        private DataSet ds;
        private SQLiteDataAdapter da;
        private string nomPlanete;
        private int numeroMission;
        private List<(int idEspece, int objectif)> listeCaptures = new List<(int, int)>();
        private bool tabControl_navigationManuelle = false;

        public FormCreationMission()
        {
            InitializeComponent();

            tabControlMission.Selecting += (s, e) =>
            {
                if (!tabControl_navigationManuelle)
                    e.Cancel = true;
            };

            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(800, 600);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            try
            {
                this.cx = Connexion.Connec;
                this.ds = new DataSet();
                this.da = new SQLiteDataAdapter();
            }
            catch (SQLiteException er) { MessageBox.Show(er.Message); }

            ChargerPlanetes();
            ChargerAliens();

            dateTimeDepart.Value = DateTime.Today;
            dateTimeRetour.Value = DateTime.Today.AddMonths(6);
            dateTimeDepart.Format = DateTimePickerFormat.Short;
            dateTimeRetour.Format = DateTimePickerFormat.Short;



        }

        private void AllerOnglet(int index)
        {
            tabControl_navigationManuelle = true;
            tabControlMission.SelectedIndex = index;
            tabControl_navigationManuelle = false;
        }

        private void ChargerPlanetes()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT nom FROM Planete ORDER BY nom";
                new SQLiteDataAdapter(sql, this.cx).Fill(dt);
                cboNomPlanete.DataSource = dt;
                cboNomPlanete.DisplayMember = "nom";
                cboNomPlanete.ValueMember = "nom";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement planètes : " + ex.Message);
            }
        }

        private void ChargerChefDeMission()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT m.matricule,
                              m.nom || ' ' || m.prenom || ' - ' || mil.grade AS affichage
                       FROM   Membre m
                       JOIN   Militaire mil ON mil.matriculeMembre = m.matricule
                       ORDER  BY m.nom, m.prenom";
                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
                SQLiteDataReader reader = cmd.ExecuteReader();

                dt.Columns.Add("matricule");
                dt.Columns.Add("affichage");

                while (reader.Read())
                {
                    string matricule = reader["matricule"].ToString();
                    if (MembreDisponible(matricule))
                        dt.Rows.Add(matricule, reader["affichage"]);
                }
                reader.Close();

                cboChefDeMission.DataSource = dt;
                cboChefDeMission.DisplayMember = "affichage";
                cboChefDeMission.ValueMember = "matricule";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement chefs de mission : " + ex.Message);
            }
        }

        private void ChargerMembres()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT m.matricule,
                              m.nom || ' ' || m.prenom || ' - ' ||
                              CASE WHEN mil.matriculeMembre IS NOT NULL
                                   THEN 'Militaire : ' || mil.grade
                                   ELSE 'Civil : '    || c.Specialite
                              END AS affichage
                       FROM   Membre m
                       LEFT JOIN Militaire mil ON mil.matriculeMembre = m.matricule
                       LEFT JOIN Civil     c   ON c.matriculeMembre   = m.matricule
                       ORDER  BY m.nom, m.prenom";
                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
                SQLiteDataReader reader = cmd.ExecuteReader();

                dt.Columns.Add("matricule");
                dt.Columns.Add("affichage");

                while (reader.Read())
                {
                    string matricule = reader["matricule"].ToString();
                    if (MembreDisponible(matricule))
                        dt.Rows.Add(matricule, reader["affichage"]);
                }
                reader.Close();

                cboAjtMembre.DataSource = dt;
                cboAjtMembre.DisplayMember = "affichage";
                cboAjtMembre.ValueMember = "matricule";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement membres : " + ex.Message);
            }
        }

        private void ChargerAliens()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT e.id,
                             e.nom || ' - ' || e.couleur AS affichage
                             FROM   Espece e
                             JOIN   Ennemi en ON en.idEspece = e.id
                             ORDER  BY e.nom";
                new SQLiteDataAdapter(sql, this.cx).Fill(dt);
                cboAliens.DataSource = dt;
                cboAliens.DisplayMember = "affichage";
                cboAliens.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement aliens  : " + ex.Message);
            }
        }

        private void FormCreationMission_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("../../../../Images_App/Logo Star Gate.ico");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNomPlanete.SelectedItem == null) return;

            string planete = cboNomPlanete.SelectedValue.ToString();
            string sql = "SELECT COALESCE(MAX(numero), 0) + 1 FROM Mission WHERE nomPlanete = @planete";
            SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
            cmd.Parameters.AddWithValue("@planete", planete);
            int numero = Convert.ToInt32(cmd.ExecuteScalar());
            this.nomPlanete = planete;
            this.numeroMission = numero;
            lblNomMission.Text = $"Nom de la mission : {planete} - {numero}";


        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void txtNbMembres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNbMembres_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtObjDataBaz_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtNbAliens_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btValiderLaMission_Click(object sender, EventArgs e)
        {

            if (cboChefDeMission.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un chef de mission.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtFeuilleDeRoute.Text))
            {
                MessageBox.Show("Veuillez saisir une feuille de route.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtNbMembres.Text))
            {
                MessageBox.Show("Veuillez saisir un nombre de membres.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtObjDataBaz.Text))
            {
                MessageBox.Show("Veuillez saisir un objectif de données Baz.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtBudget.Text))
            {
                MessageBox.Show("Veuillez saisir un budget.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dateTimeRetour.Value <= dateTimeDepart.Value)
            {
                MessageBox.Show("La date de retour doit être après la date de départ.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"INSERT INTO Mission 
                           (nomPlanete, numero, nbMembreRequis, dateDepart, dateRetour,
                            matriculeChef, feuilleDeRoute, objectifDataBaz, budget)
                       VALUES 
                           (@planete, @num, @nbReq, @dep, @ret,
                            @chef, @route, @dataBaz, @budget)";

                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@num", this.numeroMission);
                cmd.Parameters.AddWithValue("@nbReq", Convert.ToInt32(txtNbMembres.Text));
                cmd.Parameters.AddWithValue("@dep", dateTimeDepart.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ret", dateTimeRetour.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@chef", cboChefDeMission.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@route", txtFeuilleDeRoute.Text.Trim());
                cmd.Parameters.AddWithValue("@dataBaz", string.IsNullOrEmpty(txtObjDataBaz.Text) ? 0 : Convert.ToInt32(txtObjDataBaz.Text));
                cmd.Parameters.AddWithValue("@budget", string.IsNullOrEmpty(txtBudget.Text) ? 0 : Convert.ToInt32(txtBudget.Text));
                cmd.ExecuteNonQuery();

                string sqlChef = @"INSERT INTO Composer (nomPlanete, numeroMission, matriculeMembre)
                   VALUES (@planete, @num, @mat)";
                SQLiteCommand cmdChef = new SQLiteCommand(sqlChef, this.cx);
                cmdChef.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmdChef.Parameters.AddWithValue("@num", this.numeroMission);
                cmdChef.Parameters.AddWithValue("@mat", cboChefDeMission.SelectedValue.ToString());
                cmdChef.ExecuteNonQuery();

                MessageBox.Show($"Mission {this.nomPlanete}-{this.numeroMission} créée avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ChargerMembres();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur création mission : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AllerOnglet(2);
            ChargerMembres();
        }

        private void cboAjtMembre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboAliens_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btAjtObjCapture_Click(object sender, EventArgs e)
        {
            if (cboAliens.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une espèce.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtNbAliens.Text))
            {
                MessageBox.Show("Veuillez saisir un nombre de captures.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEspece = Convert.ToInt32(cboAliens.SelectedValue);
            int objectif = Convert.ToInt32(txtNbAliens.Text);
            listeCaptures.Add((idEspece, objectif));

            string affichage = cboAliens.Text + " --> objectif de captures : " + txtNbAliens.Text;
            lstObj.Items.Add(affichage);
        }

        private void btValiderObjCapture_Click(object sender, EventArgs e)
        {
            if (lstObj.Items.Count == 0)
            {
                MessageBox.Show("Aucun objectif défini.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SQLiteTransaction transaction = this.cx.BeginTransaction();
            try
            {
                foreach (var (idEspece, objectif) in listeCaptures)
                {
                    string sql = @"INSERT INTO ObjectifCapture 
                               (nomPlanete, numeroMission, idEspeceEnnemi, objectif)
                           VALUES 
                               (@planete, @num, @idE, @obj)";

                    SQLiteCommand cmd = new SQLiteCommand(sql, this.cx, transaction);
                    cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                    cmd.Parameters.AddWithValue("@num", this.numeroMission);
                    cmd.Parameters.AddWithValue("@idE", idEspece);
                    cmd.Parameters.AddWithValue("@obj", objectif);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Objectifs enregistrés avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Erreur, aucune capture enregistrée : " + ex.Message,
                    "Transaction annulée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstMembres_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstObj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btAjtMembres_Click(object sender, EventArgs e)
        {
            if (cboAjtMembre.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un membre.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lstMembres.Items.Count >= Convert.ToInt32(txtNbMembres.Text))
            {
                MessageBox.Show("Nombre maximum de membres atteint.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboAjtMembre.SelectedValue.ToString() == cboChefDeMission.SelectedValue.ToString())
            {
                MessageBox.Show("Le chef de mission ne peut pas être ajouté comme membre.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"INSERT INTO Composer (nomPlanete, numeroMission, matriculeMembre)
                       VALUES (@planete, @num, @mat)";
                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@num", this.numeroMission);
                cmd.Parameters.AddWithValue("@mat", cboAjtMembre.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                lstMembres.Items.Add(cboAjtMembre.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vous avez déjà ajouté ce membre.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btValdierMembres_Click(object sender, EventArgs e)
        {
            if (lstMembres.Items.Count == 0)
            {
                MessageBox.Show("Aucun membre ajouté.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstMembres.Items.Count < Convert.ToInt32(txtNbMembres.Text))
            {
                DialogResult rep = MessageBox.Show(
                    $"Il manque encore {Convert.ToInt32(txtNbMembres.Text) - lstMembres.Items.Count} membre(s).\nVoulez-vous continuer quand même ?",
                    "Quota non atteint", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rep == DialogResult.No) return;
            }

            MessageBox.Show("Membres validés !", "Succès",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            AllerOnglet(3);
        }


        private bool MembreDisponible(string matricule)
        {
            // Vérifie si le membre est déjà dans une mission 

            string sql1 = @"SELECT COUNT(*) FROM Composer comp
                    JOIN Mission m ON m.nomPlanete = comp.nomPlanete 
                    AND m.numero = comp.numeroMission
                    WHERE comp.matriculeMembre = @mat
                    AND m.dateDepart <= @ret
                    AND m.dateRetour >= @dep";

            // Vérifie aussi s'il est chef d'une autre mission
            string sql2 = @"SELECT COUNT(*) FROM Mission m
                    WHERE m.matriculeChef = @mat
                    AND m.dateDepart <= @ret
                    AND m.dateRetour >= @dep";

            SQLiteCommand cmd1 = new SQLiteCommand(sql1, this.cx);
            cmd1.Parameters.AddWithValue("@mat", matricule);
            cmd1.Parameters.AddWithValue("@dep", dateTimeDepart.Value.ToString("yyyy-MM-dd"));
            cmd1.Parameters.AddWithValue("@ret", dateTimeRetour.Value.ToString("yyyy-MM-dd"));

            SQLiteCommand cmd2 = new SQLiteCommand(sql2, this.cx);
            cmd2.Parameters.AddWithValue("@mat", matricule);
            cmd2.Parameters.AddWithValue("@dep", dateTimeDepart.Value.ToString("yyyy-MM-dd"));
            cmd2.Parameters.AddWithValue("@ret", dateTimeRetour.Value.ToString("yyyy-MM-dd"));

            return Convert.ToInt32(cmd1.ExecuteScalar()) == 0
                && Convert.ToInt32(cmd2.ExecuteScalar()) == 0;

            // ca enleve des combo box les membres deja en mission
        }




        private void grpNouvelleMission_Enter(object sender, EventArgs e)
        {

        }

        private void txtFeuilleDeRoute_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboChefDeMission_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeDepart_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeDepart_ValueChanged(object sender, EventArgs e)
        {
            if (cboChefDeMission.Visible)
                ChargerChefDeMission();
            if (cboAjtMembre.Visible)
                ChargerMembres();
        }

        private void dateTimeRetour_ValueChanged(object sender, EventArgs e)
        {
            dateTimeRetour.Value = dateTimeDepart.Value.AddMonths(6);


            if (cboChefDeMission.Visible)
                ChargerChefDeMission();
            if (cboAjtMembre.Visible)
                ChargerMembres();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btValiderDates_Click(object sender, EventArgs e)
        {

            AllerOnglet(1);

            ChargerChefDeMission();
        }
    }
}
