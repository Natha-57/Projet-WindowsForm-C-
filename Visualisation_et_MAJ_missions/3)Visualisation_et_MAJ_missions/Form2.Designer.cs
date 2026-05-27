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
            this.btSuivant = new System.Windows.Forms.Button();
            this.btAllerToutAlaFin = new System.Windows.Forms.Button();
            this.btRevenir1foisEnArriere = new System.Windows.Forms.Button();
            this.btToutDebut = new System.Windows.Forms.Button();
            this.grpDepenses = new System.Windows.Forms.GroupBox();
            this.dgvDepenses = new System.Windows.Forms.DataGridView();
            this.grpContact = new System.Windows.Forms.GroupBox();
            this.btEditerUnPdf = new System.Windows.Forms.Button();
            this.lblSommesVersées = new System.Windows.Forms.Label();
            this.lblDepenses = new System.Windows.Forms.Label();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.lblDateEvenement = new System.Windows.Forms.Label();
            this.lblEvenement = new System.Windows.Forms.Label();
            this.lblCompteurPages = new System.Windows.Forms.Label();
            this.grpEvenement.SuspendLayout();
            this.grpDepenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepenses)).BeginInit();
            this.grpContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEvenement
            // 
            this.grpEvenement.Controls.Add(this.lblCompteurPages);
            this.grpEvenement.Controls.Add(this.lblEvenement);
            this.grpEvenement.Controls.Add(this.lblDateEvenement);
            this.grpEvenement.Controls.Add(this.btSuivant);
            this.grpEvenement.Controls.Add(this.btAllerToutAlaFin);
            this.grpEvenement.Controls.Add(this.btRevenir1foisEnArriere);
            this.grpEvenement.Controls.Add(this.btToutDebut);
            this.grpEvenement.Location = new System.Drawing.Point(80, 34);
            this.grpEvenement.Name = "grpEvenement";
            this.grpEvenement.Size = new System.Drawing.Size(482, 284);
            this.grpEvenement.TabIndex = 0;
            this.grpEvenement.TabStop = false;
            this.grpEvenement.Text = "Evènements du journal";
            // 
            // btSuivant
            // 
            this.btSuivant.Location = new System.Drawing.Point(310, 211);
            this.btSuivant.Name = "btSuivant";
            this.btSuivant.Size = new System.Drawing.Size(80, 67);
            this.btSuivant.TabIndex = 3;
            this.btSuivant.Text = ">";
            this.btSuivant.UseVisualStyleBackColor = true;
            // 
            // btAllerToutAlaFin
            // 
            this.btAllerToutAlaFin.Location = new System.Drawing.Point(396, 211);
            this.btAllerToutAlaFin.Name = "btAllerToutAlaFin";
            this.btAllerToutAlaFin.Size = new System.Drawing.Size(80, 67);
            this.btAllerToutAlaFin.TabIndex = 2;
            this.btAllerToutAlaFin.Text = ">>";
            this.btAllerToutAlaFin.UseVisualStyleBackColor = true;
            // 
            // btRevenir1foisEnArriere
            // 
            this.btRevenir1foisEnArriere.Location = new System.Drawing.Point(92, 211);
            this.btRevenir1foisEnArriere.Name = "btRevenir1foisEnArriere";
            this.btRevenir1foisEnArriere.Size = new System.Drawing.Size(80, 67);
            this.btRevenir1foisEnArriere.TabIndex = 1;
            this.btRevenir1foisEnArriere.Text = "<";
            this.btRevenir1foisEnArriere.UseVisualStyleBackColor = true;
            // 
            // btToutDebut
            // 
            this.btToutDebut.Location = new System.Drawing.Point(6, 211);
            this.btToutDebut.Name = "btToutDebut";
            this.btToutDebut.Size = new System.Drawing.Size(80, 67);
            this.btToutDebut.TabIndex = 0;
            this.btToutDebut.Text = "<<";
            this.btToutDebut.UseVisualStyleBackColor = true;
            // 
            // grpDepenses
            // 
            this.grpDepenses.Controls.Add(this.dgvDepenses);
            this.grpDepenses.Location = new System.Drawing.Point(80, 324);
            this.grpDepenses.Name = "grpDepenses";
            this.grpDepenses.Size = new System.Drawing.Size(1137, 452);
            this.grpDepenses.TabIndex = 1;
            this.grpDepenses.TabStop = false;
            this.grpDepenses.Text = "Dépenses effectuées";
            // 
            // dgvDepenses
            // 
            this.dgvDepenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepenses.Location = new System.Drawing.Point(6, 30);
            this.dgvDepenses.Name = "dgvDepenses";
            this.dgvDepenses.ReadOnly = true;
            this.dgvDepenses.RowHeadersWidth = 82;
            this.dgvDepenses.RowTemplate.Height = 33;
            this.dgvDepenses.Size = new System.Drawing.Size(1125, 416);
            this.dgvDepenses.TabIndex = 0;
            this.dgvDepenses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepenses_CellContentClick);
            // 
            // grpContact
            // 
            this.grpContact.Controls.Add(this.dgvContacts);
            this.grpContact.Location = new System.Drawing.Point(579, 34);
            this.grpContact.Name = "grpContact";
            this.grpContact.Size = new System.Drawing.Size(638, 250);
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
            // lblSommesVersées
            // 
            this.lblSommesVersées.AutoSize = true;
            this.lblSommesVersées.Location = new System.Drawing.Point(581, 287);
            this.lblSommesVersées.Name = "lblSommesVersées";
            this.lblSommesVersées.Size = new System.Drawing.Size(287, 25);
            this.lblSommesVersées.TabIndex = 4;
            this.lblSommesVersées.Text = "Total des sommes versées : ";
            // 
            // lblDepenses
            // 
            this.lblDepenses.AutoSize = true;
            this.lblDepenses.Location = new System.Drawing.Point(81, 790);
            this.lblDepenses.Name = "lblDepenses";
            this.lblDepenses.Size = new System.Drawing.Size(219, 25);
            this.lblDepenses.TabIndex = 5;
            this.lblDepenses.Text = "Total des dépenses : ";
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
            // dgvContacts
            // 
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Location = new System.Drawing.Point(13, 30);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.ReadOnly = true;
            this.dgvContacts.RowHeadersWidth = 82;
            this.dgvContacts.RowTemplate.Height = 33;
            this.dgvContacts.Size = new System.Drawing.Size(625, 214);
            this.dgvContacts.TabIndex = 0;
            // 
            // lblDateEvenement
            // 
            this.lblDateEvenement.AutoSize = true;
            this.lblDateEvenement.Location = new System.Drawing.Point(16, 40);
            this.lblDateEvenement.Name = "lblDateEvenement";
            this.lblDateEvenement.Size = new System.Drawing.Size(70, 25);
            this.lblDateEvenement.TabIndex = 5;
            this.lblDateEvenement.Text = "label1";
            // 
            // lblEvenement
            // 
            this.lblEvenement.AutoSize = true;
            this.lblEvenement.Location = new System.Drawing.Point(16, 109);
            this.lblEvenement.Name = "lblEvenement";
            this.lblEvenement.Size = new System.Drawing.Size(70, 25);
            this.lblEvenement.TabIndex = 6;
            this.lblEvenement.Text = "label2";
            // 
            // lblCompteurPages
            // 
            this.lblCompteurPages.AutoSize = true;
            this.lblCompteurPages.Location = new System.Drawing.Point(204, 232);
            this.lblCompteurPages.Name = "lblCompteurPages";
            this.lblCompteurPages.Size = new System.Drawing.Size(70, 25);
            this.lblCompteurPages.TabIndex = 7;
            this.lblCompteurPages.Text = "label1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 920);
            this.Controls.Add(this.pbHome);
            this.Controls.Add(this.lblDepenses);
            this.Controls.Add(this.lblSommesVersées);
            this.Controls.Add(this.btEditerUnPdf);
            this.Controls.Add(this.grpContact);
            this.Controls.Add(this.grpDepenses);
            this.Controls.Add(this.grpEvenement);
            this.Name = "Form2";
            this.Text = "Form2";
            this.grpEvenement.ResumeLayout(false);
            this.grpEvenement.PerformLayout();
            this.grpDepenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepenses)).EndInit();
            this.grpContact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEvenement;
        private System.Windows.Forms.GroupBox grpDepenses;
        private System.Windows.Forms.GroupBox grpContact;
        private System.Windows.Forms.Button btSuivant;
        private System.Windows.Forms.Button btAllerToutAlaFin;
        private System.Windows.Forms.Button btRevenir1foisEnArriere;
        private System.Windows.Forms.Button btToutDebut;
        private System.Windows.Forms.Button btEditerUnPdf;
        private System.Windows.Forms.Label lblSommesVersées;
        private System.Windows.Forms.Label lblDepenses;
        private System.Windows.Forms.PictureBox pbHome;
        private System.Windows.Forms.DataGridView dgvDepenses;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Label lblEvenement;
        private System.Windows.Forms.Label lblDateEvenement;
        private System.Windows.Forms.Label lblCompteurPages;
    }
}