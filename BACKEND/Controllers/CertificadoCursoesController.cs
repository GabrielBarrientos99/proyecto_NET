using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROYECTO_FLK.Models;

namespace PROYECTO_FLK.BACKEND.Controllers
{
    public class CertificadoCursoesController : Controller
    {
        private readonly BdSswoggflkContext _context;

        public CertificadoCursoesController(BdSswoggflkContext context)
        {
            _context = context;
        }

        // GET: CertificadoCursoes
        public async Task<IActionResult> Index()
        {
            var bdSswoggflkContext = _context.CertificadoCursos.Include(c => c.FkServicioNavigation);
            return View(await bdSswoggflkContext.ToListAsync());
        }

        // GET: CertificadoCursoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificadoCurso = await _context.CertificadoCursos
                .Include(c => c.FkServicioNavigation)
                .FirstOrDefaultAsync(m => m.PkCertificadoCurso == id);
            if (certificadoCurso == null)
            {
                return NotFound();
            }

            return View(certificadoCurso);
        }

        // GET: CertificadoCursoes/Create
        public IActionResult Create()
        {
            ViewData["FkServicio"] = new SelectList(_context.Servicios, "PkServicio", "PkServicio");
            return View();
        }

        // POST: CertificadoCursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkCertificadoCurso,FkServicio,FechaEmision,FechaCaducidad")] CertificadoCurso certificadoCurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificadoCurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkServicio"] = new SelectList(_context.Servicios, "PkServicio", "PkServicio", certificadoCurso.FkServicio);
            return View(certificadoCurso);
        }

        // GET: CertificadoCursoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificadoCurso = await _context.CertificadoCursos.FindAsync(id);
            if (certificadoCurso == null)
            {
                return NotFound();
            }
            ViewData["FkServicio"] = new SelectList(_context.Servicios, "PkServicio", "PkServicio", certificadoCurso.FkServicio);
            return View(certificadoCurso);
        }

        // POST: CertificadoCursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkCertificadoCurso,FkServicio,FechaEmision,FechaCaducidad")] CertificadoCurso certificadoCurso)
        {
            if (id != certificadoCurso.PkCertificadoCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificadoCurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificadoCursoExists(certificadoCurso.PkCertificadoCurso))
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
            ViewData["FkServicio"] = new SelectList(_context.Servicios, "PkServicio", "PkServicio", certificadoCurso.FkServicio);
            return View(certificadoCurso);
        }

        // GET: CertificadoCursoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificadoCurso = await _context.CertificadoCursos
                .Include(c => c.FkServicioNavigation)
                .FirstOrDefaultAsync(m => m.PkCertificadoCurso == id);
            if (certificadoCurso == null)
            {
                return NotFound();
            }

            return View(certificadoCurso);
        }

        // POST: CertificadoCursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificadoCurso = await _context.CertificadoCursos.FindAsync(id);
            if (certificadoCurso != null)
            {
                _context.CertificadoCursos.Remove(certificadoCurso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificadoCursoExists(int id)
        {
            return _context.CertificadoCursos.Any(e => e.PkCertificadoCurso == id);
        }
    }
}
