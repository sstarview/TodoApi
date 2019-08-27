using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Domian.Models;
using Todo.Api.Domian.Services.Communication;

namespace Todo.Api.Domian.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> ListAsync();
        Task<SaveTodoItemResponse> SaveAsync(TodoItem todoItem);
    }
}
