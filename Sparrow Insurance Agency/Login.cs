/*
Created By: Ramil Ignacio
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sparrow_Insurance_Agency
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            if (CheckConnection())
            {
                lblConnection.Text = "Connected. . .";
                Enabled = true;
                lblConnection.ForeColor = Color.Green;
            }
            else
            {
                Enabled = false;
                lblConnection.Text = "Disconnected. . .";
                lblConnection.ForeColor = Color.Red;
                MessageBox.Show("Cannot connect to database\n", "Error");
            }
        }

        private bool CheckConnection()
        {
            try
            {
                SparrowEntities db = new SparrowEntities();

                db.Database.Connection.Open();

                return true;
            }
            catch //Database connection issue
            {
                return false;
            }
        }

        private void TryLogin()
        {
            using (var db = new SparrowEntities())
            {
                var user = db.User.FirstOrDefault(r => r.Username.ToLower() == txtBoxUsername.Text.ToLower());

                if (user != null)
                {
                    if (user.Hash == txtBoxPassword.Text)
                    {
                        this.Hide();

                        MainWindow form = new MainWindow(user.ID);

                        form.Show();
                    }
                    else //invalid password
                        MessageBox.Show("Invalid Username/Password", "Error on Login");
                }
                else //invalid username
                    MessageBox.Show("Invalid Username/Password", "Error on Login");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TryLogin();
        }

        private void txtBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                TryLogin();
        }      

        private void txtBoxUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                TryLogin();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
    
        }

        private void btnRSI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\n"
                +"RSI Development Solutions are group of part-time freelancer\n"
                +"Who developed high quality and affordable software\n"
                +"You can contact us at \n\n"
                +"Email: ramil.charles.ignacio@gmail.com\n"
                +"Contact No: 09175214703", "RSI Development Solutions");
        }

        private void btnDatabaseConfiguration_Click(object sender, EventArgs e)
        {

        }
    }
}
