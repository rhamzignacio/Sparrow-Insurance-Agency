using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Setup.UserProfile
{
    public partial class UserList : Form
    {
        public UserList()
        {
            InitializeComponent();

            GetUserList();
        }

        private void GetUserList(string searchKey = "")
        {
            using (var db = new SparrowEntities())
            {
                IQueryable<User> userList;

                if (searchKey != "")
                {
                    userList = db.User.Where(r => r.FullName.ToLower().Contains(searchKey.ToLower()));
                }
                else
                {
                    userList = db.User;
                }

                lstViewUser.Items.Clear(); //Clear items in list view

                userList.ToList().ForEach(item =>
                {
                    ListViewItem lvi = new ListViewItem(item.ID.ToString());
                    lvi.SubItems.Add(item.Role);
                    lvi.SubItems.Add(item.Username);
                    lvi.SubItems.Add(item.FullName);

                    lstViewUser.Items.Add(lvi);
                });
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetUserList(txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetUserList(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenUser newUserForm = new OpenUser(Guid.Empty);

            newUserForm.ShowDialog();

            GetUserList(); //Refresh list
        }

        private void txtBoxEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Guid userID = Guid.Parse(lstViewUser.SelectedItems[0].SubItems[0].Text);

                OpenUser userForm = new OpenUser(userID);

                userForm.Show();

                GetUserList();
            }
            catch
            {
                MessageBox.Show("Please select data from list", "Error");
            }
        }
    }
}
