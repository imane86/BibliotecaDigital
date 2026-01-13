using BibliotecaDigital.Core.Entities;
using BibliotecaDigital.Data.Contexts;
using BibliotecaDigital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaDigital.Controllers
{
    public class UsuarioController : Controller
    {
        BibliotecaContext _context;
        //es un servicio para hashear contraseñas
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public UsuarioController(BibliotecaContext context, IPasswordHasher<Usuario> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// obtiene una lista de selección de roles para un usuario
        /// </summary>
        /// <param name="rolSeleccionado">rolActual</param>
        private SelectList GetSelectList(int? rolSeleccionado = null)
        {
            var roles = _context.Roles.Select(x => new SelectListItem
            {
                //crea en anonimo en tiempo de ejecucion
                Value = x.Id.ToString(),
                Text = x.Nombre,

            }).ToList();

            return new SelectList(roles, "Value", "Text", rolSeleccionado);

            ////otra forma de hacerlo reutilizando directamente la entidad
            //var roles2 = _context.Roles.ToList();

            //return new SelectList(roles2, "Id", "Nombre", rolSeleccionado);
        }

        public IActionResult Index()
        {

            return View(_context.Usuarios.ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Roles = GetSelectList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Usuario model)
        {
            if (ModelState.IsValid)
            {
                // Hashear la contraseña antes de guardarla
                model.PasswordHash = _passwordHasher.HashPassword(model, model.PasswordHash);
                _context.Usuarios.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Roles = GetSelectList();
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewBag.Roles = GetSelectList();
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Update(int id, BibliotecaDigital.Core.Entities.Usuario model)
        {
            if (ModelState.IsValid)
            {
                var usuarioExistente = _context.Usuarios.Find(id);
                if (usuarioExistente == null)
                {
                    return NotFound();
                }
                usuarioExistente.NombreUsuario = model.NombreUsuario;
                usuarioExistente.Email = model.Email;
                // Si la contraseña ha sido modificada, hashearla de nuevo
                if (!string.IsNullOrEmpty(model.PasswordHash))
                {
                    usuarioExistente.PasswordHash = _passwordHasher.HashPassword(model, model.PasswordHash);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Roles = GetSelectList();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Deleted(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
