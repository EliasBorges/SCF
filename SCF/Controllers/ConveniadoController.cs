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
    public class ConveniadoController : Controller
    {
        private SCFContext db = new SCFContext();

        // GET: Conveniado
        public ActionResult Index()
        {
            return View(db.Conveniado.ToList());
        }

        // GET: Conveniado/Details/5
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

        // GET: Conveniado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conveniado/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Matricula,CPF,RG,DataNascimento,DataAdmissao,Logradouro,Numero,Complemento,Bairro,CEP,Cidade,TelResidencial,TelCelular1,Email,EstadoCivil,Observacao,TipoConveniado")] Conveniado conveniado)
        {
            if (ModelState.IsValid)
            {
                db.Conveniado.Add(conveniado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conveniado);
        }

        // GET: Conveniado/Edit/5
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
            return View(conveniado);
        }

        // POST: Conveniado/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Matricula,CPF,RG,DataNascimento,DataAdmissao,Logradouro,Numero,Complemento,Bairro,CEP,Cidade,TelResidencial,TelCelular1,Email,EstadoCivil,Observacao,TipoConveniado")] Conveniado conveniado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conveniado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conveniado);
        }

        // GET: Conveniado/Delete/5
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

        // POST: Conveniado/Delete/5
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
