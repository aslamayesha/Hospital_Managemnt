//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication15
{
    using System;
    using System.Collections.Generic;
    
    public partial class History_doctor
    {
        public int id { get; set; }
        public int register_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string email { get; set; }
    
        public virtual Register Register { get; set; }
    }
}