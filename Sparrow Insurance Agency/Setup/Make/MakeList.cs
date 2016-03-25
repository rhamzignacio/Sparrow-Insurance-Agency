using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Setup.Make
{
    public partial class MakeList : Form
    {
        public MakeList()
        {
            InitializeComponent();
            GetMakeList();
        }

        private void GetMakeList(string searchKey = "")
        {
            lstViewMake.Items.Clear();
            using(var db = new SparrowEntities())
            {
                var makeList = db.MakeProfile.AsQueryable();

                if (searchKey != "")
                    makeList = makeList.Where(r => r.Name.ToLower().Contains(searchKey.ToLower()));

                makeList.ToList().ForEach(item =>
                {
                    ListViewItem lvi = new ListViewItem(item.ID.ToString());
                    lvi.SubItems.Add(item.Name);

                    lstViewMake.Items.Add(lvi);
                });
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetMakeList(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenMake form = new OpenMake(Guid.Empty);
            form.ShowDialog();
            GetMakeList();
        }

        private void txtBoxEdit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenMake form = new OpenMake(Guid.Parse(lstViewMake.SelectedItems[0].SubItems[0].Text));
                form.Show();
                GetMakeList();
            }
            catch
            {
                MessageBox.Show("Please select data from list", "Error");
            }
        }
    }
}
