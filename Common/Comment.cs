//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int ID { get; set; }
        public string Comment1 { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int ThreadId { get; set; }
    
        public virtual Thread Thread { get; set; }
        public virtual User User { get; set; }
    }
}
