using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCF.Controllers
{
    public class FinanceiroController : Controller
    {
        // GET: Financeiro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManterFluxoCaixa()
        {
            return View();
        }

        public ActionResult VisualizarContaPagar()
        {
            return View();
        }

        public ActionResult VisualizarContaReceber()
        {
            return View();
        }
    }
}