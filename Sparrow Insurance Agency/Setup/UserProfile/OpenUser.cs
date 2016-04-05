using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow_Insurance_Agency.Setup.UserProfile
{
    public partial class OpenUser : Form
    {
        Guid userID = Guid.Empty;

        public OpenUser(Guid _userID)
        {
            InitializeComponent();

            if (_userID != Guid.Empty)
            {
                userID = _userID;

                GetUserInfo();
            }
        }

        private void GetUserInfo()
        {
            using (var db = new SparrowEntities())
            {
                var userInfo = db.User.FirstOrDefault(r => r.ID == userID);

                if(userInfo == null) //If no user found in the database
                {
                    MessageBox.Show("Cannot found user", "Error");
                }
                else //assign data to its corresponding fields
                {
                    txtBoxUsername.Text = userInfo.Username;
                    txtBoxPassword.Text = txtBoxConfirmPassword.Text = userInfo.Hash;
                    txtBoxFirstName.Text = userInfo.FirstName;
                    txtBoxLastName.Text = userInfo.LastName;
                    txtBoxMiddleName.Text = userInfo.MiddleName;
                    comboBoxRole.Text = userInfo.Role;
                }
            }
        }

        private void PasswordNotMatch()
        {
            if (txtBoxPassword.Text != txtBoxConfirmPassword.Text)
            {
                MessageBox.Show("Password not match", "Error");

                txtBoxPassword.Text = "";
                txtBoxConfirmPassword.Text = "";
            }
        }

        private bool IfUsernameExist(string _username)
        {
            using (var db = new SparrowEntities())
            {
                var user = db.User.FirstOrDefault(r => r.Username == _username);

                if (user != null)
                    return true;
                else
                    return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string errorMessage = "";

                //Error handler for missing required fields
                if (txtBoxUsername.Text == "")
                    errorMessage += "Username is required\n";

                if (txtBoxFirstName.Text == "")
                    errorMessage += "First name is required\n";

                if (txtBoxLastName.Text == "")
                    errorMessage += "Last name is required\n";

                if (comboBoxRole.Text == "")
                    errorMessage += "Role is required\n";

                if (errorMessage == "")
                {
                    if (!IfUsernameExist(txtBoxUsername.Text))
                    {
                        using (var db = new SparrowEntities())
                        {
                            if (userID == Guid.Empty)//new
                            {
                                User newUser = new User
                                {
                                    ID = Guid.NewGuid(),
                                    FirstName = txtBoxFirstName.Text,
                                    MiddleName = txtBoxMiddleName.Text,
                                    LastName = txtBoxLastName.Text,
                                    Username = txtBoxUsername.Text,
                                    Hash = txtBoxPassword.Text,
                                    Role = comboBoxRole.Text,
                                    FullName = txtBoxFirstName.Text + " " + txtBoxMiddleName.Text + " " + txtBoxLastName.Text
                                };
                                db.Entry(newUser).State = EntityState.Added;
                            }
                            else//update
                            {
                                var user = db.User.FirstOrDefault(r => r.ID == userID);

                                //update user info
                                user.FirstName = txtBoxFirstName.Text;
                                user.MiddleName = txtBoxMiddleName.Text;
                                user.LastName = txtBoxLastName.Text;
                                user.Username = txtBoxUsername.Text;
                                user.Hash = txtBoxPassword.Text;
                                user.Role = comboBoxRole.Text;
                                user.FullName = txtBoxFirstName.Text + " " + txtBoxMiddleName.Text + " " + txtBoxLastName.Text;

                                db.Entry(user).State = EntityState.Modified;
                            }
                            db.SaveChanges();

                            MessageBox.Show("Successfully saved");

                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username already used", "Error on saving/updating");
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage, "Error on saving/updating");
                }
            }
            catch
            {
                MessageBox.Show("There was some kind of error", "Error");
            }
        }
    }
}
