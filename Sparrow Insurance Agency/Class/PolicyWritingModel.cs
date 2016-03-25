//Created by: Ramil Ignacio

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow_Insurance_Agency.Class
{
    public class PolicyWritingModel
    {
        public string Save(CarInsurancePolicy policy, List<CarInsurrancePayment> payments)
        {
            using(var db = new SparrowEntities())
            {
                string errorMessage = "";

                //Check if exist
                //Serial No
                var serialNo = db.CarInsurancePolicy.FirstOrDefault(r => r.SerialNo == policy.SerialNo);

                var motorNo = db.CarInsurancePolicy.FirstOrDefault(r => r.MotorNo == policy.MotorNo);

                var plateNo = db.CarInsurancePolicy.FirstOrDefault(r => r.PlateNo == policy.PlateNo);

                if (serialNo != null)
                    errorMessage += "Serial No already exist";

                if (motorNo != null)
                    errorMessage += "Motor No already exist";

                if (plateNo != null)
                    errorMessage += "Plate No already exist";

                if (errorMessage == "")
                {
                    //CarInsurancePolicy newPolicy = new CarInsurancePolicy();
                    //newPolicy = policy;

                    try
                    {
                        if (policy.ID == Guid.Empty || policy.ID == null)
                        {
                            policy.ID = Guid.NewGuid(); //new ID

                            db.Entry(policy).State = EntityState.Added;
                        }
                        else
                            db.Entry(policy).State = EntityState.Modified;

                        //Payments
                        payments.ForEach(payment =>
                        {
                            db.Entry(payment).State = EntityState.Added;
                        });

                        db.SaveChanges();

                        return "Y"; //Return Y if successfully saved
                    }
                    catch (Exception error)
                    {
                        return error.Message;
                    }
                }
                else
                {
                    return errorMessage;
                }
            }
        }

       
    }
}
