using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_NguyenDucThong.Controllers;
using Tuan4_NguyenDucThong.Models;

namespace Tuan4_NguyenDucThong.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        MyDataDataContext data = new MyDataDataContext();

        public ActionResult Index()
        {
            return View();
        }
        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang == null)
            {
                listGioHang = new List<GioHang>(); 
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }
        public ActionResult addGioHang(int id, string strURL)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.Find(x => x.masach == id);    
            if(sanpham == null)
            {
                sanpham = new GioHang(id);
                listGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);    
            }
        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang != null)
            {
                tsl = listGioHang.Sum(n => n.iSoLuong);
            }
            return tsl;
        }

        private int SumProducts()
        {
            int tsl = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang!= null)
            {
                tsl = listGioHang.Count;
            }
            return tsl;
        }

        private double SumMoney()
        {
            double sum = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang != null)
            {
                sum = listGioHang.Sum(n => n.dThanhTien);
            }
            return sum;
        }

        public ActionResult GioHang()
        {
            List<GioHang> listGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.SumMonney = SumMoney();
            ViewBag.SumProducts = SumProducts();
            return View(listGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.SumMonney = SumMoney();
            ViewBag.SumProducts = SumProducts();
            return PartialView();
        }

        // DeleteGioHang
        public ActionResult DeleteGioHang(int id)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.SingleOrDefault(n => n.masach == id);
            if(sanpham != null)
            {
                listGioHang.RemoveAll(n=>n.masach == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }

        //UpdateGioHang
        public ActionResult UpdateGioHang(int id, FormCollection collection)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.SingleOrDefault(n=>n.masach == id);
            if(sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(collection["txtSolg"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        // DeleteAllGioHang
        public ActionResult DeleteAllGioHang()
        {
            List<GioHang> listGioHang = LayGioHang();
            listGioHang.Clear();
            return RedirectToAction("GioHang");
        }
        

    }
}