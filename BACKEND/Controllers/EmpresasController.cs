using Microsoft.AspNetCore.Mvc;
using PROYECTO_FLK.Models; 

namespace YourNamespace.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly BdSswoggflkContext _context; 

        public EmpresasController(BdSswoggflkContext context)
        {
            _context = context;
        }

        public IActionResult GestionarEmpresas()
        {
            var empresas = _context.Empresas.ToList(); // Obtén la lista de empresas desde la base de datos
            return View(empresas); // Pasa los datos a la vista
        }
    }
}
