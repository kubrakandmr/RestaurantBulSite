﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RestaurantBul.Models;

namespace RestaurantBul.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Place);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        

        // GET: Comments/Create
        public ActionResult Create(int Id)
        {
            //ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceName");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,Content,CommentPic,Point,PlaceID,UserID")] Comment comment,int Id, HttpPostedFileBase CommentPic)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    if (CommentPic != null)
                    {
                        WebImage img = new WebImage(CommentPic.InputStream);
                        FileInfo photoInfo = new FileInfo(CommentPic.FileName);

                        string newfoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                        img.Resize(800, 350); //resim boyutu için
                        img.Save("../UpLoads/Pictures/" + newfoto);
                        comment.CommentPic = "../UpLoads/Pictures/" + newfoto;
                    }

                    string usid = User.Identity.GetUserId();
                    var us = (from a in db.Users
                              where a.Id == usid
                              select a).FirstOrDefault();
                    comment.ApplicationUser = us;
                    var pla = (from a in db.Places
                               where a.PlaceID == Id
                               select a).FirstOrDefault();
                    comment.Place = pla;
                    db.Comments.Add(comment);
                    db.SaveChanges();

                    return View();
                }
                catch (Exception)
                {
                    return View(comment);

                }


            }

            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceName", comment.PlaceID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,Content,CommentPic,Point,PlaceID,UserID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceName", comment.PlaceID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
