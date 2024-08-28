using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FLK.Models;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;




namespace PROYECTO_FLK.Controllers
{
    public class AgendarCitaController : Controller
    {
        private readonly BdSswoggflkContext _context;
        private readonly ICompositeViewEngine _viewEngine;


        public AgendarCitaController(BdSswoggflkContext context, ICompositeViewEngine viewEngine)
        {
            _context = context;
            _viewEngine = viewEngine;

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

       [HttpPost]
        public IActionResult SeleccionarServicio(int selectedTipoServicioId)
        {
            var viewModel = new AgendarCitaViewModel
            {
                SelectedTipoServicioId = selectedTipoServicioId,
                TipoInspeccions = _context.TipoInspeccions
                    .Where(t => t.FkTipoCertificadoDePersonal == selectedTipoServicioId)
                    .ToList()
            };
            return PartialView("SeleccionarTipoInspeccion", viewModel);
        }

        [HttpPost]
        public IActionResult SeleccionarTipoInspeccion(int selectedTipoServicioId, int selectedTipoInspeccionId)
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

                var inspeccion = new Inspeccione
                {
                    FkTipoDeServicio = model.SelectedTipoServicioId,
                    FkTipoInspecciones = model.SelectedTipoInspeccionId,
                    FkEmpresas = empresa.PkEmpresas,
                    // Otras propiedades
                };

                _context.Inspecciones.Add(inspeccion);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult CompletarInspeccion(int empresaId)
        {
            var model = new AgendarCitaViewModel
            {
                InspeccionCompleta = new Inspeccione
                {
                    FkEmpresas = empresaId
                }
            };

            // Devuelve un PartialView en lugar de un View
            return PartialView("CompletarInspeccion", model);
        }

        [HttpPost]
        public IActionResult CompletarInspeccion(AgendarCitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var inspeccion = model.InspeccionCompleta;
                inspeccion.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
                _context.Inspecciones.Add(inspeccion);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }

}

