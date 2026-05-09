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
            this.grpNouvelleMission = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNomPlanete = new System.Windows.Forms.ComboBox();
            this.btValiderPlanete = new System.Windows.Forms.Button();
            this.txtNbMembres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObjDataBaz = new System.Windows.Forms.TextBox();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.cboChefDeMission = new System.Windows.Forms.ComboBox();
            this.dateTimeDepart = new System.Windows.Forms.DateTimePicker();
            this.dateTimeRetour = new System.Windows.Forms.DateTimePicker();
            this.txtFeuilleDeRoute = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btValiderLaMission = new System.Windows.Forms.Button();
            this.lblNomMission = new System.Windows.Forms.Label();
            this.grpNouvelleMission.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNouvelleMission
            // 
            this.grpNouvelleMission.Controls.Add(this.lblNomMission);
            this.grpNouvelleMission.Controls.Add(this.btValiderLaMission);
            this.grpNouvelleMission.Controls.Add(this.label13);
            this.grpNouvelleMission.Controls.Add(this.label12);
            this.grpNouvelleMission.Controls.Add(this.label11);
            this.grpNouvelleMission.Controls.Add(this.txtFeuilleDeRoute);
            this.grpNouvelleMission.Controls.Add(this.dateTimeRetour);
            this.grpNouvelleMission.Controls.Add(this.dateTimeDepart);
            this.grpNouvelleMission.Controls.Add(this.cboChefDeMission);
            this.grpNouvelleMission.Controls.Add(this.txtBudget);
            this.grpNouvelleMission.Controls.Add(this.txtObjDataBaz);
            this.grpNouvelleMission.Controls.Add(this.label10);
            this.grpNouvelleMission.Controls.Add(this.label9);
            this.grpNouvelleMission.Controls.Add(this.label8);
            this.grpNouvelleMission.Controls.Add(this.label7);
            this.grpNouvelleMission.Controls.Add(this.label6);
            this.grpNouvelleMission.Controls.Add(this.label5);
            this.grpNouvelleMission.Controls.Add(this.label4);
            this.grpNouvelleMission.Controls.Add(this.label3);
            this.grpNouvelleMission.Controls.Add(this.label2);
            this.grpNouvelleMission.Controls.Add(this.txtNbMembres);
            this.grpNouvelleMission.Controls.Add(this.btValiderPlanete);
            this.grpNouvelleMission.Controls.Add(this.cboNomPlanete);
            this.grpNouvelleMission.Controls.Add(this.label1);
            this.grpNouvelleMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNouvelleMission.Location = new System.Drawing.Point(30, 26);
            this.grpNouvelleMission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpNouvelleMission.Name = "grpNouvelleMission";
            this.grpNouvelleMission.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpNouvelleMission.Size = new System.Drawing.Size(673, 633);
            this.grpNouvelleMission.TabIndex = 0;
            this.grpNouvelleMission.TabStop = false;
            this.grpNouvelleMission.Text = "Nouvelle mission";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "1- Choix de la planète";
            // 
            // cboNomPlanete
            // 
            this.cboNomPlanete.FormattingEnabled = true;
            this.cboNomPlanete.Location = new System.Drawing.Point(207, 35);
            this.cboNomPlanete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboNomPlanete.Name = "cboNomPlanete";
            this.cboNomPlanete.Size = new System.Drawing.Size(190, 26);
            this.cboNomPlanete.TabIndex = 1;
            this.cboNomPlanete.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btValiderPlanete
            // 
            this.btValiderPlanete.Location = new System.Drawing.Point(449, 35);
            this.btValiderPlanete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btValiderPlanete.Name = "btValiderPlanete";
            this.btValiderPlanete.Size = new System.Drawing.Size(151, 26);
            this.btValiderPlanete.TabIndex = 2;
            this.btValiderPlanete.Text = "Valider planète";
            this.btValiderPlanete.UseVisualStyleBackColor = true;
            this.btValiderPlanete.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNbMembres
            // 
            this.txtNbMembres.Location = new System.Drawing.Point(182, 429);
            this.txtNbMembres.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNbMembres.Name = "txtNbMembres";
            this.txtNbMembres.Size = new System.Drawing.Size(54, 24);
            this.txtNbMembres.TabIndex = 3;
            this.txtNbMembres.TextChanged += new System.EventHandler(this.txtNbMembres_TextChanged);
            this.txtNbMembres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNbMembres_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "2 - Choix du chef de mission";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "3 - Paramètres de la mission";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date Départ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Date Retour";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 307);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Feuille de route";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 435);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Nombre membres";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 488);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "ObjectifDataBaz";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 529);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "Budget";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 189);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 18);
            this.label10.TabIndex = 12;
            // 
            // txtObjDataBaz
            // 
            this.txtObjDataBaz.Location = new System.Drawing.Point(182, 482);
            this.txtObjDataBaz.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtObjDataBaz.Name = "txtObjDataBaz";
            this.txtObjDataBaz.Size = new System.Drawing.Size(54, 24);
            this.txtObjDataBaz.TabIndex = 13;
            this.txtObjDataBaz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObjDataBaz_KeyPress);
            // 
            // txtBudget
            // 
            this.txtBudget.Location = new System.Drawing.Point(182, 523);
            this.txtBudget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(54, 24);
            this.txtBudget.TabIndex = 14;
            this.txtBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBudget_KeyPress);
            // 
            // cboChefDeMission
            // 
            this.cboChefDeMission.FormattingEnabled = true;
            this.cboChefDeMission.Location = new System.Drawing.Point(234, 113);
            this.cboChefDeMission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboChefDeMission.Name = "cboChefDeMission";
            this.cboChefDeMission.Size = new System.Drawing.Size(354, 26);
            this.cboChefDeMission.TabIndex = 15;
            // 
            // dateTimeDepart
            // 
            this.dateTimeDepart.Location = new System.Drawing.Point(156, 200);
            this.dateTimeDepart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimeDepart.Name = "dateTimeDepart";
            this.dateTimeDepart.Size = new System.Drawing.Size(151, 24);
            this.dateTimeDepart.TabIndex = 16;
            // 
            // dateTimeRetour
            // 
            this.dateTimeRetour.Location = new System.Drawing.Point(156, 240);
            this.dateTimeRetour.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimeRetour.Name = "dateTimeRetour";
            this.dateTimeRetour.Size = new System.Drawing.Size(151, 24);
            this.dateTimeRetour.TabIndex = 17;
            // 
            // txtFeuilleDeRoute
            // 
            this.txtFeuilleDeRoute.Location = new System.Drawing.Point(156, 301);
            this.txtFeuilleDeRoute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFeuilleDeRoute.Name = "txtFeuilleDeRoute";
            this.txtFeuilleDeRoute.Size = new System.Drawing.Size(323, 24);
            this.txtFeuilleDeRoute.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(248, 432);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 18);
            this.label11.TabIndex = 19;
            this.label11.Text = "personnes";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(248, 485);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 18);
            this.label12.TabIndex = 20;
            this.label12.Text = "tonnes";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(248, 526);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 18);
            this.label13.TabIndex = 21;
            this.label13.Text = "€";
            // 
            // btValiderLaMission
            // 
            this.btValiderLaMission.Location = new System.Drawing.Point(488, 485);
            this.btValiderLaMission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btValiderLaMission.Name = "btValiderLaMission";
            this.btValiderLaMission.Size = new System.Drawing.Size(139, 89);
            this.btValiderLaMission.TabIndex = 22;
            this.btValiderLaMission.Text = "Valider la mission";
            this.btValiderLaMission.UseVisualStyleBackColor = true;
            // 
            // lblNomMission
            // 
            this.lblNomMission.AutoSize = true;
            this.lblNomMission.Location = new System.Drawing.Point(34, 85);
            this.lblNomMission.Name = "lblNomMission";
            this.lblNomMission.Size = new System.Drawing.Size(0, 18);
            this.lblNomMission.TabIndex = 23;
            // 
            // FormCreationMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 692);
            this.Controls.Add(this.grpNouvelleMission);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormCreationMission";
            this.Text = "Création d\'une nouvelle mission";
            this.Load += new System.EventHandler(this.FormCreationMission_Load);
            this.grpNouvelleMission.ResumeLayout(false);
            this.grpNouvelleMission.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNouvelleMission;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNbMembres;
        private System.Windows.Forms.Button btValiderPlanete;
        private System.Windows.Forms.ComboBox cboNomPlanete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeRetour;
        private System.Windows.Forms.DateTimePicker dateTimeDepart;
        private System.Windows.Forms.ComboBox cboChefDeMission;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.TextBox txtObjDataBaz;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFeuilleDeRoute;
        private System.Windows.Forms.Button btValiderLaMission;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNomMission;
    }
}

