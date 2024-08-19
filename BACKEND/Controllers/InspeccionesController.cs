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

        // Acción para mostrar la vista de inspecciones y asignaturas
        public async Task<IActionResult> GestionarInspeccionesYAsignaturas(string searchInspeccion, string searchAsignatura)
        {
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

            // Creación del ViewModel para pasar ambos conjuntos de datos a la vista
            var viewModel = new InspeccionesViewModel
            {
                Inspecciones = await inspecciones.ToListAsync(),
                Asignaturas = await asignaturas.ToListAsync()
            };

            return View(viewModel);
        }

        // Aquí podrías añadir otras acciones como Crear, Editar, Eliminar para inspecciones y asignaturas.
    }

    // ViewModel que agrupa los datos de inspecciones y asignaturas
    public class InspeccionesViewModel
    {
        public List<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
        public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
    }
}
