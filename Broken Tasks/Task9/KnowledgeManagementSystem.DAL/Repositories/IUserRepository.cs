using KnowledgeManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManagementSystem.DAL.Repositories
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class, new()
    {
      
    }
}
