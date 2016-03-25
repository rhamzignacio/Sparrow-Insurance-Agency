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
    public partial class OpenBank : Form
    {
        Guid bankID;
        public OpenBank(Guid bankID)
        {
            InitializeComponent();

            this.bankID = bankID;
        }

       private void SaveUpdateBank()
        {
            if (txtBoxName.Text != "")
            {
                try
                {
                    using (var db = new SparrowEntities())
                    {
                        if (bankID == Guid.Empty) //new
                        {
                            BankProfile newBank = new BankProfile
                            {
                                ID = Guid.NewGuid(),
                                Name = txtBoxName.Text
                            };
                            var ifExist = db.BankProfile.FirstOrDefault(r => r.Name.ToLower() == txtBoxName.Text.ToLower());

                            if (ifExist == null)
                                db.Entry(newBank).State = EntityState.Added;
                            else
                            {
                                MessageBox.Show("Bank already exist", "Error on saving");
                                return;
                            }
                        }
                        else //update
                        {
                            var updateBank = db.BankProfile.FirstOrDefault(r => r.ID == bankID);
                            updateBank.Name = txtBoxName.Text;

                            db.Entry(updateBank).State = EntityState.Modified;
                        }
                        db.SaveChanges();
                        MessageBox.Show("Successfully saved", "Bank profile");
                        Close();
                    }
                }
                catch (Exception errorMessage)
                {
                    MessageBox.Show(errorMessage.Message, "Error on saving");
                }
            }
            else
                MessageBox.Show("Bank name is required", "Error");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveUpdateBank();
        }
    }
}
