using BibliotecaDigital.Core.Entities;
using BibliotecaDigital.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDigital.Controllers
{
    public class LibroController : Controller
    {
        private readonly BibliotecaContext _context;

        public LibroController(BibliotecaContext context)
        {
             _context = context;
        }

        public IActionResult Index()
        {

            // Lógica para obtener la lista de libros
            var model = _context.Libros.ToList();

            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Libro libro)  
        {
            if (ModelState.IsValid)
            {
                // Lógica para guardar el libro en la base de datos
                return RedirectToAction("Index");
            }
            return View(libro);
        }
         

        public IActionResult Update(int id)
        {
            // Lógica para obtener el libro por id
            return View();
        }
        [HttpPost]
        public IActionResult Update(Libro libro)
        {
            if (ModelState.IsValid)
            {
                // Lógica para actualizar el libro en la base de datos
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        public IActionResult Delete(int id)
        {
            // Lógica para eliminar el libro por id
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deleted(int id)
        {
            // Lógica para eliminar el libro de la base de datos
            return RedirectToAction("Index");
        }
    }
}

