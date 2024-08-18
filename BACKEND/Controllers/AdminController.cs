using Microsoft.AspNetCore.Mvc;

namespace PROYECTO_FLK.BACKEND.Controllers
{

    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Administrador()
        {
            return View();
        }

        public IActionResult GestionarUsuarios()
        {
            return View();
        }
        public IActionResult GestionarCertificados()
        {
            return View();
        }
        public IActionResult GestionarEmpresas()
        {
            return View();
        }
        public IActionResult GestionarAgendaGeneral()
        {
            return View();
        }
        public IActionResult GestionarTiposdeCertificados()
        {
            return View();
        }

        public IActionResult GestionarTiposdeServicio()
        {
            return View();
        }
        public IActionResult GestionarServicios()
        {
            return View();
        }
    }
}
