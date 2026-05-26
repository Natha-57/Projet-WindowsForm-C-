using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Visualisation_et_MAJ_missions
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pbHome.SizeMode = PictureBoxSizeMode.CenterImage;
            pbHome.SizeMode = PictureBoxSizeMode.Zoom;
            pbHome.Image = Image.FromFile(@"C:\Users\micka\OneDrive\Bureau\REDACTED_PROJECT_NAME\REDACTED_PROJECT_NAME\Resources\home.png");

            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
