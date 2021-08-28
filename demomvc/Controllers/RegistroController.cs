using Microsoft.AspNetCore.Mvc;
using demomvc.Models;
using demomvc.Data;
using System.Linq;

namespace demomvc.Controllers
{
    public class RegistroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.DataRegistros.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Registro objRegistro)
        {
            
            objRegistro.descuento = objRegistro.precio-(0.10*objRegistro.precio);
            _context.Add(objRegistro);
            _context.SaveChanges();
            ViewData["Message"] = "Sé registró exitosamente";
            return RedirectToAction(nameof(Index));

            

        }

        public IActionResult Edit(int id)
        {
            Registro objRegistro = _context.DataRegistros.Find(id);
            if (objRegistro == null)
            {
                return NotFound();
            }
            return View(objRegistro);
        }
        
         [HttpPost]
        public IActionResult Edit(int id,[Bind("id,nombre,categoria,precio,descuentor")] Registro objRegistro)
        {
            objRegistro.descuento = objRegistro.precio-(0.10*objRegistro.precio);
             _context.Update(objRegistro);
             _context.SaveChanges();
              ViewData["Message"] = "El contacto ya esta actualizado";
             return View(objRegistro);
             }
        public IActionResult Delete(int id)
        {
            Registro objRegistro = _context.DataRegistros.Find(id);
            _context.DataRegistros.Remove(objRegistro);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}