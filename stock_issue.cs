//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCCWebsite002
{
    using System;
    using System.Collections.Generic;
    
    public partial class stock_issue
    {
        public int stockissueid { get; set; }
        public Nullable<int> cadetid { get; set; }
        public string issuedate { get; set; }
        public Nullable<int> issueqty { get; set; }
        public Nullable<int> stockid { get; set; }
    
        public virtual cadet cadet { get; set; }
        public virtual stock stock { get; set; }
    }
}
