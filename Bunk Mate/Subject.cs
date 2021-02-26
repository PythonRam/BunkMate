using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bunk_Mate
{
    public partial class Subject : Form
    {
        public int whichTab=00;
        public Subject()
        {
            InitializeComponent();
        }

        public Subject(int subject)
        {
            InitializeComponent();
            showData(lblSubjectTitle, 0, subject,1);
            showData(lblTotalClasses, 0, subject, 2);
            showData(lblAttended, 0, subject, 3);
            showData(lblBunked, 0, subject, 4);
            showData(lblPercentage, 0, subject, 5);
            try
            {
                txtComment.Text = (Convert.ToInt16(lblPercentage.Text) <= 75) ? "Attendence is low try not to bunk anymore classes" : "Attendence is pretty good keep up ";
            }
            catch
            {
                txtComment.Text = "Please update the program to continue";

            }
            txtComment.ReadOnly = true;
            
            showData(lblS1, 2, subject,2);
            showData(lblS2, 1, subject,2);
            showData(lblAss, 3, subject,2);

        }
        private void showData(Label lbl,int a,int subject,int b)
         {
            try
            {
                lbl.Text = UniversalValues.StudentData.Tables[a].Rows[subject][b].ToString();
            }
            catch
            {
                lbl.Hide();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            whichTab = 1;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            whichTab = 2;
            Close();
        }

    }
}
