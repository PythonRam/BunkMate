using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Net;
namespace Bunk_Mate
{
    public partial class BunkMateMainPage : Form
    {
        private List<string> info;
       
        public BunkMateMainPage()
        {
            InitializeComponent();
            this.CenterToScreen();
            /*
             Properties.Settings.Default.USERNAME = null;
             Properties.Settings.Default.PASSWORD = null;
             Properties.Settings.Default.Save();
            */
            this.StatsDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.bunksDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            lblSyncDate.Text = UniversalValues.SyncTime.ToString();
            WebRequest request = WebRequest.Create("http://websismit.manipal.edu/websis/control/main");
            bunksPanel.Hide();
            bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if(networkUp)
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response == null || response.StatusCode != HttpStatusCode.OK) { lblWebsisStatus.Text = "Down at " + DateTime.Now.ToString(); }
                else { lblWebsisStatus.Text = "Websis is up and running"; }
            }
            else
            {
                MessageBox.Show("No internet connection the last successfull update data will be displayed ");
                lblWebsisStatus.Text = "No internet connection";
            }


            if (UniversalValues.DoExist())
            {

                //Properties.Settings.Default.FirstRun = test;
                if (Properties.Settings.Default.FirstRun)
                {
                    Properties.Settings.Default.FirstRun = false;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.SyncTime = DateTime.Now;
                    createStudentDataXML();
                    if(tryLogin())
                    {
                        MessageBox.Show("Try login using the menu above");
                        
                    }


                    // UniversalValues.Load();
                    // setData();
                }
                else
                {
                    UniversalValues.Load();
                    setData();
                }
            }
            else
            {
                createStudentDataXML();
                tryLogin();

            }
        }


        private void createStudentDataXML()

        {
            if (!(System.IO.File.Exists("StudentData.xml")))
            {
                XmlTextWriter writer = new XmlTextWriter("StudentData.xml", System.Text.Encoding.UTF8);

            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tryLogin();


        }


        private void dataChange(List<string> info)
        {
            DateTime now = DateTime.Now;

            DataTable AttendenceTable = HTMLToDataTable.ParseTable(info[1]);


            DataTable[] InternalsTable = new DataTable[3];
            InternalsTable[0] = HTMLToDataTable.ParseTable(info[2]);
            InternalsTable[1] = HTMLToDataTable.ParseTable(info[3]);
            InternalsTable[2] = HTMLToDataTable.ParseTable(info[4]);


            DataTable StatsTable = getInternals(InternalsTable, AttendenceTable);

            UniversalValues.StudentData.Tables.Clear();
            UniversalValues.StudentData.Tables.Add(AttendenceTable);
            UniversalValues.StudentData.Tables.AddRange(InternalsTable);
            UniversalValues.StudentData.Tables.Add(StatsTable);
            UniversalValues.Save();

            setData();

        }
        private void firstRun(bool fr)
        {
            if (fr)
            {
                string data;
                using (StreamReader sr = new StreamReader(@"C:\Users\MAHE\Documents\Bunk Mate\Bunk Mate\RequestsForC#\data.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    data = sr.ReadToEnd();


                }
                info = Sorting.GetTables(data);
                dataChange(info);
            }

        }
        private void setData()
        {


            giveDataSource(Internals1DataView, 1, lblS1);
            giveDataSource(Internals2DataView, 2, lblS2);
            giveDataSource(Internals3DataView, 3, lblAss);

            UniversalValues.StudentData.Tables[0].Columns.RemoveAt(UniversalValues.StudentData.Tables[0].Columns.Count - 1);
            giveDataSource(AttendenceDataView, 0, lblAtt);


            setlabels(UniversalValues.StudentData.Tables[0]);

            StatsDataView.DataSource = (UniversalValues.StudentData.Tables[4]);

            setNumerics((UniversalValues.StudentData.Tables[0]));
            
            makeAttendenceGraph(UniversalValues.StudentData.Tables[4]);
            UniversalValues.Save();

        }
        private void giveDataSource(DataGridView ID, int index, Label lbl)
        {
            if (doesTableExist(index))
            {
                DataTable dt = UniversalValues.StudentData.Tables[index].Copy();
                dt.Columns.RemoveAt(0);
                ID.DataSource = dt;


                lbl.Hide();
            }
            else
            {
                ID.BackgroundColor = System.Drawing.Color.LightGray;
                lbl.Show();
                lbl.Text = "Not uploaded yet";

                lbl.Size = lbl.Parent.Size;


            }
        }

        private bool doesTableExist(int index)
        {
            if (UniversalValues.StudentData.Tables[index].Columns.Count <= 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void setlabels(DataTable AttendenceTable)
        {
            Subject1.Text = AttendenceTable.Rows[0][1].ToString();
            label4.Text = AttendenceTable.Rows[0][1].ToString();

            Subject2.Text = AttendenceTable.Rows[1][1].ToString();
            label5.Text = AttendenceTable.Rows[1][1].ToString();

            Subject3.Text = AttendenceTable.Rows[2][1].ToString();
            label6.Text = AttendenceTable.Rows[2][1].ToString();

            Subject4.Text = AttendenceTable.Rows[3][1].ToString();
            label7.Text = AttendenceTable.Rows[3][1].ToString();

            Subject5.Text = AttendenceTable.Rows[4][1].ToString();
            label8.Text = AttendenceTable.Rows[4][1].ToString();

            Subject6.Text = AttendenceTable.Rows[5][1].ToString();
            label9.Text = AttendenceTable.Rows[5][1].ToString();
        }
        private bool tryLogin()
        {
            bool loginFailed=false;
            LoginPage Lp = new LoginPage();
            Lp.ShowDialog();
            lblWebsisStatus.Text ="Websis is :"+ Lp.websisStatus;
            if (Lp.loginSuccess)
            {

                dataChange(Lp.info);
                MessageBox.Show("Login success");
                loginFailed = false;
            }
            else
            {
                MessageBox.Show("Login failed");
                loginFailed = true;
            }
            return loginFailed;


        }
        public void TryLogin(string USERNAME, string PASSWORD)
        {
           LoginPage Lp = new LoginPage(USERNAME, PASSWORD);
             lblWebsisStatus.Text ="Websis is "+ Lp.websisStatus;
            if (Lp.loginSuccess)
            {
                Properties.Settings.Default.USERNAME = USERNAME;
                Properties.Settings.Default.PASSWORD = PASSWORD;
                Properties.Settings.Default.SyncTime = DateTime.Now;
                Properties.Settings.Default.Save();
                dataChange(Lp.info);
                MessageBox.Show("Update success");
            }

        }
        private DataTable getInternals(DataTable[] dt, DataTable at)
        {
            DataTable rt = new DataTable();
            rt.Columns.Add("Course Code");
            rt.Columns.Add("Course Name");
            rt.Columns.Add("Attendence");
            rt.Columns["Attendence"].DataType = typeof(double);


            rt.Columns.Add("Internals");
            rt.Columns["Internals"].DataType = typeof(double);
            DataColumn dc = new DataColumn();
           

            for (int i = 0; i < dt[0].Rows.Count; i++)
            {
                
                if(dt[2].Rows.Count==dt[0].Rows.Count)
                {
                    rt.Rows.Add(at.Rows[i][0].ToString(),
                   at.Rows[i][1].ToString(),
                   Convert.ToDouble(at.Rows[i][5].ToString()),
                    Convert.ToDouble(dt[0].Rows[i][1]) + Convert.ToDouble(dt[1].Rows[i][2]) + Convert.ToDouble(dt[2].Rows[i][2]));
                }
                else
                {
                    if(dt[1].Rows.Count==dt[0].Rows.Count)
                    {
                        rt.Rows.Add(at.Rows[i][0].ToString(),
                   at.Rows[i][1].ToString(),
                   Convert.ToDouble(at.Rows[i][5].ToString()),
                    Convert.ToDouble(dt[0].Rows[i][2]) + Convert.ToDouble(dt[1].Rows[i][2]));

                    }
                    else
                    {
                        try
                        {
                            rt.Rows.Add(at.Rows[i][0].ToString(),
                 at.Rows[i][1].ToString(),
                 Convert.ToDouble(at.Rows[i][5].ToString()),
                  Convert.ToDouble(dt[0].Rows[i][2]));
                        }
                        catch
                        {
                            rt.Rows.Add(at.Rows[i][0].ToString(),
                 at.Rows[i][1].ToString(),
                 Convert.ToDouble(at.Rows[i][5].ToString()),
                  "Not Uploaded yet");
                        }
                    }
                }
                

            }
        
    
            for(int k = 0; k < rt.Columns.Count; k++) { rt.Columns[k].ReadOnly = true; };
            makeAttendenceGraph(rt);
            return rt;
        }
        private void makeAttendenceGraph(DataTable dt)
        {


            AttendenceChart.Series["Attendence"].SetDefault(true);


            AttendenceChart.Series.Clear();
            AttendenceChart.ChartAreas.Clear();
            AttendenceChart.Text = "Attendence Chart";
            AttendenceChart.Series.Add("Attendence");
            AttendenceChart.ChartAreas.Add("ch1");
            AttendenceChart.DataSource = dt;
            AttendenceChart.GetType();
            AttendenceChart.ChartAreas[0].AxisY.Maximum = 100;
            AttendenceChart.ChartAreas[0].AxisY.Minimum = 0;
            AttendenceChart.ChartAreas[0].AxisY.Interval = 10;
            AttendenceChart.Series["Attendence"].IsValueShownAsLabel = true;
            AttendenceChart.Series["Attendence"].AxisLabel = "Attendence Chart";
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                AttendenceChart.Series["Attendence"].Points.AddXY(dt.Rows[i][1].ToString(),dt.Rows[i][2].ToString());
                
            }
            AttendenceChart.Series["Attendence"].AxisLabel = "Attendance";
            AttendenceChart.Update();
            
        }
      
        private void setNumerics (DataTable dt)
        {
            numericUpDown1.Minimum = Convert.ToDecimal(dt.Rows[0][4].ToString());
            numericUpDown2.Minimum = Convert.ToDecimal(dt.Rows[1][4].ToString());
            numericUpDown3.Minimum = Convert.ToDecimal(dt.Rows[2][4].ToString());
            numericUpDown4.Minimum = Convert.ToDecimal(dt.Rows[3][4].ToString());
            numericUpDown5.Minimum = Convert.ToDecimal(dt.Rows[4][4].ToString());
            numericUpDown6.Minimum = Convert.ToDecimal(dt.Rows[5][4].ToString());

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tryUpdate();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            openSubjectDialog(0);
        }
        private void openSubjectDialog(int a)
        {
            Subject S = new Subject(a);
            S.ShowDialog();
            if (S.whichTab == 1)
            {
                tabContents.SelectTab(0);
            }
            else if (S.whichTab == 2)
            {
                tabContents.SelectTab(1);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            openSubjectDialog(1);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            openSubjectDialog(2);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            openSubjectDialog(3);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            openSubjectDialog(4);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            openSubjectDialog(5);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tryUpdate();
            
        }
        private void tryUpdate()
        {
            
            TryLogin(UniversalValues.USERNAME, UniversalValues.PASSWORD);
            DateTime SyncTime = DateTime.Now;
            UniversalValues.SyncTime = SyncTime;
            Properties.Settings.Default.SyncTime = SyncTime;
            lblSyncDate.Text = SyncTime.ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tryUpdate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Course Name");
            dt.Columns.Add("Bunks");
            dt.Columns.Add("Date Updated");
            dt.Rows.Add(Subject1.Text,numericUpDown1.Value,DateTime.Today.ToString());
            dt.Rows.Add(Subject2.Text, numericUpDown2.Value, DateTime.Today.ToString());
            dt.Rows.Add(Subject3.Text, numericUpDown3.Value, DateTime.Today.ToString());
            dt.Rows.Add(Subject4.Text, numericUpDown4.Value, DateTime.Today.ToString());
            dt.Rows.Add(Subject5.Text, numericUpDown5.Value, DateTime.Today.ToString());
            dt.Rows.Add(Subject6.Text, numericUpDown6.Value, DateTime.Today.ToString());
            UniversalValues.StudentData.Tables.RemoveAt(UniversalValues.StudentData.Tables.Count - 1);
            UniversalValues.StudentData.Tables.Add(dt);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            bunksPanel.Show();
            DataTable dt = new DataTable();
            dt.Columns.Add("Course Name");
            dt.Columns.Add("Bunks");
            dt.Columns.Add("Date Updated");
            dt.Rows.Add(Subject1.Text, numericUpDown1.Value, DateTime.Today.ToShortDateString().ToString());
            dt.Rows.Add(Subject2.Text, numericUpDown2.Value, DateTime.Today.ToShortDateString().ToString());
            dt.Rows.Add(Subject3.Text, numericUpDown3.Value, DateTime.Today.ToShortDateString().ToString());
            dt.Rows.Add(Subject4.Text, numericUpDown4.Value, DateTime.Today.ToShortDateString().ToString());
            dt.Rows.Add(Subject5.Text, numericUpDown5.Value, DateTime.Today.ToShortDateString().ToString());
            dt.Rows.Add(Subject6.Text, numericUpDown6.Value, DateTime.Today.ToShortDateString().ToString());
            UniversalValues.StudentData.Tables.RemoveAt(UniversalValues.StudentData.Tables.Count - 1);
            UniversalValues.StudentData.Tables.Add(dt);
            dt.Columns["Course Name"].ReadOnly=true;
            
            dt.Columns["Date Updated"].ReadOnly=true;
            bunksDataView.DataSource= UniversalValues.StudentData.Tables[UniversalValues.StudentData.Tables.Count - 1];

        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            bunksPanel.Hide();
        }

        private void ViewScreenShot_Click(object sender, EventArgs e)
        {
            Screenshot ss = new Screenshot();
            ss.ShowDialog();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowIcon = true;
            ab.ShowDialog();

        }
    }


}
