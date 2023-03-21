using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Nhom12_DoAnLapTrinhWeb_QuanLyThueTro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//them Page list
using PagedList;

namespace Nhom12_DoAnLapTrinhWeb_QuanLyThueTro.Controllers
{    
    public class HomeController : Controller
    {       
        // GET: Home
        

        public HomeController()
        {
        }

        public ActionResult Order()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
                PhieuDat pd = new PhieuDat();
                pd.IDUser = User.Identity.GetUserName();
                pd.Datetime = DateTime.Now;
                pd.IDPhong = int.Parse(Request.Form["id"]);
                var phong =context.Phongs.FirstOrDefault(x => x.ID == int.Parse(Request.Form["id"]));
                pd.TienCoc = (Double)phong.DonGia*10/100;
                context.PhieuDats.InsertOnSubmit(pd);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //public ActionResult Order_Pay(FormCollection col)
        //{
        //Phong p = new Phong();
        //NganHang ng = new NganHang();
        //PhieuDat ph = new PhieuDat();
        //if (col.Count > 0)
        //{
        //    ng = _quanLyWebThueTroDataContext.NganHangs.Where(x=>x.ID.Equals(col["ID"]) && x.Value.Equals("Value")).FirstOrDefault();

        //   if (ng != null)
        //    {
        //p = _quanLyWebThueTroDataContext.Phongs.FirstOrDefault(x => x.ID == int.Parse(col["ID"]));
        //var tiencoc = (double)p.DonGia;
        //ph.IDPhong = p.ID;
        //ph.Request = 0;
        //ph.IDUser = User.Identity.GetUserName();
        //ph.Datetime = DateTime.Now;
        //ph.TienCoc = tiencoc * (10 / 100);
        //_quanLyWebThueTroDataContext.PhieuDats.InsertOnSubmit(ph);
        //            Redirect("~/Home/Index");
        //        }
        //    }
        //    return View();
        //}
        /*Order_Pay model = new Order_Pay();

        if (!ModelState.IsValid)
        {
            return View("Details");
        }


        model.Pay.ID =
        model.Pay.Value =
        var check = _quanLyWebThueTroDataContext.NganHangs.Where(x => x.ID == model.Pay.ID && x.Value == model.Pay.Value).FirstOrDefault();
        if (check == null)
        {
            return View("Details");
        }
        else
        {
            var tiencoc = (double)model.Phong.DonGia;
            model.Order.IDPhong = id;
            model.Order.Request = 0;
            model.Order.IDUser = User.Identity.GetUserName();
            model.Order.Datetime = DateTime.Now;
            model.Order.TienCoc = tiencoc * (10 / 100);
            _quanLyWebThueTroDataContext.PhieuDats.InsertOnSubmit(model.Order);
            return View("Index");
        }

        return View("Details");*/
        public ActionResult Index()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            return View(context.P_Trang(1, 0));
        }

        public ActionResult IndexTrang(int id, int loai)
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();

            return View(context.P_Trang(id, loai));
        }

        public ActionResult Index1()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();/*Show ra phòng loại 1 các phòng*/

            return View(context.P_Trang(1,1));
        }
        public ActionResult Index2()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();/*Show ra phòng loại 2 các phòng*/

            return View(context.P_Trang(1, 2));
        }
        public ActionResult Index3()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();/*Show ra phòng loại 3 các phòng*/

            return View(context.P_Trang(1, 3));
        }
        public ActionResult IndexSearch(string Search)
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            return View(context.P_Search(Search));
        }
        public ActionResult IndexGiaDuoi1trieu()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            return View(context.P_Phong().Where(x => x.DonGia <= 1000000).ToList());
        }
        public ActionResult IndexGiaTu1Den2Tr()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            return View(context.P_Phong().Where(x => x.DonGia >= 1000000 && x.DonGia <= 2000000).ToList());
        }
        public ActionResult IndexGiaTu2Den4Tr()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            return View(context.P_Phong().Where(x => x.DonGia >= 2000000 && x.DonGia <= 4000000));
        }
        public ActionResult IndexGiaTren5tr()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            return View(context.P_Phong().Where(x => x.DonGia >= 5000000));
        }
        public ActionResult Details(int id)
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            Phong p = context.Phongs.FirstOrDefault(x => x.ID == id);
            return View(p);
        }
        /*public ActionResult Details(int id)
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            Order_Pay model = new Order_Pay();

            model.Phong = context.Phongs.FirstOrDefault(x => x.ID == id);


            if (Request.Form.Count > 0)
            {
                model.Pay.ID = Request.Form["Pay.ID"];               
                model.Pay.Value = Request.Form["Pay.Value"];
                var check = context.NganHangs.Where(x => x.ID == model.Pay.ID && x.Value == model.Pay.Value).FirstOrDefault();
                if (check == null)
                {
                    return View();
                }
                else
                {
                    Phong phong = context.Phongs.FirstOrDefault((x => x.ID == id));
                    var tiencoc = (double)phong.DonGia;
                    model.Order.IDPhong = id;
                    model.Order.Request = 0;
                    model.Order.IDUser = User.Identity.GetUserName();
                    model.Order.Datetime = DateTime.Now;
                    model.Order.TienCoc = tiencoc * (10 / 100);
                    context.PhieuDats.InsertOnSubmit(model.Order);
                    return View("Index");
                }
            }
            return View(model);*/
    }
}