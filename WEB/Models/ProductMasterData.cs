using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WEB.Models
{
    public class ProductMasterData
    {

        public int Id { get; set; }
        [Display(Name = "Đường dẫn")]
        public string Name { get; set; }
        public string Avarta { get; set; }
        public string Slug { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdateOnUtc { get; set; }
        public Nullable<int> Typeid { get; set; }
        public Nullable<double> PriceDiscount { get; set; }
        public Nullable<double> Price { get; set; }
        public string FullDescription { get; set; }
        public string ShortDes { get; set; }
        public Nullable<int> Categoryid { get; set; }
        public Nullable<int> Brandid { get; set; }
   
    }
}