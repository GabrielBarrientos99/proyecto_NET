using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FLK.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_FLK.Controllers
{
    public class InspeccionesController : Controller
    {
        private readonly BdSswoggflkContext _context;

        public InspeccionesController(BdSswoggflkContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> InspeccionesAsignaturas(string searchInspeccion, string searchAsignatura)
        {
            // Guardar los parámetros de búsqueda en ViewData para usarlos en la vista
            ViewData["searchInspeccion"] = searchInspeccion;
            ViewData["searchAsignatura"] = searchAsignatura;

            // Filtrado de inspecciones
            var inspecciones = from i in _context.Inspecciones.Include(i => i.FkTipoInspeccionesNavigation)
                               select i;

            if (!string.IsNullOrEmpty(searchInspeccion))
            {
                inspecciones = inspecciones.Where(i => i.Descripcion.Contains(searchInspeccion));
            }

            // Filtrado de asignaturas
            var asignaturas = from a in _context.Asignaturas
                              select a;

            if (!string.IsNullOrEmpty(searchAsignatura))
            {
                asignaturas = asignaturas.Where(a => a.Nombre.Contains(searchAsignatura));
            }

            // Crear el ViewModel con los datos filtrados
            var viewModel = new InspeccionesViewModel
            {
                Inspecciones = await inspecciones.ToListAsync(),
                Asignaturas = await asignaturas.ToListAsync()
            };

            return View(viewModel);
        }
    }
}
