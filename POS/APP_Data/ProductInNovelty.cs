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
    using System.Collections.Generic;
    
    public partial class ProductInNovelty
    {
        public long Id { get; set; }
        public Nullable<long> NoveltySystemId { get; set; }
        public Nullable<long> ProductId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual NoveltySystem NoveltySystem { get; set; }
        public virtual Product Product { get; set; }
    }
}
