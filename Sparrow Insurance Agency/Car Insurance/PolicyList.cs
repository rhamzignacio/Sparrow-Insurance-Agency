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

namespace Sparrow_Insurance_Agency.Car_Insurance
{
    public partial class PolicyList : Form
    {
        //Search Parameter

        Guid currentUser;

        public PolicyList(Guid currentUser)
        {
            InitializeComponent();

            this.currentUser = currentUser; //assign ID of Current User

            GetPolicyList();//load all data upon init
        }

        private void SelectPolicy()
        {
            try
            {
                Guid ID = Guid.Parse(listViewPolicy.SelectedItems[0].SubItems[0].Text);

                PolicyWriting form = new PolicyWriting(currentUser, ID);

                form.ShowDialog();

                GetPolicyList();
            }
            catch
            {
                MessageBox.Show("Please select data from list", "Error");
            }
        }

        public void GetPolicyList(string motorNo = "", string policyNo = "", string assured = "",
        string plateNo = "",string serialNo = "", string status = "")
        {
            listViewPolicy.Items.Clear();

            using(var db = new SparrowEntities())
            {
                var policyLists = db.CarInsurancePolicy.AsQueryable(); //Get all data

                decimal totalBalance = 0; // for total balance label

                //Filter data by search parameters
                //Search Parameters

                if (status != "")
                    policyLists = policyLists.Where(r => r.Status == status);

                if (motorNo != "")
                    policyLists = policyLists.Where(r => r.MotorNo.ToLower().Contains(motorNo.ToLower()));

                if (policyNo != "")
                    policyLists = policyLists.Where(r => r.PolicyNo.ToLower().Contains(policyNo.ToLower()));

                if (plateNo != "")
                    policyLists = policyLists.Where(r => r.PlateNo.ToLower().Contains(plateNo.ToLower()));

                if (serialNo != "")
                    policyLists = policyLists.Where(r => r.SerialNo.ToLower().Contains(serialNo.ToLower()));

                if (assured != "")
                    policyLists = policyLists.Where(r => r.Assured.ToLower().Contains(assured.ToLower()));


                var list = policyLists.OrderByDescending(r=>r.PolicyNo).ToList();

                int counter = 0;

                int paidCounter = 0, unpaidCounter = 0, canceledCounter = 0, voidCounter = 0 ;

                list.ForEach(item => //add data to list view
                {
                    totalBalance += item.Balance;

                    counter++;

                    ListViewItem lvi = new ListViewItem(item.ID.ToString());

                    lvi.SubItems.Add(counter.ToString());
                    if (item.Paid > 0 && item.Status == "New") //Status
                    {
                        if (!checkBoxPaid.Checked)
                            return;

                        lvi.SubItems.Add("Paid");
                        paidCounter++;
                    }
                    else
                    {                     
                        if (item.Status == "Canceled")
                        {
                            if (!checkBoxCancel.Checked)
                                return;

                            canceledCounter++;
                            lvi.SubItems.Add(item.Status);
                        }
                        else if(item.Status == "Void")
                        {
                            if (!checkBoxVoid.Checked)
                                return;

                            voidCounter++;
                            lvi.SubItems.Add(item.Status);
                        }
                        else
                        {
                            if (!checkBoxUnpaid.Checked)
                                return;

                            unpaidCounter++;
                            lvi.SubItems.Add("Unpaid");
                        }

                    }

                    lvi.SubItems.Add(item.Category); //Classification

                    lvi.SubItems.Add(item.PolicyNo); //Policy No               

                    lvi.SubItems.Add(item.Assured); //Assured

                    lvi.SubItems.Add(item.PlateNo); //Plate No

                    lvi.SubItems.Add(item.MotorNo); //Motor No

                    lvi.SubItems.Add(item.SerialNo); //Serial No

                    lvi.SubItems.Add(string.Format("{0:0.00}", item.Amount)); //Amount 

                    lvi.SubItems.Add(string.Format("{0:0.00}", item.Paid)); //Paid

                    lvi.SubItems.Add(string.Format("{0:0.00}", item.Balance)); //Balance

                    //Color of row
                    if (item.Status == "New" || item.Status == "Unpaid")
                    {
                        if (item.Paid >= item.TotalAnnualPremium)
                            lvi.BackColor = Color.PaleGreen;
                        else
                            lvi.BackColor = Color.Yellow;
                    }
                    else if (item.Status == "Paid")
                        lvi.BackColor = Color.PaleGreen;
                    else if (item.Status == "Void")
                        lvi.BackColor = Color.LightSteelBlue;
                    else //Canceled
                        lvi.BackColor = Color.Tomato;


                    listViewPolicy.Items.Add(lvi);
                });//end of foreach       

                //Status counting
                lblCancelCount.Text = canceledCounter.ToString();
                lblPaidCount.Text = paidCounter.ToString();
                lblUnpaidCount.Text = unpaidCounter.ToString();
                lblTotal.Text = counter.ToString();
                lblVoidCount.Text = voidCounter.ToString();
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            AdvancedSearch form = new AdvancedSearch(this);

            form.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            PolicyWriting form = new PolicyWriting(currentUser,Guid.Empty);

            form.ShowDialog();

            GetPolicyList();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            SelectPolicy();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetPolicyList();
        }

        private void listViewPolicy_DoubleClick(object sender, EventArgs e)
        {
            SelectPolicy();
        }

        private void lblVoidCount_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBoxCancel_CheckedChanged(object sender, EventArgs e)
        {
            GetPolicyList();
        }

        private void checkBoxVoid_CheckedChanged(object sender, EventArgs e)
        {
            GetPolicyList();
        }

        private void checkBoxUnpaid_CheckedChanged(object sender, EventArgs e)
        {
            GetPolicyList();
        }

        private void checkBoxPaid_CheckedChanged(object sender, EventArgs e)
        {
            GetPolicyList();
        }
    }
}
