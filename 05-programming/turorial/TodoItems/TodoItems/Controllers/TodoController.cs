using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TodoItems.Models;
using TodoItems.Services;

namespace TodoItems.Controllers
{

    [ApiController]
    [Route("[controller]")]//URL: api/todo
    public class TodoController : ControllerBase
    {
        private readonly ICrudService<TodoItem, int> _todoService;
        public TodoController(ICrudService<TodoItem, int> todoService)
        {
            _todoService = todoService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<TodoItem>> GetAll() => _todoService.GetAll().ToList();
        
        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todo = _todoService.Get(id);
            if (todo is null) return NotFound();
            else return todo;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(TodoItem todo)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _todoService.Add(todo);
                return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem todo)
        {
            var existingTodoItem = _todoService.Get(id);
            if (existingTodoItem is null || existingTodoItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _todoService.Update(existingTodoItem, todo);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todoService.Get(id);
            if (todo is null) return NotFound();
            _todoService.Delete(id);
            return NoContent();
        }
    }

}
