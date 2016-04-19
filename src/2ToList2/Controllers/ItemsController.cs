﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using _2ToList2.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace _2ToList2.Controllers
{
    public class ItemsController : Controller
    {
        private _2ToList2Context db = new _2ToList2Context();
        public IActionResult Index()
        {
            return View(db.Items.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }
        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            db.Items.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
