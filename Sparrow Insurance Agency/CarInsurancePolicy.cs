//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sparrow_Insurance_Agency
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarInsurancePolicy
    {
        public System.Guid ID { get; set; }
        public string Assured { get; set; }
        public string Address { get; set; }
        public string YearModel { get; set; }
        public string SerialNo { get; set; }
        public string MotorNo { get; set; }
        public string PlateNo { get; set; }
        public string Color { get; set; }
        public string Mortagee { get; set; }
        public string Deductible { get; set; }
        public Nullable<System.Guid> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Aircon { get; set; }
        public string SterioSpeakers { get; set; }
        public string Magwheels { get; set; }
        public string Others { get; set; }
        public string Status { get; set; }
        public Nullable<System.Guid> CarInsuranceCoverageID { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<System.Guid> ModifyBy { get; set; }
        public Nullable<System.DateTime> Effectivity { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> TotalAnnualPremium { get; set; }
        public Nullable<decimal> A_LossAndDamage { get; set; }
        public Nullable<decimal> A_CTPL { get; set; }
        public Nullable<decimal> A_ExcessBodilyInjury { get; set; }
        public Nullable<decimal> A_VolPropertyDamage { get; set; }
        public Nullable<decimal> P_PersonalAccident { get; set; }
        public Nullable<decimal> P_MR { get; set; }
        public Nullable<decimal> P_Total { get; set; }
        public Nullable<decimal> P_AdditionalCharges { get; set; }
        public Nullable<decimal> P_DocumentaryTax { get; set; }
        public Nullable<decimal> P_EVAT { get; set; }
        public Nullable<decimal> P_LocalGovernmentTax { get; set; }
        public Nullable<decimal> P_LossAndDamage { get; set; }
        public Nullable<decimal> P_CTPL { get; set; }
        public Nullable<decimal> P_ExcessBodilyInjury { get; set; }
        public Nullable<decimal> P_VolPropertyDamage { get; set; }
        public System.Guid Agent { get; set; }
        public string PolicyNo { get; set; }
        public decimal Paid { get; set; }
        public string Payment_Method { get; set; }
        public string Car_Class { get; set; }
        public string Car_Make { get; set; }
        public Nullable<decimal> Gross { get; set; }
        public Nullable<decimal> Net { get; set; }
        public string Category { get; set; }
        public Nullable<System.DateTime> Expiration_Date { get; set; }
    
        public virtual CarInsuranceCoverage CarInsuranceCoverage { get; set; }
    }
}
