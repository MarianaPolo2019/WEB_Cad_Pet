using Cad_Pet.Context;
using Cad_Pet.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Cad_Pet.Controllers
{
    public class DonoController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Dono
        public ActionResult Index()
        {
            return View(db.Donos.ToList());
        }
        #region Create
        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DonoModel donoModel)
        {
            if (ModelState.IsValid)
            {
                db.Donos.Add(donoModel);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(donoModel);
        }
        #endregion

        #region Details
        //GET: Details
        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonoModel donoModel = db.Donos.Find(id);
            if (donoModel ==null )
            {
                return HttpNotFound();
            }
            return View(donoModel);
        }


        #endregion

        #region Edit
        //GET: Edit
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonoModel donoModel = db.Donos.Find(id);
            if (donoModel == null)
            {
                return HttpNotFound();
            }
            return View(donoModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: Edit
        public ActionResult Edit(DonoModel donoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(donoModel);
        }
        #endregion

        #region Delete
        //GET: Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonoModel donoModel = db.Donos.Find(id);
            if (donoModel == null)
            {
                return HttpNotFound();
            }
            return View(donoModel);
        }
        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonoModel donoModel = db.Donos.Find(id);
            db.Donos.Remove(donoModel);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}