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
using iTextSharp.text;
using iTextSharp.text.pdf;
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

            ChargerDepenses();
            ChargerContacts();
            ChargerEvenements();
            ChargerBilanCaptures();


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
            string filtre = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
            DataRow[] rows = MesDatas.DsGlobal.Tables["Depense"].Select(filtre);

            DataTable dt = new DataTable();
            dt.Columns.Add("N°");
            dt.Columns.Add("Date");
            dt.Columns.Add("Motif");
            dt.Columns.Add("Montant");
            dt.Columns.Add("Type dépense");

            int total = 0;
            foreach (DataRow row in rows)
            {
                string filtreType = $"id = {row["idTypeDepense"]}";
                DataRow[] type = MesDatas.DsGlobal.Tables["TypeDepense"].Select(filtreType);
                string libelle = type.Length > 0 ? type[0]["libelle"].ToString() : "";

                string dateFormatee;
                try { dateFormatee = Convert.ToDateTime(row["dateD"]).ToString("dd/MM/yyyy"); }
                catch { dateFormatee = row["dateD"].ToString(); }

                dt.Rows.Add(row["id"], dateFormatee, row["motif"], row["montant"], libelle);
                total += Convert.ToInt32(row["montant"]);
            }

            dgvDepenses.DataSource = dt;
            lblDepenses.Text = $"Total des dépenses : {total} €";

        }



        private void ChargerContacts()
        {
            string filtre = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
            DataRow[] rows = MesDatas.DsGlobal.Tables["Contact"].Select(filtre);

            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Somme");
            dt.Columns.Add("Appréciation");
            dt.Columns.Add("Informateur");
            dt.Columns.Add("Espèce");

            int total = 0;
            foreach (DataRow row in rows)
            {
                string filtreInfo = $"nomCode = '{row["nomCodeInformateur"]}'";
                DataRow[] info = MesDatas.DsGlobal.Tables["Informateur"].Select(filtreInfo);
                string nomInfo = info.Length > 0 ? info[0]["nom"].ToString() : "";

                string nomEspece = "";
                if (info.Length > 0)
                {
                    string filtreEspece = $"id = {info[0]["idEspeceEnnemi"]}";
                    DataRow[] espece = MesDatas.DsGlobal.Tables["Espece"].Select(filtreEspece);
                    nomEspece = espece.Length > 0 ? espece[0]["nom"].ToString() : "";
                }

                string dateFormatee;
                try { dateFormatee = Convert.ToDateTime(row["dateC"]).ToString("dd/MM/yyyy"); }
                catch { dateFormatee = row["dateC"].ToString(); }

                dt.Rows.Add(dateFormatee, row["sommeVersee"], row["appreciation"], nomInfo, nomEspece);
                total += Convert.ToInt32(row["sommeVersee"]);
            }

            dgvContacts.DataSource = dt;
            lblSommesVersées.Text = $"Total des sommes versées : {total} €";
        }

        private void ChargerEvenements()
        {
            string filtre = $"nomPlanete = '{this.planete}' AND numero = {this.num}";
            DataRow[] rows = MesDatas.DsGlobal.Tables["JournalDeBord"].Select(filtre, "dateJ ASC");

            dtEvenements = new DataTable();
            dtEvenements.Columns.Add("dateJ");
            dtEvenements.Columns.Add("commentaires");

            foreach (DataRow row in rows)
                dtEvenements.Rows.Add(row["dateJ"], row["commentaires"]);

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


        private void ChargerBilanCaptures()
        {
            string nomTable = $"BilanCapture{this.planete}{this.num}";

            if (!MesDatas.DsGlobal.Tables.Contains(nomTable))
            {
                DataTable bilan = new DataTable(nomTable);
                bilan.Columns.Add("Nom de l'espèce");
                bilan.Columns.Add("Objectif initial", typeof(int));
                bilan.Columns.Add("Captures réalisées", typeof(int));
                bilan.Columns.Add("Taux de réussite (%)", typeof(string));
                MesDatas.DsGlobal.Tables.Add(bilan);
            }
            else
            {
                MesDatas.DsGlobal.Tables[nomTable].Clear();
            }

            string filtreObj = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
            DataRow[] objectifs = MesDatas.DsGlobal.Tables["ObjectifCapture"].Select(filtreObj);

            foreach (DataRow obj in objectifs)
            {
                int idEspece = Convert.ToInt32(obj["idEspeceEnnemi"]);
                int objectif = Convert.ToInt32(obj["objectif"]);

                DataRow[] espece = MesDatas.DsGlobal.Tables["Espece"].Select($"id = {idEspece}");
                string nomEspece = espece.Length > 0 ? espece[0]["nom"].ToString() : "Inconnue";

                string filtreCap = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num} AND idEspeceEnnemi = {idEspece}";
                DataRow[] captures = MesDatas.DsGlobal.Tables["Capturer"].Select(filtreCap);
                int nbCaptures = captures.Length > 0 ? Convert.ToInt32(captures[0]["nombre"]) : 0;

                string taux = objectif > 0
                    ? Math.Round((double)nbCaptures / objectif * 100, 1) + " %"
                    : "N/A";

                MesDatas.DsGlobal.Tables[nomTable].Rows.Add(nomEspece, objectif, nbCaptures, taux);
            }

        }

        private void btEditerUnPdf_Click(object sender, EventArgs e)
        {
            LancerPDF();
        }

        private void LancerPDF()
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(
                iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
            string filePath = "RapportMission.pdf";

            try
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                var fontTitre = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 14);
                var fontBold = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 11);
                var fontNormal = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10);

                // Titre
                doc.Add(new iTextSharp.text.Paragraph("Rapport de mission", fontTitre));
                doc.Add(new iTextSharp.text.Paragraph(iTextSharp.text.Chunk.NEWLINE));

                // Infos mission 
                string filtreM = $"nomPlanete = '{this.planete}' AND numero = {this.num}";
                DataRow[] rowsM = MesDatas.DsGlobal.Tables["Mission"].Select(filtreM);

                if (rowsM.Length > 0)
                {
                    DataRow mission = rowsM[0];

                    // Chef
                    DataRow[] rowsChef = MesDatas.DsGlobal.Tables["Membre"].Select(
                        $"matricule = '{mission["matriculeChef"]}'");
                    string chef = rowsChef.Length > 0
                        ? rowsChef[0]["nom"] + " " + rowsChef[0]["prenom"]
                        : "Inconnu";

                    doc.Add(new iTextSharp.text.Paragraph(
                        $"Départ le {mission["dateDepart"]}    Retour le {mission["dateRetour"]}", fontNormal));
                    doc.Add(new iTextSharp.text.Paragraph(iTextSharp.text.Chunk.NEWLINE));
                    doc.Add(new iTextSharp.text.Paragraph(
                        "Sous la responsabilité de " + chef, fontBold));
                    doc.Add(Chunk.NEWLINE);

                    // Solde
                    string filtreD = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
                    DataRow[] deps = MesDatas.DsGlobal.Tables["Depense"].Select(filtreD);
                    int totalDep = 0;
                    foreach (DataRow d in deps)
                        totalDep += Convert.ToInt32(d["montant"]);

                    int budget = Convert.ToInt32(mission["budget"]);
                    doc.Add(new iTextSharp.text.Paragraph($"Budget initial : {budget} €", fontNormal));
                    doc.Add(new iTextSharp.text.Paragraph($"Solde après dépenses : {budget - totalDep} €", fontNormal));
                    doc.Add(new iTextSharp.text.Paragraph(iTextSharp.text.Chunk.NEWLINE));
                    doc.Add(new iTextSharp.text.Paragraph("Feuille de route :", fontBold));
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new iTextSharp.text.Paragraph(mission["feuilleDeRoute"].ToString(), fontNormal));
                }

                doc.Add(new iTextSharp.text.Paragraph("\n-------------------------------------------\n"));

                // Membres 
                doc.Add(new iTextSharp.text.Paragraph("Liste des membres", fontBold));
                doc.Add(Chunk.NEWLINE);
                string filtreComp = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
                DataRow[] rowsComp = MesDatas.DsGlobal.Tables["Composer"].Select(filtreComp);
                foreach (DataRow row in rowsComp)
                {
                    DataRow[] mb = MesDatas.DsGlobal.Tables["Membre"].Select(
                        $"matricule = '{row["matriculeMembre"]}'");
                    if (mb.Length > 0)
                        doc.Add(new iTextSharp.text.Paragraph(
                            "--> " + mb[0]["nom"] + " " + mb[0]["prenom"], fontNormal));
                }

                doc.Add(new iTextSharp.text.Paragraph("\n-------------------------------------------\n"));

                // Journal de bord 
                doc.Add(new iTextSharp.text.Paragraph("Journal de bord :", fontBold));
                doc.Add(Chunk.NEWLINE);
                string filtreJdb = $"nomPlanete = '{this.planete}' AND numero = {this.num}";
                DataRow[] rowsJdb = MesDatas.DsGlobal.Tables["JournalDeBord"].Select(filtreJdb, "dateJ ASC");
                foreach (DataRow row in rowsJdb)
                    doc.Add(new iTextSharp.text.Paragraph(
                        $"Le {row["dateJ"]} --> {row["commentaires"]}", fontNormal));

                doc.Add(new iTextSharp.text.Paragraph("\n-------------------------------------------\n"));

                // Dépenses
                doc.Add(new iTextSharp.text.Paragraph("Dépenses effectuées :", fontBold));
                doc.Add(Chunk.NEWLINE);
                string filtreDep = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
                DataRow[] rowsDep = MesDatas.DsGlobal.Tables["Depense"].Select(filtreDep, "dateD ASC");
                int total = 0, i = 1;
                foreach (DataRow row in rowsDep)
                {
                    int montant = Convert.ToInt32(row["montant"]);
                    total += montant;

                    DataRow[] type = MesDatas.DsGlobal.Tables["TypeDepense"].Select(
                        $"id = {row["idTypeDepense"]}");
                    string libelle = type.Length > 0 ? type[0]["libelle"].ToString() : "";

                    doc.Add(new iTextSharp.text.Paragraph(
                        $"{i}) le {row["dateD"]} : {row["motif"]} -> {montant} € ({libelle})", fontNormal));
                    i++;
                }
                doc.Add(Chunk.NEWLINE);
                doc.Add(new iTextSharp.text.Paragraph($"Total des dépenses : {total} €", fontBold));

                doc.Add(new iTextSharp.text.Paragraph("\n-------------------------------------------\n"));

                // Contacts
                doc.Add(new iTextSharp.text.Paragraph("Contacts avec les informateurs :", fontBold));
                doc.Add(Chunk.NEWLINE);
                string filtreC = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
                DataRow[] rowsC = MesDatas.DsGlobal.Tables["Contact"].Select(filtreC, "dateC ASC");
                int totalSommes = 0;
                foreach (DataRow row in rowsC)
                {
                    int somme = Convert.ToInt32(row["sommeVersee"]);
                    totalSommes += somme;

                    DataRow[] info = MesDatas.DsGlobal.Tables["Informateur"].Select(
                        $"nomCode = '{row["nomCodeInformateur"]}'");
                    string nomInfo = info.Length > 0 ? info[0]["nom"].ToString() : "";

                    doc.Add(new iTextSharp.text.Paragraph(
                        $"Le {row["dateC"]} : rencontre avec {nomInfo} -> {somme} € ({row["appreciation"]})",
                        fontNormal));
                }
                doc.Add(Chunk.NEWLINE);
                doc.Add(new iTextSharp.text.Paragraph(

                    $"Total des sommes versées : {totalSommes} €", fontBold));

                doc.Add(new iTextSharp.text.Paragraph("\n-------------------------------------------\n"));

                // Bilan des captures
                doc.Add(new iTextSharp.text.Paragraph("Bilan des captures :", fontBold));
                doc.Add(Chunk.NEWLINE);
                string nomTable = $"BilanCapture{this.planete}{this.num}";
                if (MesDatas.DsGlobal.Tables.Contains(nomTable))
                {
                    iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(4);
                    table.WidthPercentage = 100;

                    // En-têtes
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(
                        new iTextSharp.text.Phrase("Nom de l'espèce", fontBold)));
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(
                        new iTextSharp.text.Phrase("Objectif initial", fontBold)));
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(
                        new iTextSharp.text.Phrase("Captures réalisées", fontBold)));
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(
                        new iTextSharp.text.Phrase("Taux de réussite (%)", fontBold)));

                    // Données
                    foreach (DataRow row in MesDatas.DsGlobal.Tables[nomTable].Rows)
                    {
                        table.AddCell(row["Nom de l'espèce"].ToString());
                        table.AddCell(row["Objectif initial"].ToString());
                        table.AddCell(row["Captures réalisées"].ToString());
                        table.AddCell(row["Taux de réussite (%)"].ToString());
                    }

                    doc.Add(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur PDF : " + ex.Message);
            }
            finally
            {
                doc.Close();
                MessageBox.Show("PDF généré : RapportMission.pdf dans \\bin\\Debug");
            }
        }

    }
}
