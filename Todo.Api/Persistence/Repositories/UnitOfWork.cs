using System.Threading.Tasks;
using Todo.Api.Domian.Repositories;
using Todo.Api.Persistence.Context;

namespace Todo.Api.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoDbContext _context;

        public UnitOfWork(TodoDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
