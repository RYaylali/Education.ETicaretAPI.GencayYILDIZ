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
        public IQueryable<T> GetAll(bool traacking = true) //Bütün veri tabanındaki verileri getirir.tABLE DBSET DİR DBSETTTE QUERYABLE CİNSİNDEN SORGU ATABİLMEMİZİ SAĞLARS
        {
            var query = Table.AsQueryable();
            if (!traacking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetByIdAsync(string id, bool traacking = true)
        //=>Table.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));//Baseentitye
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!traacking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool traacking = true) //şarta göre ilk veri gelir
        {
            var query = Table.AsQueryable();
            if (!traacking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool traacking = true) //Şarta göre olan veriler gelir
        {
            var query = Table.AsQueryable();
            if (!traacking)
                query = query.AsNoTracking();
            return query;
        }
        // !!!!! NOT (TRAKİNG) = Traking ile veri tabanının takibi sağlanır işlem kolaylığı sağlar true durumda veri tabanın da değişiklik yapılarak işlem tamamlanır.traking false edilerek görsel işlemler veri tabanına işlenmeden yapılabilir.
    }
}
