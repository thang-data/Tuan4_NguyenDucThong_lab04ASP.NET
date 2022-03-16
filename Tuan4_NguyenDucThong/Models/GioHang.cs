using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tuan4_NguyenDucThong.Models;

namespace Tuan4_NguyenDucThong.Models
{
    public class GioHang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int masach
        {
            get;set;
        }
        [Display(Name = "Ten sach")]
        public string tensach { get; set; }
        [Display(Name = "Anh bia")]
        public string hinh { get; set; }
        [Display(Name = "Gia ban")]
        public Double giaban { get; set; }
        [Display(Name = "So luong")]
        public int iSoLuong { get; set; }
        [Display(Name = "Gia ban")]
        public Double dThanhTien
        {
            get
            {
                return iSoLuong * giaban;
            }
        }

        public GioHang(int id)
        {
            masach = id;
            Sach sach = data.Saches.Single(n => n.masach == masach);
            tensach = sach.tensach;
            hinh = sach.hinh;
            giaban = double.Parse(sach.giaban.ToString());
            iSoLuong = 1;
        }
    }
}