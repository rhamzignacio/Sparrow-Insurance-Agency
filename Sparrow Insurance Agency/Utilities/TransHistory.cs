using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow_Insurance_Agency.Utilities
{
    public class TransHistory
    {
        public string Save(string message, Guid userID)
        {
            using(var db=new SparrowEntities())
            {
                try
                {
                    TransactionHistory transHistory = new TransactionHistory();
                    transHistory.ID = new Guid();
                    transHistory.UserID = userID;
                    transHistory.Remarks = message;
                    transHistory.Date = DateTime.Now;

                    db.Entry(transHistory).State = EntityState.Added;

                    db.SaveChanges();

                    return "OK";
                }
                catch (Exception error)
                {
                    return error.Message;               
                }

            }
        }
    }
}
