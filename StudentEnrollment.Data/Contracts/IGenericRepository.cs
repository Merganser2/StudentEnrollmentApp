using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity // could have used "class" to be more generic
    {
        Task<TEntity> GetAsync(int? id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int? id);
        Task<bool> Exists(int? id);
    }
}