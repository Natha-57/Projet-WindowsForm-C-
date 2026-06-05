namespace _2__Creation_De_Mission
{
    partial class FormCreationMission
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btValiderDates = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFeuilleDeRoute = new System.Windows.Forms.RichTextBox();
            this.lstMembres = new System.Windows.Forms.ListBox();
            this.lstObj = new System.Windows.Forms.ListBox();
            this.btValiderObjCapture = new System.Windows.Forms.Button();
            this.btAjtObjCapture = new System.Windows.Forms.Button();
            this.txtNbAliens = new System.Windows.Forms.TextBox();
            this.cboAliens = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btValdierMembres = new System.Windows.Forms.Button();
            this.btAjtMembres = new System.Windows.Forms.Button();
            this.cboAjtMembre = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblNomMission = new System.Windows.Forms.Label();
            this.btValiderLaMission = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimeRetour = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDepart = new System.Windows.Forms.DateTimePicker();
            this.cboChefDeMission = new System.Windows.Forms.ComboBox();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.txtObjDataBaz = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNbMembres = new System.Windows.Forms.TextBox();
            this.cboNomPlanete = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlMission = new System.Windows.Forms.TabControl();
            this.Initialisation = new System.Windows.Forms.TabPage();
            this.Paramètres = new System.Windows.Forms.TabPage();
            this.Affectation = new System.Windows.Forms.TabPage();
            this.Objectifs = new System.Windows.Forms.TabPage();
            this.tabControlMission.SuspendLayout();
            this.Initialisation.SuspendLayout();
            this.Paramètres.SuspendLayout();
            this.Affectation.SuspendLayout();
            this.Objectifs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btValiderDates
            // 
            this.btValiderDates.Location = new System.Drawing.Point(471, 590);
            this.btValiderDates.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btValiderDates.Name = "btValiderDates";
            this.btValiderDates.Size = new System.Drawing.Size(291, 109);
            this.btValiderDates.TabIndex = 39;
            this.btValiderDates.Text = "Page Suivante ->";
            this.btValiderDates.UseVisualStyleBackColor = true;
            this.btValiderDates.Click += new System.EventHandler(this.btValiderDates_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(151, 144);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(282, 46);
            this.label16.TabIndex = 38;
            this.label16.Text = "Chef de mission";
            // 
            // txtFeuilleDeRoute
            // 
            this.txtFeuilleDeRoute.Location = new System.Drawing.Point(159, 361);
            this.txtFeuilleDeRoute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFeuilleDeRoute.Name = "txtFeuilleDeRoute";
            this.txtFeuilleDeRoute.Size = new System.Drawing.Size(602, 113);
            this.txtFeuilleDeRoute.TabIndex = 37;
            this.txtFeuilleDeRoute.Text = "";
            // 
            // lstMembres
            // 
            this.lstMembres.FormattingEnabled = true;
            this.lstMembres.ItemHeight = 46;
            this.lstMembres.Location = new System.Drawing.Point(77, 237);
            this.lstMembres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstMembres.Name = "lstMembres";
            this.lstMembres.Size = new System.Drawing.Size(714, 372);
            this.lstMembres.TabIndex = 36;
            this.lstMembres.SelectedIndexChanged += new System.EventHandler(this.lstMembres_SelectedIndexChanged);
            // 
            // lstObj
            // 
            this.lstObj.FormattingEnabled = true;
            this.lstObj.ItemHeight = 46;
            this.lstObj.Location = new System.Drawing.Point(77, 228);
            this.lstObj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstObj.Name = "lstObj";
            this.lstObj.Size = new System.Drawing.Size(714, 372);
            this.lstObj.TabIndex = 35;
            this.lstObj.SelectedIndexChanged += new System.EventHandler(this.lstObj_SelectedIndexChanged);
            // 
            // btValiderObjCapture
            // 
            this.btValiderObjCapture.Location = new System.Drawing.Point(500, 648);
            this.btValiderObjCapture.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btValiderObjCapture.Name = "btValiderObjCapture";
            this.btValiderObjCapture.Size = new System.Drawing.Size(291, 109);
            this.btValiderObjCapture.TabIndex = 34;
            this.btValiderObjCapture.Text = "Valider la Mission";
            this.btValiderObjCapture.UseVisualStyleBackColor = true;
            this.btValiderObjCapture.Click += new System.EventHandler(this.btValiderObjCapture_Click);
            // 
            // btAjtObjCapture
            // 
            this.btAjtObjCapture.Location = new System.Drawing.Point(626, 125);
            this.btAjtObjCapture.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btAjtObjCapture.Name = "btAjtObjCapture";
            this.btAjtObjCapture.Size = new System.Drawing.Size(165, 54);
            this.btAjtObjCapture.TabIndex = 32;
            this.btAjtObjCapture.Text = "Ajouter";
            this.btAjtObjCapture.UseVisualStyleBackColor = true;
            this.btAjtObjCapture.Click += new System.EventHandler(this.btAjtObjCapture_Click);
            // 
            // txtNbAliens
            // 
            this.txtNbAliens.Location = new System.Drawing.Point(489, 125);
            this.txtNbAliens.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtNbAliens.Name = "txtNbAliens";
            this.txtNbAliens.Size = new System.Drawing.Size(96, 50);
            this.txtNbAliens.TabIndex = 31;
            this.txtNbAliens.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNbAliens_KeyPress);
            // 
            // cboAliens
            // 
            this.cboAliens.FormattingEnabled = true;
            this.cboAliens.Location = new System.Drawing.Point(77, 125);
            this.cboAliens.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboAliens.Name = "cboAliens";
            this.cboAliens.Size = new System.Drawing.Size(360, 54);
            this.cboAliens.TabIndex = 30;
            this.cboAliens.SelectedIndexChanged += new System.EventHandler(this.cboAliens_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 19);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(433, 46);
            this.label15.TabIndex = 29;
            this.label15.Text = "5 - Objectifs de captures";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // btValdierMembres
            // 
            this.btValdierMembres.Location = new System.Drawing.Point(500, 673);
            this.btValdierMembres.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btValdierMembres.Name = "btValdierMembres";
            this.btValdierMembres.Size = new System.Drawing.Size(291, 109);
            this.btValdierMembres.TabIndex = 28;
            this.btValdierMembres.Text = "Page Suivante ->";
            this.btValdierMembres.UseVisualStyleBackColor = true;
            this.btValdierMembres.Click += new System.EventHandler(this.btValdierMembres_Click);
            // 
            // btAjtMembres
            // 
            this.btAjtMembres.Location = new System.Drawing.Point(626, 125);
            this.btAjtMembres.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btAjtMembres.Name = "btAjtMembres";
            this.btAjtMembres.Size = new System.Drawing.Size(165, 54);
            this.btAjtMembres.TabIndex = 26;
            this.btAjtMembres.Text = "Ajouter";
            this.btAjtMembres.UseVisualStyleBackColor = true;
            this.btAjtMembres.Click += new System.EventHandler(this.btAjtMembres_Click);
            // 
            // cboAjtMembre
            // 
            this.cboAjtMembre.FormattingEnabled = true;
            this.cboAjtMembre.Location = new System.Drawing.Point(77, 125);
            this.cboAjtMembre.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboAjtMembre.Name = "cboAjtMembre";
            this.cboAjtMembre.Size = new System.Drawing.Size(500, 54);
            this.cboAjtMembre.TabIndex = 25;
            this.cboAjtMembre.SelectedIndexChanged += new System.EventHandler(this.cboAjtMembre_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 15);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(491, 46);
            this.label14.TabIndex = 24;
            this.label14.Text = "4 - Affectation des membres";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // lblNomMission
            // 
            this.lblNomMission.AutoSize = true;
            this.lblNomMission.Location = new System.Drawing.Point(151, 144);
            this.lblNomMission.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomMission.Name = "lblNomMission";
            this.lblNomMission.Size = new System.Drawing.Size(213, 46);
            this.lblNomMission.TabIndex = 23;
            this.lblNomMission.Text = "NomMission";
            // 
            // btValiderLaMission
            // 
            this.btValiderLaMission.Location = new System.Drawing.Point(470, 812);
            this.btValiderLaMission.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btValiderLaMission.Name = "btValiderLaMission";
            this.btValiderLaMission.Size = new System.Drawing.Size(291, 109);
            this.btValiderLaMission.TabIndex = 22;
            this.btValiderLaMission.Text = "Page Suivante ->";
            this.btValiderLaMission.UseVisualStyleBackColor = true;
            this.btValiderLaMission.Click += new System.EventHandler(this.btValiderLaMission_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(652, 712);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 46);
            this.label13.TabIndex = 21;
            this.label13.Text = "€";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(604, 635);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 46);
            this.label12.TabIndex = 20;
            this.label12.Text = "tonnes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(603, 535);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(185, 46);
            this.label11.TabIndex = 19;
            this.label11.Text = "personnes";
            // 
            // dateTimeRetour
            // 
            this.dateTimeRetour.Location = new System.Drawing.Point(471, 460);
            this.dateTimeRetour.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dateTimeRetour.Name = "dateTimeRetour";
            this.dateTimeRetour.Size = new System.Drawing.Size(291, 50);
            this.dateTimeRetour.TabIndex = 17;
            // 
            // dateTimeDepart
            // 
            this.dateTimeDepart.Location = new System.Drawing.Point(471, 375);
            this.dateTimeDepart.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dateTimeDepart.Name = "dateTimeDepart";
            this.dateTimeDepart.Size = new System.Drawing.Size(291, 50);
            this.dateTimeDepart.TabIndex = 16;
            // 
            // cboChefDeMission
            // 
            this.cboChefDeMission.FormattingEnabled = true;
            this.cboChefDeMission.Location = new System.Drawing.Point(473, 141);
            this.cboChefDeMission.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboChefDeMission.Name = "cboChefDeMission";
            this.cboChefDeMission.Size = new System.Drawing.Size(288, 54);
            this.cboChefDeMission.TabIndex = 15;
            this.cboChefDeMission.SelectedIndexChanged += new System.EventHandler(this.cboChefDeMission_SelectedIndexChanged);
            // 
            // txtBudget
            // 
            this.txtBudget.Location = new System.Drawing.Point(473, 709);
            this.txtBudget.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(159, 50);
            this.txtBudget.TabIndex = 14;
            this.txtBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBudget_KeyPress);
            // 
            // txtObjDataBaz
            // 
            this.txtObjDataBaz.Location = new System.Drawing.Point(532, 628);
            this.txtObjDataBaz.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtObjDataBaz.Name = "txtObjDataBaz";
            this.txtObjDataBaz.Size = new System.Drawing.Size(63, 50);
            this.txtObjDataBaz.TabIndex = 13;
            this.txtObjDataBaz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObjDataBaz_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(154, 709);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 46);
            this.label9.TabIndex = 11;
            this.label9.Text = "Budget";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 627);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(292, 46);
            this.label8.TabIndex = 10;
            this.label8.Text = "ObjectifDataBaz";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 537);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(313, 46);
            this.label7.TabIndex = 9;
            this.label7.Text = "Nombre membres";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 269);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(284, 46);
            this.label6.TabIndex = 8;
            this.label6.Text = "Feuille de route";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 460);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 46);
            this.label5.TabIndex = 7;
            this.label5.Text = "Date Retour";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 375);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 46);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date Départ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(488, 46);
            this.label3.TabIndex = 5;
            this.label3.Text = "3 - Paramètres de la mission";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 265);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "2 - Choix des dates";
            // 
            // txtNbMembres
            // 
            this.txtNbMembres.Location = new System.Drawing.Point(532, 537);
            this.txtNbMembres.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtNbMembres.Name = "txtNbMembres";
            this.txtNbMembres.Size = new System.Drawing.Size(63, 50);
            this.txtNbMembres.TabIndex = 3;
            this.txtNbMembres.TextChanged += new System.EventHandler(this.txtNbMembres_TextChanged);
            this.txtNbMembres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNbMembres_KeyPress);
            // 
            // cboNomPlanete
            // 
            this.cboNomPlanete.FormattingEnabled = true;
            this.cboNomPlanete.Location = new System.Drawing.Point(471, 13);
            this.cboNomPlanete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboNomPlanete.Name = "cboNomPlanete";
            this.cboNomPlanete.Size = new System.Drawing.Size(291, 54);
            this.cboNomPlanete.TabIndex = 1;
            this.cboNomPlanete.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "1- Choix de la planète";
            // 
            // tabControlMission
            // 
            this.tabControlMission.Controls.Add(this.Initialisation);
            this.tabControlMission.Controls.Add(this.Paramètres);
            this.tabControlMission.Controls.Add(this.Affectation);
            this.tabControlMission.Controls.Add(this.Objectifs);
            this.tabControlMission.Location = new System.Drawing.Point(11, 11);
            this.tabControlMission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControlMission.Name = "tabControlMission";
            this.tabControlMission.SelectedIndex = 0;
            this.tabControlMission.Size = new System.Drawing.Size(858, 1017);
            this.tabControlMission.TabIndex = 1;
            // 
            // Initialisation
            // 
            this.Initialisation.Controls.Add(this.btValiderDates);
            this.Initialisation.Controls.Add(this.label1);
            this.Initialisation.Controls.Add(this.cboNomPlanete);
            this.Initialisation.Controls.Add(this.lblNomMission);
            this.Initialisation.Controls.Add(this.label2);
            this.Initialisation.Controls.Add(this.label4);
            this.Initialisation.Controls.Add(this.label5);
            this.Initialisation.Controls.Add(this.dateTimeDepart);
            this.Initialisation.Controls.Add(this.dateTimeRetour);
            this.Initialisation.Location = new System.Drawing.Point(8, 60);
            this.Initialisation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Initialisation.Name = "Initialisation";
            this.Initialisation.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Initialisation.Size = new System.Drawing.Size(842, 949);
            this.Initialisation.TabIndex = 0;
            this.Initialisation.Text = "Initialisation";
            this.Initialisation.UseVisualStyleBackColor = true;
            // 
            // Paramètres
            // 
            this.Paramètres.Controls.Add(this.txtFeuilleDeRoute);
            this.Paramètres.Controls.Add(this.label16);
            this.Paramètres.Controls.Add(this.label3);
            this.Paramètres.Controls.Add(this.cboChefDeMission);
            this.Paramètres.Controls.Add(this.label6);
            this.Paramètres.Controls.Add(this.label7);
            this.Paramètres.Controls.Add(this.txtNbMembres);
            this.Paramètres.Controls.Add(this.label11);
            this.Paramètres.Controls.Add(this.label8);
            this.Paramètres.Controls.Add(this.txtObjDataBaz);
            this.Paramètres.Controls.Add(this.label12);
            this.Paramètres.Controls.Add(this.btValiderLaMission);
            this.Paramètres.Controls.Add(this.label9);
            this.Paramètres.Controls.Add(this.label13);
            this.Paramètres.Controls.Add(this.txtBudget);
            this.Paramètres.Location = new System.Drawing.Point(8, 60);
            this.Paramètres.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Paramètres.Name = "Paramètres";
            this.Paramètres.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Paramètres.Size = new System.Drawing.Size(842, 949);
            this.Paramètres.TabIndex = 1;
            this.Paramètres.Text = "Paramètres";
            this.Paramètres.UseVisualStyleBackColor = true;
            // 
            // Affectation
            // 
            this.Affectation.Controls.Add(this.lstMembres);
            this.Affectation.Controls.Add(this.label14);
            this.Affectation.Controls.Add(this.cboAjtMembre);
            this.Affectation.Controls.Add(this.btAjtMembres);
            this.Affectation.Controls.Add(this.btValdierMembres);
            this.Affectation.Location = new System.Drawing.Point(8, 60);
            this.Affectation.Name = "Affectation";
            this.Affectation.Padding = new System.Windows.Forms.Padding(3);
            this.Affectation.Size = new System.Drawing.Size(842, 949);
            this.Affectation.TabIndex = 2;
            this.Affectation.Text = "Affectation";
            this.Affectation.UseVisualStyleBackColor = true;
            // 
            // Objectifs
            // 
            this.Objectifs.Controls.Add(this.btValiderObjCapture);
            this.Objectifs.Controls.Add(this.lstObj);
            this.Objectifs.Controls.Add(this.label15);
            this.Objectifs.Controls.Add(this.cboAliens);
            this.Objectifs.Controls.Add(this.btAjtObjCapture);
            this.Objectifs.Controls.Add(this.txtNbAliens);
            this.Objectifs.Location = new System.Drawing.Point(8, 60);
            this.Objectifs.Name = "Objectifs";
            this.Objectifs.Padding = new System.Windows.Forms.Padding(3);
            this.Objectifs.Size = new System.Drawing.Size(842, 949);
            this.Objectifs.TabIndex = 3;
            this.Objectifs.Text = "Objectifs";
            this.Objectifs.UseVisualStyleBackColor = true;
            // 
            // FormCreationMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 1033);
            this.Controls.Add(this.tabControlMission);
            this.Font = new System.Drawing.Font("Trebuchet MS", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "FormCreationMission";
            this.Text = "Création d\'une nouvelle mission";
            this.Load += new System.EventHandler(this.FormCreationMission_Load);
            this.tabControlMission.ResumeLayout(false);
            this.Initialisation.ResumeLayout(false);
            this.Initialisation.PerformLayout();
            this.Paramètres.ResumeLayout(false);
            this.Paramètres.PerformLayout();
            this.Affectation.ResumeLayout(false);
            this.Affectation.PerformLayout();
            this.Objectifs.ResumeLayout(false);
            this.Objectifs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNbMembres;
        private System.Windows.Forms.ComboBox cboNomPlanete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeRetour;
        private System.Windows.Forms.DateTimePicker dateTimeDepart;
        private System.Windows.Forms.ComboBox cboChefDeMission;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.TextBox txtObjDataBaz;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btValiderLaMission;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNomMission;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboAjtMembre;
        private System.Windows.Forms.Button btValdierMembres;
        private System.Windows.Forms.Button btAjtMembres;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNbAliens;
        private System.Windows.Forms.ComboBox cboAliens;
        private System.Windows.Forms.Button btAjtObjCapture;
        private System.Windows.Forms.Button btValiderObjCapture;
        private System.Windows.Forms.ListBox lstObj;
        private System.Windows.Forms.ListBox lstMembres;
        private System.Windows.Forms.RichTextBox txtFeuilleDeRoute;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btValiderDates;
        private System.Windows.Forms.TabControl tabControlMission;
        private System.Windows.Forms.TabPage Initialisation;
        private System.Windows.Forms.TabPage Paramètres;
        private System.Windows.Forms.TabPage Affectation;
        private System.Windows.Forms.TabPage Objectifs;
    }
}

