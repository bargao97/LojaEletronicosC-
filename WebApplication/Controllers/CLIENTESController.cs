using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.Enums;

namespace WebApplication.Controllers
{
    public class CLIENTESController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CLIENTES
        public ActionResult Index()
        {
            return View(db.CLIENTES.ToList());
        }

        // GET: CLIENTES/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTES.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pedidos = db.PEDIDOS.Where(s => s.ID_CLIENTE == id).OrderByDescending(s => s.COD_PEDIDO);
            ViewBag.Produtos = db.PRODUTOS.Where(s=>s.REGIAO == cLIENTE.REGIAO).OrderBy(S => S.COD_PRODUTO).ToList();
            return View(cLIENTE);
        }

        // GET: CLIENTES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CLIENTES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CLIENTE,NOME,CPF_CNPJ,DDD,CONTATO,UF,CIDADE,CEP,LOGRADOURO,Numero,BAIRRO,REGIAO")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {

                if (cLIENTE.UF == "GO" || cLIENTE.UF == "DF" || cLIENTE.UF == "MT" || cLIENTE.UF == "MS")
                {
                    cLIENTE.REGIAO = REGIAO.CENTRO_OESTE;
                }
                else if (cLIENTE.UF == "AC" || cLIENTE.UF == "AP" || cLIENTE.UF == "AM" || cLIENTE.UF == "PA" || cLIENTE.UF == "RO" || cLIENTE.UF == "RR" || cLIENTE.UF == "TO")
                {
                    cLIENTE.REGIAO = REGIAO.NORTE;
                }
                else if (cLIENTE.UF == "PR" || cLIENTE.UF == "SC" || cLIENTE.UF == "RS")
                {
                    cLIENTE.REGIAO = REGIAO.SUL;
                }
                else if (cLIENTE.UF == "AL" || cLIENTE.UF == "BA" || cLIENTE.UF == "CE" || cLIENTE.UF == "MA" || cLIENTE.UF == "PB" || cLIENTE.UF == "PI" || cLIENTE.UF == "PE" || cLIENTE.UF == "RN" || cLIENTE.UF == "SE")
                {
                    cLIENTE.REGIAO = REGIAO.NORDESTE;
                }
                else if (cLIENTE.UF == "SP" || cLIENTE.UF == "MG" || cLIENTE.UF == "RJ" || cLIENTE.UF == "ES")
                {
                    cLIENTE.REGIAO = REGIAO.SUDESTE;
                }
                    Random rnd = new Random();
                int COD = rnd.Next(100000, 999999);
                string generatorID = cLIENTE.UF + COD;

                cLIENTE.COD_CLIENTE = generatorID;
                db.CLIENTES.Add(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cLIENTE);
        }

        // GET: CLIENTES/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTES.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: CLIENTES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CLIENTE,NOME,CPF_CNPJ,DDD,CONTATO,UF,CIDADE,CEP,LOGRADOURO,Numero,BAIRRO,REGIAO")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cLIENTE);
        }

        // GET: CLIENTES/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTES.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: CLIENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CLIENTE cLIENTE = db.CLIENTES.Find(id);
            db.CLIENTES.Remove(cLIENTE);
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
