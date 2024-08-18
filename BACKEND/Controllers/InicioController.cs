using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_FLK.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using PROYECTO_FLK.BACKEND.Servicios.Contrato;

namespace PROYECTO_FLK.BACKEND.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public InicioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string nombre_usuario, string contraseña)
        {
            Usuario usuario_encontrado = await _usuarioService.GetUsuario(nombre_usuario, contraseña);

            if (usuario_encontrado == null)
            {

                ViewData["Mensaje"] = "No se encontro Usuario";
                return View();

            }
            List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,usuario_encontrado.NombreUsuario)
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true

            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                 properties);


            //return RedirectToAction("Index", "Home");

            if (usuario_encontrado.FkRol == 1)
            {
                return RedirectToAction("Administrador", "Admin");
            }
            if (usuario_encontrado.FkRol == 2)
            {
                return RedirectToAction("Recepcionista", "Recepcionista");
            }
            if (usuario_encontrado.FkRol == 3)
            {
                return RedirectToAction("AsistentedeOperaciones", "AsistenteOperaciones");
            }

            //if (usuario_encontrado.FkRol == 2)
            //{
            //    return RedirectToAction("Recepcionista", "Admin");
            //}


            //if (usuario_encontrado.FkRol == 3)
            //{
            //    return RedirectToAction("Asistente de Operaciones", "Admin");
            //}

            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}

