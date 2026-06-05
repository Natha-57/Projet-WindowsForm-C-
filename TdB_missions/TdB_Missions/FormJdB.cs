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
        private string planete;
        private int num;
        private DataTable dtEvenements;
        private int indexEvenement = 0;
        public FormJdB(string planete, int num)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.planete = planete;
            this.num = num;

            ChargerDepenses();
            ChargerContacts();
            ChargerEvenements();
            ChargerBilanCaptures();


            pbHome.SizeMode = PictureBoxSizeMode.CenterImage;
            pbHome.SizeMode = PictureBoxSizeMode.Zoom;
            pbHome.Image = System.Drawing.Image.FromFile("..\\..\\..\\..\\Images_App\\Icones diverses\\home.png");
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
            this.BackgroundImage = System.Drawing.Image.FromFile("../../../../Images_App/Fond étoilé - Planètes.png");

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
            // Couleurs / Thème Stargate pour le pdf
            BaseColor NOIR = new BaseColor(10, 12, 20);
            BaseColor CYAN = new BaseColor(0, 229, 255);
            BaseColor OR = new BaseColor(255, 215, 0);
            BaseColor GRIS_CLAIR = new BaseColor(180, 200, 210);
            BaseColor GRIS_FONCE = new BaseColor(30, 40, 55);
            BaseColor CYAN_DARK = new BaseColor(0, 60, 80);

            // Polices d'écriture
            iTextSharp.text.Font fTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, CYAN);
            iTextSharp.text.Font fSousTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, OR);
            iTextSharp.text.Font fBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, CYAN);
            iTextSharp.text.Font fNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9, GRIS_CLAIR);
            iTextSharp.text.Font fSmall = FontFactory.GetFont(FontFactory.HELVETICA, 8, GRIS_CLAIR);
            iTextSharp.text.Font fTableHdr = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, NOIR);

            Document doc = new Document(PageSize.A4, 30, 30, 40, 40);
            string filePath = "RapportMission.pdf";

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                writer.PageEvent = new StargatePdfPageEvent(NOIR, CYAN, OR);
                doc.Open();

                // En-tête du document
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.WidthPercentage = 100;
                headerTable.SpacingAfter = 10;

                PdfPCell titleCell = new PdfPCell();
                titleCell.BackgroundColor = NOIR;
                titleCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                titleCell.BorderColorBottom = CYAN;
                titleCell.BorderWidthBottom = 1.5f;
                titleCell.PaddingBottom = 8;

                Paragraph deco = new Paragraph("◈  ◈  ◈  STARGATE COMMAND  ◈  ◈  ◈",
                    FontFactory.GetFont(FontFactory.HELVETICA, 8, new BaseColor(0, 140, 160)));
                deco.Alignment = Element.ALIGN_CENTER;
                titleCell.AddElement(deco);

                Paragraph titreDoc = new Paragraph("RAPPORT DE MISSION", fTitre);
                titreDoc.Alignment = Element.ALIGN_CENTER;
                titleCell.AddElement(titreDoc);

                Paragraph classif = new Paragraph(
                    "CLASSIFICATION : TOP SECRET  //  SGC-INTERNAL",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 7, OR));
                classif.Alignment = Element.ALIGN_CENTER;
                titleCell.AddElement(classif);

                headerTable.AddCell(titleCell);
                doc.Add(headerTable);
                doc.Add(new Paragraph(" "));

                // Infos Mission
                string filtreM = $"nomPlanete = '{this.planete}' AND numero = {this.num}";
                DataRow[] rowsM = MesDatas.DsGlobal.Tables["Mission"].Select(filtreM);

                if (rowsM.Length > 0)
                {
                    DataRow mission = rowsM[0];

                    DataRow[] rowsChef = MesDatas.DsGlobal.Tables["Membre"].Select(
                        $"matricule = '{mission["matriculeChef"]}'");
                    string chef = rowsChef.Length > 0
                        ? rowsChef[0]["nom"] + " " + rowsChef[0]["prenom"]
                        : "Inconnu";

                    PdfPTable infoTbl = new PdfPTable(new float[] { 1f, 2f });
                    infoTbl.WidthPercentage = 100;
                    infoTbl.SpacingAfter = 8;

                    Action<string, string> addInfoRow = (label, value) =>
                    {
                        PdfPCell lbl = new PdfPCell(new Phrase(label, fBold));
                        lbl.BackgroundColor = GRIS_FONCE;
                        lbl.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                        lbl.BorderColorLeft = CYAN;
                        lbl.BorderWidthLeft = 2f;
                        lbl.PaddingLeft = 6; lbl.PaddingTop = 4; lbl.PaddingBottom = 4;

                        PdfPCell val = new PdfPCell(new Phrase(value, fNormal));
                        val.BackgroundColor = NOIR;
                        val.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        val.PaddingLeft = 6; val.PaddingTop = 4; val.PaddingBottom = 4;

                        infoTbl.AddCell(lbl);
                        infoTbl.AddCell(val);
                    };

                    addInfoRow("PLANÈTE CIBLE", this.planete.ToUpper());
                    addInfoRow("N° MISSION", this.num.ToString());
                    addInfoRow("DÉPART", mission["dateDepart"].ToString());
                    addInfoRow("RETOUR", mission["dateRetour"].ToString());
                    addInfoRow("COMMANDANT", chef.ToUpper());

                    string filtreD = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
                    DataRow[] deps = MesDatas.DsGlobal.Tables["Depense"].Select(filtreD);
                    int totalDep = 0;
                    foreach (DataRow d in deps) totalDep += Convert.ToInt32(d["montant"]);
                    int budget = Convert.ToInt32(mission["budget"]);
                    int solde = budget - totalDep;

                    addInfoRow("BUDGET INITIAL", $"{budget} crédits");
                    addInfoRow("SOLDE APRÈS DÉPENSES", $"{solde} crédits");

                    doc.Add(infoTbl);

                    doc.Add(SectionHeader("▶  FEUILLE DE ROUTE", fSousTitre, CYAN));
                    PdfPTable frTbl = new PdfPTable(1);
                    frTbl.WidthPercentage = 100;
                    frTbl.SpacingAfter = 12;
                    PdfPCell frCell = new PdfPCell(new Phrase(mission["feuilleDeRoute"].ToString(), fNormal));
                    frCell.BackgroundColor = GRIS_FONCE;
                    frCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    frCell.BorderColorLeft = CYAN;
                    frCell.BorderWidthLeft = 3f;
                    frCell.Padding = 8;
                    frTbl.AddCell(frCell);
                    doc.Add(frTbl);
                }

                // Membres
                doc.Add(SectionHeader("▶  ÉQUIPE EN MISSION", fSousTitre, CYAN));

                string filtreComp = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
                DataRow[] rowsComp = MesDatas.DsGlobal.Tables["Composer"].Select(filtreComp);

                PdfPTable memTbl = new PdfPTable(new float[] { 0.3f, 1f });
                memTbl.WidthPercentage = 100;
                memTbl.SpacingAfter = 12;

                PdfPCell mhNum = new PdfPCell(new Phrase("#", fTableHdr));
                PdfPCell mhName = new PdfPCell(new Phrase("MEMBRE", fTableHdr));
                foreach (var c in new[] { mhNum, mhName })
                {
                    c.BackgroundColor = CYAN_DARK;
                    c.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    c.BorderColorBottom = CYAN;
                    c.BorderWidthBottom = 1.5f;
                    c.HorizontalAlignment = Element.ALIGN_CENTER;
                    c.Padding = 5;
                }
                memTbl.AddCell(mhNum);
                memTbl.AddCell(mhName);

                int idx = 1;
                foreach (DataRow row in rowsComp)
                {
                    DataRow[] mb = MesDatas.DsGlobal.Tables["Membre"].Select(
                        $"matricule = '{row["matriculeMembre"]}'");
                    if (mb.Length > 0)
                    {
                        bool pair = idx % 2 == 0;
                        BaseColor bg = pair ? GRIS_FONCE : NOIR;

                        PdfPCell cNum = new PdfPCell(new Phrase(idx.ToString(), fSmall));
                        PdfPCell cName = new PdfPCell(new Phrase(
                            mb[0]["nom"] + " " + mb[0]["prenom"], fNormal));

                        foreach (var c in new[] { cNum, cName })
                        {
                            c.BackgroundColor = bg;
                            c.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            c.PaddingLeft = 8; c.PaddingTop = 4; c.PaddingBottom = 4;
                        }
                        cNum.HorizontalAlignment = Element.ALIGN_CENTER;
                        memTbl.AddCell(cNum);
                        memTbl.AddCell(cName);
                        idx++;
                    }
                }
                doc.Add(memTbl);

                // Journal de bord
                doc.Add(SectionHeader("▶  JOURNAL DE BORD", fSousTitre, CYAN));

                string filtreJdb = $"nomPlanete = '{this.planete}' AND numero = {this.num}";
                DataRow[] rowsJdb = MesDatas.DsGlobal.Tables["JournalDeBord"].Select(filtreJdb, "dateJ ASC");

                PdfPTable jdbTbl = new PdfPTable(new float[] { 1f, 3f });
                jdbTbl.WidthPercentage = 100;
                jdbTbl.SpacingAfter = 12;
                AddTableHeader(jdbTbl, new[] { "DATE", "ENTRÉE DE JOURNAL" }, fTableHdr, CYAN_DARK, CYAN);

                idx = 1;
                foreach (DataRow row in rowsJdb)
                {
                    bool pair = idx % 2 == 0;
                    BaseColor bg = pair ? GRIS_FONCE : NOIR;

                    PdfPCell cDate = new PdfPCell(new Phrase(row["dateJ"].ToString(), fSmall));
                    PdfPCell cText = new PdfPCell(new Phrase(row["commentaires"].ToString(), fNormal));
                    foreach (var c in new[] { cDate, cText })
                    {
                        c.BackgroundColor = bg;
                        c.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        c.PaddingLeft = 8; c.PaddingTop = 4; c.PaddingBottom = 4;
                    }
                    jdbTbl.AddCell(cDate);
                    jdbTbl.AddCell(cText);
                    idx++;
                }
                doc.Add(jdbTbl);

                // Dépenses
                doc.Add(SectionHeader("▶  DÉPENSES EFFECTUÉES", fSousTitre, CYAN));

                string filtreDep = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
                DataRow[] rowsDep = MesDatas.DsGlobal.Tables["Depense"].Select(filtreDep, "dateD ASC");

                PdfPTable depTbl = new PdfPTable(new float[] { 0.4f, 1f, 2f, 0.8f, 1f });
                depTbl.WidthPercentage = 100;
                depTbl.SpacingAfter = 4;
                AddTableHeader(depTbl,
                    new[] { "#", "DATE", "MOTIF", "MONTANT", "TYPE" },
                    fTableHdr, CYAN_DARK, CYAN);

                int total = 0; idx = 1;
                foreach (DataRow row in rowsDep)
                {
                    int montant = Convert.ToInt32(row["montant"]);
                    total += montant;
                    DataRow[] type = MesDatas.DsGlobal.Tables["TypeDepense"].Select(
                        $"id = {row["idTypeDepense"]}");
                    string libelle = type.Length > 0 ? type[0]["libelle"].ToString() : "";

                    bool pair = idx % 2 == 0;
                    BaseColor bg = pair ? GRIS_FONCE : NOIR;
                    foreach (string txt in new[] {
                        idx.ToString(), row["dateD"].ToString(),
                        row["motif"].ToString(), montant + " €", libelle })
                    {
                        PdfPCell c = new PdfPCell(new Phrase(txt, fSmall));
                        c.BackgroundColor = bg;
                        c.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        c.PaddingLeft = 6; c.PaddingTop = 3; c.PaddingBottom = 3;
                        depTbl.AddCell(c);
                    }
                    idx++;
                }
                doc.Add(depTbl);

                PdfPTable totDepTbl = new PdfPTable(1);
                totDepTbl.WidthPercentage = 100;
                totDepTbl.SpacingAfter = 12;
                PdfPCell totDepCell = new PdfPCell(new Phrase($"TOTAL DES DÉPENSES : {total} €", fBold));
                totDepCell.BackgroundColor = CYAN_DARK;
                totDepCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                totDepCell.BorderColorBottom = CYAN;
                totDepCell.BorderWidthBottom = 1.5f;
                totDepCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                totDepCell.Padding = 5;
                totDepTbl.AddCell(totDepCell);
                doc.Add(totDepTbl);

                // Contacts
                doc.Add(SectionHeader("▶  CONTACTS – INFORMATEURS", fSousTitre, CYAN));

                string filtreC = $"nomPlanete = '{this.planete}' AND numeroMission = {this.num}";
                DataRow[] rowsC = MesDatas.DsGlobal.Tables["Contact"].Select(filtreC, "dateC ASC");

                PdfPTable cntTbl = new PdfPTable(new float[] { 0.8f, 1.5f, 0.8f, 1f });
                cntTbl.WidthPercentage = 100;
                cntTbl.SpacingAfter = 4;
                AddTableHeader(cntTbl,
                    new[] { "DATE", "INFORMATEUR", "SOMME", "APPRÉCIATION" },
                    fTableHdr, CYAN_DARK, CYAN);

                int totalSommes = 0; idx = 1;
                foreach (DataRow row in rowsC)
                {
                    int somme = Convert.ToInt32(row["sommeVersee"]);
                    totalSommes += somme;
                    DataRow[] info = MesDatas.DsGlobal.Tables["Informateur"].Select(
                        $"nomCode = '{row["nomCodeInformateur"]}'");
                    string nomInfo = info.Length > 0 ? info[0]["nom"].ToString() : "";

                    bool pair = idx % 2 == 0;
                    BaseColor bg = pair ? GRIS_FONCE : NOIR;
                    foreach (string txt in new[] {
                        row["dateC"].ToString(), nomInfo,
                        somme + " €", row["appreciation"].ToString() })
                    {
                        PdfPCell c = new PdfPCell(new Phrase(txt, fSmall));
                        c.BackgroundColor = bg;
                        c.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        c.PaddingLeft = 6; c.PaddingTop = 3; c.PaddingBottom = 3;
                        cntTbl.AddCell(c);
                    }
                    idx++;
                }
                doc.Add(cntTbl);

                PdfPTable totCntTbl = new PdfPTable(1);
                totCntTbl.WidthPercentage = 100;
                totCntTbl.SpacingAfter = 12;
                PdfPCell totCntCell = new PdfPCell(new Phrase($"TOTAL SOMMES VERSÉES : {totalSommes} €", fBold));
                totCntCell.BackgroundColor = CYAN_DARK;
                totCntCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                totCntCell.BorderColorBottom = CYAN;
                totCntCell.BorderWidthBottom = 1.5f;
                totCntCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                totCntCell.Padding = 5;
                totCntTbl.AddCell(totCntCell);
                doc.Add(totCntTbl);

                // Bilan des captures
                doc.Add(SectionHeader("▶  BILAN DES CAPTURES", fSousTitre, CYAN));

                string nomTable = $"BilanCapture{this.planete}{this.num}";
                if (MesDatas.DsGlobal.Tables.Contains(nomTable))
                {
                    PdfPTable capTbl = new PdfPTable(4);
                    capTbl.WidthPercentage = 100;
                    capTbl.SpacingAfter = 12;
                    AddTableHeader(capTbl,
                        new[] { "ESPÈCE", "OBJECTIF INITIAL", "CAPTURES RÉALISÉES", "TAUX DE RÉUSSITE (%)" },
                        fTableHdr, CYAN_DARK, CYAN);

                    idx = 1;
                    foreach (DataRow row in MesDatas.DsGlobal.Tables[nomTable].Rows)
                    {
                        bool pair = idx % 2 == 0;
                        BaseColor bg = pair ? GRIS_FONCE : NOIR;

                        string tauxStr = row["Taux de réussite (%)"].ToString();
                        float taux = 0;
                        float.TryParse(tauxStr, out taux);
                        BaseColor tauxColor = taux >= 80 ? new BaseColor(0, 200, 100)
                                            : taux >= 50 ? OR
                                            : new BaseColor(220, 60, 60);

                        var colonnes = new (string txt, bool isLast)[]
                        {
                            (row["Nom de l'espèce"].ToString(),    false),
                            (row["Objectif initial"].ToString(),    false),
                            (row["Captures réalisées"].ToString(), false),
                            (tauxStr,                               true)
                        };

                        foreach (var col in colonnes)
                        {
                            iTextSharp.text.Font f = col.isLast
                                ? FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, tauxColor)
                                : fSmall;
                            PdfPCell c = new PdfPCell(new Phrase(col.txt, f));
                            c.BackgroundColor = bg;
                            c.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            c.PaddingLeft = 6; c.PaddingTop = 3; c.PaddingBottom = 3;
                            c.HorizontalAlignment = Element.ALIGN_CENTER;
                            capTbl.AddCell(c);
                        }
                        idx++;
                    }
                    doc.Add(capTbl);
                }

                // Pied de page final
                PdfPTable footTbl = new PdfPTable(1);
                footTbl.WidthPercentage = 100;
                PdfPCell footCell = new PdfPCell(new Phrase(
                    "◈  FIN DU RAPPORT  ◈  SGC – DOCUMENT CLASSIFIÉ  ◈",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, new BaseColor(0, 140, 160))));
                footCell.BackgroundColor = NOIR;
                footCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                footCell.BorderColorTop = CYAN;
                footCell.BorderWidthTop = 1f;
                footCell.HorizontalAlignment = Element.ALIGN_CENTER;
                footCell.PaddingTop = 6;
                footTbl.AddCell(footCell);
                doc.Add(footTbl);
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

        // Esthétique : barre colorée + fond sombre pour les titres de sections

        private static PdfPTable SectionHeader(string texte, iTextSharp.text.Font font, BaseColor couleurBarre)
        {
            PdfPTable t = new PdfPTable(1);
            t.WidthPercentage = 100;
            t.SpacingBefore = 10;
            t.SpacingAfter = 4;

            PdfPCell cell = new PdfPCell(new Phrase(texte, font));
            cell.BackgroundColor = new BaseColor(20, 30, 45);
            cell.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER;
            cell.BorderColorLeft = couleurBarre;
            cell.BorderWidthLeft = 4f;
            cell.BorderColorBottom = couleurBarre;
            cell.BorderWidthBottom = 0.5f;
            cell.PaddingLeft = 8;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            t.AddCell(cell);
            return t;
        }

        private static void AddTableHeader(
            PdfPTable table, string[] headers,
            iTextSharp.text.Font font, BaseColor bgColor, BaseColor borderColor)
        {
            foreach (string h in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(h, font));
                cell.BackgroundColor = bgColor;
                cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                cell.BorderColorBottom = borderColor;
                cell.BorderWidthBottom = 1.5f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 5;
                table.AddCell(cell);
            }
        }

        // Esthétique : fond sombre + bordure cyan + coins décorés en or + pied de page avec numéro de page et classification

        public class StargatePdfPageEvent : PdfPageEventHelper
        {
            private readonly BaseColor _fondNoir;
            private readonly BaseColor _cyan;
            private readonly BaseColor _or;

            public StargatePdfPageEvent(BaseColor fondNoir, BaseColor cyan, BaseColor or)
            {
                _fondNoir = fondNoir;
                _cyan = cyan;
                _or = or;
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfContentByte cb = writer.DirectContentUnder;

                cb.SetColorFill(_fondNoir);
                cb.Rectangle(0, 0, document.PageSize.Width, document.PageSize.Height);
                cb.Fill();

                cb.SetColorStroke(_cyan);
                cb.SetLineWidth(1.2f);
                cb.Rectangle(15, 15, document.PageSize.Width - 30, document.PageSize.Height - 30);
                cb.Stroke();

                DrawCorner(cb, 15, 15, _or, 0);
                DrawCorner(cb, document.PageSize.Width - 15, 15, _or, 90);
                DrawCorner(cb, document.PageSize.Width - 15, document.PageSize.Height - 15, _or, 180);
                DrawCorner(cb, 15, document.PageSize.Height - 15, _or, 270);

                cb.BeginText();
                cb.SetColorFill(_cyan);
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false), 7);
                string pageNum = $"PAGE {writer.PageNumber}  //  CONFIDENTIEL SGC";
                cb.ShowTextAligned(Element.ALIGN_CENTER, pageNum, document.PageSize.Width / 2, 20, 0);
                cb.EndText();
            }

            private static void DrawCorner(
                PdfContentByte cb, float x, float y, BaseColor color, float angle)
            {
                cb.SaveState();
                cb.SetColorStroke(color);
                cb.SetLineWidth(1.5f);
                cb.ConcatCTM(
                    (float)Math.Cos(angle * Math.PI / 180),
                   -(float)Math.Sin(angle * Math.PI / 180),
                    (float)Math.Sin(angle * Math.PI / 180),
                    (float)Math.Cos(angle * Math.PI / 180),
                    x, y);
                cb.MoveTo(0, 0); cb.LineTo(12, 0);
                cb.MoveTo(0, 0); cb.LineTo(0, 12);
                cb.Stroke();
                cb.RestoreState();
            }
        }
    }
}