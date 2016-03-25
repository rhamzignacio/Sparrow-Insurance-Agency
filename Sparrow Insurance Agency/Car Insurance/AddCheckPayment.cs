//Created by: Ramil Ignacio
using System;
using System.Windows.Forms;
using Sparrow_Insurance_Agency.Utilities;
using Sparrow_Insurance_Agency.Class;
using System.Collections.Generic;

namespace Sparrow_Insurance_Agency.Car_Insurance
{
    public partial class AddCheckPayment : Form
    {
        TextboxUtilities utilities = new TextboxUtilities();
        PolicyWriting parentForm;

        Guid bankID;
        string bankName;
        decimal totalPayable = 0;

        private class BankDropDown
        {
            public Guid BankID { get; set; }
            public string BankName { set; get; }
        }
        
        public AddCheckPayment(PolicyWriting parentForm, decimal totalPayable)
        {
            InitializeComponent();

            this.parentForm = parentForm;
            this.totalPayable = totalPayable;

            GetBankList();
        }

        private void GetBankList()//initialize data upon loading form
        {
            cmbBoxBank.Items.Clear();
            List<BankDropDown> bankList = new List<BankDropDown>();

            var banks = new AdminModel().GetAllActiveBanks();//load bank list to dropdown list

            banks.ForEach(bank =>
            {               
                BankDropDown bankDropdown = new BankDropDown
                {
                    BankID = bank.ID,
                    BankName = bank.Name
                };
                bankList.Add(bankDropdown);
            });
            cmbBoxBank.ValueMember = "BankID";
            cmbBoxBank.DisplayMember = "BankName";
            cmbBoxBank.DataSource = bankList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            string errorMessage = "";

            if (txtBoxAmount.Text == "")
                errorMessage += "Amount is required \n";

            if (txtBoxCheckNo.Text == "")
                errorMessage += "Check No. is required \n";

            if (txtBoxCheckName.Text == "")
                errorMessage += "Name is required \n";

            if (errorMessage == "")
            {
                if (totalPayable >= decimal.Parse(txtBoxAmount.Text))
                {
                    ListViewItem lvi = new ListViewItem(checkDatePicker.Text); //Check Date

                    lvi.SubItems.Add(bankName); //Bank

                    lvi.SubItems.Add(txtBoxCheckNo.Text); //Check No.

                    lvi.SubItems.Add(txtBoxCheckName.Text); //Check Name

                    lvi.SubItems.Add(string.Format("{0:0.00}", decimal.Parse(txtBoxAmount.Text))); //Amount

                    lvi.SubItems.Add(txtBoxRemarks.Text); //Remarks

                    lvi.SubItems.Add(bankID.ToString()); //BankID

                    parentForm.listViewPayment.Items.Add(lvi);

                    parentForm.totalPaid = parentForm.totalPaid + decimal.Parse(txtBoxAmount.Text);

                    Close();
                }
                else
                    MessageBox.Show("Amount is greater than total payable","Error");
            }
            else
                MessageBox.Show(errorMessage, "Error");
        }

        private void txtBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilities.TextBoxIntergerOnly(sender, e); //accepts integer only
        }

        private void cmbBoxBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            bankID = Guid.Parse(cmbBoxBank.SelectedValue.ToString());
            bankName = cmbBoxBank.Text;
        }
    }
}
