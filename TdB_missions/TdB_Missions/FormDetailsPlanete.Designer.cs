namespace Volet_4___Races_Aliens
{
    partial class FormDetailsPlanete
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailsPlanete));
            this.button_fermer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_fermer
            // 
            this.button_fermer.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold);
            this.button_fermer.Location = new System.Drawing.Point(235, 530);
            this.button_fermer.Name = "button_fermer";
            this.button_fermer.Size = new System.Drawing.Size(149, 45);
            this.button_fermer.TabIndex = 0;
            this.button_fermer.Text = "Fermer";
            // 
            // FormDetails
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(620, 590);
            this.Controls.Add(this.button_fermer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Détails";
            this.Load += new System.EventHandler(this.FormDetails_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button button_fermer;
    }
}