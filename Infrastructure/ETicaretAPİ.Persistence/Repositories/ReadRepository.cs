using ETicaretAPI.Application.Repository;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPİ.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;
        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll() => Table;//Bütün veri tabanındaki verileri getirir.tABLE DBSET DİR DBSETTTE QUERYABLE CİNSİNDEN SORGU ATABİLMEMİZİ SAĞLAR
        public async Task<T> GetByIdAsync(string id)
            //=>Table.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));//Baseentitye
            => await Table.FindAsync(Guid.Parse(id));
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method) => await Table.FirstOrDefaultAsync(method);//şarta göre ilk veri gelir
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => Table.Where(method);//şarta göre olan veriler gelir

    }
}
