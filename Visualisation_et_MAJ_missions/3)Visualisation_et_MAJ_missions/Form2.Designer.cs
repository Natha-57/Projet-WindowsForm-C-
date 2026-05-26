namespace _3_Visualisation_et_MAJ_missions
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpEvenement = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grpDepenses = new System.Windows.Forms.GroupBox();
            this.grpContact = new System.Windows.Forms.GroupBox();
            this.btEditerUnPdf = new System.Windows.Forms.Button();
            this.txtSommesVersées = new System.Windows.Forms.Label();
            this.txtDepenses = new System.Windows.Forms.Label();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.grpEvenement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEvenement
            // 
            this.grpEvenement.Controls.Add(this.richTextBox1);
            this.grpEvenement.Controls.Add(this.button4);
            this.grpEvenement.Controls.Add(this.button3);
            this.grpEvenement.Controls.Add(this.button2);
            this.grpEvenement.Controls.Add(this.button1);
            this.grpEvenement.Location = new System.Drawing.Point(80, 34);
            this.grpEvenement.Name = "grpEvenement";
            this.grpEvenement.Size = new System.Drawing.Size(447, 807);
            this.grpEvenement.TabIndex = 0;
            this.grpEvenement.TabStop = false;
            this.grpEvenement.Text = "Evènements du journal";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(179, 735);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(90, 67);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(275, 734);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 67);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(361, 734);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 67);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 734);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 67);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 734);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // grpDepenses
            // 
            this.grpDepenses.Location = new System.Drawing.Point(579, 34);
            this.grpDepenses.Name = "grpDepenses";
            this.grpDepenses.Size = new System.Drawing.Size(638, 452);
            this.grpDepenses.TabIndex = 1;
            this.grpDepenses.TabStop = false;
            this.grpDepenses.Text = "Dépenses effectuées";
            // 
            // grpContact
            // 
            this.grpContact.Location = new System.Drawing.Point(579, 572);
            this.grpContact.Name = "grpContact";
            this.grpContact.Size = new System.Drawing.Size(638, 193);
            this.grpContact.TabIndex = 2;
            this.grpContact.TabStop = false;
            this.grpContact.Text = "Contacts avec les informateurs";
            // 
            // btEditerUnPdf
            // 
            this.btEditerUnPdf.Location = new System.Drawing.Point(80, 847);
            this.btEditerUnPdf.Name = "btEditerUnPdf";
            this.btEditerUnPdf.Size = new System.Drawing.Size(979, 61);
            this.btEditerUnPdf.TabIndex = 3;
            this.btEditerUnPdf.Text = "Editer un PDF";
            this.btEditerUnPdf.UseVisualStyleBackColor = true;
            // 
            // txtSommesVersées
            // 
            this.txtSommesVersées.AutoSize = true;
            this.txtSommesVersées.Location = new System.Drawing.Point(579, 793);
            this.txtSommesVersées.Name = "txtSommesVersées";
            this.txtSommesVersées.Size = new System.Drawing.Size(287, 25);
            this.txtSommesVersées.TabIndex = 4;
            this.txtSommesVersées.Text = "Total des sommes versées : ";
            // 
            // txtDepenses
            // 
            this.txtDepenses.AutoSize = true;
            this.txtDepenses.Location = new System.Drawing.Point(579, 506);
            this.txtDepenses.Name = "txtDepenses";
            this.txtDepenses.Size = new System.Drawing.Size(219, 25);
            this.txtDepenses.TabIndex = 5;
            this.txtDepenses.Text = "Total des dépenses : ";
            // 
            // pbHome
            // 
            this.pbHome.Location = new System.Drawing.Point(1129, 829);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(88, 79);
            this.pbHome.TabIndex = 7;
            this.pbHome.TabStop = false;
            this.pbHome.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 920);
            this.Controls.Add(this.pbHome);
            this.Controls.Add(this.txtDepenses);
            this.Controls.Add(this.txtSommesVersées);
            this.Controls.Add(this.btEditerUnPdf);
            this.Controls.Add(this.grpContact);
            this.Controls.Add(this.grpDepenses);
            this.Controls.Add(this.grpEvenement);
            this.Name = "Form2";
            this.Text = "Form2";
            this.grpEvenement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEvenement;
        private System.Windows.Forms.GroupBox grpDepenses;
        private System.Windows.Forms.GroupBox grpContact;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btEditerUnPdf;
        private System.Windows.Forms.Label txtSommesVersées;
        private System.Windows.Forms.Label txtDepenses;
        private System.Windows.Forms.PictureBox pbHome;
    }
}