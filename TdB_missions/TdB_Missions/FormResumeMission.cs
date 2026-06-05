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
        private SQLiteConnection cx = Connexion.Connec;
        private string nomPlanete;
        private int numeroMission;

        public FormResumeMission(string nomPlanete, int numeroMission)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.nomPlanete = nomPlanete;
            this.numeroMission = numeroMission;

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

            pbJdB.SizeMode = PictureBoxSizeMode.Zoom;
            pbJdB.Image = Image.FromFile("..\\..\\..\\..\\Images_App\\Icones diverses\\jdb.png");

            pbHome.SizeMode = PictureBoxSizeMode.Zoom;
            pbHome.Image = Image.FromFile("..\\..\\..\\..\\Images_App\\Icones diverses\\home.png");

            pbDepense.SizeMode = PictureBoxSizeMode.Zoom;
            pbDepense.Image = Image.FromFile("..\\..\\..\\..\\Images_App\\Icones diverses\\depense.png");

            pbEvenement.SizeMode = PictureBoxSizeMode.Zoom;
            pbEvenement.Image = Image.FromFile("..\\..\\..\\..\\Images_App\\Icones diverses\\event.png");

            pbContact.SizeMode = PictureBoxSizeMode.Zoom;
            pbContact.Image = Image.FromFile("..\\..\\..\\..\\Images_App\\Icones diverses\\contact.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("../../../../Images_App/Logo Star Gate.ico");
        }

        private void ChargerMission()
        {
            string cheminPhoto = $"..\\..\\..\\..\\Images_App\\Planètes\\Logo - {this.nomPlanete}.png";
            if (File.Exists(cheminPhoto))
            {
                pbPlanete.Image = Image.FromFile(cheminPhoto);
                pbPlanete.SizeMode = PictureBoxSizeMode.Zoom;
            }

            string filtre = $"nomPlanete = '{this.nomPlanete}' AND numero = {this.numeroMission}";
            DataRow[] rows = MesDatas.DsGlobal.Tables["Mission"].Select(filtre);
            if (rows.Length == 0) return;
            DataRow mission = rows[0];

            string filtreChef = $"matricule = '{mission["matriculeChef"]}'";
            DataRow[] rowsChef = MesDatas.DsGlobal.Tables["Membre"].Select(filtreChef);
            string chef = rowsChef.Length > 0
                ? rowsChef[0]["nom"] + " " + rowsChef[0]["prenom"]
                : "Inconnu";

            lblNomMission.Text = this.nomPlanete + " - " + this.numeroMission;
            lblDateDepart.Text = Convert.ToDateTime(mission["dateDepart"]).ToShortDateString();
            lblDateRetour.Text = Convert.ToDateTime(mission["dateRetour"]).ToShortDateString();
            txtFeuilleRoute.Text = mission["feuilleDeRoute"].ToString();
            lblBudget.Text = mission["budget"] + " €";

            string filtreDepense = $"nomPlanete = '{this.nomPlanete}' AND numeroMission = {this.numeroMission}";
            DataRow[] depenses = MesDatas.DsGlobal.Tables["Depense"].Select(filtreDepense);
            int totalDepenses = 0;
            foreach (DataRow d in depenses)
                totalDepenses += Convert.ToInt32(d["montant"]);

            int budget = Convert.ToInt32(mission["budget"]);
            lblSoldeApresDepenses.Text = (budget - totalDepenses) + " €";
        }

        private void ChargerObjectifs()
        {
            string filtre = $"nomPlanete = '{this.nomPlanete}' AND numeroMission = {this.numeroMission}";
            DataRow[] rows = MesDatas.DsGlobal.Tables["ObjectifCapture"].Select(filtre);

            lstObjectifs.Items.Clear();
            foreach (DataRow row in rows)
            {
                string filtreEspece = $"id = {row["idEspeceEnnemi"]}";
                DataRow[] especes = MesDatas.DsGlobal.Tables["Espece"].Select(filtreEspece);
                string nomEspece = especes.Length > 0 ? especes[0]["nom"].ToString() : "Inconnue";
                lstObjectifs.Items.Add($"{nomEspece} -> {row["objectif"]} capture(s)");
            }
        }

        private void ChargerMembres()
        {
            string filtre = $"nomPlanete = '{this.nomPlanete}' AND numeroMission = {this.numeroMission}";
            DataRow[] rows = MesDatas.DsGlobal.Tables["Composer"].Select(filtre);

            flpMembres.Controls.Clear();
            foreach (DataRow row in rows)
            {
                string matricule = row["matriculeMembre"].ToString();

                DataRow[] membre = MesDatas.DsGlobal.Tables["Membre"].Select($"matricule = '{matricule}'");
                if (membre.Length == 0) continue;

                DataRow[] mil = MesDatas.DsGlobal.Tables["Militaire"].Select($"matriculeMembre = '{matricule}'");
                DataRow[] civ = MesDatas.DsGlobal.Tables["Civil"].Select($"matriculeMembre = '{matricule}'");
                string type = mil.Length > 0 ? mil[0]["grade"].ToString()
                              : civ.Length > 0 ? civ[0]["Specialite"].ToString()
                              : "";

                Panel pnl = new Panel { Width = 80, Height = 100, Margin = new Padding(5) };

                PictureBox pb = new PictureBox
                {
                    Width = 60,
                    Height = 60,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(10, 5)
                };
                string cheminPhoto = $"Membres\\Logo - {type}.png";
                if (File.Exists(cheminPhoto))
                    pb.Image = Image.FromFile(cheminPhoto);

                Label lbl = new Label
                {
                    Text = membre[0]["nom"] + "\n" + membre[0]["prenom"],
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
        }

        private void pbJdB_Click(object sender, EventArgs e)
        {
            FormJdB f2 = new FormJdB(this.nomPlanete, this.numeroMission);
            f2.ShowDialog();
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbContact_Click(object sender, EventArgs e)
        {
            grpNouvelEvenement.Hide();
            grpNouvelleDepense.Hide();
            grpNouveauContact.Show();
            var (dateDepart, _) = GetDatesMission();
            dtpNouveauContact.Value = dateDepart;
            ChargerMembresSimplifie();
            ChargerEspeces();
        }

        private void pbDepense_Click(object sender, EventArgs e)
        {
            grpNouvelEvenement.Hide();
            grpNouveauContact.Hide();
            var (dateDepart, _) = GetDatesMission();
            dtpNouvelleDepense.Value = dateDepart;
            grpNouvelleDepense.Show();
            ChargerTypesDepenses();
        }

        private void pbEvenement_Click(object sender, EventArgs e)
        {
            grpNouveauContact.Hide();
            grpNouvelleDepense.Hide();
            grpNouvelEvenement.Show();
            var (dateDepart, _) = GetDatesMission();
            dtpNouvelEvenement.Value = dateDepart;
        }

        private void ChargerMembresSimplifie()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT nomCode, nom FROM Informateur WHERE nomCode IS NOT NULL ORDER BY nom";
                new SQLiteDataAdapter(sql, this.cx).Fill(dt);
                cboMembre3.DataSource = dt;
                cboMembre3.DisplayMember = "nom";
                cboMembre3.ValueMember = "nomCode";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement informateurs : " + ex.Message);
            }
        }

        private void ChargerTypesDepenses()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT id, libelle FROM TypeDepense";
                new SQLiteDataAdapter(sql, this.cx).Fill(dt);
                cboMembre1.DataSource = dt;
                cboMembre1.DisplayMember = "libelle";
                cboMembre1.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement types de dépenses : " + ex.Message);
            }
        }

        private void ChargerEspeces()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT e.id, e.nom || ' - ' || e.couleur AS affichage
                                 FROM   Espece e
                                 JOIN   Ennemi en ON en.idEspece = e.id
                                 ORDER  BY e.nom";
                new SQLiteDataAdapter(sql, this.cx).Fill(dt);
                cboEspece.DataSource = dt;
                cboEspece.DisplayMember = "affichage";
                cboEspece.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement espèces : " + ex.Message);
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
                string sqlCheck = @"SELECT COUNT(*) FROM JournalDeBord 
                                    WHERE nomPlanete = @planete 
                                    AND   numero     = @num 
                                    AND   dateJ      = @date";
                SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck, this.cx);
                cmdCheck.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmdCheck.Parameters.AddWithValue("@num", this.numeroMission);
                cmdCheck.Parameters.AddWithValue("@date", dtpNouvelEvenement.Value.ToString("yyyy-MM-dd"));
                if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("Un événement existe déjà à cette date.\nChoisissez une autre date.",
                        "Date déjà utilisée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var (dateDepart, dateRetour) = GetDatesMission();
                if (dtpNouvelEvenement.Value < dateDepart || dtpNouvelEvenement.Value > dateRetour)
                {
                    MessageBox.Show($"La date doit être comprise entre le {dateDepart.ToShortDateString()} et le {dateRetour.ToShortDateString()}.",
                        "Date hors bornes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = @"INSERT INTO JournalDeBord (nomPlanete, numero, dateJ, commentaires)
                               VALUES (@planete, @num, @date, @commentaire)";
                SQLiteCommand cmd = new SQLiteCommand(sql, this.cx);
                cmd.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmd.Parameters.AddWithValue("@num", this.numeroMission);
                cmd.Parameters.AddWithValue("@date", dtpNouvelEvenement.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@commentaire", txtCommentaireEvenement.Text.Trim());
                cmd.ExecuteNonQuery();
                RafraichirDataSet();
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
                string sqlCheck = @"SELECT COUNT(*) FROM Contact 
                                    WHERE nomPlanete    = @planete 
                                    AND   numeroMission = @num 
                                    AND   dateC         = @date";
                SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck, this.cx);
                cmdCheck.Parameters.AddWithValue("@planete", this.nomPlanete);
                cmdCheck.Parameters.AddWithValue("@num", this.numeroMission);
                cmdCheck.Parameters.AddWithValue("@date", dtpNouveauContact.Value.ToString("yyyy-MM-dd"));
                if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("Un contact existe déjà à cette date.\nChoisissez une autre date.",
                        "Date déjà utilisée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var (dateDepart, dateRetour) = GetDatesMission();
                if (dtpNouveauContact.Value < dateDepart || dtpNouveauContact.Value > dateRetour)
                {
                    MessageBox.Show($"La date doit être comprise entre le {dateDepart.ToShortDateString()} et le {dateRetour.ToShortDateString()}.",
                        "Date hors bornes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                RafraichirDataSet();
                MessageBox.Show("Contact ajouté !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                grpNouveauContact.Visible = false;
                ChargerMission();
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

            var (dateDepart, dateRetour) = GetDatesMission();
            if (dtpNouvelleDepense.Value < dateDepart || dtpNouvelleDepense.Value > dateRetour)
            {
                MessageBox.Show($"La date doit être comprise entre le {dateDepart.ToShortDateString()} et le {dateRetour.ToShortDateString()}.",
                    "Date hors bornes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtreMission = $"nomPlanete = '{this.nomPlanete.Replace("'", "''")}' AND numero = {this.numeroMission}";
            DataRow[] rowsMission = MesDatas.DsGlobal.Tables["Mission"].Select(filtreMission);
            int budget = Convert.ToInt32(rowsMission[0]["budget"]);

            string filtreDepense = $"nomPlanete = '{this.nomPlanete.Replace("'", "''")}' AND numeroMission = {this.numeroMission}";
            DataRow[] depenses = MesDatas.DsGlobal.Tables["Depense"].Select(filtreDepense);
            int totalDepenses = 0;
            foreach (DataRow d in depenses)
                totalDepenses += Convert.ToInt32(d["montant"]);

            int soldeActuel = budget - totalDepenses;
            int montantSaisi = Convert.ToInt32(txtNouvelleDepense.Text);

            if (montantSaisi > soldeActuel)
            {
                MessageBox.Show($"Impossible d'ajouter cette dépense.\nMontant saisi : {montantSaisi} €\nSolde disponible : {soldeActuel} €",
                    "Solde insuffisant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        private (DateTime dateDepart, DateTime dateRetour) GetDatesMission()
        {
            string filtre = $"nomPlanete = '{this.nomPlanete}' AND numero = {this.numeroMission}";
            DataRow[] rows = MesDatas.DsGlobal.Tables["Mission"].Select(filtre);
            DateTime dep = Convert.ToDateTime(rows[0]["dateDepart"]);
            DateTime ret = Convert.ToDateTime(rows[0]["dateRetour"]);
            return (dep, ret);
        }


        private void RafraichirDataSet()
        {
            string sql;
            DataTable schemaTable = Connexion.Connec.GetSchema("Tables");
            foreach (DataRow row in schemaTable.Rows)
            {
                string nomTable = row[2].ToString();
                sql = "SELECT * FROM " + nomTable;
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, Connexion.Connec);
                MesDatas.DsGlobal.Tables[nomTable].Clear();
                da.Fill(MesDatas.DsGlobal, nomTable);
            }
        }


        private void lblSoldeApresDepenses_Click(object sender, EventArgs e) { }
        private void txtNouvelleDepense_TextChanged(object sender, EventArgs e) { }
        private void cboEspece_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboMembre2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtNouvelleDepense_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtNouveauContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void flpMembres_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpNouvelleDepense_ValueChanged(object sender, EventArgs e)
        {
            var (dateDepart, dateRetour) = GetDatesMission();
            if (dtpNouvelleDepense.Value < dateDepart)
                dtpNouvelleDepense.Value = dateDepart;
            else if (dtpNouvelleDepense.Value > dateRetour)
                dtpNouvelleDepense.Value = dateRetour;
        }

        private void dptNouveauContact_ValueChanged(object sender, EventArgs e)
        {
            var (dateDepart, dateRetour) = GetDatesMission();
            if (dtpNouvelleDepense.Value < dateDepart)
                dtpNouvelleDepense.Value = dateDepart;
            else if (dtpNouvelleDepense.Value > dateRetour)
                dtpNouvelleDepense.Value = dateRetour;
        }

        private void dtpNouvelEvenement_ValueChanged(object sender, EventArgs e)
        {
            var (dateDepart, dateRetour) = GetDatesMission();
            if (dtpNouvelleDepense.Value < dateDepart)
                dtpNouvelleDepense.Value = dateDepart;
            else if (dtpNouvelleDepense.Value > dateRetour)
                dtpNouvelleDepense.Value = dateRetour;
        }
    }
}