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
    
    public partial class ItemStockDetail
    {
        public long ID { get; set; }
        public long ItemID { get; set; }
        public Nullable<long> FinancialYearID { get; set; }
        public Nullable<long> DocumentID { get; set; }
        public Nullable<long> TransactionID { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<long> LocationID { get; set; }
        public Nullable<decimal> OpeningStock { get; set; }
        public Nullable<decimal> TransactionQty { get; set; }
        public Nullable<decimal> ClosingStock { get; set; }
    
        public virtual DocumentsList DocumentsList { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual ItemMaster ItemMaster { get; set; }
    }
}
