//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TShirts.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Color
    {
        public Color()
        {
            this.Designs = new HashSet<Design>();
            this.Sizes = new HashSet<Size>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }
        public int SortOrder { get; set; }
    
        public virtual Range Range { get; set; }
        public virtual ICollection<Design> Designs { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
    }
}
