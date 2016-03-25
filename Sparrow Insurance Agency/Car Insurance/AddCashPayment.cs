using System;
using System.Windows.Forms;
using Sparrow_Insurance_Agency.Utilities;

namespace Sparrow_Insurance_Agency.Car_Insurance
{
    public partial class AddCashPayment : Form
    {
        PolicyWriting parentForm;
        TextboxUtilities utilities = new TextboxUtilities();
        decimal totalPayable;

        public AddCashPayment(PolicyWriting parentForm, decimal totalPayable)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.totalPayable = totalPayable;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilities.TextBoxIntergerOnly(sender, e);
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (txtBoxAmount.Text != "")
            {
                if (totalPayable >= decimal.Parse(txtBoxAmount.Text))
                {
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToShortDateString()); //Date

                    lvi.SubItems.Add(string.Format("{0:0.00}", decimal.Parse(txtBoxAmount.Text))); //Amount

                    lvi.SubItems.Add(txtBoxRemarks.Text); //Remarks

                    parentForm.listViewPayment.Items.Add(lvi);

                    parentForm.totalPaid = parentForm.totalPaid + decimal.Parse(txtBoxAmount.Text);

                    Close();
                }
                else
                    MessageBox.Show("Amount is greater than total payable", "Error");
            }
            else
                MessageBox.Show("Amount is required", "Error");
        }
    }
}
