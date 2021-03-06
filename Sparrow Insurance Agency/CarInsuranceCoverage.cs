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
    
    public partial class CarInsuranceCoverage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarInsuranceCoverage()
        {
            this.CarInsurancePolicy = new HashSet<CarInsurancePolicy>();
        }
    
        public System.Guid ID { get; set; }
        public Nullable<decimal> A_LossAndDamage { get; set; }
        public Nullable<decimal> A_CTPL { get; set; }
        public Nullable<decimal> A_ExcessBodilyInjury { get; set; }
        public Nullable<decimal> A_VolPropertyDamage { get; set; }
        public Nullable<decimal> A_PersonalAccident { get; set; }
        public Nullable<decimal> A_MR { get; set; }
        public Nullable<decimal> A_Total { get; set; }
        public Nullable<decimal> P_LossAndDamage { get; set; }
        public Nullable<decimal> P_CPTL { get; set; }
        public Nullable<decimal> P_ExcessBodilyInjury { get; set; }
        public Nullable<decimal> P_VolPropertyDamage { get; set; }
        public Nullable<decimal> P_PersonalAccident { get; set; }
        public Nullable<decimal> P_MR { get; set; }
        public Nullable<decimal> P_Total { get; set; }
        public Nullable<decimal> P_AdditionalCharges { get; set; }
        public Nullable<decimal> P_DocumentaryTax { get; set; }
        public Nullable<decimal> P_EVAT { get; set; }
        public Nullable<decimal> P_LocalGovernmentTax { get; set; }
        public decimal TotalAnnualPremium { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarInsurancePolicy> CarInsurancePolicy { get; set; }
    }
}
