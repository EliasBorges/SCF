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
using SCF.Controllers;
using System.Text.RegularExpressions;

namespace SCF.Controllers
{
    public class ConveniadoController : BootstrapBaseController
    {
        private SCFContext db = new SCFContext();

        #region Métodos
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
        public ActionResult Create([Bind(Include = "Nome,Matricula,CPF,RG,DataNascimento,DataAdmissao,Logradouro,Numero,Complemento,Bairro,CEP,Cidade,TelResidencial,TelCelular1,Email,EstadoCivil,Observacao,TipoConveniado")] Conveniado conveniado)
        {
            try
            {
                if (ValidaCPF(conveniado.CPF))
                {
                    if (ModelState.IsValid)
                    {
                        db.Conveniado.Add(conveniado);
                        db.SaveChanges();
                        Success("Conveniado salvo com Sucesso!");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Error("Ocorreu um erro ao tentar validar a estrutura do Conveniado!");
                        return View("Create", conveniado);
                    }
                }
                else
                {
                    Error("CPF com formato inválido!!");
                    return View("Create", conveniado);
                }

            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");


                return View("Create", conveniado);
            }
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

        #endregion
        
        #region Validações

        public bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
        #endregion
    }
}
