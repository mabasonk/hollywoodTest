using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodTest.Domain.IRepositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
