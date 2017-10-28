using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCF;

namespace SCF.Views.Conveniado
{
    public class ConveniadoesController : Controller
    {
        private SCFEntities db = new SCFEntities();

        // GET: Conveniadoes
        public ActionResult Index()
        {
            var conveniado = db.Conveniado.Include(c => c.Endereco).Include(c => c.TipoConveniado);
            return View(conveniado.ToList());
        }

        // GET: Conveniadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conveniado conveniado = db.Conveniado.Find(id);
            if (conveniado == null)
            {
                return HttpNotFound();
            }
            return View(conveniado);
        }

        // GET: Conveniadoes/Create
        public ActionResult Create()
        {
            ViewBag.IdEndereco = new SelectList(db.Endereco, "IdEndereco", "Descricao");
            ViewBag.IdTipoConveniado = new SelectList(db.TipoConveniado, "IdTipoConveniado", "Descricao");
            return View();
        }

        // POST: Conveniadoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdConveniado,Descricao,IdEndereco,Numero,Complemento,Bairro,IdTipoConveniado")] Conveniado conveniado)
        {
            if (ModelState.IsValid)
            {
                db.Conveniado.Add(conveniado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEndereco = new SelectList(db.Endereco, "IdEndereco", "Descricao", conveniado.IdEndereco);
            ViewBag.IdTipoConveniado = new SelectList(db.TipoConveniado, "IdTipoConveniado", "Descricao", conveniado.IdTipoConveniado);
            return View(conveniado);
        }

        // GET: Conveniadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conveniado conveniado = db.Conveniado.Find(id);
            if (conveniado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEndereco = new SelectList(db.Endereco, "IdEndereco", "Descricao", conveniado.IdEndereco);
            ViewBag.IdTipoConveniado = new SelectList(db.TipoConveniado, "IdTipoConveniado", "Descricao", conveniado.IdTipoConveniado);
            return View(conveniado);
        }

        // POST: Conveniadoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdConveniado,Descricao,IdEndereco,Numero,Complemento,Bairro,IdTipoConveniado")] Conveniado conveniado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conveniado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEndereco = new SelectList(db.Endereco, "IdEndereco", "Descricao", conveniado.IdEndereco);
            ViewBag.IdTipoConveniado = new SelectList(db.TipoConveniado, "IdTipoConveniado", "Descricao", conveniado.IdTipoConveniado);
            return View(conveniado);
        }

        // GET: Conveniadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conveniado conveniado = db.Conveniado.Find(id);
            if (conveniado == null)
            {
                return HttpNotFound();
            }
            return View(conveniado);
        }

        // POST: Conveniadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conveniado conveniado = db.Conveniado.Find(id);
            db.Conveniado.Remove(conveniado);
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
