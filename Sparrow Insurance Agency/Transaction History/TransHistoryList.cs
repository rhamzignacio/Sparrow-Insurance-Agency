//Created By: Ramil Ignacio
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Transaction_History
{
    public partial class TransHistoryList : Form
    {
        public TransHistoryList()
        {
            InitializeComponent();
        }
        #region Functions
        private void GetTransHistory(DateTime? FromDate = null, DateTime? ToDate = null, Guid? userID = null)
        {
            using(var db = new SparrowEntities())
            {
                lstViewTransactionHistory.Items.Clear(); //Clear items in List

                var list = db.TransactionHistory.OrderByDescending(r => r.Date).AsQueryable();

                //Search Parameter
                if (FromDate != null && ToDate != null)
                    list = list.Where(r => r.Date >= FromDate && r.Date <= ToDate);

                if (userID != null)
                    list = list.Where(r => r.UserID == userID);
                

                list.ToList().ForEach(item =>
                {
                    var user = db.User.FirstOrDefault(r => r.ID == item.UserID);

                    ListViewItem lvi = new ListViewItem(item.Date.ToShortDateString());

                    lvi.SubItems.Add(item.Remarks);

                    lvi.SubItems.Add(user.FirstName +  " " + user.MiddleName + " " + user.LastName);

                    lstViewTransactionHistory.Items.Add(lvi);
                });

                lblTotalCount.Text = list.Count().ToString();//Get Total Count
            }
        }
        #endregion

        private void btnAll_Click(object sender, EventArgs e)
        {
            GetTransHistory(); //Get All Transaction History
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime FromDate;
            DateTime ToDate;

            if (dateTimePickerFrom.Text != "" && dateTimePickerTo.Text != "")
            { 
                FromDate = DateTime.Parse(dateTimePickerFrom.Text);

                ToDate = DateTime.Parse(dateTimePickerTo.Text);

                GetTransHistory(FromDate, ToDate, null); //Get Transaction History within Date Range
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
