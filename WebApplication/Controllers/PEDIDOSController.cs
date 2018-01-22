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
    public class PEDIDOSController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PEDIDOS
        public ActionResult Index()
        {
            var pEDIDOS = db.PEDIDOS.Include(p => p.CLIENTES);
            return View(pEDIDOS.ToList());
        }

        // GET: PEDIDOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pEDIDO = db.PEDIDOS.Find(id);
            if (pEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(pEDIDO);
        }

        // GET: PEDIDOS/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTES, "COD_CLIENTE", "NOME");
            return View();
        }

        // POST: PEDIDOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PEDIDO,NOME,PRECO,ID_CLIENTE")] PEDIDO pEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.PEDIDOS.Add(pEDIDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTES, "COD_CLIENTE", "NOME", pEDIDO.ID_CLIENTE);
            return View(pEDIDO);
        }

        // GET: PEDIDOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pEDIDO = db.PEDIDOS.Find(id);
            if (pEDIDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTES, "COD_CLIENTE", "NOME", pEDIDO.ID_CLIENTE);
            return View(pEDIDO);
        }

        // POST: PEDIDOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PEDIDO,NOME,PRECO,ID_CLIENTE")] PEDIDO pEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pEDIDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTES, "COD_CLIENTE", "NOME", pEDIDO.ID_CLIENTE);
            return View(pEDIDO);
        }

        // GET: PEDIDOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pEDIDO = db.PEDIDOS.Find(id);
            if (pEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(pEDIDO);
        }

        // POST: PEDIDOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PEDIDO pEDIDO = db.PEDIDOS.Find(id);
            db.PEDIDOS.Remove(pEDIDO);
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
