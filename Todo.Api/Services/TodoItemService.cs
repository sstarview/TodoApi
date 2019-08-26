using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Domian.Models;
using Todo.Api.Domian.Repositories;
using Todo.Api.Domian.Services;

namespace Todo.Api.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRespository _todoItemRespository;

        public TodoItemService(ITodoItemRespository todoItemRespository)
        {
            _todoItemRespository = todoItemRespository;
        }

        public async Task<IEnumerable<TodoItem>> ListAsync()
        {
            return await _todoItemRespository.ListAsync();
        }
    }
}
