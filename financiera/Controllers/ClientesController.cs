using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using financiera.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace financiera.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Clientes.Include(c => c.IdDepartamentoNavigation).Include(c => c.IdTipoClienteNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.IdDepartamentoNavigation)
                .Include(c => c.IdTipoClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList( _context.Departamentos,"IdDepartamento","NombreDepartamento");
            ViewData["IdTipoCliente"] = new SelectList( _context.TipoClientes,"IdTipoCliente","Nombre");

            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,IdTipoCliente,Cedula,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,RazonSocial,IdDepartamento,Direccion,Telefono,Correo,Activo,FechaRegistro")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.IdCliente = _context.Clientes
                    .OrderByDescending(c => c.IdCliente)
                    .Select(c => c.IdCliente)
                    .FirstOrDefault() + 1;

                _context.Add(cliente);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento");
            ViewData["IdTipoCliente"] = new SelectList(_context.TipoClientes, "IdTipoCliente", "Nombre");
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento");
            ViewData["IdTipoCliente"] = new SelectList(_context.TipoClientes, "IdTipoCliente", "Nombre");
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,IdTipoCliente,Cedula,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,RazonSocial,IdDepartamento,Direccion,Telefono,Correo,Activo,FechaRegistro")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.IdCliente))
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
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento");
            ViewData["IdTipoCliente"] = new SelectList(_context.TipoClientes, "IdTipoCliente", "Nombre");
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.IdDepartamentoNavigation)
                .Include(c => c.IdTipoClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
