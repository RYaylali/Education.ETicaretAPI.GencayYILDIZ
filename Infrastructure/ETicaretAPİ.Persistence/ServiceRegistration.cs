using Microsoft.EntityFrameworkCore;
using ETicaretAPİ.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repository;
using ETicaretAPİ.Persistence.Repositories;

namespace ETicaretAPİ.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices( this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepositrory, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepostitory>();
            services.AddScoped<IProducReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
