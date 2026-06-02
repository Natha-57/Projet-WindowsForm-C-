using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Volet_4___Races_Aliens
{
    partial class FormDetailAlien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailAlien));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_fermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(20, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_fermer
            // 
            this.button_fermer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_fermer.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_fermer.Location = new System.Drawing.Point(200, 440);
            this.button_fermer.Name = "button_fermer";
            this.button_fermer.Size = new System.Drawing.Size(149, 45);
            this.button_fermer.TabIndex = 1;
            this.button_fermer.Text = "Fermer";
            this.button_fermer.Click += new System.EventHandler(this.button_fermer_Click);
            // 
            // FormDetailAlien
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 500);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_fermer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormDetailAlien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormDetailAlien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pictureBox1;
        private Button button_fermer;
    }
}