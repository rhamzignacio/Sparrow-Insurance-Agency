using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Car_Insurance.Report
{
    public partial class SalesAgent : Form
    {
        TextBox agentID;
        TextBox txtBoxAgent;
        public SalesAgent(TextBox agentID, TextBox txtBoxAgent)
        {
            InitializeComponent();

            GetAgents("");

            this.agentID = agentID;

            this.txtBoxAgent = txtBoxAgent;
        }

        private void GetAgents(string searchKey)
        {
            listViewAgent.Items.Clear();

            using (var db = new SparrowEntities())
            {
                var agents = db.SalesAgent.OrderBy(r => r.LastName).AsQueryable();

                if (searchKey != "")
                {
                    if (radBtnAgentNo.Checked)
                        agents = agents.Where(r => r.AgentNo.Contains(searchKey));
                    else if (radBtnFirstName.Checked)
                        agents = agents.Where(r => r.FirstName.ToLower().Contains(searchKey.ToLower()));
                    else if (radBtnLastName.Checked)
                        agents = agents.Where(r => r.LastName.ToLower().Contains(searchKey.ToLower()));
                }

                agents.ToList().ForEach(agent =>
                {
                    ListViewItem lvi = new ListViewItem(agent.ID.ToString());

                    lvi.SubItems.Add(agent.AgentNo.ToString());

                    lvi.SubItems.Add(agent.FirstName + " " + agent.LastName);

                    listViewAgent.Items.Add(lvi);
                });
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetAgents(txtBoxSearch.Text);
        }

        private void txtBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                GetAgents(txtBoxSearch.Text);
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (listViewAgent.SelectedItems != null)
            {
               agentID.Text = listViewAgent.SelectedItems[0].SubItems[0].Text.ToString();
               txtBoxAgent.Text = listViewAgent.SelectedItems[0].SubItems[2].Text.ToString();

                Close();
            }
            else //No data selected
                MessageBox.Show("Please select data from list");
        }
    }
}
