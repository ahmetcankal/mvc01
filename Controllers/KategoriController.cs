using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eticaret01.Models;


namespace eticaret01.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        musteriEntities db = new musteriEntities();        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult katListe()
        {
            return PartialView(db.tbkategoriler.ToList());
        }



    }
}