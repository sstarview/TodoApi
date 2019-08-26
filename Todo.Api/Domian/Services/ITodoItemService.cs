using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Api.Domian.Models;

namespace Todo.Api.Domian.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> ListAsync();
    }
}
