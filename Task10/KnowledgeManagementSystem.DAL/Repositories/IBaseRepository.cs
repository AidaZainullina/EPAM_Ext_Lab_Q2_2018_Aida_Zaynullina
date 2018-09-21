using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10;

namespace KnowledgeManagementSystem.DAL.Repositories
{
    public interface IBaseRepository<T> where T : class, new()
    {
        T Get(int id = default);

        List<T> GetAll();

        bool Save(UserModel entity);

        bool Delete(int id = default);

        bool AddData();

        bool DeleteData();
    }
}
