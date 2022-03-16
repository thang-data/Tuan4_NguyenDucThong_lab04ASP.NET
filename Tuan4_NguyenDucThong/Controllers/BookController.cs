using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_NguyenDucThong.Models;
namespace Tuan4_NguyenDucThong.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        MyDataDataContext data = new MyDataDataContext();   
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListBook()
        {
            var all_Book = from ss in data.Saches select ss;    
            return View(all_Book);
        }

        // Details
        public ActionResult Detail(int id)
        {
            var D_book = data.Saches.Where(m=>m.masach == id).First();
            return View(D_book);
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Sach s)
        {
            var E_nameBook = collection["tensach"];
            var E_image = collection["hinh"];
            var E_price = Convert.ToDecimal(collection["giaban"]);
            var E_dayUpdate = Convert.ToDateTime(collection["ngaycapnhap"]);
            var E_quantityofinventory = Convert.ToInt32(collection["soluongton"]);

            if(string.IsNullOrEmpty(E_nameBook))
            {
                ViewData["Error"] = "Don't Empty";
            }
            else
            {
                s.tensach = E_nameBook; 
                s.hinh = E_image;   
                s.giaban = E_price;
                s.ngaycapnhat = E_dayUpdate;
                s.soluongton = E_quantityofinventory;
                data.Saches.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListBook");   
            }
            return this.Create();

        }

        //Edit
        public ActionResult Edit(int id)
        {
            var E_book = data.Saches.First(m => m.masach == id);
            return View(E_book);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            var E_id = data.Saches.First(m => m.masach == id);  
            var E_nameBook = collection["tensach"];
            var E_image = collection["hinh"];
            var E_price = Convert.ToDecimal(collection["giaban"]);
            var E_dayUpdate = Convert.ToDateTime(collection["ngaycapnhap"]);
            var E_quantityofinventory = Convert.ToInt32(collection["soluongton"]);

            if (string.IsNullOrEmpty(E_nameBook))
            {
                ViewData["Error"] = "Don't Empty";
            }
            else
            {
                E_id.tensach = E_nameBook;
                E_id.hinh = E_image;
                E_id.giaban = E_price;
                E_id.ngaycapnhat = E_dayUpdate;
                E_id.soluongton = E_quantityofinventory;
                UpdateModel(E_id);
                data.SubmitChanges();
                return RedirectToAction("ListBook");
            }
            return this.Edit(id);
        }


        // Delete
        public ActionResult Delete (int id)
        {
            var D_book = data.Saches.Where(m => m.masach == id).First();
            return View(D_book);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_book = data.Saches.Where(m => m.masach == id).First();
            data.Saches.DeleteOnSubmit(D_book);
            data.SubmitChanges();
            return RedirectToAction("ListBook");
        }

        // get Path img in system
        public string ProcessUpLoad(HttpPostedFileBase file)
        {
            if(file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));  
            return "/Content/images/" + file.FileName;
        }
    }
}