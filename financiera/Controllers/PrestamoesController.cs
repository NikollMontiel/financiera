using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using financiera.Models;

namespace financiera.Controllers
{
    public class PrestamoesController : Controller
    {
        private readonly AppDbContext _context;

        public PrestamoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Prestamoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Prestamos.Include(p => p.CodMonedaNavigation).Include(p => p.IdClienteNavigation).Include(p => p.IdEstadoPrestamoNavigation).Include(p => p.IdTipoPrestamoNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Prestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.CodMonedaNavigation)
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdEstadoPrestamoNavigation)
                .Include(p => p.IdTipoPrestamoNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public IActionResult Create()
        {
            ViewData["CodMoneda"] = new SelectList(_context.TipoMoneda, "CodMoneda", "CodMoneda");
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Cedula");
            ViewData["IdEstadoPrestamo"] = new SelectList(_context.EstadoPrestamos, "IdEstadoPrestamo", "IdEstadoPrestamo");
            ViewData["IdTipoPrestamo"] = new SelectList(_context.TipoPrestamos, "IdTipoPrestamo", "IdTipoPrestamo");
            return View();
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestamo,IdCliente,IdTipoPrestamo,CodMoneda,Monto,TasaInteres,PlazoMeses,FechaSolicitud,IdEstadoPrestamo,Observacion,Activo")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodMoneda"] = new SelectList(_context.TipoMoneda, "CodMoneda", "CodMoneda", prestamo.CodMoneda);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Cedula", prestamo.IdCliente);
            ViewData["IdEstadoPrestamo"] = new SelectList(_context.EstadoPrestamos, "IdEstadoPrestamo", "IdEstadoPrestamo", prestamo.IdEstadoPrestamo);
            ViewData["IdTipoPrestamo"] = new SelectList(_context.TipoPrestamos, "IdTipoPrestamo", "IdTipoPrestamo", prestamo.IdTipoPrestamo);
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["CodMoneda"] = new SelectList(_context.TipoMoneda, "CodMoneda", "CodMoneda", prestamo.CodMoneda);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Cedula", prestamo.IdCliente);
            ViewData["IdEstadoPrestamo"] = new SelectList(_context.EstadoPrestamos, "IdEstadoPrestamo", "IdEstadoPrestamo", prestamo.IdEstadoPrestamo);
            ViewData["IdTipoPrestamo"] = new SelectList(_context.TipoPrestamos, "IdTipoPrestamo", "IdTipoPrestamo", prestamo.IdTipoPrestamo);
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrestamo,IdCliente,IdTipoPrestamo,CodMoneda,Monto,TasaInteres,PlazoMeses,FechaSolicitud,IdEstadoPrestamo,Observacion,Activo")] Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.IdPrestamo))
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
            ViewData["CodMoneda"] = new SelectList(_context.TipoMoneda, "CodMoneda", "CodMoneda", prestamo.CodMoneda);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Cedula", prestamo.IdCliente);
            ViewData["IdEstadoPrestamo"] = new SelectList(_context.EstadoPrestamos, "IdEstadoPrestamo", "IdEstadoPrestamo", prestamo.IdEstadoPrestamo);
            ViewData["IdTipoPrestamo"] = new SelectList(_context.TipoPrestamos, "IdTipoPrestamo", "IdTipoPrestamo", prestamo.IdTipoPrestamo);
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.CodMonedaNavigation)
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdEstadoPrestamoNavigation)
                .Include(p => p.IdTipoPrestamoNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.IdPrestamo == id);
        }
    }
}
