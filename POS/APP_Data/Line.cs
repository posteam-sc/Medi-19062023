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
    
    public partial class Line
    {
        public Line()
        {
            this.GiftSystems = new HashSet<GiftSystem>();
            this.NoveltySystems = new HashSet<NoveltySystem>();
            this.Products = new HashSet<Product>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
    
        public virtual ICollection<GiftSystem> GiftSystems { get; set; }
        public virtual ICollection<NoveltySystem> NoveltySystems { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
