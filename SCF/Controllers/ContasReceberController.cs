using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCF.BancoDados;
using SCF.Models;

namespace SCF.Controllers
{
    public class ContasReceberController : Controller
    {
        private SCFContext db = new SCFContext();

        // GET: ContasReceber
        public ActionResult Index()
        {
            return View(db.ContasReceber.ToList());
        }

        // GET: ContasReceber/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasReceber contasReceber = db.ContasReceber.Find(id);
            if (contasReceber == null)
            {
                return HttpNotFound();
            }
            return View(contasReceber);
        }

        // GET: ContasReceber/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContasReceber/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContasReceberId,Desdobramento,ConveniadoId,Valor,DataVencimento,ValorPago,DataPagamento")] ContasReceber contasReceber)
        {
            if (ModelState.IsValid)
            {
                db.ContasReceber.Add(contasReceber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contasReceber);
        }

        // GET: ContasReceber/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasReceber contasReceber = db.ContasReceber.Find(id);
            if (contasReceber == null)
            {
                return HttpNotFound();
            }
            return View(contasReceber);
        }

        // POST: ContasReceber/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContasReceberId,Desdobramento,ConveniadoId,Valor,DataVencimento,ValorPago,DataPagamento")] ContasReceber contasReceber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contasReceber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contasReceber);
        }

        // GET: ContasReceber/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasReceber contasReceber = db.ContasReceber.Find(id);
            if (contasReceber == null)
            {
                return HttpNotFound();
            }
            return View(contasReceber);
        }

        // POST: ContasReceber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContasReceber contasReceber = db.ContasReceber.Find(id);
            db.ContasReceber.Remove(contasReceber);
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
