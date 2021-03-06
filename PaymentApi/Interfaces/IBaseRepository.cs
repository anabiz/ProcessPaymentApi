using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Internclap.Core.Interfaces
{
    public interface IBaseRepository<T>
    { 
        Task<T> Find(int? id);
        Task Save(T t);
        Task<bool> Exist(int? id);
    }
}
