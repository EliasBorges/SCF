using BootstrapMvcSample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCF.Controllers
{
    public class ConveniadoController : BootstrapBaseController
    {
        // GET: Conveniado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManterConveniado()
        {
            return View();
        }
    }
}