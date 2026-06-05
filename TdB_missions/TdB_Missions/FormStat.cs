using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TdB_Missions
{
    public partial class FormStat : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        public FormStat()
        {
            

            InitializeComponent();
        }

        private void FormStat_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("../../../../Images_App/Logo Star Gate.ico");
            try
            {
                string sql = "SELECT * FROM membre ORDER BY prenom";
                new SQLiteDataAdapter(sql, Connexion.Connec).Fill(dt);

                this.comboBox1.DataSource = dt;
                this.comboBox1.DisplayMember = "prenom";
                this.comboBox1.ValueMember = "matricule";

                this.comboBox2.DataSource = dt;
                this.comboBox2.DisplayMember = "nom";
                this.comboBox2.ValueMember = "matricule";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement membres : " + ex.Message);
            }

            // Titre
            labelTitre.AutoSize = false;
            labelTitre.TextAlign = ContentAlignment.MiddleCenter;
            labelTitre.Width = this.ClientSize.Width;
            labelTitre.Left = 0;

            int centreX = this.ClientSize.Width / 2;

            labelPrenom.Left = centreX - comboBox1.Width / 2 - labelPrenom.Width - 10;
            labelPrenom.Top = comboBox1.Top + (comboBox1.Height - labelPrenom.Height) / 2;
            comboBox1.Left = centreX - comboBox1.Width / 2;

            labelNom.Left = labelPrenom.Left;
            labelNom.Top = comboBox2.Top + (comboBox2.Height - labelNom.Height) / 2;
            comboBox2.Left = centreX - comboBox2.Width / 2;

            // labelMessage centré
            labelMessage.AutoSize = false;
            labelMessage.TextAlign = ContentAlignment.MiddleCenter;
            labelMessage.Width = this.ClientSize.Width;
            labelMessage.Left = 0;
            labelMessage.Visible = false;

            AfficherCoequipiers();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Synchronise comboBox2 sur le même membre
            comboBox2.SelectedValue = comboBox1.SelectedValue;
            AfficherCoequipiers();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Synchronise comboBox1 sur le même membre
            comboBox1.SelectedValue = comboBox2.SelectedValue;
            AfficherCoequipiers();
        }

        private void AfficherCoequipiers()
        {
            string matricule = this.comboBox1.SelectedValue?.ToString() ?? "";
            if (string.IsNullOrEmpty(matricule)) return;

            // Vérifie d'abord si le membre a des missions
            DataTable dtMissions = new DataTable();
            string sqlMissions = "SELECT COUNT(*) FROM Composer WHERE matriculeMembre = '" + matricule + "'";
            new SQLiteDataAdapter(sqlMissions, Connexion.Connec).Fill(dtMissions);
            int nbMissions = Convert.ToInt32(dtMissions.Rows[0][0]);

            if (nbMissions == 0)
            {
                dt1.Clear();
                this.dataGridView1.DataSource = dt1;
                labelMessage.Text = "Ce membre n'a été affecté à aucune mission.";
                labelMessage.Visible = true;
                return;
            }

            // A des missions → cherche les coéquipiers
            string sql = @"
        SELECT 
            m.matricule, 
            m.nom, 
            m.prenom,
            c.nomPlanete || c.numeroMission AS mission
        FROM Membre m
        JOIN Composer c ON m.matricule = c.matriculeMembre
        WHERE m.matricule != '" + matricule + @"'
        AND c.nomPlanete IN (SELECT nomPlanete FROM Composer WHERE matriculeMembre = '" + matricule + @"')
        AND c.numeroMission IN (SELECT numeroMission FROM Composer WHERE matriculeMembre = '" + matricule + @"')
        ORDER BY m.nom, c.nomPlanete, c.numeroMission";

            dt1.Clear();
            new SQLiteDataAdapter(sql, Connexion.Connec).Fill(dt1);
            this.dataGridView1.DataSource = dt1;

            if (dt1.Rows.Count == 0)
            {
                labelMessage.Text = "Ce membre est affecté à une mission mais n'a pas de coéquipier.";
                labelMessage.Visible = true;
            }
            else
            {
                labelMessage.Visible = false;
            }

            // Renomme les colonnes
            if (this.dataGridView1.Columns.Contains("matricule"))
                this.dataGridView1.Columns["matricule"].HeaderText = "Matricule";
            if (this.dataGridView1.Columns.Contains("nom"))
                this.dataGridView1.Columns["nom"].HeaderText = "Nom";
            if (this.dataGridView1.Columns.Contains("prenom"))
                this.dataGridView1.Columns["prenom"].HeaderText = "Prénom";
            if (this.dataGridView1.Columns.Contains("mission"))
                this.dataGridView1.Columns["mission"].HeaderText = "Mission commune";

            this.dataGridView1.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 255);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelMessage_Click(object sender, EventArgs e)
        {

        }

        private void button_retour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
