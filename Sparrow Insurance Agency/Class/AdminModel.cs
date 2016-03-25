//Created By: Ramil Ignacio
//Purpose: Loading of Admin data to other forms

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow_Insurance_Agency.Class
{
    public class AdminModel
    {
        #region User
        public User GetUser(Guid _userID)
        {
            using(var db = new SparrowEntities())
            {
                return db.User.FirstOrDefault(r => r.ID == _userID);
            }
        }
        #endregion

        #region Bank
        public List<BankProfile> GetAllActiveBanks()
        {
            using(var db = new SparrowEntities())
            {
                return db.BankProfile.ToList();
            }
        }

        public Guid GetBankID(string bankName)
        {
            using(var db = new SparrowEntities())
            {
                try
                {
                    return db.BankProfile.FirstOrDefault(r => r.Name.ToLower() == bankName.ToLower()).ID;
                }
                catch
                {
                    return Guid.Empty;
                }
            }
        }
        #endregion
    }
}
