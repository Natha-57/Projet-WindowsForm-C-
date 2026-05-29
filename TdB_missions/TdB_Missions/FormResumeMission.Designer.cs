namespace _3_Visualisation_et_MAJ_missions
{
    partial class FormResumeMission
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
            this.lblNomMission = new System.Windows.Forms.Label();
            this.lblDateDepart = new System.Windows.Forms.Label();
            this.lblBudget = new System.Windows.Forms.Label();
            this.lblSoldeApresDepenses = new System.Windows.Forms.Label();
            this.lblDateRetour = new System.Windows.Forms.Label();
            this.grpFeuilleDeRoute = new System.Windows.Forms.GroupBox();
            this.txtFeuilleRoute = new System.Windows.Forms.RichTextBox();
            this.grpMembresEquipage = new System.Windows.Forms.GroupBox();
            this.flpMembres = new System.Windows.Forms.FlowLayoutPanel();
            this.grbMembres = new System.Windows.Forms.GroupBox();
            this.lstObjectifs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbJdB = new System.Windows.Forms.PictureBox();
            this.pbPlanete = new System.Windows.Forms.PictureBox();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.grpFeuilleDeRoute.SuspendLayout();
            this.grpMembresEquipage.SuspendLayout();
            this.grbMembres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbJdB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomMission
            // 
            this.lblNomMission.AutoSize = true;
            this.lblNomMission.Location = new System.Drawing.Point(330, 41);
            this.lblNomMission.Name = "lblNomMission";
            this.lblNomMission.Size = new System.Drawing.Size(64, 13);
            this.lblNomMission.TabIndex = 0;
            this.lblNomMission.Text = "NomMission";
            // 
            // lblDateDepart
            // 
            this.lblDateDepart.AutoSize = true;
            this.lblDateDepart.Location = new System.Drawing.Point(178, 120);
            this.lblDateDepart.Name = "lblDateDepart";
            this.lblDateDepart.Size = new System.Drawing.Size(35, 13);
            this.lblDateDepart.TabIndex = 1;
            this.lblDateDepart.Text = "label1";
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.Location = new System.Drawing.Point(384, 120);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(35, 13);
            this.lblBudget.TabIndex = 2;
            this.lblBudget.Text = "label2";
            // 
            // lblSoldeApresDepenses
            // 
            this.lblSoldeApresDepenses.AutoSize = true;
            this.lblSoldeApresDepenses.ForeColor = System.Drawing.Color.Red;
            this.lblSoldeApresDepenses.Location = new System.Drawing.Point(458, 152);
            this.lblSoldeApresDepenses.Name = "lblSoldeApresDepenses";
            this.lblSoldeApresDepenses.Size = new System.Drawing.Size(35, 13);
            this.lblSoldeApresDepenses.TabIndex = 3;
            this.lblSoldeApresDepenses.Text = "label4";
            this.lblSoldeApresDepenses.Click += new System.EventHandler(this.lblSoldeApresDepenses_Click);
            // 
            // lblDateRetour
            // 
            this.lblDateRetour.AutoSize = true;
            this.lblDateRetour.Location = new System.Drawing.Point(178, 152);
            this.lblDateRetour.Name = "lblDateRetour";
            this.lblDateRetour.Size = new System.Drawing.Size(35, 13);
            this.lblDateRetour.TabIndex = 4;
            this.lblDateRetour.Text = "label4";
            // 
            // grpFeuilleDeRoute
            // 
            this.grpFeuilleDeRoute.Controls.Add(this.txtFeuilleRoute);
            this.grpFeuilleDeRoute.Location = new System.Drawing.Point(57, 208);
            this.grpFeuilleDeRoute.Name = "grpFeuilleDeRoute";
            this.grpFeuilleDeRoute.Size = new System.Drawing.Size(519, 83);
            this.grpFeuilleDeRoute.TabIndex = 5;
            this.grpFeuilleDeRoute.TabStop = false;
            this.grpFeuilleDeRoute.Text = "Feuille de route";
            // 
            // txtFeuilleRoute
            // 
            this.txtFeuilleRoute.Location = new System.Drawing.Point(4, 19);
            this.txtFeuilleRoute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFeuilleRoute.Name = "txtFeuilleRoute";
            this.txtFeuilleRoute.Size = new System.Drawing.Size(512, 61);
            this.txtFeuilleRoute.TabIndex = 0;
            this.txtFeuilleRoute.Text = "";
            // 
            // grpMembresEquipage
            // 
            this.grpMembresEquipage.Controls.Add(this.flpMembres);
            this.grpMembresEquipage.Location = new System.Drawing.Point(56, 297);
            this.grpMembresEquipage.Name = "grpMembresEquipage";
            this.grpMembresEquipage.Size = new System.Drawing.Size(519, 145);
            this.grpMembresEquipage.TabIndex = 6;
            this.grpMembresEquipage.TabStop = false;
            this.grpMembresEquipage.Text = "Membres de l\'équipage";
            // 
            // flpMembres
            // 
            this.flpMembres.AutoScroll = true;
            this.flpMembres.Location = new System.Drawing.Point(5, 17);
            this.flpMembres.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpMembres.Name = "flpMembres";
            this.flpMembres.Size = new System.Drawing.Size(510, 123);
            this.flpMembres.TabIndex = 1;
            // 
            // grbMembres
            // 
            this.grbMembres.Controls.Add(this.lstObjectifs);
            this.grbMembres.Location = new System.Drawing.Point(56, 448);
            this.grbMembres.Name = "grbMembres";
            this.grbMembres.Size = new System.Drawing.Size(519, 96);
            this.grbMembres.TabIndex = 7;
            this.grbMembres.TabStop = false;
            this.grbMembres.Text = "Membres de l\'équipage";
            // 
            // lstObjectifs
            // 
            this.lstObjectifs.FormattingEnabled = true;
            this.lstObjectifs.Location = new System.Drawing.Point(4, 17);
            this.lstObjectifs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstObjectifs.Name = "lstObjectifs";
            this.lstObjectifs.Size = new System.Drawing.Size(512, 69);
            this.lstObjectifs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Date de départ : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Date de retour prévue : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Budget : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(330, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Solde après dépenses : ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(530, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 30);
            this.label5.TabIndex = 12;
            this.label5.Text = "Journal de Board";
            // 
            // pbJdB
            // 
            this.pbJdB.Location = new System.Drawing.Point(532, 41);
            this.pbJdB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbJdB.Name = "pbJdB";
            this.pbJdB.Size = new System.Drawing.Size(50, 46);
            this.pbJdB.TabIndex = 13;
            this.pbJdB.TabStop = false;
            this.pbJdB.Click += new System.EventHandler(this.pbJdB_Click);
            // 
            // pbPlanete
            // 
            this.pbPlanete.Location = new System.Drawing.Point(180, 6);
            this.pbPlanete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbPlanete.Name = "pbPlanete";
            this.pbPlanete.Size = new System.Drawing.Size(120, 89);
            this.pbPlanete.TabIndex = 14;
            this.pbPlanete.TabStop = false;
            // 
            // pbHome
            // 
            this.pbHome.Location = new System.Drawing.Point(67, 41);
            this.pbHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(58, 46);
            this.pbHome.TabIndex = 15;
            this.pbHome.TabStop = false;
            this.pbHome.Click += new System.EventHandler(this.pbHome_Click);
            // 
            // FormResumeMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 552);
            this.Controls.Add(this.pbHome);
            this.Controls.Add(this.pbPlanete);
            this.Controls.Add(this.pbJdB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbMembres);
            this.Controls.Add(this.grpMembresEquipage);
            this.Controls.Add(this.grpFeuilleDeRoute);
            this.Controls.Add(this.lblDateRetour);
            this.Controls.Add(this.lblSoldeApresDepenses);
            this.Controls.Add(this.lblBudget);
            this.Controls.Add(this.lblDateDepart);
            this.Controls.Add(this.lblNomMission);
            this.MaximumSize = new System.Drawing.Size(640, 591);
            this.MinimumSize = new System.Drawing.Size(640, 591);
            this.Name = "FormResumeMission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resume Mission";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpFeuilleDeRoute.ResumeLayout(false);
            this.grpMembresEquipage.ResumeLayout(false);
            this.grbMembres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbJdB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomMission;
        private System.Windows.Forms.Label lblDateDepart;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.Label lblSoldeApresDepenses;
        private System.Windows.Forms.Label lblDateRetour;
        private System.Windows.Forms.GroupBox grpFeuilleDeRoute;
        private System.Windows.Forms.GroupBox grpMembresEquipage;
        private System.Windows.Forms.RichTextBox txtFeuilleRoute;
        private System.Windows.Forms.GroupBox grbMembres;
        private System.Windows.Forms.ListBox lstObjectifs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbJdB;
        private System.Windows.Forms.FlowLayoutPanel flpMembres;
        private System.Windows.Forms.PictureBox pbPlanete;
        private System.Windows.Forms.PictureBox pbHome;
    }
}

