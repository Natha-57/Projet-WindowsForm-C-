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
            this.grpDepenses = new System.Windows.Forms.GroupBox();
            this.grpContact = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.grpEvenement.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEvenement
            // 
            this.grpEvenement.Controls.Add(this.richTextBox1);
            this.grpEvenement.Controls.Add(this.button4);
            this.grpEvenement.Controls.Add(this.button3);
            this.grpEvenement.Controls.Add(this.button2);
            this.grpEvenement.Controls.Add(this.button1);
            this.grpEvenement.Location = new System.Drawing.Point(80, 87);
            this.grpEvenement.Name = "grpEvenement";
            this.grpEvenement.Size = new System.Drawing.Size(447, 737);
            this.grpEvenement.TabIndex = 0;
            this.grpEvenement.TabStop = false;
            this.grpEvenement.Text = "Evènements du journal";
            // 
            // grpDepenses
            // 
            this.grpDepenses.Location = new System.Drawing.Point(579, 87);
            this.grpDepenses.Name = "grpDepenses";
            this.grpDepenses.Size = new System.Drawing.Size(638, 485);
            this.grpDepenses.TabIndex = 1;
            this.grpDepenses.TabStop = false;
            this.grpDepenses.Text = "Dépenses effectuées";
            // 
            // grpContact
            // 
            this.grpContact.Location = new System.Drawing.Point(579, 612);
            this.grpContact.Name = "grpContact";
            this.grpContact.Size = new System.Drawing.Size(638, 225);
            this.grpContact.TabIndex = 2;
            this.grpContact.TabStop = false;
            this.grpContact.Text = "Contacts avec les informateurs";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 664);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 67);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(361, 664);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 67);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(275, 664);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 67);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(179, 664);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(90, 67);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 920);
            this.Controls.Add(this.grpContact);
            this.Controls.Add(this.grpDepenses);
            this.Controls.Add(this.grpEvenement);
            this.Name = "Form2";
            this.Text = "Form2";
            this.grpEvenement.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}