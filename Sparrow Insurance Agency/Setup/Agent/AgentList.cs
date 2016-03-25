using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Setup.Agent
{
    public partial class AgentList : Form
    {
        public AgentList()
        {
            InitializeComponent();

            GetAgents();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetAgents();
        }

        private void GetAgents()
        {
            lstViewAgent.Items.Clear(); //Clear Items
            using(var db = new SparrowEntities())
            {
                var agents = db.SalesAgent.AsQueryable();

                if (txtSearch.Text != "")
                    agents = agents.Where(r => r.FullName.ToLower().Contains(txtSearch.Text.ToLower()));

                agents.ToList().ForEach(item =>
                {
                    ListViewItem lvi = new ListViewItem(item.ID.ToString()); //ID
                    lvi.SubItems.Add(item.AgentNo); //Agent No
                    lvi.SubItems.Add(item.FullName); //Name
                    lstViewAgent.Items.Add(lvi);
                });
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("You are about to delete an agent. Do you really wand to delete the selected agent?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Delete Code
                }
            }
            catch (Exception q)
            {
                MessageBox.Show("Unable to delete Agent. Error: " + q.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAddEditForm(Guid ID)
        {
            OpenAgent form = new OpenAgent(ID);
            form.ShowDialog();

            GetAgents();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenAddEditForm(Guid.Empty);
        }

        private void txtBoxEdit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenAddEditForm(Guid.Parse(lstViewAgent.SelectedItems[0].SubItems[0].Text));
            }
            catch
            {
                MessageBox.Show("Please select data on list", "Error");
            }
        }
    }
}
