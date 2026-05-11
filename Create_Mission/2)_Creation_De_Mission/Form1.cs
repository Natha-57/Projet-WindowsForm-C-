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
using BCrypt.Net;
using System.IO;

namespace _2__Creation_De_Mission
{
    public partial class FormCreationMission : Form
    {

        private SQLiteConnection cx;
        private DataSet ds;
        private SQLiteDataAdapter da;
        private string nomPlanete;    
        private int numeroMission;


        public FormCreationMission()
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(800, 600);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        

            try
            {
                string chaine = "Data Source=..\\..\\Stargate.db";
                this.cx = new SQLiteConnection(chaine);
                this.cx.Open();
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
                new SQLiteDataAdapter(sql, this.cx).Fill(dt);  
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
                            ELSE 'Civil : ' || c.Specialite
                            END AS affichage
                            FROM   Membre m
                            LEFT JOIN Militaire mil ON mil.matriculeMembre = m.matricule
                            LEFT JOIN Civil c   ON c.matriculeMembre = m.matricule
                            ORDER BY m.nom, m.prenom";
                new SQLiteDataAdapter(sql, this.cx).Fill(dt);
                cboAjtMembre.DataSource = dt;
                cboAjtMembre.DisplayMember = "affichage";
                cboAjtMembre.ValueMember = "matricule";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement membres  : " + ex.Message);
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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (cboNomPlanete.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une planète.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string planete = cboNomPlanete.SelectedValue.ToString();

            string sql = "SELECT COALESCE(MAX(numero), 0) + 1 FROM Mission WHERE nomPlanete = @planete"; // COALESCE pour gérer le cas où il n'y a aucune mission pour cette planète
            SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
            cmd.Parameters.AddWithValue("@planete", planete);
            int numero = Convert.ToInt32(cmd.ExecuteScalar());
            this.nomPlanete = planete;
            this.numeroMission = numero;
            lblNomMission.Text = $"Nom de la mission : {planete} - {numero}";




            ChargerChefDeMission();
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

            string affichage = cboAliens.Text + " --> objectif de captures : " + txtNbAliens.Text;
            lstObj.Items.Add(affichage);
        }

        private void btValiderObjCapture_Click(object sender, EventArgs e)
        {
          
        }
    }
}
