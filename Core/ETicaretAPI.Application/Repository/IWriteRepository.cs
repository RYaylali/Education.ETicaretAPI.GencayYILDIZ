using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repository
{
    public interface IOrderWriteRepository<T> :IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);//liste olarak ekleme
        bool Update(T model);
        Task<bool> RemoveAsync(string id);//id şeklinde silme
        bool Remove(T model);//tek silme
        bool RemoveRange(List<T> models);
        Task<int> SaveAsync();
    }
}
