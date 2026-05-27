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
            this.lstMembres = new System.Windows.Forms.ListBox();
            this.btJournalDeBoard = new System.Windows.Forms.Button();
            this.grbMembres = new System.Windows.Forms.GroupBox();
            this.lstObjectifs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpFeuilleDeRoute.SuspendLayout();
            this.grpMembresEquipage.SuspendLayout();
            this.grbMembres.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomMission
            // 
            this.lblNomMission.AutoSize = true;
            this.lblNomMission.Location = new System.Drawing.Point(608, 63);
            this.lblNomMission.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNomMission.Name = "lblNomMission";
            this.lblNomMission.Size = new System.Drawing.Size(130, 25);
            this.lblNomMission.TabIndex = 0;
            this.lblNomMission.Text = "NomMission";
            // 
            // lblDateDepart
            // 
            this.lblDateDepart.AutoSize = true;
            this.lblDateDepart.Location = new System.Drawing.Point(355, 231);
            this.lblDateDepart.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateDepart.Name = "lblDateDepart";
            this.lblDateDepart.Size = new System.Drawing.Size(70, 25);
            this.lblDateDepart.TabIndex = 1;
            this.lblDateDepart.Text = "label1";
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.Location = new System.Drawing.Point(769, 231);
            this.lblBudget.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(70, 25);
            this.lblBudget.TabIndex = 2;
            this.lblBudget.Text = "label2";
            // 
            // lblSoldeApresDepenses
            // 
            this.lblSoldeApresDepenses.AutoSize = true;
            this.lblSoldeApresDepenses.ForeColor = System.Drawing.Color.Red;
            this.lblSoldeApresDepenses.Location = new System.Drawing.Point(916, 292);
            this.lblSoldeApresDepenses.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSoldeApresDepenses.Name = "lblSoldeApresDepenses";
            this.lblSoldeApresDepenses.Size = new System.Drawing.Size(70, 25);
            this.lblSoldeApresDepenses.TabIndex = 3;
            this.lblSoldeApresDepenses.Text = "label4";
            // 
            // lblDateRetour
            // 
            this.lblDateRetour.AutoSize = true;
            this.lblDateRetour.Location = new System.Drawing.Point(355, 292);
            this.lblDateRetour.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateRetour.Name = "lblDateRetour";
            this.lblDateRetour.Size = new System.Drawing.Size(70, 25);
            this.lblDateRetour.TabIndex = 4;
            this.lblDateRetour.Text = "label4";
            // 
            // grpFeuilleDeRoute
            // 
            this.grpFeuilleDeRoute.Controls.Add(this.txtFeuilleRoute);
            this.grpFeuilleDeRoute.Location = new System.Drawing.Point(114, 400);
            this.grpFeuilleDeRoute.Margin = new System.Windows.Forms.Padding(6);
            this.grpFeuilleDeRoute.Name = "grpFeuilleDeRoute";
            this.grpFeuilleDeRoute.Padding = new System.Windows.Forms.Padding(6);
            this.grpFeuilleDeRoute.Size = new System.Drawing.Size(1038, 159);
            this.grpFeuilleDeRoute.TabIndex = 5;
            this.grpFeuilleDeRoute.TabStop = false;
            this.grpFeuilleDeRoute.Text = "Feuille de route";
            // 
            // txtFeuilleRoute
            // 
            this.txtFeuilleRoute.Location = new System.Drawing.Point(9, 37);
            this.txtFeuilleRoute.Name = "txtFeuilleRoute";
            this.txtFeuilleRoute.Size = new System.Drawing.Size(1020, 113);
            this.txtFeuilleRoute.TabIndex = 0;
            this.txtFeuilleRoute.Text = "";
            // 
            // grpMembresEquipage
            // 
            this.grpMembresEquipage.Controls.Add(this.lstMembres);
            this.grpMembresEquipage.Location = new System.Drawing.Point(113, 571);
            this.grpMembresEquipage.Margin = new System.Windows.Forms.Padding(6);
            this.grpMembresEquipage.Name = "grpMembresEquipage";
            this.grpMembresEquipage.Padding = new System.Windows.Forms.Padding(6);
            this.grpMembresEquipage.Size = new System.Drawing.Size(1038, 279);
            this.grpMembresEquipage.TabIndex = 6;
            this.grpMembresEquipage.TabStop = false;
            this.grpMembresEquipage.Text = "Membres de l\'équipage";
            // 
            // lstMembres
            // 
            this.lstMembres.FormattingEnabled = true;
            this.lstMembres.ItemHeight = 25;
            this.lstMembres.Location = new System.Drawing.Point(9, 33);
            this.lstMembres.Name = "lstMembres";
            this.lstMembres.Size = new System.Drawing.Size(1020, 229);
            this.lstMembres.TabIndex = 0;
            // 
            // btJournalDeBoard
            // 
            this.btJournalDeBoard.Location = new System.Drawing.Point(857, 1065);
            this.btJournalDeBoard.Name = "btJournalDeBoard";
            this.btJournalDeBoard.Size = new System.Drawing.Size(295, 113);
            this.btJournalDeBoard.TabIndex = 7;
            this.btJournalDeBoard.Text = "Journal de Board >";
            this.btJournalDeBoard.UseVisualStyleBackColor = true;
            this.btJournalDeBoard.Click += new System.EventHandler(this.btJournalDeBoard_Click);
            // 
            // grbMembres
            // 
            this.grbMembres.Controls.Add(this.lstObjectifs);
            this.grbMembres.Location = new System.Drawing.Point(113, 862);
            this.grbMembres.Margin = new System.Windows.Forms.Padding(6);
            this.grbMembres.Name = "grbMembres";
            this.grbMembres.Padding = new System.Windows.Forms.Padding(6);
            this.grbMembres.Size = new System.Drawing.Size(1038, 184);
            this.grbMembres.TabIndex = 7;
            this.grbMembres.TabStop = false;
            this.grbMembres.Text = "Membres de l\'équipage";
            // 
            // lstObjectifs
            // 
            this.lstObjectifs.FormattingEnabled = true;
            this.lstObjectifs.ItemHeight = 25;
            this.lstObjectifs.Location = new System.Drawing.Point(9, 33);
            this.lstObjectifs.Name = "lstObjectifs";
            this.lstObjectifs.Size = new System.Drawing.Size(1020, 129);
            this.lstObjectifs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 231);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Date de départ : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 292);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Date de retour prévue : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(659, 231);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Budget : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(659, 292);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Solde après dépenses : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1072, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "label1";
            // 
            // FormResumeMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 1061);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbMembres);
            this.Controls.Add(this.btJournalDeBoard);
            this.Controls.Add(this.grpMembresEquipage);
            this.Controls.Add(this.grpFeuilleDeRoute);
            this.Controls.Add(this.lblDateRetour);
            this.Controls.Add(this.lblSoldeApresDepenses);
            this.Controls.Add(this.lblBudget);
            this.Controls.Add(this.lblDateDepart);
            this.Controls.Add(this.lblNomMission);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormResumeMission";
            this.Text = "Resume Mission";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpFeuilleDeRoute.ResumeLayout(false);
            this.grpMembresEquipage.ResumeLayout(false);
            this.grbMembres.ResumeLayout(false);
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
        private System.Windows.Forms.Button btJournalDeBoard;
        private System.Windows.Forms.RichTextBox txtFeuilleRoute;
        private System.Windows.Forms.GroupBox grbMembres;
        private System.Windows.Forms.ListBox lstObjectifs;
        private System.Windows.Forms.ListBox lstMembres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

