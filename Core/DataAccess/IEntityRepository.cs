using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramewok
{
    public interface EfEntityRepositoryBase<T> where T : class
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetByFilter(Expression<Func<T,bool>>filter);
    }
}
