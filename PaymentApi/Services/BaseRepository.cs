using Internclap.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Internclap.Infrastructure.Services
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly PaymentContext _dataContext;
        private readonly DbSet<T> entitySet;
        public BaseRepository(PaymentContext dataContext)
        {
            _dataContext = dataContext;
            entitySet = dataContext.Set<T>();
        }
     

        public async Task<bool> Exist(int? id)
        {
            var entity = await entitySet.FindAsync(id);
            return entity != null ? true : false;
        }

        public async Task<T> Find(int? id)
        {
            var entity = await entitySet.FindAsync(id);
            return entity;
        }

        public async Task Save(T t)
        {
            if (t != null)
            {
                entitySet.Add(t);
                await _dataContext.SaveChangesAsync();
            }
        }
     
      
    }
}

