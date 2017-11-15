using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCF.Models
{
    public class Login
    {
        public static bool VerificaEmail(string email)
        {
            using (CadastroLogin dc = new CadastroLogin())
            {
                var existeEmail = (from u in dc.Usuarios
                                   where u.Email == email
                                   select u).FirstOrDefault();
                if (existeEmail != null)
                    return true;
                else
                    return false;
            }
        }
    }
}