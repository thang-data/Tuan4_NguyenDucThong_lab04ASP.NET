using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_NguyenDucThong.Models;
namespace Tuan4_NguyenDucThong.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var all_Book = (from ss in data.Saches select ss).OrderBy(m => m.masach);
            int pageSize = 3;
            int pageNum = page ?? 1;


            return View(all_Book.ToPagedList(pageNum, pageSize));
        }
    }
}