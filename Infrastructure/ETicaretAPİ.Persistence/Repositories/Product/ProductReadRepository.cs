using ETicaretAPI.Application.Repository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPİ.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProducReadRepository
    {
        public ProductReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
