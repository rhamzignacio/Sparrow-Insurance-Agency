//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sparrow_Insurance_Agency
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarInsuranceCommission
    {
        public System.Guid ID { get; set; }
        public System.Guid CarInsurancePolicyID { get; set; }
        public System.Guid SalesAgent { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public byte[] Remarks { get; set; }
    }
}
