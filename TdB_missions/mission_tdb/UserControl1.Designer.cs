namespace mission_tdb
{
    partial class UserControl1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        private void InitializeComponent()
        {
            this.label1    = new System.Windows.Forms.Label();
            this.label2    = new System.Windows.Forms.Label();
            this.label3    = new System.Windows.Forms.Label();
            this.label4    = new System.Windows.Forms.Label();
            this.label5    = new System.Windows.Forms.Label();
            this.label6    = new System.Windows.Forms.Label();
            this.label7    = new System.Windows.Forms.Label();
            this.button1   = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            // label1 — Nom mission (titre)
            this.label1.AutoSize = true;
            this.label1.Font     = new System.Drawing.Font("Impact", 12F);
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name     = "label1";
            this.label1.Size     = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 0;
            this.label1.Text     = "label1";

            // label2 — Date départ
            this.label2.AutoSize = true;
            this.label2.Font     = new System.Drawing.Font("Impact", 11F);
            this.label2.Location = new System.Drawing.Point(220, 60);
            this.label2.Name     = "label2";
            this.label2.Size     = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text     = "label2";

            // label3 — Date retour
            this.label3.AutoSize = true;
            this.label3.Font     = new System.Drawing.Font("Impact", 11F);
            this.label3.Location = new System.Drawing.Point(500, 60);
            this.label3.Name     = "label3";
            this.label3.Size     = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 2;
            this.label3.Text     = "label3";

            // label4 — Chef de mission
            this.label4.AutoSize = true;
            this.label4.Font     = new System.Drawing.Font("Impact", 11F);
            this.label4.Location = new System.Drawing.Point(220, 100);
            this.label4.Name     = "label4";
            this.label4.Size     = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 3;
            this.label4.Text     = "label4";
            this.label4.Click   += new System.EventHandler(this.label4_Click);

            // label5 — Nb jours
            this.label5.AutoSize = true;
            this.label5.Font     = new System.Drawing.Font("Impact", 11F);
            this.label5.Location = new System.Drawing.Point(500, 100);
            this.label5.Name     = "label5";
            this.label5.Size     = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 4;
            this.label5.Text     = "label5";

            // label6 — Budget
            this.label6.AutoSize = true;
            this.label6.Font     = new System.Drawing.Font("Impact", 11F);
            this.label6.Location = new System.Drawing.Point(220, 145);
            this.label6.Name     = "label6";
            this.label6.Size     = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 5;
            this.label6.Text     = "label6";

            // label7 — État (badge coloré)
            this.label7.AutoSize  = false;
            this.label7.Font      = new System.Drawing.Font("Impact", 11F);
            this.label7.Location  = new System.Drawing.Point(500, 138);
            this.label7.Size      = new System.Drawing.Size(160, 30);
            this.label7.Name      = "label7";
            this.label7.TabIndex  = 6;
            this.label7.Text      = "label7";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // button1 — + d'infos
            this.button1.Font     = new System.Drawing.Font("Impact", 12F);
            this.button1.Location = new System.Drawing.Point(904, 70);
            this.button1.Name     = "button1";
            this.button1.Size     = new System.Drawing.Size(159, 77);
            this.button1.TabIndex = 8;
            this.button1.Text     = "+ d'informations";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click   += new System.EventHandler(this.button1_Click);

            // pictureBox1
            this.pictureBox1.Location = new System.Drawing.Point(29, 45);
            this.pictureBox1.Name     = "pictureBox1";
            this.pictureBox1.Size     = new System.Drawing.Size(155, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop  = false;

            // UserControl1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle         = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1115, 210);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
