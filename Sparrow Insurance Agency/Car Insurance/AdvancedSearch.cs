//Created By: Ramil Ignacio
using System;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Car_Insurance
{
    public partial class AdvancedSearch : Form
    {
        PolicyList policyList;

        public AdvancedSearch(PolicyList policyList)
        {
            InitializeComponent();

            this.policyList = policyList; //to access functions in parent form
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            policyList.GetPolicyList(txtBoxMotorNo.Text, txtBoxPolicyNo.Text, 
                txtBoxAssured.Text, txtBoxPlateNo.Text, txtBoxSerialNo.Text, 
                cmbBoxStatus.Text);
        }

        private void AdvancedSearch_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear Search Filter
            txtBoxMotorNo.Text = txtBoxAssured.Text = txtBoxPolicyNo.Text = 
                txtBoxPlateNo.Text = txtBoxSerialNo.Text = cmbBoxStatus.Text = "";

            policyList.GetPolicyList(txtBoxMotorNo.Text, txtBoxPolicyNo.Text,
                txtBoxAssured.Text, txtBoxPlateNo.Text, txtBoxSerialNo.Text,
                cmbBoxStatus.Text);
        }
    }
}
