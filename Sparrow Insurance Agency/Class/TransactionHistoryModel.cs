using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow_Insurance_Agency.Class
{
    public class TransactionHistoryModel
    {
        public void Save(Guid userID, string remarks)
        {
            using(var db=new SparrowEntities())
            {
                TransactionHistory trans = new TransactionHistory
                {
                    ID = Guid.NewGuid(),
                    Remarks = remarks,
                    Date = DateTime.Now
                };
                db.Entry(trans).State = System.Data.EntityState.Added;

                db.SaveChanges();
            }
        }
    }
}
