//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDMS.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class D
    {
        public D()
        {
            this.ASCs = new HashSet<ASC>();
        }
    
        public int dsid { get; set; }
        public int districtid { get; set; }
        [Display(Name="Divisional Secretarian")]
        public string dsname { get; set; }
    
        public virtual ICollection<ASC> ASCs { get; set; }
        public virtual DSTRCT DSTRCT { get; set; }
    }
}
