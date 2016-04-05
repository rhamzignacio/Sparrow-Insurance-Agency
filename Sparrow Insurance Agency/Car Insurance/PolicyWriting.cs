//Created by: Ramil Ignacio

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sparrow_Insurance_Agency.Class;
using Sparrow_Insurance_Agency.Car_Insurance;
using Sparrow_Insurance_Agency.Utilities;
using Sparrow_Insurance_Agency.Car_Insurance.Report;
using System.Data.Entity;

namespace Sparrow_Insurance_Agency
{
    public partial class PolicyWriting : Form
    {
        Guid currentUser;
        public Guid AgentID;
        Guid policyID = Guid.Empty;
        TextboxUtilities utility = new TextboxUtilities();
        TransHistory history = new TransHistory();
        public decimal totalPaid = 0;

        public PolicyWriting(Guid user, Guid policyID)
        {
            InitializeComponent();

            GetMakeDropDown();

            GetMortageeDropDown();

            if (user != Guid.Empty)
                currentUser = user;

            if (policyID != Guid.Empty)
            {
                this.policyID = policyID;

                EnableDisableButton(true);

                GetPolicy();

                GetPayments();               
            }
            else
            {
                EnableDisableButton(false);

                CreatePaymentColumn("CASH");

                datePickerExpiryDate.Value = datePickerEffectivity.Value.AddYears(1);

                txtBoxPolicyNo.Focus();
            }                   
        }

        private void GetMortageeDropDown()
        {
            txtBoxMortage.Items.Clear();

            using (var db = new SparrowEntities())
            {
                var banks = db.BankProfile.ToList();

                banks.ForEach(item =>
                {
                    txtBoxMortage.Items.Add(item.Name);
                });
            }
        }

        private void GetMakeDropDown()
        {
            cmbBoxMake.Items.Clear();
            using (var db= new SparrowEntities())
            {
                var makes = db.MakeProfile.ToList();

                makes.ForEach(item =>
                {
                    cmbBoxMake.Items.Add(item.Name);
                });
            }
        }

        private void GetPayments()
        {
            using (var db = new SparrowEntities())
            {
                var policy = db.CarInsurancePolicy.FirstOrDefault(r => r.ID == policyID);
                var payments = db.CarInsurrancePayment.Where(r => r.CarInsurancePolicyID == policyID);

                if (policy.Payment_Method == "CASH")
                {
                    CreatePaymentColumn("CASH");
                    payments.ToList().ForEach(item =>
                    {
                        ListViewItem lvi = new ListViewItem(item.Date.ToShortDateString());
                        lvi.SubItems.Add(string.Format("{0:0.00}",item.Amount));
                        lvi.SubItems.Add(item.Remarks);

                        listViewPayment.Items.Add(lvi);
                    });
                }
                else
                {
                    CreatePaymentColumn("CHECK");
                    payments.ToList().ForEach(item =>
                    {
                        var bank = db.BankProfile.FirstOrDefault(r => r.ID == item.BankID);
                        ListViewItem lvi = new ListViewItem(item.Check_Date.ToString());
                        lvi.SubItems.Add(bank.Name);
                        lvi.SubItems.Add(item.Check_No);
                        lvi.SubItems.Add(item.Check_Name);
                        lvi.SubItems.Add(string.Format("{0:0.00}", item.Amount));
                        lvi.SubItems.Add(item.Remarks);

                        listViewPayment.Items.Add(lvi);
                    });
                }
            }
        }

        private void GetPolicy()
        {
            using (var db = new SparrowEntities())
            {
                var policy = db.CarInsurancePolicy.FirstOrDefault(r => r.ID == policyID);
                if (policy.Agent != Guid.Empty)
                {
                    var agent = db.SalesAgent.FirstOrDefault(r => r.ID == policy.Agent);

                    //Assign value to fields
                    //Text fields
                    txtBoxAgent.Text = agent.FullName;
                    AgentID = agent.ID;
                }
                txtBoxAssured.Text = policy.Assured;
                txtBoxDeductible.Text = policy.Deductible;
                txtBoxMortage.Text = policy.Mortagee;
                txtBoxMotorNo.Text = policy.MotorNo;
                txtBoxPlateNo.Text = policy.PlateNo;
                txtBoxPolicyNo.Text = policy.PolicyNo;
                txtBoxSerialNo.Text = policy.SerialNo;
                txtBoxUnit.Text = policy.Unit;
                txtBoxYearModel.Text = policy.YearModel;
                txtBoxColor.Text = policy.Color;

                //ComboBox
                cmbBoxCategory.Text = policy.Category;
                cmbBoxClass.Text = policy.Car_Class;
                cmbBoxMake.Text = policy.Car_Make;

                //Status
                if(policy.Status == "Canceled")
                {
                    lblStatus.ForeColor = Color.Red;
                    btnAdd.Enabled = btnRenew.Enabled = btnPrintPayment.Enabled =
                        btnCancel.Enabled = btnSave.Enabled = btnDelete.Enabled = false;
                }

                lblStatus.Text = policy.Status;

                //Amounts
                
                txtBoxPCPTL.Text = string.Format("{0:0.00}", policy.P_CTPL);
                txtBoxPExcessBodilyInjury.Text = string.Format("{0:0.00}", policy.P_ExcessBodilyInjury);
                txtBoxPLossAndDamage.Text = string.Format("{0:0.00}", policy.P_LossAndDamage);
                txtBoxPPersonalAccident.Text = string.Format("{0:0.00}", policy.P_PersonalAccident);
                txtBoxPVolPropertyDamage.Text = string.Format("{0:0.00}", policy.P_VolPropertyDamage);
                txtBoxTotalAnnualPremium.Text = string.Format("{0:0.00}", policy.TotalAnnualPremium);

                txtBoxGross.Text = string.Format("{0:0.00}", policy.Gross);
                txtBoxNet.Text = string.Format("{0:0.00}", policy.Net);
                lblPayable.Text = txtBoxGross.Text;
                ComputeGrossAndNet();
            }
        }

        private void CreatePaymentColumn(string paymentMethod)
        {
            listViewPayment.Clear();

            listViewPayment.View = View.Details;

            if (paymentMethod == "CASH")
            {
                listViewPayment.Columns.Add("Date", 150, HorizontalAlignment.Left);

                listViewPayment.Columns.Add("Amount", 150, HorizontalAlignment.Right);

                listViewPayment.Columns.Add("Remarks", 300, HorizontalAlignment.Left);
            }
            else
            {
                listViewPayment.Columns.Add("Check Date", 150, HorizontalAlignment.Left);

                listViewPayment.Columns.Add("Bank", 200, HorizontalAlignment.Left);

                listViewPayment.Columns.Add("Check No.", 150, HorizontalAlignment.Left);

                listViewPayment.Columns.Add("Check Name", 200, HorizontalAlignment.Left);

                listViewPayment.Columns.Add("Amount", 150, HorizontalAlignment.Right);

                listViewPayment.Columns.Add("Remarks", 300, HorizontalAlignment.Left);

                listViewPayment.Columns.Add("BankID", 0, HorizontalAlignment.Left);
            }
        }

        private void GetPayment(string paymentMethod)
        {
            using (var db = new SparrowEntities())
            {
                var payments = db.CarInsurrancePayment.Where(r => r.CarInsurancePolicyID == policyID).ToList();

                payments.ForEach(payment =>
                {
                    if (paymentMethod == "CASH")
                    {
                        listViewPayment.Items.Add(payment.Date.ToShortDateString());

                        listViewPayment.Items.Add(string.Format("{0:0.00}", payment.Amount));
                    }
                    else
                    {
                        var bank = db.BankProfile.FirstOrDefault(r => r.ID == payment.BankID);

                        listViewPayment.Items.Add(payment.Check_Date.ToString());

                        listViewPayment.Items.Add(bank.Name);

                        listViewPayment.Items.Add(payment.Check_No);

                        listViewPayment.Items.Add(payment.Check_Name);

                        listViewPayment.Items.Add(string.Format("{0:0.00}", payment.Amount));
                    }
                });
            }
        }

        private void SavePayments(Guid _policyID)
        {
            try
            {
                using (var db = new SparrowEntities())
                {
                    foreach (ListViewItem anItem in listViewPayment.Items)
                    {
                        string method = "";
                        if (radioButtonCash.Checked)
                            method = "CASH";
                        else
                            method = "CHECKED";

                        CarInsurrancePayment payment = new CarInsurrancePayment
                        {
                            ID = Guid.NewGuid(),
                            Date = DateTime.Parse(anItem.SubItems[0].Text),
                            Amount = decimal.Parse(anItem.SubItems[1].Text),
                            CarInsurancePolicyID = _policyID,
                            Method = method
                        };

                        db.Entry(payment).State = EntityState.Added;

                    }
                    db.SaveChanges();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error on saving payments");
            }
        }

        private bool IfPolicyNoExist()
        {
            using (var db = new SparrowEntities())
            {
                var policyNo = db.CarInsurancePolicy.FirstOrDefault(r => r.PolicyNo == txtBoxPolicyNo.Text && r.ID != policyID);

                if (policyNo != null)
                {
                    return true;
                }
                return false;
            }
        }

        #region FunctionsPolicy
        //Functions

        private void Save()
        {
            string errorMessage = "";

            if (txtBoxPolicyNo.Text == "")
                errorMessage += "Policy No. is required\n";

            if (txtBoxAssured.Text == "")
                errorMessage += "Assured is required\n";

            if (txtBoxYearModel.Text == "")
                errorMessage += "Year Model is required\n";

            if (txtBoxSerialNo.Text == "")
                errorMessage += "Serial No is required\n";

            if (txtBoxMotorNo.Text == "")
                errorMessage += "Motor No is required\n";

            if (txtBoxPlateNo.Text == "")
                errorMessage += "Plate No is required\n";

            if (txtBoxNet.Text == "")
                errorMessage += "Net is required \n";

            if (txtBoxTotalAnnualPremium.Text == "")
                errorMessage += "Net Remitance is required \n";

            if (txtBoxGross.Text == "")
                errorMessage += "Gross is required \n";

            if (decimal.Parse(txtBoxNet.Text) < decimal.Parse(txtBoxTotalAnnualPremium.Text))
                errorMessage += "Actual Total must be greater than or equal to Total Annual Premium \n";

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save ?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                using (var db = new SparrowEntities())
                {
                    if (errorMessage != "")
                    {
                        MessageBox.Show(errorMessage, "Error on Saving");
                    }
                    else
                    {
                        SavePolicy(); //Save Car insurance Policy
                    }
                }
            }
        }

        public void SavePolicy()
        {
            var db = new SparrowEntities();

            if (!IfPolicyNoExist())
            {
                if (policyID == Guid.Empty) //New Policy Writing
                {
                    CarInsurancePolicy policy = new CarInsurancePolicy();

                    policy.ID = policyID = Guid.NewGuid(); //Creates new Unique Identifier ID
                    policy.Status = lblStatus.Text;
                    policy.Assured = txtBoxAssured.Text;
                    policy.Address = rchTxtBoxAddress.Text;
                    policy.Mortagee = txtBoxMortage.Text;
                    policy.Effectivity = datePickerEffectivity.Value;
                    policy.Expiration_Date = datePickerExpiryDate.Value;
                    policy.Deductible = txtBoxDeductible.Text;
                    policy.YearModel = txtBoxYearModel.Text;
                    policy.Unit = txtBoxUnit.Text;
                    policy.SerialNo = txtBoxSerialNo.Text;
                    policy.MotorNo = txtBoxMotorNo.Text;
                    policy.PlateNo = txtBoxPlateNo.Text;
                    policy.Others = rchTextBoxOthers.Text;
                    policy.PolicyNo = txtBoxPolicyNo.Text;
                    policy.Agent = AgentID;
                    policy.Car_Class = cmbBoxClass.Text;
                    policy.Category = cmbBoxCategory.Text;
                    policy.Car_Make = cmbBoxMake.Text;
                    policy.Color = txtBoxColor.Text;
                    policy.CreateDate = datePickerWritingDate.Value;

                    if (radioButtonCash.Checked)
                        policy.Payment_Method = "CASH";
                    else
                        policy.Payment_Method = "CHECK";

                    //Amounts
                    policy.Paid = 0;

                    if (txtBoxTotalAnnualPremium.Text != "")
                        policy.TotalAnnualPremium = decimal.Parse(txtBoxTotalAnnualPremium.Text);
                    else
                        policy.TotalAnnualPremium = 0;

                    if (txtBoxNet.Text != "")
                        policy.Amount = policy.Balance = decimal.Parse(txtBoxNet.Text);
                    else
                        policy.Amount = policy.Balance = 0;

                    if (txtBoxPLossAndDamage.Text != "")
                        policy.P_LossAndDamage = decimal.Parse(txtBoxPLossAndDamage.Text);
                    else
                        policy.P_LossAndDamage = 0;

                    if (txtBoxPCPTL.Text != "")
                        policy.P_CTPL = decimal.Parse(txtBoxPCPTL.Text);
                    else
                        policy.P_CTPL = 0;

                    if (txtBoxPExcessBodilyInjury.Text != "")
                        policy.P_ExcessBodilyInjury = decimal.Parse(txtBoxPExcessBodilyInjury.Text);
                    else
                        policy.P_ExcessBodilyInjury = 0;

                    if (txtBoxPVolPropertyDamage.Text != "")
                        policy.P_VolPropertyDamage = decimal.Parse(txtBoxPVolPropertyDamage.Text);
                    else
                        policy.P_VolPropertyDamage = 0;

                    if (txtBoxPPersonalAccident.Text != "")
                        policy.P_PersonalAccident = decimal.Parse(txtBoxPPersonalAccident.Text);
                    else
                        policy.P_PersonalAccident = 0;

                    if (txtBoxGross.Text != "")
                        policy.Gross = decimal.Parse(txtBoxGross.Text);
                    else
                        policy.Gross = 0;

                    if (txtBoxNet.Text != "")
                        policy.Net = decimal.Parse(txtBoxNet.Text);
                    else
                        policy.Net = 0;

                    //Checkboxes
                    if (checkBoxAircon.Checked)
                        policy.Aircon = "Y";
                    else
                        policy.Aircon = "N";

                    if (checkBoxSterioSpeakers.Checked)
                        policy.SterioSpeakers = "Y";
                    else
                        policy.SterioSpeakers = "N";

                    if (checkBoxMagwheels.Checked)
                        policy.Magwheels = "Y";
                    else
                        policy.Magwheels = "N";

                    policy.CreateBy = currentUser;

                    try
                    {
                        decimal totalPaid = 0;

                        //Save Payments
                        foreach (ListViewItem anItem in listViewPayment.Items)
                        {                         
                            string method = "";

                            if (radioButtonCash.Checked)
                                method = "CASH";
                            else
                                method = "CHECKED";

                            if (method == "CASH")
                            {
                                CarInsurrancePayment cashPayment = new CarInsurrancePayment
                                {
                                    ID = Guid.NewGuid(),
                                    Date = DateTime.Now,
                                    Amount = decimal.Parse(anItem.SubItems[1].Text),
                                    CarInsurancePolicyID = policyID,
                                    Method = method
                                };

                                totalPaid += cashPayment.Amount;

                                db.Entry(cashPayment).State = EntityState.Added;
                            }
                            else //Check Payment
                            {
                                CarInsurrancePayment checkPayment = new CarInsurrancePayment
                                {
                                    ID = Guid.NewGuid(),
                                    Date = DateTime.Now,
                                    Check_Date = DateTime.Parse(anItem.SubItems[0].Text),
                                    BankID = Guid.Parse(anItem.SubItems[6].Text),
                                    Check_Name = anItem.SubItems[3].Text,
                                    Check_No = anItem.SubItems[2].Text,
                                    Amount = decimal.Parse(anItem.SubItems[4].Text),
                                    Remarks = anItem.SubItems[5].Text,
                                    CarInsurancePolicyID = policyID,
                                    Method = method
                                };

                                totalPaid += checkPayment.Amount;

                                db.Entry(checkPayment).State = EntityState.Added;
                            }
                        }//end of foreach

                        //update paid
                        policy.Paid = totalPaid;

                        db.Entry(policy).State = EntityState.Added;

                        db.SaveChanges();

                        MessageBox.Show("Saved Successfully");

                        EnableDisableButton(true);

                        history.Save("Added New Policy No: " + policy.PolicyNo, currentUser);
                    }
                    catch
                    {
                        MessageBox.Show("Error on saving", "Error");
                    }
                }
                else //Update Policy Writing
                {
                    var existingPolicy = db.CarInsurancePolicy.FirstOrDefault(r => r.ID == policyID);

                    if (existingPolicy != null)
                    {
                        existingPolicy.Status = lblStatus.Text;
                        existingPolicy.Assured = txtBoxAssured.Text;
                        existingPolicy.Address = rchTxtBoxAddress.Text;
                        existingPolicy.Mortagee = txtBoxMortage.Text;
                        existingPolicy.Effectivity = datePickerEffectivity.Value;
                        existingPolicy.Expiration_Date = datePickerExpiryDate.Value;
                        existingPolicy.Deductible = txtBoxDeductible.Text;
                        existingPolicy.YearModel = txtBoxYearModel.Text;
                        existingPolicy.Unit = txtBoxUnit.Text;
                        existingPolicy.SerialNo = txtBoxSerialNo.Text;
                        existingPolicy.MotorNo = txtBoxMotorNo.Text;
                        existingPolicy.PlateNo = txtBoxPlateNo.Text;
                        existingPolicy.Others = rchTextBoxOthers.Text;
                        existingPolicy.Agent = AgentID;                  
                        existingPolicy.CreateDate = datePickerWritingDate.Value;
                        existingPolicy.PolicyNo = txtBoxPolicyNo.Text;
                        existingPolicy.Car_Class = cmbBoxClass.Text;
                        existingPolicy.Category = cmbBoxCategory.Text;
                        existingPolicy.Car_Make = cmbBoxMake.Text;
                        existingPolicy.Color = txtBoxColor.Text;

                        if (radioButtonCash.Checked)
                            existingPolicy.Payment_Method = "CASH";
                        else
                            existingPolicy.Payment_Method = "CHECK";

                        //Amounts
                        if (txtBoxTotalAnnualPremium.Text != "")
                            existingPolicy.TotalAnnualPremium = decimal.Parse(txtBoxTotalAnnualPremium.Text);
                        else
                            existingPolicy.TotalAnnualPremium = 0;

                        if (txtBoxNet.Text != "")
                            existingPolicy.Amount = decimal.Parse(txtBoxNet.Text);
                        else
                            existingPolicy.Amount = 0;

                        if (txtBoxPLossAndDamage.Text != "")
                            existingPolicy.P_LossAndDamage = decimal.Parse(txtBoxPLossAndDamage.Text);
                        else
                            existingPolicy.P_LossAndDamage = 0;

                        if (txtBoxPCPTL.Text != "")
                            existingPolicy.P_CTPL = decimal.Parse(txtBoxPCPTL.Text);
                        else
                            existingPolicy.P_CTPL = 0;

                        if (txtBoxPExcessBodilyInjury.Text != "")
                            existingPolicy.P_ExcessBodilyInjury = decimal.Parse(txtBoxPExcessBodilyInjury.Text);
                        else
                            existingPolicy.P_ExcessBodilyInjury = 0;

                        if (txtBoxPVolPropertyDamage.Text != "")
                            existingPolicy.P_VolPropertyDamage = decimal.Parse(txtBoxPVolPropertyDamage.Text);
                        else
                            existingPolicy.P_VolPropertyDamage = 0;

                        if (txtBoxPPersonalAccident.Text != "")
                            existingPolicy.P_PersonalAccident = decimal.Parse(txtBoxPPersonalAccident.Text);
                        else
                            existingPolicy.P_PersonalAccident = 0;

                        if (txtBoxGross.Text != "")
                            existingPolicy.Gross = decimal.Parse(txtBoxGross.Text);
                        else
                            existingPolicy.Gross = 0;

                        if (txtBoxNet.Text != "")
                            existingPolicy.Net = decimal.Parse(txtBoxNet.Text);
                        else
                            existingPolicy.Net = 0;

                        //Checkboxes
                        if (checkBoxAircon.Checked)
                            existingPolicy.Aircon = "Y";
                        else
                            existingPolicy.Aircon = "N";

                        if (checkBoxSterioSpeakers.Checked)
                            existingPolicy.SterioSpeakers = "Y";
                        else
                            existingPolicy.SterioSpeakers = "N";

                        if (checkBoxMagwheels.Checked)
                            existingPolicy.Magwheels = "Y";
                        else
                            existingPolicy.Magwheels = "N";

                        try
                        {                           
                            //Save Payments
                            //Delate previous payment first
                            var payments = db.CarInsurrancePayment.Where(r => r.CarInsurancePolicyID == policyID);

                            payments.ToList().ForEach(item =>
                            {
                                db.Entry(item).State = EntityState.Deleted;
                            });

                            decimal totalPaid = 0;

                            foreach (ListViewItem anItem in listViewPayment.Items)
                            {
                                string method = "";
                                if (radioButtonCash.Checked)
                                    method = "CASH";
                                else
                                    method = "CHECKED";

                                if (method == "CASH")
                                {
                                    CarInsurrancePayment cashPayment = new CarInsurrancePayment
                                    {
                                        ID = Guid.NewGuid(),
                                        Date = DateTime.Now,
                                        Amount = decimal.Parse(anItem.SubItems[1].Text),
                                        CarInsurancePolicyID = policyID,
                                        Method = method
                                    };

                                    totalPaid += cashPayment.Amount;

                                    db.Entry(cashPayment).State = EntityState.Added;
                                }
                                else //Check Payment
                                {
                                    CarInsurrancePayment checkPayment = new CarInsurrancePayment
                                    {
                                        ID = Guid.NewGuid(),
                                        Date = DateTime.Now,
                                        Check_Date = DateTime.Parse(anItem.SubItems[0].Text),
                                        BankID = Guid.Parse(anItem.SubItems[6].Text),
                                        Check_Name = anItem.SubItems[3].Text,
                                        Check_No = anItem.SubItems[2].Text,
                                        Amount = decimal.Parse(anItem.SubItems[4].Text),
                                        Remarks = anItem.SubItems[5].Text
                                    };

                                    totalPaid += checkPayment.Amount;

                                    db.Entry(checkPayment).State = EntityState.Added;
                                }
                            }

                            existingPolicy.Paid = totalPaid;

                            db.Entry(existingPolicy).State = EntityState.Modified;

                            db.SaveChanges();

                            MessageBox.Show("Updated Successfully");

                            EnableDisableButton(true);

                            history.Save("Modified Policy No: " + existingPolicy.PolicyNo, currentUser);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "Error on Updating");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Policy no. already exist", "Error on saving");
        }

        public void EnableDisableButton(bool input)
        {
            //stand by function to be deleted if not used
            btnCancel.Enabled = input;
            btnRenew.Enabled = input;
        }

        //Enable textbox if the checkbox is ticked
        private void TickTextbox(bool ifChecked, TextBox textBox)
        {
            if (ifChecked)
                textBox.Enabled = true;
            else
            {
                textBox.Enabled = false;

                textBox.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void GetTotal()
        {
            //decimal lossDamage = 0, cptl = 0, excessBodily = 0, propertyDamage = 0, personalAccident = 0;

            //convert textbox to decimal and assign to responding variables
            //if (txtBoxPLossAndDamage.Text != "")
            //    lossDamage = decimal.Parse(txtBoxPLossAndDamage.Text);

            //if (txtBoxPCPTL.Text != "")
            //    cptl = decimal.Parse(txtBoxPCPTL.Text);

            //if (txtBoxPExcessBodilyInjury.Text != "")
            //    excessBodily = decimal.Parse(txtBoxPExcessBodilyInjury.Text);

            //if (txtBoxPPersonalAccident.Text != "")
            //    personalAccident = decimal.Parse(txtBoxPPersonalAccident.Text);

            //if (txtBoxPVolPropertyDamage.Text != "")
            //    propertyDamage = decimal.Parse(txtBoxPVolPropertyDamage.Text);

            //get SUM
            //total = lossDamage + cptl + excessBodily + propertyDamage + personalAccident;

            //txtBoxTotalAnnualPremium.Text = txtBoxGross.Text =
            //    txtBoxNet.Text = string.Format("{0:0.00}", total); //Total    
             
            //ComputeGrossAndNet();
            //lblPayable.Text = txtBoxGross.Text;
        }

        private void GetTotalPaid(int amountLocation) 
        {
            decimal total = 0;

            foreach (ListViewItem item in listViewPayment.Items)
            {
                total += decimal.Parse(item.SubItems[amountLocation].Text);
            }

            lblPaid.Text = string.Format("{0:0.00}", total);
        }

        private void ComputeGrossAndNet()
        {
            lblNet.Text = utility.AmountFormat(string.Format("{0:0.00}", (decimal.Parse(txtBoxNet.Text=="" ? "0.00" : txtBoxNet.Text) 
                - decimal.Parse(txtBoxTotalAnnualPremium.Text =="" ? "0.00" : txtBoxTotalAnnualPremium.Text))));

            lblGross.Text = utility.AmountFormat(string.Format("{0:0.00}", (decimal.Parse(txtBoxGross.Text =="" ? "0.00" 
                : txtBoxGross.Text) - decimal.Parse(txtBoxNet.Text == "" ? "0.00" : txtBoxNet.Text))));

            lblPayable.Text = txtBoxGross.Text;
        }

        #endregion


        #region Events
        //Events      

        private void txtBoxPLossAndDamage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxTotal_KeyUp(object sender, KeyEventArgs e)
        {

        }      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing is not yet available", "Error");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (policyID != Guid.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var db = new SparrowEntities())
                    {
                        try
                        {
                            var policy = db.CarInsurancePolicy.First(r => r.ID == policyID);

                            policy.Status = "Canceled";
                            db.Entry(policy).State = EntityState.Modified;
                            db.SaveChanges();

                            MessageBox.Show("Policy No: " + policy.PolicyNo + " successfully canceled");

                            lblStatus.Text = "Canceled";
                            lblStatus.BackColor = Color.Red;
                        }
                        catch
                        {
                            MessageBox.Show("Can't cancel policy some kind of error", "Error");
                        }
                    }
                }
                else
                    MessageBox.Show("Policy not yet saved", "Error");
            }
        }

        private void radioButtonCash_CheckedChanged(object sender, EventArgs e)
        {
            CreatePaymentColumn("CASH");
        }

        private void radioButtonCheck_CheckedChanged(object sender, EventArgs e)
        {
            CreatePaymentColumn("CHECK");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                if (radioButtonCash.Checked) //Cash
                {
                    AddCashPayment form = new AddCashPayment(this, decimal.Parse(lblPayable.Text));
                    form.ShowDialog();
                    GetTotalPaid(1);
                }
                else //Check
                {
                    AddCheckPayment form = new AddCheckPayment(this, decimal.Parse(lblPayable.Text));
                    form.ShowDialog();
                    GetTotalPaid(4);
                }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var temp = listViewPayment.SelectedItems[0].Text;

                DialogResult result = MessageBox.Show("Are you sure you want to Delete ?", "", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    listViewPayment.SelectedItems[0].Remove();
                }
            }
            catch
            {
                MessageBox.Show("Please select data from list", "Error");
            }
            
        }

        private void txtBoxPLossAndDamage_KeyPress(object sender, KeyPressEventArgs e)
        {
            utility.TextBoxIntergerOnly(sender, e);           
        }

        private void txtBoxPCPTL_KeyPress(object sender, KeyPressEventArgs e)
        {
            utility.TextBoxIntergerOnly(sender, e);
        }

        private void txtBoxPExcessBodilyInjury_KeyPress(object sender, KeyPressEventArgs e)
        {
            utility.TextBoxIntergerOnly(sender, e);
        }

        private void txtBoxPVolPropertyDamage_KeyPress(object sender, KeyPressEventArgs e)
        {
            utility.TextBoxIntergerOnly(sender, e);
        }

        private void txtBoxPPersonalAccident_KeyPress(object sender, KeyPressEventArgs e)
        {
            utility.TextBoxIntergerOnly(sender, e);
        }

        private void txtBoxTotalAnnualPremium_KeyPress(object sender, KeyPressEventArgs e)
        {
            utility.TextBoxIntergerOnly(sender, e);
        }

        private void txtBoxNet_KeyPress(object sender, KeyPressEventArgs e)
        {
            utility.TextBoxIntergerOnly(sender, e);
        }

        private void txtBoxGross_KeyPress(object sender, KeyPressEventArgs e)
        {
            utility.TextBoxIntergerOnly(sender, e);
        }

        private void txtBoxPLossAndDamage_TextChanged_1(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtBoxPCPTL_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtBoxPExcessBodilyInjury_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtBoxPVolPropertyDamage_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtBoxPPersonalAccident_TextChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void btnAddAgent_Click(object sender, EventArgs e)
        {
            Agent form = new Agent(this);
            form.ShowDialog();
        }

        private void txtBoxNet_TextChanged(object sender, EventArgs e)
        {
            ComputeGrossAndNet();
        }

        private void txtBoxGross_TextChanged(object sender, EventArgs e)
        {
            ComputeGrossAndNet();
        }

        private void txtBoxTotalAnnualPremium_TextChanged(object sender, EventArgs e)
        {
            ComputeGrossAndNet();
        }

        private void txtBoxAssured_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void rchTxtBoxAddress_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxMortage_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxDeductible_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void datePickerEffectivity_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void cmbBoxCategory_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxPolicyNo_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxYearModel_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxUnit_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxSerialNo_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxMotorNo_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxPlateNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxPlateNo_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void cmbBoxMake_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void cmbBoxClass_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxPLossAndDamage_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);            
        }

        private void txtBoxPCPTL_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxPExcessBodilyInjury_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxPVolPropertyDamage_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxPPersonalAccident_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxTotalAnnualPremium_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxNet_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxGross_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxPLossAndDamage_Leave(object sender, EventArgs e)
        {
            txtBoxPLossAndDamage.Text = utility.AmountFormat(txtBoxPLossAndDamage.Text);
        }

        private void txtBoxPCPTL_Leave(object sender, EventArgs e)
        {
            txtBoxPCPTL.Text = utility.AmountFormat(txtBoxPCPTL.Text);
        }

        private void txtBoxPExcessBodilyInjury_Leave(object sender, EventArgs e)
        {
            txtBoxPExcessBodilyInjury.Text = utility.AmountFormat(txtBoxPExcessBodilyInjury.Text);
        }

        private void txtBoxPVolPropertyDamage_Leave(object sender, EventArgs e)
        {
            txtBoxPVolPropertyDamage.Text = utility.AmountFormat(txtBoxPVolPropertyDamage.Text);
        }

        private void txtBoxPPersonalAccident_Leave(object sender, EventArgs e)
        {
            txtBoxPPersonalAccident.Text = utility.AmountFormat(txtBoxPPersonalAccident.Text);
        }

        private void txtBoxTotalAnnualPremium_Leave(object sender, EventArgs e)
        {
            txtBoxTotalAnnualPremium.Text = utility.AmountFormat(txtBoxTotalAnnualPremium.Text);
        }

        private void txtBoxNet_Leave(object sender, EventArgs e)
        {
            txtBoxNet.Text = utility.AmountFormat(txtBoxNet.Text);
        }

        private void txtBoxGross_Leave(object sender, EventArgs e)
        {
            txtBoxGross.Text = utility.AmountFormat(txtBoxGross.Text);
        }

        private void txtBoxPolicyNo_Leave(object sender, EventArgs e)
        {
            if (IfPolicyNoExist())
            {
                MessageBox.Show("Policy No already exist", "Error");
            }
        }

        private void txtBoxColor_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void txtBoxColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void rchTextBoxOthers_KeyUp(object sender, KeyEventArgs e)
        {
            utility.Tab(e);
        }

        private void datePickerExpiryDate_KeyUp(object sender, KeyEventArgs e)
        {
            txtBoxYearModel.Focus();
        }

        private void datePickerEffectivity_ValueChanged(object sender, EventArgs e)
        {
            datePickerExpiryDate.Value = datePickerEffectivity.Value.AddYears(1);
        }

        private void btnPrintPayments_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintPayment_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentReportParameters reportParameter = new PaymentReportParameters
                {
                    PolicyNo = txtBoxPolicyNo.Text,
                    PolicyID = policyID,
                    Assured = txtBoxAssured.Text,
                    PlateNo = txtBoxPlateNo.Text,
                    SerialNo = txtBoxSerialNo.Text,
                    EngineNo = txtBoxMotorNo.Text,
                    Gross = txtBoxGross.Text
                };

                InsurancePaymentSummary reportForm = new InsurancePaymentSummary(reportParameter);

                reportForm.Show();
            }
            catch
            {
                MessageBox.Show("Can't load payment summary\n There was some kind of error", "Error");
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to renew ?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    lblStatus.Text = "Renew";

                    //Clear Computation
                    txtBoxPLossAndDamage.Text = txtBoxPCPTL.Text = txtBoxPExcessBodilyInjury.Text =
                    txtBoxPVolPropertyDamage.Text = txtBoxPPersonalAccident.Text = txtBoxTotalAnnualPremium.Text =
                    txtBoxNet.Text = txtBoxGross.Text = "";

                    //Clear Payments
                    CreatePaymentColumn("CASH");

                    //Change Dates
                    datePickerEffectivity.Value = DateTime.Now;
                    datePickerExpiryDate.Value = DateTime.Now.AddYears(1);
                    datePickerWritingDate.Value = DateTime.Now;

                    //Clear Policy No
                    txtBoxPolicyNo.Text = "";

                    //To determine as new data
                    policyID = Guid.Empty;

                    lblPaid.Text = "0.00";
                    lblPayable.Text = "0.00";
                }
                catch
                {
                    MessageBox.Show("There was some kind of error", "Error");
                }
            }
        }


    }
}
