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
    
    public partial class MINORPADDY
    {
        public int id { get; set; }
        public int aiid { get; set; }
        public int yearid { get; set; }
        public int monthid { get; set; }
        public int varietyid { get; set; }
        public double monthlytarget { get; set; }
        public double monthlyprogress { get; set; }
    
        public virtual AILIST AILIST { get; set; }
        public virtual MONTH MONTH { get; set; }
        public virtual VARIETY VARIETY { get; set; }
        public virtual YEAR YEAR { get; set; }
    }
}
