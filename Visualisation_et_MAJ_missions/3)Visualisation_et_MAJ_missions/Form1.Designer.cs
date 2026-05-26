namespace _3_Visualisation_et_MAJ_missions
{
    partial class Form1
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
            this.grpMembresEquipage = new System.Windows.Forms.GroupBox();
            this.btJournalDeBoard = new System.Windows.Forms.Button();
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
            this.lblDateDepart.Location = new System.Drawing.Point(108, 231);
            this.lblDateDepart.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateDepart.Name = "lblDateDepart";
            this.lblDateDepart.Size = new System.Drawing.Size(70, 25);
            this.lblDateDepart.TabIndex = 1;
            this.lblDateDepart.Text = "label1";
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.Location = new System.Drawing.Point(806, 231);
            this.lblBudget.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(70, 25);
            this.lblBudget.TabIndex = 2;
            this.lblBudget.Text = "label2";
            // 
            // lblSoldeApresDepenses
            // 
            this.lblSoldeApresDepenses.AutoSize = true;
            this.lblSoldeApresDepenses.Location = new System.Drawing.Point(806, 312);
            this.lblSoldeApresDepenses.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSoldeApresDepenses.Name = "lblSoldeApresDepenses";
            this.lblSoldeApresDepenses.Size = new System.Drawing.Size(70, 25);
            this.lblSoldeApresDepenses.TabIndex = 3;
            this.lblSoldeApresDepenses.Text = "label3";
            // 
            // lblDateRetour
            // 
            this.lblDateRetour.AutoSize = true;
            this.lblDateRetour.Location = new System.Drawing.Point(108, 312);
            this.lblDateRetour.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateRetour.Name = "lblDateRetour";
            this.lblDateRetour.Size = new System.Drawing.Size(70, 25);
            this.lblDateRetour.TabIndex = 4;
            this.lblDateRetour.Text = "label4";
            // 
            // grpFeuilleDeRoute
            // 
            this.grpFeuilleDeRoute.Location = new System.Drawing.Point(114, 400);
            this.grpFeuilleDeRoute.Margin = new System.Windows.Forms.Padding(6);
            this.grpFeuilleDeRoute.Name = "grpFeuilleDeRoute";
            this.grpFeuilleDeRoute.Padding = new System.Windows.Forms.Padding(6);
            this.grpFeuilleDeRoute.Size = new System.Drawing.Size(1038, 279);
            this.grpFeuilleDeRoute.TabIndex = 5;
            this.grpFeuilleDeRoute.TabStop = false;
            this.grpFeuilleDeRoute.Text = "Feuille de route";
            // 
            // grpMembresEquipage
            // 
            this.grpMembresEquipage.Location = new System.Drawing.Point(114, 727);
            this.grpMembresEquipage.Margin = new System.Windows.Forms.Padding(6);
            this.grpMembresEquipage.Name = "grpMembresEquipage";
            this.grpMembresEquipage.Padding = new System.Windows.Forms.Padding(6);
            this.grpMembresEquipage.Size = new System.Drawing.Size(1038, 279);
            this.grpMembresEquipage.TabIndex = 6;
            this.grpMembresEquipage.TabStop = false;
            this.grpMembresEquipage.Text = "Membres de l\'équipage";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 1213);
            this.Controls.Add(this.btJournalDeBoard);
            this.Controls.Add(this.grpMembresEquipage);
            this.Controls.Add(this.grpFeuilleDeRoute);
            this.Controls.Add(this.lblDateRetour);
            this.Controls.Add(this.lblSoldeApresDepenses);
            this.Controls.Add(this.lblBudget);
            this.Controls.Add(this.lblDateDepart);
            this.Controls.Add(this.lblNomMission);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

