using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom12_DoAnLapTrinhWeb_QuanLyThueTro.Models;
using System.IO;
//them Page list
using PagedList;
using Microsoft.AspNet.Identity;

namespace Nhom12_DoAnLapTrinhWeb_QuanLyThueTro.Areas.User.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        //*Quy Định:
        //IDLoaiPhong =1 -> phòng thuê trọ
        //IDLoaiPhong =2 ->  Văn Phòng
        //IDLoaiPhong =3 ->  Ở Ghép
        //*/        

        public ActionResult IndexOrderInfo()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();/*Show ra tất cả các phòng*/

            return View(context.P_OrderInfo(User.Identity.GetUserName()));
        }

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

            return View(context.P_Trang(1, 1));
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
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
                Phong p = new Phong();
                p.TieuDe = Request.Form["TieuDe"];
                p.IDLoaiPhong = int.Parse(Request.Form["IDLoaiPhong"]);
                p.TinhTrang = "null";
                p.TenChuTro = "null";
                p.DienTichPhong = Request.Form["DienTichPhong"];
                p.DonGia = float.Parse(Request.Form["DonGia"]);
                p.SDT = int.Parse(Request.Form["SDT"]);
                p.MoTa = Request.Form["Mota"];
                p.DiaChiTro = Request.Form["DiaChiTro"];
                HttpPostedFileBase file = Request.Files["img"];
                if (file != null)
                {
                    var tenFile = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img"), tenFile);
                    file.SaveAs(path);
                    p.img = file.FileName;
                }
                context.Phongs.InsertOnSubmit(p);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        
    }
}