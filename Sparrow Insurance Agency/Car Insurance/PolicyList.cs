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

        public void GetPolicyList(string motorNo = "", string policyNo = "", string assured = "",
        string plateNo = "",string serialNo = "", string status = "")
        {
            listViewPolicy.Items.Clear();

            using(var db = new SparrowEntities())
            {
                var policyLists = db.CarInsurancePolicy.OrderByDescending(r=>r.CreateDate).AsQueryable(); //Get all data

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


                var list = policyLists.ToList();

                list.ForEach(item => //add data to list view
                {
                    totalBalance += item.Balance;

                    ListViewItem lvi = new ListViewItem(item.ID.ToString());

                    lvi.SubItems.Add(item.Status);

                    lvi.SubItems.Add(item.PolicyNo);

                    lvi.SubItems.Add(item.Assured);

                    lvi.SubItems.Add(item.PlateNo);

                    lvi.SubItems.Add(item.MotorNo);

                    lvi.SubItems.Add(item.SerialNo);

                    lvi.SubItems.Add(string.Format("{0:0.00}", item.Amount));

                    lvi.SubItems.Add(string.Format("{0:0.00}", item.Paid));

                    lvi.SubItems.Add(string.Format("{0:0.00}", item.Balance));

                    listViewPolicy.Items.Add(lvi);
                });//end of foreach             

                //Counts
                //lblNew.Text = "New: " + list.Where(r => r.Status.ToLower() == "new").Count().ToString();

                //lblPaid.Text = "Paid: " + list.Where(r => r.Status.ToLower() == "paid").Count().ToString();              

                //lblExpired.Text = "Expired: " + list.Where(r => r.Status.ToLower() == "expired").Count().ToString();
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
            try
            {
                Guid ID = Guid.Parse(listViewPolicy.SelectedItems[0].SubItems[0].Text);

                PolicyWriting form = new PolicyWriting(currentUser, ID);

                form.Show();

                GetPolicyList();
            }
            catch
            {
                MessageBox.Show("Please select data from list", "Error");
            }
        }
    }
}
