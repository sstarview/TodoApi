using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Domian.Models;
using Todo.Api.Domian.Repositories;
using Todo.Api.Persistence.Context;

namespace Todo.Api.Persistence.Repositories
{
    public class TodoItemRepository : BaseRepository, ITodoItemRespository
    {
        public TodoItemRepository(TodoDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<TodoItem>> ListAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }
    }
}
