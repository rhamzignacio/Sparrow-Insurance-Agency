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

namespace Sparrow_Insurance_Agency.Setup.Make
{
    public partial class OpenMake : Form
    {
        Guid makeID;
        public OpenMake(Guid makeID)
        {
            InitializeComponent();
            this.makeID = makeID;

            if (makeID != Guid.Empty) //Update
            {
                GetMake();
                btnAdd.Text = "Update";
            }
            else
                btnAdd.Text = "Save";
        }

        private void GetMake()
        {
            using(var db = new SparrowEntities())
            {
                var make = db.MakeProfile.FirstOrDefault(r => r.ID == makeID);
                txtBoxName.Text = make.Name;
            }
        }

        private void SaveMake()
        {
            try
            {
                using (var db = new SparrowEntities())
                {
                    var ifExist = db.MakeProfile.FirstOrDefault(r => r.Name.ToLower() == txtBoxName.Text.ToLower() && r.ID != makeID);

                    if (ifExist == null)
                    {
                        if (makeID == Guid.Empty) //New
                        {
                            MakeProfile newMake = new MakeProfile
                            {
                                ID = Guid.NewGuid(),
                                Name = txtBoxName.Text
                            };
                            db.Entry(newMake).State = EntityState.Added;
                        }
                        else //Update
                        {
                            var updateMake = db.MakeProfile.FirstOrDefault(r => r.ID == makeID);
                            updateMake.Name = txtBoxName.Text;
                            db.Entry(updateMake).State = EntityState.Modified;
                        }
                    }
                    else
                        MessageBox.Show(txtBoxName.Text + " already exist in database", "Error on saving");

                    db.SaveChanges();
                    MessageBox.Show("Successfully save make", "Saved");
                    Close();
                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error on saving");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveMake();
        }
    }
}
