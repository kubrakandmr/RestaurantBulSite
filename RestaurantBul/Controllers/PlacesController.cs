using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using RestaurantBul.Models;
using static RestaurantBul.Enums.Enums;

namespace RestaurantBul.Controllers
{
    public class PlacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Places
        public ActionResult Index()
        {
            return View(db.Places.ToList());
        }

        public ActionResult BreakfastList()
        {
            CategoryName side = CategoryName.Kahvalti;
            var result = db.Places.Where(x => x.CategoryName == side).ToList();
            db.SaveChanges();
            return View(result);

        }

        public ActionResult EnjoyList()
        {
            CategoryName side = CategoryName.EğlenceyeCik;
            var result = db.Places.Where(x => x.CategoryName == side).ToList();
            db.SaveChanges();
            return View(result);

        }

        public ActionResult EatandOutList()
        {
            CategoryName side = CategoryName.YeveKalk;
            var result = db.Places.Where(x => x.CategoryName == side).ToList();
            db.SaveChanges();
            return View(result);

        }

        public ActionResult EatList()
        {
            CategoryName side = CategoryName.Yemek;
            var result = db.Places.Where(x => x.CategoryName == side).ToList();
            db.SaveChanges();
            return View(result);

        }

        public ActionResult CafeList()
        {
            CategoryName side = CategoryName.CafeyeGit;
            var result = db.Places.Where(x => x.CategoryName == side).ToList();
            db.SaveChanges();
            return View(result);

        }
        [HttpGet]
        public ActionResult PlaceDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PlaceDetails(Place place)
        {
            var result = (from a in db.Places
                          join b in db.Comments on a.PlaceID equals b.PlaceID
                          join c in db.Users on b.ApplicationUser.Id equals c.Id
                          select new
                          {
                              a.PlaceName,
                              a.OpenTime,
                              a.Phone,
                              a.County,
                              a.CloseTime,
                              a.City,
                              a.Address,
                              b.Content,
                              b.CommentPic,
                              c.Name,
                              c.Surname

                          }).ToList();
            return View(result);

        }

        [HttpPost]
        public ActionResult SearchPlace(string mekanadı)
        {

            var aranan = db.Places.Where(x => x.PlaceName==mekanadı).ToList();
            
            return View(aranan.OrderByDescending(x => x.AvgPrice > 50));
        }

        // GET: Places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }



        [HttpGet]
        public ActionResult MekanEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult MekanEkle(AddPlaViewModel p, HttpPostedFileBase MenuPic)
        {
            Place place = new Place();
            Additional additional = new Additional();
            AddPla addPla = new AddPla();

            if (MenuPic != null)
            {
                WebImage img = new WebImage(MenuPic.InputStream);
                FileInfo photoInfo = new FileInfo(MenuPic.FileName);

                string newfoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                img.Resize(800, 350); //resim boyutu için
                img.Save("../UpLoads/MenuPic/" + newfoto);
                place.MenuPic = "../UpLoads/MenuPic/" +newfoto;
                place.PlaceName = p.PlaceName;
                //place.MenuPic = p.MenuPic;
                place.CategoryName = p.CategoryName;
                place.Phone = p.Phone;
                place.Address = p.Address;
                place.County = p.County;
                place.City = p.City;
                place.OpenTime = p.OpenTime;
                place.CloseTime = p.CloseTime;
                place.AvgPrice = p.AvgPrice;
            }
         
            db.Places.Add(place);
            db.SaveChanges();

            int sonmekan = db.Places.OrderByDescending(x => x.PlaceID).FirstOrDefault().PlaceID;

            #region MyRegion
            additional.AlkolServis = p.AlkolServis;
            additional.CanliMuzik = p.CanliMuzik;
            additional.DenizKenari = p.DenizKenari;
            additional.DisMekan = p.DisMekan;
            additional.GelAl = p.GelAl;
            additional.HayvanDostu = p.HayvanDostu;
            additional.Kahvalti = p.Kahvalti;
            additional.OnlineRezervasyon = p.OnlineRezervasyon;
            additional.Otopark = p.Otopark;
            additional.PaketServis = p.PaketServis;
            additional.SigaraAlanı = p.SigaraAlanı;
            additional.TatlivePasta = p.TatlivePasta;
            additional.TerasiVar = p.TerasiVar;
            additional.Wifi = p.Wifi;
            additional.İcMekan = p.İcMekan;
            #endregion
            db.Additionals.Add(additional);
            db.SaveChanges();

            int sonid = db.Additionals.OrderByDescending(x => x.AdditionalID).FirstOrDefault().AdditionalID;


            addPla.PlaceID = sonmekan;
            addPla.AdditionalID = sonid;
            db.AddPlas.Add(addPla);
            db.SaveChanges();

            

            return View();




        }
        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceID,PlaceName,MenuPic,CategoryName,Phone,Address,County,City,OpenTime,CloseTime,AvgPrice")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(place);
        }

        // GET: Places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceID,PlaceName,MenuPic,CategoryName,Phone,Address,County,City,OpenTime,CloseTime,AvgPrice")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            db.Places.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
