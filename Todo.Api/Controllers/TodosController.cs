using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Domian.Models;
using Todo.Api.Domian.Services;
using Todo.Api.Extensions;
using Todo.Api.Resources;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        private readonly IMapper _mapper;

        public TodosController(ITodoItemService todoItemService, IMapper mapper)
        {
            _todoItemService = todoItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            var todoItems = await _todoItemService.ListAsync();
            return todoItems;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTodoResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var todoItem = _mapper.Map<SaveTodoResource, TodoItem>(resource);
            var result = await _todoItemService.SaveAsync(todoItem);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.TodoItem);
        }


    }
}