using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Domian.Models;
using Todo.Api.Domian.Services;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodosController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            var todoItems = await _todoItemService.ListAsync();
            return todoItems;
        }
    }
}