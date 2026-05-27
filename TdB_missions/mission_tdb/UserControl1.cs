using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mission_tdb
{
    public partial class UserControl1: UserControl
    {
        Form f;
        public UserControl1()
        {
            InitializeComponent();
        }
        public UserControl1(string nom_mission, string date_dep, string date_fin, string nom_chef, string image_path )
        {
            InitializeComponent();
            label1.Text = nom_mission;
            label2.Text = date_dep;
            label3.Text = date_fin;
            label4.Text = nom_chef;
            pictureBox1.Image = Image.FromFile(image_path);
     
            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
        public Button getBoutton()
        {
            return this.button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.ShowDialog();
        }
    }
}
