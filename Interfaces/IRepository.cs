using System.Collections.Generic;

namespace FlixNet.Interfaces
{
    public interface IRepository<T>
    {
      List<T> ToList();
      T ReturnById(int id);
      void Insert(T entity);
      void Delete(int id);
      void Update(int id, T entity);
      int NextId();
    }
}