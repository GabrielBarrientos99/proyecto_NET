using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        // Acción para mostrar el formulario de edición
        public IActionResult Editar(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var empresa = _context.Empresas.FirstOrDefault(e => e.Ruc == id);
            if (empresa == null)
                return NotFound();

            return View(empresa);
        }

        [HttpPost]
        public IActionResult Editar(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                var existingEmpresa = _context.Empresas.AsNoTracking().FirstOrDefault(e => e.Ruc == empresa.Ruc);
                if (existingEmpresa == null)
                {
                    ModelState.AddModelError(string.Empty, "La empresa que intentas editar no existe.");
                    return View(empresa);
                }

                try
                {
                    _context.Empresas.Update(empresa);
                    _context.SaveChanges();
                    return RedirectToAction("GestionarEmpresas");
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error de concurrencia al intentar guardar los cambios.");
                    return View(empresa);
                }
            }

            return View(empresa);
        }


        // Acción para confirmar eliminación
        public IActionResult Eliminar(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var empresa = _context.Empresas.FirstOrDefault(e => e.Ruc == id);
            if (empresa == null)
                return NotFound();

            return View(empresa);
        }

        // Acción para procesar la eliminación
        [HttpPost, ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(string id)
        {
            var empresa = _context.Empresas.FirstOrDefault(e => e.Ruc == id);
            if (empresa == null)
                return NotFound();

            _context.Empresas.Remove(empresa);
            _context.SaveChanges();
            return RedirectToAction("GestionarEmpresas");
        }
    }
}



    

