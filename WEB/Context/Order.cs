//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEB.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Productid { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatednUtc { get; set; }
        public string UserId { get; set; }
    }
}
