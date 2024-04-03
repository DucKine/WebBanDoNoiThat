using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IServices<T> where T:class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(string searchString, int Page, int Pagesize);
        int Insert(T t);
        int Update(T t);
        int Delete(int id);
        T GetById(int id);
        T GetByUserName(string UserName);
        bool Login(string username, string password);
      
        Contact GetContact();
    }
}
