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
    
    public partial class ASC
    {
        public ASC()
        {
            this.AILISTs = new HashSet<AILIST>();
        }
    
        public int ascid { get; set; }
        public int dsid { get; set; }
        public string ascname { get; set; }
    
        public virtual ICollection<AILIST> AILISTs { get; set; }
        public virtual D D { get; set; }
    }
}