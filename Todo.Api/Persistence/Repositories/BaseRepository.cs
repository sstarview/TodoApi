using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Api.Persistence.Context;

namespace Todo.Api.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly TodoDbContext _context;

        public BaseRepository(TodoDbContext context)
        {
            _context = context;
        }
    }
}
