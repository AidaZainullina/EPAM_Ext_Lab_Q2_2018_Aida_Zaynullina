using KnowledgeManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManagementSystem.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public bool AddData()
        {
            throw new NotImplementedException();
        }

        public bool DeleteData()
        {
            throw new NotImplementedException();
        }
    }
}
