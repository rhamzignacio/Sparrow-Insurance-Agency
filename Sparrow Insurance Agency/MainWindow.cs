using System;
using System.Windows.Forms;
using Sparrow_Insurance_Agency.Car_Insurance;
using Sparrow_Insurance_Agency.Transaction_History;
using Sparrow_Insurance_Agency.Setup.Agent;
using Sparrow_Insurance_Agency.Setup.Bank;
using Sparrow_Insurance_Agency.Setup.Make;
using Sparrow_Insurance_Agency.Car_Insurance.Report;
using Sparrow_Insurance_Agency.Setup.UserProfile;

namespace Sparrow_Insurance_Agency
{
    public partial class MainWindow : Form
    {
        Guid currentUser;

        public MainWindow(Guid user)
        {
            InitializeComponent();

            if (user != Guid.Empty)
            {
                currentUser = user;

                //HomePage();//show homepage
            }
        }

        private void HomePage()
        {
            panelMain.Controls.Clear();

            Home form = new Home(currentUser);
            form.TopLevel = false;
            form.Visible = true;

            panelMain.Controls.Add(form);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();
        }

        private void newClientToolStripMenuItem_Click(object sender, EventArgs e) //Car Insurance - New Policy Writing
        {
            panelMain.Controls.Clear();

            PolicyWriting form = new PolicyWriting(currentUser, Guid.Empty);
            form.TopLevel = false;
            form.Visible = true;

            panelMain.Controls.Add(form);
        }

        private void clientListToolStripMenuItem_Click(object sender, EventArgs e) //Policy List
        {
            panelMain.Controls.Clear();

            PolicyList form = new PolicyList(currentUser);
            form.TopLevel = false;
            form.Visible = true;

            panelMain.Controls.Add(form);
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e) //Home
        {
            //HomePage();

            panelMain.Controls.Clear(); //Clear loaded form
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) //Logout
        {
            Close();
        }  

        private void historyToolStripMenuItem_Click(object sender, EventArgs e) //Setup - History
        {
            panelMain.Controls.Clear();

            TransHistoryList form = new TransHistoryList();
            form.TopLevel = false;
            form.Visible = true;

            panelMain.Controls.Add(form);
        }

        private void salesAgentListToolStripMenuItem_Click(object sender, EventArgs e) //Sales Agent List
        {
            AgentList form = new AgentList();

            form.Show();
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e) //New Sales Agent
        {
            OpenAgent form = new OpenAgent(Guid.Empty);

            form.ShowDialog();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e) //Setup - Bank - New Bank
        {
            OpenBank form = new OpenBank(Guid.Empty);

            form.ShowDialog();
        }

        private void bankListToolStripMenuItem_Click(object sender, EventArgs e) //Setup - Bank - Bank List
        {
            BankList form = new BankList();

            form.Show();
        }

        private void newMakeToolStripMenuItem_Click(object sender, EventArgs e) //Setup - Make - New Make
        {
            OpenMake form = new OpenMake(Guid.Empty);

            form.ShowDialog();
        }

        private void makeListToolStripMenuItem_Click(object sender, EventArgs e) //Setup - Make - Make list
        {
            MakeList form = new MakeList();

            form.Show();
        }

        private void totalIncomeToolStripMenuItem_Click(object sender, EventArgs e) //Report - Total Income
        {
            Total_Income form = new Total_Income();

            form.Show();
        }

        private void carInsuranceSummaryToolStripMenuItem_Click(object sender, EventArgs e) //Report - Car Insurance Summary
        {
            CarInsuranceSummary form = new CarInsuranceSummary();

            form.Show();
        }

        private void salesAgentCommissionToolStripMenuItem_Click(object sender, EventArgs e)//Rerpot - Sales Agent Commission
        {
            SalesAgentIncome form = new SalesAgentIncome();

            form.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) //Setup - User - New User
        {
            OpenUser form = new OpenUser(Guid.Empty);

            form.Show();
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e) //Setup - User - New user list
        {
            UserList form = new UserList();

            form.Show();
        }

        private void housingLoanToolStripMenuItem_Click(object sender, EventArgs e) //Housing Loan
        {
            MessageBox.Show("Housing-loan module is not yet available on this version", "Warning");
        }
    }
}
