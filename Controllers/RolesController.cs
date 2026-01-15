using BibliotecaDigital.Core.Entities;
using BibliotecaDigital.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDigital.Controllers
{

    public class RolesController : Controller
    {


        BibliotecaContext _context;



        public RolesController(BibliotecaContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var roles = _context.Roles
                .OrderBy(x => x.Nombre)
                .ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Roles.Add(rol);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        public IActionResult Update(int id)
        {
            var rol = _context.Roles.Find(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }
        [HttpPost]
        public IActionResult Update(Rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Roles.Update(rol);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        public IActionResult Delete(int id)
        {
            var rol = _context.Roles.Find(id);
            if (rol == null)
            {
                return NotFound();
            }
            _context.Roles.Remove(rol);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Deleted(int id)
        {
            var rol = _context.Roles.Find(id);
            if (rol == null)
            {
                return NotFound();
            }
            _context.Roles.Remove(rol);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }



}

