using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PRODUTOSController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PRODUTOS
        public ActionResult Index()
        {
            return View(db.PRODUTOS.ToList());
        }

        // GET: PRODUTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUTO pRODUTO = db.PRODUTOS.Find(id);
            if (pRODUTO == null)
            {
                return HttpNotFound();
            }
             var CREDENCIAMENTOS = db.CREDENCIAMENTOS.Include(c => c.COLABORADORES).Include(c => c.CONTRATO).Include(c => c.ESPECIALIDADE_EXAMES);
            return View(pRODUTO);
        }

        // GET: PRODUTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRODUTOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PRODUTO,NOME,PRECO,REGIAO")] PRODUTO pRODUTO)
        {
            if (ModelState.IsValid)
            {  
                Random rnd = new Random();
                pRODUTO.COD_PRODUTO = rnd.Next(10000000,99999999);
                db.PRODUTOS.Add(pRODUTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRODUTO);
        }
        // GET: PRODUTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUTO pRODUTO = db.PRODUTOS.Find(id);
            if (pRODUTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUTO);
        }

        // POST: PRODUTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUTO pRODUTO = db.PRODUTOS.Find(id);
            db.PRODUTOS.Remove(pRODUTO);
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
