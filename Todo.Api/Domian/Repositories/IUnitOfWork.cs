using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Api.Domian.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
