using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom12_DoAnLapTrinhWeb_QuanLyThueTro.Models;
using System.IO;
using Microsoft.AspNet.Identity;
//them Page list
/*using PagedList.Mvc;
using PagedList;*/
namespace Nhom12_DoAnLapTrinhWeb_QuanLyThueTro.Areas.Admin.Controllers
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
      
        public ActionResult IndexBaiDang()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();/*Bai dang where tinh trang = null*/
            return View(context.P_BaiDang());
        }

        public ActionResult IndexOrder()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();/*Phong where tinh trang = trong && id = idphong*/
            return View(context.P_Order());
        }

        //*Phong where tinh trang = trong && id = idphong*//*


        public ActionResult IndexSummary(string t1, string t2)
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
           /* if (Request.Form.Count > 0)
            {
                string t1 = Request.Form["t1"];
                string t2 = Request.Form["t2"];
                return View(context.P_Summary(t1, t2));
            }*/
            return View(context.P_Summary(t1, t2));
        }
        public ActionResult IndexSummaryInfo()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();/*Phong where tinh trang = trong && id = idphong*/
            return View(context.P_SummaryInfo());
        }
        public ActionResult Index()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext(); 
              List<Phong> dsp = context.Phongs.ToList();
            return View(dsp);
        }
        public ActionResult Index1()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            List<Phong> dsp = context.Phongs.Where(x => x.IDLoaiPhong == 1).ToList();/*Show ra phòng loại 1 các phòng*/


            return View(dsp);
        }
        public ActionResult Index2()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            List<Phong> dsp = context.Phongs.Where(x => x.IDLoaiPhong == 2).ToList();/*Show ra phòng loại 2 các phòng*/


            return View(dsp);          
        }
        public ActionResult Index3()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            List<Phong> dsp = context.Phongs.Where(x => x.IDLoaiPhong == 3).ToList();/*Show ra phòng loại 3 các phòng*/

            return View(dsp);
        }
        public ActionResult IndexSearch(string Search)
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            return View(context.P_Search(Search));
        }
        public ActionResult IndexGiaDuoi1trieu()
        {
            
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            List<Phong> dsp = context.Phongs.Where(x => x.DonGia <= 1000000).ToList();
            return View(dsp);
        }
        public ActionResult IndexGiaTu1Den2Tr()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            List<Phong> dsp = context.Phongs.Where(x => x.DonGia >=1000000 && x.DonGia <= 2000000).ToList();
            return View(dsp);
        }
        public ActionResult IndexGiaTu2Den4Tr()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            List<Phong> dsp = context.Phongs.Where(x => x.DonGia >= 2000000 && x.DonGia <=4000000).ToList();
            return View(dsp);
        }
        public ActionResult IndexGiaTren5tr()
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            List<Phong> dsp = context.Phongs.Where(x => x.DonGia >=5000000).ToList();
            return View(dsp);
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
                p.TinhTrang = Request.Form["TinhTrang"];
                p.TenChuTro = Request.Form["TenChuTro"];
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
        public ActionResult Delete(int id)
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            Phong p = context.Phongs.FirstOrDefault(x => x.ID == id);
            if (p != null)
            {
                context.Phongs.DeleteOnSubmit(p);
                context.SubmitChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeletePD(int id)
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            PhieuDat p = context.PhieuDats.FirstOrDefault(x => x.ID == id);
            if (p != null)
            {
                context.PhieuDats.DeleteOnSubmit(p);
                context.SubmitChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            QuanLyWebThueTroDataContext context = new QuanLyWebThueTroDataContext();
            Phong p = context.Phongs.FirstOrDefault(x => x.ID == id);
            if (Request.Form.Count == 0)
            {
                return View(p);
            }
            p.TieuDe = Request.Form["TieuDe"];
            p.IDLoaiPhong = int.Parse(Request.Form["IDLoaiPhong"]);
            p.TinhTrang = Request.Form["TinhTrang"];
            p.TenChuTro = Request.Form["TenChuTro"];
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
            context.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}