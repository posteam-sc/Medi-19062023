//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.APP_Data
{
    using System;
    
    public partial class GetStockInSAPById_Result
    {
        public long Id { get; set; }
        public Nullable<long> ProductId { get; set; }
        public string BatchNo { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public int AvailableQty { get; set; }
        public Nullable<int> ProductQty { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}