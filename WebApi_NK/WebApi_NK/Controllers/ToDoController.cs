using Microsoft.AspNetCore.Mvc;
using WebApi_NK.DTOs;
using WebApi_NK.Models;
using WebApi_NK.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_NK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly ITodoService _todoService;

        public ToDoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            return (await _todoService.GetTodoItems()).ToArray();
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            var item=await _todoService.GetTodoItem(id);
            return item != null
                ? item
                : NotFound();
        }

        // POST api/<ToDoController>
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> Post([FromBody] CreateTodoItemRequest request)
        {
            var createdItem = await _todoService.CreateTodoItem(request);
            return (createdItem);
        }

        // PUT api/<ToDoController>/5
        [HttpPatch("{id}/status")]
        public async Task<ActionResult<TodoItem>> Put(int id, [FromBody] bool isCompleted)
        {

            var todoItem = await _todoService.ChangeTodoItem(id,isCompleted);

            return todoItem!= null
                ?todoItem
                :NotFound();
                
                

        }

        // DELETE api/<ToDoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
