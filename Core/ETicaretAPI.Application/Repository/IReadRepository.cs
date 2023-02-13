using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repository
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool traacking = true);//bütün product ne varsa getirir sorguna göre gelir--default olarak traking mekanizması true olarak oluşturuldu
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool traacking = true);//where sorgusu yerine kullanılır
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool traacking = true);//Şarta uygun olan ilk veri gelir
        Task<T> GetByIdAsync(string id, bool traacking = true);//id ye göre veri gelir
    }
}
