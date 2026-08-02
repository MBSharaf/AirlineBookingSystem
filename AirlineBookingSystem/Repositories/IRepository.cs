using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AirlineBookingSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(

            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>[]? includes = null,
            bool AsTracking = true

            );
         Task<T?> GetOneAsync(

            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>[]? includes = null,
            bool AsTracking = true

            );
    }
}
