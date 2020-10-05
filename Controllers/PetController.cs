using Cad_Pet.Context;
using Cad_Pet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Bend.Controllers
{
    public class PetController : Controller

    {
        private Contexto db = new Contexto();

        // GET: Index
        public ActionResult Index()
        {
            var pets = db.Pets.Include(a => a.DonoModel).ToList();
            return View(pets.ToList());
        }

        #region Create
        //GET: Create
        public ActionResult Create()
        {
            ViewBag.DonoId = new SelectList(db.Donos, "Id", "Nome");
            return View();
        }
        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetModel petModel)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(petModel);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DonoId = new SelectList(db.Donos, "Id", "Nome", petModel.DonoId);
            return View(petModel);
        }
        #endregion

        #region Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            PetModel petModel = db.Pets.Find(id);
            if (petModel == null)
            {
                return HttpNotFound();
            }
            return View(petModel);
        }
        #endregion

        #region Edit
        //GET: Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            PetModel petModel = db.Pets.Find(id);
            if (petModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonoId = new SelectList(db.Donos, "Id", "Nome", petModel.DonoId);
            return View(petModel);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PetModel petModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DonoId = new SelectList(db.Donos, "Id", "Nome", petModel.DonoId);
            return View(petModel);
        }
        #endregion

        #region Delete
        //GET: Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            PetModel petModel = db.Pets.Find(id);
            if (petModel == null)
            {
                return HttpNotFound();
            }
            return View(petModel);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetModel petModel = db.Pets.Find(id);
            db.Pets.Remove(petModel);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}