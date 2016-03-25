using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Setup.Bank
{
    public partial class BankList : Form
    {
        public BankList()
        {
            InitializeComponent();

            GetBank();
        }    

        private void GetBank()
        {
            lstViewBank.Items.Clear();
            using(var db = new SparrowEntities())
            {
                var banks = db.BankProfile.AsQueryable();

                if (txtSearch.Text != "")
                    banks = banks.Where(r => r.Name.ToLower().Contains(txtSearch.Text.ToLower()));

                banks.ToList().ForEach(item =>
                {
                    ListViewItem lvi = new ListViewItem(item.ID.ToString());
                    lvi.SubItems.Add(item.Name);

                    lstViewBank.Items.Add(lvi);
                });
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetBank();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenBank form = new OpenBank(Guid.Empty);
            form.ShowDialog();
            GetBank();
        }

        private void txtBoxEdit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenBank form = new OpenBank(Guid.Parse(lstViewBank.SelectedItems[0].SubItems[0].Text));
                form.ShowDialog();
                GetBank();
            }
            catch
            {
                MessageBox.Show("Please select data from list", "Error");
            }
        }
    }
}
