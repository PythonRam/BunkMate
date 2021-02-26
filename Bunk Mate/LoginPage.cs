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
    public partial class LoginPage : Form
    {
        public string tables;
        public List<string> info;
        public bool loginSuccess = false;
        public string websisStatus;
        public LoginPage()
        {
            InitializeComponent();
            this.CenterToParent();
            txtboxPassword.PasswordChar = '\u25CF';
        }
        public LoginPage(string USERNAME,string PASSWORD)
        {
            Login(USERNAME,PASSWORD);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            Close();
            
        }
      
           
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(txtboxUserName.Text, txtboxPassword.Text);
        }

        private void LoginPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsInputKey(Keys.Enter)) { btnLogin.Focus(); }
        }
        private void CreateDataLink()
        {
            string DataLink= "http://websismit.manipal.edu/sis/control/ListCTPEnrollment?customTimePeriodId=";
            int month= DateTime.Now.Month;
            if (month<=7)
            {
                DataLink = DataLink + "MAY" + DateTime.Now.Year;
            }
            else
            {
                DataLink = DataLink + "NOV" + DateTime.Now.Year;
            }
            Properties.Settings.Default.DataLink = DataLink;

        }
        private void Login(string USERNAME,string PASSWORD)
        {
            CreateDataLink();
            Request req = new Request(Properties.Settings.Default.LoginLink, Properties.Settings.Default.DataLink, USERNAME, PASSWORD);
            if (req.loginFailed)
            {
                loginSuccess = false; websisStatus = req.webSisStatus;
                if (!req.networkUp)
                {
                     MessageBox.Show("Please check the network connection before trying to update");
                }

                else
                {
                    MessageBox.Show("Please Check for the password it has been updated or changed "); 
                }
            }
            else
            {
                UniversalValues.USERNAME = USERNAME;
                UniversalValues.PASSWORD = PASSWORD;
                UniversalValues.changed = true;
                Properties.Settings.Default.USERNAME = UniversalValues.USERNAME;
                Properties.Settings.Default.PASSWORD = UniversalValues.PASSWORD;
                Properties.Settings.Default.SyncTime = DateTime.Now;
                Properties.Settings.Default.Save();
                websisStatus = req.webSisStatus;
                info = req.info;
                loginSuccess = true;
                Close();
            }

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
