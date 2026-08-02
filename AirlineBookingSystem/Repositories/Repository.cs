using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static System.Net.WebRequestMethods;

namespace AirlineBookingSystem.Repositories
{
    public class Repository<T> : IRepository<T>  where T : class 
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context; //new ApplicationDbContext();
            _dbset = _context.Set<T>();
        }

        private IQueryable<T> Query(

            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>[]? includes = null,
            bool AsTracking = true

            )
        {
            var entity = _dbset.AsQueryable();
            // filter
            if (filter != null)
            {
                entity = _dbset.Where(filter);
            }
            if (includes != null)
            {
                foreach (var includ in includes)
                {
                    entity = entity.Include(includ);
                }
            }
            if (!AsTracking)
            {
                entity = entity.AsNoTracking();
            }
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            
            Expression<Func<T, bool >>? filter = null ,
            Expression<Func<T, object>>[]? includes = null , 
            bool AsTracking = true

            )
        {
            var entity = Query(filter, includes, AsTracking);
            return await entity.ToListAsync();
        }

        public async Task<T?> GetOneAsync(

            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>[]? includes = null,
            bool AsTracking = true

            )
        {
            var entity = Query(filter, includes, AsTracking);
            return await entity.FirstOrDefaultAsync();
        }
    }
}
