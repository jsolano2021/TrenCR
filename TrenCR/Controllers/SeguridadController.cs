using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrenCR.Models;

namespace TrenCR.Controllers
{
    public class SeguridadController : Controller
    {
        private readonly TrenCRContext _context;

        public SeguridadController(TrenCRContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario user)
        {

            if (user != null)
            {
                Usuario miUsuario = _context.Usuario.Where(x => x.UserName.ToUpper().Equals(user.UserName.ToUpper())
                             && x.Password.Equals(user.Password)).FirstOrDefault();

                if (miUsuario != null)
                {
                    HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(miUsuario));

                    if (miUsuario.IdPerfil == 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Boletos");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Seguridad");
                }
            }

            return View();
        }
         
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Usuario");
            return RedirectToAction("Login", "Seguridad");
        }
    }
}
