using Microsoft.AspNetCore.Mvc;
using TodoApplication.AppContext;
using TodoApplication.Models;

namespace TodoApplication.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public TodoController(ApplicationDbContext dbcontext )
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var todos = _dbcontext.todos.ToList();
            return View(todos);
        }

        // Create 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Todo obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _dbcontext.todos.Add(obj);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            return View(obj);
        }
        // Detailed Todo
        public IActionResult Details(int id)
        {
            var todo = _dbcontext.todos.Find(id);


            return View(todo);
        }
        // Update
        public IActionResult Update(int id) {
            var todo = _dbcontext.todos.Find(id);

            return View(todo);
        }

        [HttpPost]
        public IActionResult Update(Todo obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _dbcontext.todos.Update(obj);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            return View(obj);
        }


        //Delete
        public IActionResult Delete(int id)
        {
            var todo = _dbcontext.todos.Find(id);
            if (todo is not null)
            {
                _dbcontext.todos.Remove(todo);
                _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }


    }
}
