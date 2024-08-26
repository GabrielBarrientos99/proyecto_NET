using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FLK.Models;
using System.Linq;
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


        public async Task<IActionResult> Index()
        {
            var inspecciones = await _context.Inspecciones
                .Include(i => i.FkEmpresasNavigation)
                .Include(i => i.FkTipoDeServicioNavigation)
                .Include(i => i.FkTipoInspeccionesNavigation)
                .ToListAsync();

            var tiposServicio = await _context.TiposServicios.ToListAsync();
            var tiposDeInspeccion = await _context.TipoInspeccions.ToListAsync();
            var empresas = await _context.Empresas.ToListAsync();

            var viewModel = new AgendarCitaViewModel
            {
                Inspecciones = inspecciones,
                TiposServicios = tiposServicio,
                TipoInspeccions = tiposDeInspeccion,
                Empresas = empresas
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AgendarCita()
        {
            ViewBag.TiposDeServicio = _context.TiposServicios.ToList();
            return View();
        }

        public IActionResult SeleccionarServicio()
        {
            var viewModel = new AgendarCitaViewModel
            {
                TiposServicios = _context.TiposServicios.ToList()
            };
            return PartialView("SeleccionarServicio", viewModel);
        }

        [HttpPost]
        public IActionResult SeleccionarTipoInspeccion(int selectedTipoServicioId)
        {
            var viewModel = new AgendarCitaViewModel
            {
                SelectedTipoServicioId = selectedTipoServicioId,
                TipoInspeccions = _context.TipoInspeccions.Where(t => t.FkTipoCertificadoDePersonal == selectedTipoServicioId).ToList()
            };

            return PartialView("SeleccionarTipoInspeccion", viewModel);
        }

        [HttpGet]
        public IActionResult RegistrarEmpresa(int selectedTipoServicioId, int selectedTipoInspeccionId)
        {
            var viewModel = new AgendarCitaViewModel
            {
                SelectedTipoServicioId = selectedTipoServicioId,
                SelectedTipoInspeccionId = selectedTipoInspeccionId,
                NuevaEmpresa = new Empresa()
            };

            return PartialView("RegistrarEmpresa", viewModel);
        }

        [HttpPost]
        public IActionResult RegistrarEmpresa(AgendarCitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var empresa = model.NuevaEmpresa;
                _context.Empresas.Add(empresa);
                _context.SaveChanges();

                // Rediriges al modal de completar inspección manteniendo los valores seleccionados
                model.InspeccionCompleta = new Inspeccione
                {
                    FkEmpresas = empresa.PkEmpresas,
                    FkTipoDeServicio = model.SelectedTipoServicioId,
                    FkTipoInspecciones = model.SelectedTipoInspeccionId
                };

                return PartialView("CompletarInspeccion", model); // Devuelve el modal como vista parcial
            }

            return PartialView("RegistrarEmpresa", model); // Si hay un error, regresa la misma vista
        }

        [HttpPost]
        public async Task<IActionResult> CompletarInspeccion(Inspeccione inspeccion)
        {
            if (ModelState.IsValid)
            {
                inspeccion.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
                _context.Inspecciones.Add(inspeccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView("CompletarInspeccion", inspeccion);
        }
    }
}
