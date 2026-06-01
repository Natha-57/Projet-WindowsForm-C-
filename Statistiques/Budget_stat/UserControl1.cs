using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Budget_stat
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public UserControl1(String nommission, String[] depenses, float[] prix, float budget )
        {
            label3.Text = nommission;
            label1.Text = "Budget initial de la mission : " + budget.ToString();
            float b = 0;
            foreach (float nb in prix)
            {
                b += nb;
            }
            if(b > budget)
            {
                label2.Text = "Budget final : " + b.ToString();
            }
            else
            {
                label2.Text = "Budget final : " + budget.ToString();
            }
            for(int i = 0; i< nommission.Length; i++)
            {
                Label lab = new Label();
                lab.AutoSize = true;
                lab.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lab.Location = new System.Drawing.Point(60, 141 + i*20);
                lab.Text = depenses[i] + "\t---\t" + prix[i].ToString();
            }
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
