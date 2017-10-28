using BootstrapMvcSample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCF.Controllers
{
    public class LoginController : BootstrapBaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManterLogin()
        {
            return View();
        }
    }
}