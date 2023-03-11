    using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)//Inceptorda update ve created işlemlerine atama yapabilmek için. Her savechanges tetiklendiğinde burası devre girirer
        {
            // ChangeTracker=entityler üzerinden yapılan değişiklerin veya yeni eklenen verinin yakalanması sağlar. Update operasyonlarında Track edilen verileri yakalayıp elde edilir.
            var datas = ChangeTracker
                   .Entries<BaseEntity>();//Entries metotu gelen girdileri entri ile yakalanır.Burada sürece giren bütün baseentityleri yakalar.Baseentity yakalama sebebimizde ortak class olduğu içinn
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.UtcNow,
                    EntityState.Deleted => item.Entity.DeletedDate = DateTime.UtcNow,
                   
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
