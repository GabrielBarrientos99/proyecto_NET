using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FLK.Models;
using System.Threading.Tasks;

namespace PROYECTO_FLK.Controllers
{
    public class AgendarCitaController : Controller
    {
        private readonly BdSswoggflkContext _context;

        public AgendarCitaController(BdSswoggflkContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var inspecciones = _context.Inspecciones
                .Include(i => i.FkEmpresasNavigation)
                .Include(i => i.FkTipoDeServicioNavigation)
                .Include(i => i.FkTipoInspeccionesNavigation)
                .ToList();

            var tiposServicio = _context.TiposServicios.ToList(); // Aquí cargas los tipos de servicio

            var viewModel = new AgendarCitaViewModel
            {
                Inspecciones = inspecciones,
                TiposServicios = tiposServicio
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AgendarCita()
        {
            ViewBag.TiposDeServicio = _context.TiposServicios.ToList();
            return View();
        }


        // Método para cargar el modal de selección de servicio
        public IActionResult SeleccionarServicio()
        {
            var servicios = _context.TiposServicios.ToList();
            return PartialView("SeleccionarServicio", servicios);
        }


        [HttpPost]
        public IActionResult SeleccionarTipoInspeccion(int servicioId)
        {
            var tiposInspeccion = _context.TipoInspeccions
                .Where(t => t.FkTipoCertificadoDePersonal == servicioId)
                .Select(t => new { t.PkTipoInspeccion, t.Titulo }) // Solo selecciona el campo "Titulo"
                .ToList();

            return PartialView("SeleccionarTipoInspeccion", tiposInspeccion);
        }


        [HttpGet]
        public IActionResult RegistrarEmpresa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEmpresa(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AgendarCita));
            }
            return View(empresa);
        }

        [HttpGet]
        public IActionResult CompletarInspeccion()
        {
            return PartialView("CompletarInspeccion");
        }

        [HttpPost]
        public async Task<IActionResult> CompletarInspeccion(Inspeccione inspeccion)
        {
            if (ModelState.IsValid)
            {
                _context.Inspecciones.Add(inspeccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView("CompletarInspeccion", inspeccion);
        }
    }
}
