using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repository
{
    public interface IReadRepository<T>:IRepository<T> where T : BaseEntity 
    {
        IQueryable<T> GetAll();//bütün product ne varsa getirir sorguna göre gelir
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);//where sorgusu yerine kullanılır
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);//Şarta uygun olan ilk veri gelir
        Task<T> GetByIdAsync(string id);//id ye göre veri gelir
    }
}
