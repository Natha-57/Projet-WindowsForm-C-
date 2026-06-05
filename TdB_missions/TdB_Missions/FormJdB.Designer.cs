namespace _3_Visualisation_et_MAJ_missions
{
    partial class FormJdB
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
            this.lblCompteurPages = new System.Windows.Forms.Label();
            this.lblEvenement = new System.Windows.Forms.Label();
            this.lblDateEvenement = new System.Windows.Forms.Label();
            this.btSuivant = new System.Windows.Forms.Button();
            this.btAllerToutAlaFin = new System.Windows.Forms.Button();
            this.btRevenir1foisEnArriere = new System.Windows.Forms.Button();
            this.btToutDebut = new System.Windows.Forms.Button();
            this.grpDepenses = new System.Windows.Forms.GroupBox();
            this.dgvDepenses = new System.Windows.Forms.DataGridView();
            this.grpContact = new System.Windows.Forms.GroupBox();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.btEditerUnPdf = new System.Windows.Forms.Button();
            this.lblSommesVersées = new System.Windows.Forms.Label();
            this.lblDepenses = new System.Windows.Forms.Label();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.grpEvenement.SuspendLayout();
            this.grpDepenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepenses)).BeginInit();
            this.grpContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
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
            this.grpEvenement.Location = new System.Drawing.Point(80, 35);
            this.grpEvenement.Margin = new System.Windows.Forms.Padding(4);
            this.grpEvenement.Name = "grpEvenement";
            this.grpEvenement.Padding = new System.Windows.Forms.Padding(4);
            this.grpEvenement.Size = new System.Drawing.Size(482, 285);
            this.grpEvenement.TabIndex = 0;
            this.grpEvenement.TabStop = false;
            this.grpEvenement.Text = "Evènements du journal";
            // 
            // lblCompteurPages
            // 
            this.lblCompteurPages.AutoSize = true;
            this.lblCompteurPages.Location = new System.Drawing.Point(204, 233);
            this.lblCompteurPages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompteurPages.Name = "lblCompteurPages";
            this.lblCompteurPages.Size = new System.Drawing.Size(70, 25);
            this.lblCompteurPages.TabIndex = 7;
            this.lblCompteurPages.Text = "label1";
            // 
            // lblEvenement
            // 
            this.lblEvenement.Location = new System.Drawing.Point(16, 98);
            this.lblEvenement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEvenement.Name = "lblEvenement";
            this.lblEvenement.Size = new System.Drawing.Size(460, 110);
            this.lblEvenement.TabIndex = 6;
            this.lblEvenement.Text = "label2";
            this.lblEvenement.Click += new System.EventHandler(this.lblEvenement_Click);
            // 
            // lblDateEvenement
            // 
            this.lblDateEvenement.AutoSize = true;
            this.lblDateEvenement.Location = new System.Drawing.Point(16, 40);
            this.lblDateEvenement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateEvenement.Name = "lblDateEvenement";
            this.lblDateEvenement.Size = new System.Drawing.Size(70, 25);
            this.lblDateEvenement.TabIndex = 5;
            this.lblDateEvenement.Text = "label1";
            // 
            // btSuivant
            // 
            this.btSuivant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSuivant.Location = new System.Drawing.Point(310, 212);
            this.btSuivant.Margin = new System.Windows.Forms.Padding(4);
            this.btSuivant.Name = "btSuivant";
            this.btSuivant.Size = new System.Drawing.Size(80, 67);
            this.btSuivant.TabIndex = 3;
            this.btSuivant.Text = ">";
            this.btSuivant.UseVisualStyleBackColor = true;
            this.btSuivant.Click += new System.EventHandler(this.btSuivant_Click);
            // 
            // btAllerToutAlaFin
            // 
            this.btAllerToutAlaFin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAllerToutAlaFin.Location = new System.Drawing.Point(396, 212);
            this.btAllerToutAlaFin.Margin = new System.Windows.Forms.Padding(4);
            this.btAllerToutAlaFin.Name = "btAllerToutAlaFin";
            this.btAllerToutAlaFin.Size = new System.Drawing.Size(80, 67);
            this.btAllerToutAlaFin.TabIndex = 2;
            this.btAllerToutAlaFin.Text = ">>";
            this.btAllerToutAlaFin.UseVisualStyleBackColor = true;
            this.btAllerToutAlaFin.Click += new System.EventHandler(this.btAllerToutAlaFin_Click);
            // 
            // btRevenir1foisEnArriere
            // 
            this.btRevenir1foisEnArriere.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRevenir1foisEnArriere.Location = new System.Drawing.Point(92, 212);
            this.btRevenir1foisEnArriere.Margin = new System.Windows.Forms.Padding(4);
            this.btRevenir1foisEnArriere.Name = "btRevenir1foisEnArriere";
            this.btRevenir1foisEnArriere.Size = new System.Drawing.Size(80, 67);
            this.btRevenir1foisEnArriere.TabIndex = 1;
            this.btRevenir1foisEnArriere.Text = "<";
            this.btRevenir1foisEnArriere.UseVisualStyleBackColor = true;
            this.btRevenir1foisEnArriere.Click += new System.EventHandler(this.btRevenir1foisEnArriere_Click);
            // 
            // btToutDebut
            // 
            this.btToutDebut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btToutDebut.Location = new System.Drawing.Point(6, 212);
            this.btToutDebut.Margin = new System.Windows.Forms.Padding(4);
            this.btToutDebut.Name = "btToutDebut";
            this.btToutDebut.Size = new System.Drawing.Size(80, 67);
            this.btToutDebut.TabIndex = 0;
            this.btToutDebut.Text = "<<";
            this.btToutDebut.UseVisualStyleBackColor = true;
            this.btToutDebut.Click += new System.EventHandler(this.btToutDebut_Click);
            // 
            // grpDepenses
            // 
            this.grpDepenses.Controls.Add(this.dgvDepenses);
            this.grpDepenses.Location = new System.Drawing.Point(80, 323);
            this.grpDepenses.Margin = new System.Windows.Forms.Padding(4);
            this.grpDepenses.Name = "grpDepenses";
            this.grpDepenses.Padding = new System.Windows.Forms.Padding(4);
            this.grpDepenses.Size = new System.Drawing.Size(1136, 452);
            this.grpDepenses.TabIndex = 1;
            this.grpDepenses.TabStop = false;
            this.grpDepenses.Text = "Dépenses effectuées";
            // 
            // dgvDepenses
            // 
            this.dgvDepenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepenses.Location = new System.Drawing.Point(6, 31);
            this.dgvDepenses.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDepenses.Name = "dgvDepenses";
            this.dgvDepenses.ReadOnly = true;
            this.dgvDepenses.RowHeadersWidth = 82;
            this.dgvDepenses.RowTemplate.Height = 33;
            this.dgvDepenses.Size = new System.Drawing.Size(1124, 415);
            this.dgvDepenses.TabIndex = 0;
            this.dgvDepenses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepenses_CellContentClick);
            // 
            // grpContact
            // 
            this.grpContact.Controls.Add(this.dgvContacts);
            this.grpContact.Location = new System.Drawing.Point(580, 35);
            this.grpContact.Margin = new System.Windows.Forms.Padding(4);
            this.grpContact.Name = "grpContact";
            this.grpContact.Padding = new System.Windows.Forms.Padding(4);
            this.grpContact.Size = new System.Drawing.Size(638, 250);
            this.grpContact.TabIndex = 2;
            this.grpContact.TabStop = false;
            this.grpContact.Text = "Contacts avec les informateurs";
            // 
            // dgvContacts
            // 
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Location = new System.Drawing.Point(12, 31);
            this.dgvContacts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.ReadOnly = true;
            this.dgvContacts.RowHeadersWidth = 82;
            this.dgvContacts.RowTemplate.Height = 33;
            this.dgvContacts.Size = new System.Drawing.Size(624, 213);
            this.dgvContacts.TabIndex = 0;
            // 
            // btEditerUnPdf
            // 
            this.btEditerUnPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditerUnPdf.Location = new System.Drawing.Point(80, 846);
            this.btEditerUnPdf.Margin = new System.Windows.Forms.Padding(4);
            this.btEditerUnPdf.Name = "btEditerUnPdf";
            this.btEditerUnPdf.Size = new System.Drawing.Size(980, 62);
            this.btEditerUnPdf.TabIndex = 3;
            this.btEditerUnPdf.Text = "Editer un PDF";
            this.btEditerUnPdf.UseVisualStyleBackColor = true;
            this.btEditerUnPdf.Click += new System.EventHandler(this.btEditerUnPdf_Click);
            // 
            // lblSommesVersées
            // 
            this.lblSommesVersées.AutoSize = true;
            this.lblSommesVersées.Location = new System.Drawing.Point(580, 287);
            this.lblSommesVersées.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSommesVersées.Name = "lblSommesVersées";
            this.lblSommesVersées.Size = new System.Drawing.Size(287, 25);
            this.lblSommesVersées.TabIndex = 4;
            this.lblSommesVersées.Text = "Total des sommes versées : ";
            // 
            // lblDepenses
            // 
            this.lblDepenses.AutoSize = true;
            this.lblDepenses.Location = new System.Drawing.Point(80, 790);
            this.lblDepenses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepenses.Name = "lblDepenses";
            this.lblDepenses.Size = new System.Drawing.Size(219, 25);
            this.lblDepenses.TabIndex = 5;
            this.lblDepenses.Text = "Total des dépenses : ";
            // 
            // pbHome
            // 
            this.pbHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHome.Location = new System.Drawing.Point(1128, 829);
            this.pbHome.Margin = new System.Windows.Forms.Padding(4);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(88, 79);
            this.pbHome.TabIndex = 7;
            this.pbHome.TabStop = false;
            this.pbHome.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormJdB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 919);
            this.Controls.Add(this.pbHome);
            this.Controls.Add(this.lblDepenses);
            this.Controls.Add(this.lblSommesVersées);
            this.Controls.Add(this.btEditerUnPdf);
            this.Controls.Add(this.grpContact);
            this.Controls.Add(this.grpDepenses);
            this.Controls.Add(this.grpEvenement);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormJdB";
            this.Text = "Journal de Board";
            this.Load += new System.EventHandler(this.FormJdB_Load);
            this.grpEvenement.ResumeLayout(false);
            this.grpEvenement.PerformLayout();
            this.grpDepenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepenses)).EndInit();
            this.grpContact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
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