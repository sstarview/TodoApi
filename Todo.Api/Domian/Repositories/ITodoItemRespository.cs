using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Domian.Models;

namespace Todo.Api.Domian.Repositories
{
    public interface ITodoItemRespository
    {
        Task<IEnumerable<TodoItem>> ListAsync();
        Task AddAsync(TodoItem todoItem);
        Task<TodoItem> FindByIdAsync(int id);
        void Update(TodoItem todoItem);
    }
}
