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

            cmbBoxDateType.Text = "N/A";

            datePickerTo.Hide();

            datePickerFrom.Hide();

            lblTo.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            policyList.GetPolicyList(txtBoxMotorNo.Text, txtBoxPolicyNo.Text, 
                txtBoxAssured.Text, txtBoxPlateNo.Text, txtBoxSerialNo.Text);
        }

        private void AdvancedSearch_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear Search Filter
            txtBoxMotorNo.Text = txtBoxAssured.Text = txtBoxPolicyNo.Text = 
                txtBoxPlateNo.Text = txtBoxSerialNo.Text = "";

            policyList.GetPolicyList(txtBoxMotorNo.Text, txtBoxPolicyNo.Text,
                txtBoxAssured.Text, txtBoxPlateNo.Text, txtBoxSerialNo.Text);
        }

        private void cmbBoxDateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBoxDateType.Text == "Date Range")
            {
                datePickerFrom.Show();
                datePickerTo.Show();
                lblTo.Show();
            }
            else if(cmbBoxDateType.Text == "Exact Date")
            {
                datePickerFrom.Show();
                datePickerTo.Hide();
                lblTo.Hide();
            }
            else
            {
                datePickerFrom.Hide();
                datePickerTo.Hide();
                lblTo.Hide();
            }
        }
    }
}
