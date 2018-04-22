//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ItemMaster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bank
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bank()
        {
            this.PaymentReceiptDetails = new HashSet<PaymentReceiptDetail>();
        }
    
        public long ID { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string MICRCode { get; set; }
        public string BranchAddress { get; set; }
        public string ContactNo { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public Nullable<long> StateID { get; set; }
        public Nullable<long> CountryID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentReceiptDetail> PaymentReceiptDetails { get; set; }
    }
}