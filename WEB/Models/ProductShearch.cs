using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Context;


namespace WEB.Models
{
    public class ProductShearch
    {
        sqlwebEntities objsqlwebEntities = new sqlwebEntities();
        public List<Product> SearchByKey(string key)
        {
            return objsqlwebEntities.Products.SqlQuery("Select * From Product Where Name like '%" + key + "%'").ToList();
        }
    }
}