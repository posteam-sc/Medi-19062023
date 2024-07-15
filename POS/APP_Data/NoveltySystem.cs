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
    
    public partial class NoveltySystem
    {
        public NoveltySystem()
        {
            this.ProductInNovelties = new HashSet<ProductInNovelty>();
        }
    
        public long Id { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<System.DateTime> ValidFrom { get; set; }
        public Nullable<System.DateTime> ValidTo { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> LineId { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Line Line { get; set; }
        public virtual ICollection<ProductInNovelty> ProductInNovelties { get; set; }
    }
}
