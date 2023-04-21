using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Context;
using WEB.Models;

namespace WEB.Controllers
{
    public class PaymentController : Controller
    {
        sqlwebEntities objsqlwebEntities = new sqlwebEntities();
        // GET: Payment
        public ActionResult Index()
        {

            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                Order objOrder = new Order();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatednUtc = DateTime.Now;
                objOrder.Status = 1;
                objsqlwebEntities.Orders.Add(objOrder);
                objsqlwebEntities.SaveChanges();
                int intOrderId = objOrder.Id;

                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();

                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.OrderId = intOrderId;
                    obj.Quantity = item.Quantity;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                objsqlwebEntities.OrderDetails.AddRange(lstOrderDetail);
                objsqlwebEntities.SaveChanges();
            }
            return View();
        }

    }
}