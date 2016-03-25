using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow_Insurance_Agency.Class
{
    public class PaymentReportParameters
    {
        public string PolicyNo { get; set; }
        public string Assured { get; set; }
        public string PlateNo { get; set; }
        public string SerialNo { get; set; }
        public string EngineNo { get; set; }
        public string Gross { get; set; }
        public Guid PolicyID { get; set; }
    }
}
