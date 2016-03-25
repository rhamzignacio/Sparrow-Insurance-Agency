using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sparrow_Insurance_Agency.Car_Insurance;
using Sparrow_Insurance_Agency.Transaction_History;
using Sparrow_Insurance_Agency.Setup.Agent;
using Sparrow_Insurance_Agency.Setup.Bank;
using Sparrow_Insurance_Agency.Setup.Make;
using Sparrow_Insurance_Agency.Car_Insurance.Report;

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

        private void newClientToolStripMenuItem_Click(object sender, EventArgs e) //New Policy Writing
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

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePage();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) //Logout
        {
            this.Close();
        }  

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void newToolStripMenuItem1_Click(object sender, EventArgs e) //New Bank
        {
            OpenBank form = new OpenBank(Guid.Empty);

            form.ShowDialog();
        }

        private void bankListToolStripMenuItem_Click(object sender, EventArgs e) //Bank List
        {
            BankList form = new BankList();

            form.Show();
        }

        private void newMakeToolStripMenuItem_Click(object sender, EventArgs e) //New Make
        {
            OpenMake form = new OpenMake(Guid.Empty);

            form.ShowDialog();
        }

        private void makeListToolStripMenuItem_Click(object sender, EventArgs e) //Make list
        {
            MakeList form = new MakeList();

            form.Show();
        }

        private void totalIncomeToolStripMenuItem_Click(object sender, EventArgs e) //Total Income
        {
            Total_Income form = new Total_Income();

            form.Show();
        }

        private void carInsuranceSummaryToolStripMenuItem_Click(object sender, EventArgs e) //Car Insurance Summary
        {
            CarInsuranceSummary form = new CarInsuranceSummary();

            form.Show();
        }

        private void salesAgentCommissionToolStripMenuItem_Click(object sender, EventArgs e)//Sales Agent Commission
        {
            SalesAgentIncome form = new SalesAgentIncome();

            form.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) //New User
        {

        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e) //New user list
        {

        }
    }
}
