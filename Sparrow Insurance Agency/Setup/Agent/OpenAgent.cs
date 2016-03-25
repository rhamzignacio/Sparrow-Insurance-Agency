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
    public partial class OpenAgent : Form
    {
        Guid agentID = Guid.Empty;
        public OpenAgent(Guid agentID)
        {
            InitializeComponent();
            if(agentID == Guid.Empty) //New
            {
                btnAdd.Text = "Save";
            }
            else //Update
            {
                this.agentID = agentID;

                GetAgent();

                btnAdd.Text = "Update";
            }
        }

        private void SaveUpdateAgent()
        {
            string errorMessage = "";

            if (txtBoxAgentNo.Text == "")
                errorMessage += "Agent No. is required\n";

            if (txtBoxFirstName.Text == "")
                errorMessage += "First name is required\n";

            if (txtBoxLastName.Text == "")
                errorMessage += "Last name is required\n";

            if (errorMessage == "")
            {
                try {
                    using (var db = new SparrowEntities())
                    {
                        if (agentID == Guid.Empty) //Add
                        {
                            SalesAgent newAgent = new SalesAgent
                            {
                                ID = Guid.NewGuid(),
                                FirstName = txtBoxFirstName.Text,
                                MiddleName = txtBoxMiddleName.Text,
                                LastName = txtBoxLastName.Text,
                                AgentNo = txtBoxAgentNo.Text,
                                FullName = txtBoxFirstName.Text + " " +txtBoxMiddleName.Text + " " +txtBoxLastName.Text
                            };
                            var ifExist = db.SalesAgent.FirstOrDefault(r => r.FullName.ToLower() == newAgent.FullName.ToLower());

                            if(ifExist == null)
                                db.Entry(newAgent).State = EntityState.Added;
                            else
                            {
                                MessageBox.Show("Sales agent already exist", "Error");
                                return;
                            }
                        }
                        else //Update
                        {
                            var updateAgent = db.SalesAgent.FirstOrDefault(r => r.ID == agentID);
                            updateAgent.FirstName = txtBoxFirstName.Text;
                            updateAgent.MiddleName = txtBoxMiddleName.Text;
                            updateAgent.LastName = txtBoxLastName.Text;
                            updateAgent.AgentNo = txtBoxAgentNo.Text;
                            updateAgent.FullName = txtBoxFirstName.Text + " " + txtBoxMiddleName.Text + " " + txtBoxLastName.Text;

                            db.Entry(updateAgent).State = EntityState.Modified;
                        }

                        db.SaveChanges();
                        MessageBox.Show("Successfully saved", "Sales Agent");
                        Close();
                    }
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message, "Error on saving");
                }
            }
            else
                MessageBox.Show(errorMessage, "Error on saving");
        }

        private void GetAgent()
        {
            using(var db = new SparrowEntities())
            {
                var agent = db.SalesAgent.FirstOrDefault(r => r.ID == agentID);

                txtBoxAgentNo.Text = agent.AgentNo;
                txtBoxFirstName.Text = agent.FirstName;
                txtBoxLastName.Text = agent.LastName;
                txtBoxMiddleName.Text = agent.MiddleName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveUpdateAgent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBoxMiddleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxAgentNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
