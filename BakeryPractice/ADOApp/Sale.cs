//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BakeryPractice.ADOApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Recipe_Id { get; set; }
        public decimal Cost { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
