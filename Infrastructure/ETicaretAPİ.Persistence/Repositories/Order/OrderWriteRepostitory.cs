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
    public class OrderWriteRepostitory : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepostitory(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
