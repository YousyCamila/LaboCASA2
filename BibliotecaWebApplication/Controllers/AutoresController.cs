using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWebApplication.Data;
using BibliotecaWebApplication.Models;

namespace BibliotecaWebApplication.Controllers
{
    public class AutoresController : Controller
    {
        private readonly ApplicationDbContext _context;



        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
              return _context.Autores != null ? 
                          View(await _context.Autores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Autores'  is null.");
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Autores == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores
                .FirstOrDefaultAsync(m => m.AutorId == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                if (autor.Foto != null && autor.Foto.Length > 0)
                {
                    try
                    {
                        // Verificar permisos en la carpeta
                        var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/autores");
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        // Generar un nombre único para el archivo
                        var fileName = Path.GetFileNameWithoutExtension(autor.Foto.FileName);
                        var extension = Path.GetExtension(autor.Foto.FileName);
                        var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";

                        // Definir la ruta donde se guardará el archivo
                        var filePath = Path.Combine(directoryPath, newFileName);

                        // Guardar el archivo
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await autor.Foto.CopyToAsync(fileStream);
                        }

                        // Guardar la ruta de la imagen en la base de datos
                        autor.FotoPath = "/images/autores/" + newFileName;
                    }
                    catch (Exception ex)
                    {
                        // Manejo de excepción 
                        ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar la imagen: " + ex.Message);
                        return View(autor);
                    }
                }

                // Guardar el autor en la base de datos
                _context.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Si llegamos aquí, es que hubo un problema en la validación del modelo
            return View(autor);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Autores == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AutorId,Apellidos,Nombre,Nacionalidad")] Autor autor)
        {
            if (id != autor.AutorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.AutorId))
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
            return View(autor);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Autores == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores
                .FirstOrDefaultAsync(m => m.AutorId == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Autores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Autores'  is null.");
            }
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(Guid id)
        {
          return (_context.Autores?.Any(e => e.AutorId == id)).GetValueOrDefault();
        }
    }
}
