namespace TdB_Missions
{
    partial class FormTdB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTdB));
            this.btCreerMission = new System.Windows.Forms.Button();
            this.btInfoAlien = new System.Windows.Forms.Button();
            this.btInfoPlanete = new System.Windows.Forms.Button();
            this.btStat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btCreerMission
            // 
            resources.ApplyResources(this.btCreerMission, "btCreerMission");
            this.btCreerMission.Name = "btCreerMission";
            this.btCreerMission.UseVisualStyleBackColor = true;
            this.btCreerMission.Click += new System.EventHandler(this.btCreerMission_Click);
            // 
            // btInfoAlien
            // 
            resources.ApplyResources(this.btInfoAlien, "btInfoAlien");
            this.btInfoAlien.Name = "btInfoAlien";
            this.btInfoAlien.UseVisualStyleBackColor = true;
            this.btInfoAlien.Click += new System.EventHandler(this.button1_Click);
            // 
            // btInfoPlanete
            // 
            resources.ApplyResources(this.btInfoPlanete, "btInfoPlanete");
            this.btInfoPlanete.Name = "btInfoPlanete";
            this.btInfoPlanete.UseVisualStyleBackColor = true;
            this.btInfoPlanete.Click += new System.EventHandler(this.btInfoPlanete_Click);
            // 
            // btStat
            // 
            resources.ApplyResources(this.btStat, "btStat");
            this.btStat.Name = "btStat";
            this.btStat.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FormTdB
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btStat);
            this.Controls.Add(this.btInfoPlanete);
            this.Controls.Add(this.btInfoAlien);
            this.Controls.Add(this.btCreerMission);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormTdB";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCreerMission;
        private System.Windows.Forms.Button btInfoAlien;
        private System.Windows.Forms.Button btInfoPlanete;
        private System.Windows.Forms.Button btStat;
        private System.Windows.Forms.Panel panel1;
    }
}

