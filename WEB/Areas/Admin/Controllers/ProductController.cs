using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Context;
using static WEB.Common.ListtoDataTableConverter;
using static WEB.Common;

namespace WEB.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        sqlwebEntities dbObj = new sqlwebEntities();

        public ActionResult Index(string SearchString, string currentFilter, int? page)
        {
            var lstProduct = new List<Product>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {

                lstProduct = dbObj.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {

                lstProduct = dbObj.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
        [ValidateInput(false)]
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {

                    if (objProduct.ImageUpLoad != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoad.FileName);
                        //Ten hinh
                        string extension = Path.GetExtension(objProduct.ImageUpLoad.FileName);
                        //png
                        fileName = fileName + extension;
                        //ten hinh.png
                        objProduct.Avarta = fileName;
                        //lưu file hình
                        objProduct.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                    }
                    objProduct.CreatedOnUtc = DateTime.Now;
                    dbObj.Products.Add(objProduct);
                    dbObj.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(objProduct);
        }


        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objProduct = dbObj.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = dbObj.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            dbObj.Products.Remove(objProduct);
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, Product objProduct)
        {
            if (ModelState.IsValid)
            {
                if (objProduct.ImageUpLoad != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoad.FileName);
                    //tenhinh
                    string extension = Path.GetExtension(objProduct.ImageUpLoad.FileName);
                    //png
                    fileName = fileName + extension;
                    //ten hinh.png
                    objProduct.Avarta = fileName;
                    //lưu file hình
                    objProduct.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                }
                objProduct.UpdateOnUtc = DateTime.Now;
                dbObj.Entry(objProduct).State = System.Data.Entity.EntityState.Modified;
                dbObj.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objProduct);
        }
        void LoadData()
        {
            Common objCommon = new Common();

            //lấy dữ liệu danh muc dưới DB
            var lstCat = dbObj.Categories.ToList();
            //Convert sang select list dạng value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            //lấy dữ liệu thương hiệu dưới DB
            var lstBrand = dbObj.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            //Convert sang select list dạng value, text
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");
            //Loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            //Convert sang select list dạng value, text
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }
    }
}
