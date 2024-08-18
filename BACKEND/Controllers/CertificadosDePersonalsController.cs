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
    public class CertificadosDePersonalsController : Controller
    {
        private readonly BdSswoggflkContext _context;

        public CertificadosDePersonalsController(BdSswoggflkContext context)
        {
            _context = context;
        }

        // GET: CertificadosDePersonals
        public async Task<IActionResult> Index()
        {
            var bdSswoggflkContext = _context.CertificadosDePersonals.Include(c => c.FkTipoCertificadoDePersonalNavigation).Include(c => c.FkUsuarioNavigation);
            return View(await bdSswoggflkContext.ToListAsync());
        }

        // GET: CertificadosDePersonals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificadosDePersonal = await _context.CertificadosDePersonals
                .Include(c => c.FkTipoCertificadoDePersonalNavigation)
                .Include(c => c.FkUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.PkCertificadosDePersonal == id);
            if (certificadosDePersonal == null)
            {
                return NotFound();
            }

            return View(certificadosDePersonal);
        }

        // GET: CertificadosDePersonals/Create
        public IActionResult Create()
        {
            ViewData["FkTipoCertificadoDePersonal"] = new SelectList(_context.TipoCertificadoDePersonals, "PkTipoCertificadoDePersonal", "PkTipoCertificadoDePersonal");
            ViewData["FkUsuario"] = new SelectList(_context.Usuarios, "PkUsuario", "PkUsuario");
            return View();
        }

        // POST: CertificadosDePersonals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkCertificadosDePersonal,FkUsuario,FkTipoCertificadoDePersonal,Especializacion,FechaEmision,FechaVencimiento,CertificadoPdf")] CertificadosDePersonal certificadosDePersonal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificadosDePersonal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkTipoCertificadoDePersonal"] = new SelectList(_context.TipoCertificadoDePersonals, "PkTipoCertificadoDePersonal", "PkTipoCertificadoDePersonal", certificadosDePersonal.FkTipoCertificadoDePersonal);
            ViewData["FkUsuario"] = new SelectList(_context.Usuarios, "PkUsuario", "PkUsuario", certificadosDePersonal.FkUsuario);
            return View(certificadosDePersonal);
        }

        // GET: CertificadosDePersonals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificadosDePersonal = await _context.CertificadosDePersonals.FindAsync(id);
            if (certificadosDePersonal == null)
            {
                return NotFound();
            }
            ViewData["FkTipoCertificadoDePersonal"] = new SelectList(_context.TipoCertificadoDePersonals, "PkTipoCertificadoDePersonal", "PkTipoCertificadoDePersonal", certificadosDePersonal.FkTipoCertificadoDePersonal);
            ViewData["FkUsuario"] = new SelectList(_context.Usuarios, "PkUsuario", "PkUsuario", certificadosDePersonal.FkUsuario);
            return View(certificadosDePersonal);
        }

        // POST: CertificadosDePersonals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkCertificadosDePersonal,FkUsuario,FkTipoCertificadoDePersonal,Especializacion,FechaEmision,FechaVencimiento,CertificadoPdf")] CertificadosDePersonal certificadosDePersonal)
        {
            if (id != certificadosDePersonal.PkCertificadosDePersonal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificadosDePersonal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificadosDePersonalExists(certificadosDePersonal.PkCertificadosDePersonal))
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
            ViewData["FkTipoCertificadoDePersonal"] = new SelectList(_context.TipoCertificadoDePersonals, "PkTipoCertificadoDePersonal", "PkTipoCertificadoDePersonal", certificadosDePersonal.FkTipoCertificadoDePersonal);
            ViewData["FkUsuario"] = new SelectList(_context.Usuarios, "PkUsuario", "PkUsuario", certificadosDePersonal.FkUsuario);
            return View(certificadosDePersonal);
        }

        // GET: CertificadosDePersonals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificadosDePersonal = await _context.CertificadosDePersonals
                .Include(c => c.FkTipoCertificadoDePersonalNavigation)
                .Include(c => c.FkUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.PkCertificadosDePersonal == id);
            if (certificadosDePersonal == null)
            {
                return NotFound();
            }

            return View(certificadosDePersonal);
        }

        // POST: CertificadosDePersonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificadosDePersonal = await _context.CertificadosDePersonals.FindAsync(id);
            if (certificadosDePersonal != null)
            {
                _context.CertificadosDePersonals.Remove(certificadosDePersonal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificadosDePersonalExists(int id)
        {
            return _context.CertificadosDePersonals.Any(e => e.PkCertificadosDePersonal == id);
        }
    }
}
