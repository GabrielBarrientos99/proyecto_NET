using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FLK.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_FLK.Controllers
{
    public class GestionarVehiculosController : Controller
    {
        private readonly BdSswoggflkContext _context;

        public GestionarVehiculosController(BdSswoggflkContext context)
        {
            _context = context;
        }

        // Acción para listar los vehículos y tipos de vehículos
        public async Task<IActionResult> Index()
        {
            var viewModel = new GestionarVehiculoViewModel
            {
                Vehiculos = await _context.Vehiculos
                    .Include(v => v.FkTipoDeVehiculosNavigation)
                    .ToListAsync(),
                TipoDeVehiculos = await _context.TipoDeVehiculos.ToListAsync()
            };

            return View(viewModel);
        }

        // Acción para mostrar el formulario de creación de vehículo
        public IActionResult AgregarVehiculo()
        {
            ViewBag.TiposDeVehiculos = _context.TipoDeVehiculos.ToList();
            return View();
        }

        // Acción para procesar la creación de vehículo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarVehiculo(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TiposDeVehiculos = _context.TipoDeVehiculos.ToList();
            return View(vehiculo);
        }

        // Acción para mostrar el formulario de edición de vehículo
        public async Task<IActionResult> EditarVehiculos(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            var viewModel = new GestionarVehiculoViewModel
            {
                Vehiculo = vehiculo,
                TipoDeVehiculos = await _context.TipoDeVehiculos.ToListAsync()
            };

            return View(viewModel);
        }

        // Acción para procesar la edición de vehículo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarVehiculos(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.PkVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.PkVehiculo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TiposDeVehiculos = _context.TipoDeVehiculos.ToList();
            return View(vehiculo);
        }

        // Acción para mostrar el formulario de confirmación de eliminación de vehículo
        public async Task<IActionResult> EliminarVehiculos(int id)
        {
            var vehiculo = await _context.Vehiculos
                .Include(v => v.FkTipoDeVehiculosNavigation)
                .FirstOrDefaultAsync(m => m.PkVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View("EliminarVehiculos", vehiculo);
        }

        // Acción para procesar la eliminación de vehículo
        [HttpPost, ActionName("EliminarVehiculos")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarVehiculosConfirmado(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método para verificar si el vehículo existe
        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.PkVehiculo == id);
        }

        // --- ACCIONES PARA TIPO DE VEHÍCULOS ---

        // Acción para mostrar el formulario de creación de un nuevo tipo de vehículo
        public IActionResult CrearTipoVehiculo()
        {
            return View(); // Crea una vista llamada "CrearTipoVehiculo.cshtml"
        }

        // Acción para procesar la creación de un nuevo tipo de vehículo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearTipoVehiculo(TipoDeVehiculo tipoDeVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeVehiculo);
        }

        // Acción para editar un tipo de vehículo
        public async Task<IActionResult> EditarTipoVehiculo(int id)
        {
            var tipoDeVehiculo = await _context.TipoDeVehiculos.FindAsync(id);
            if (tipoDeVehiculo == null)
            {
                return NotFound();
            }
            return View(tipoDeVehiculo); // Crea una vista llamada "EditarTipoVehiculo.cshtml"
        }

        // Acción para procesar la edición de un tipo de vehículo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarTipoVehiculo(int id, GestionarVehiculoViewModel viewModel)
        {
            if (id != viewModel.TipoDeVehiculo.PkTipoDeVehiculos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Busca el tipo de vehículo existente en la base de datos
                    var tipoVehiculo = await _context.TipoDeVehiculos.FindAsync(id);
                    if (tipoVehiculo == null)
                    {
                        return NotFound();
                    }

                    // Actualiza las propiedades del tipo de vehículo con los valores del formulario
                    tipoVehiculo.TipoDeVehiculo1 = viewModel.TipoDeVehiculo.TipoDeVehiculo1;
                    tipoVehiculo.CapacidadCarga = viewModel.TipoDeVehiculo.CapacidadCarga;
                    tipoVehiculo.Descripcion = viewModel.TipoDeVehiculo.Descripcion;

                    // Guarda los cambios en la base de datos
                    _context.Update(tipoVehiculo);
                    await _context.SaveChangesAsync();

                    // Redirige al usuario a la lista de tipos de vehículos u otra página adecuada
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TipoDeVehiculos.Any(e => e.PkTipoDeVehiculos == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Si algo falla, regresa la vista con el modelo actual
            return View(viewModel);
        }


        // Acción para eliminar un tipo de vehículo
        public async Task<IActionResult> EliminarTipoVehiculo(int id)
        {
            var tipoDeVehiculo = await _context.TipoDeVehiculos.FindAsync(id);
            if (tipoDeVehiculo == null)
            {
                return NotFound();
            }

            return View(tipoDeVehiculo); // Crea una vista llamada "EliminarTipoVehiculo.cshtml"
        }

        // Acción para confirmar la eliminación de un tipo de vehículo
        [HttpPost, ActionName("EliminarTipoVehiculo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarTipoVehiculoConfirmado(int id)
        {
            var tipoDeVehiculo = await _context.TipoDeVehiculos.FindAsync(id);
            _context.TipoDeVehiculos.Remove(tipoDeVehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método para verificar si el tipo de vehículo existe
        private bool TipoVehiculoExists(int id)
        {
            return _context.TipoDeVehiculos.Any(e => e.PkTipoDeVehiculos == id);
        }
    }
}
