using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eticaret01.Models;
using System.IO;

namespace eticaret01.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler

        musteriEntities db = new musteriEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult urunliste(int? id)
        {
            var sonuc = db.urunler.Where(x=>x.katid==id).ToList();
            return View(sonuc);
        }


        public ActionResult urundetay(int? id)
        {
            var sonuc = db.urunler.Find(id);


            return View(sonuc);
        }

        [HttpGet]
        public ActionResult ekle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ekle(FormCollection frmgelen,HttpPostedFileBase resim)
        {
            if (resim!=null)
            {

                String dosyayolu = Path.Combine(Server.MapPath("~/arayuz/urunres"),
                    Path.GetFileName(resim.FileName));
                resim.SaveAs(dosyayolu);

                urunler yeniurun = new urunler();
                yeniurun.urun_adi = frmgelen["vurunad"];
                yeniurun.resimadi = resim.FileName;
                yeniurun.katid = 2;

                db.urunler.Add(yeniurun);
                db.SaveChanges();

            }

            return View();
        }



    }
}