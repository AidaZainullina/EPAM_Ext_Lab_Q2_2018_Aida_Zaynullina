namespace KnowledgeManagementSystem.DAL.Repositories
{
    using System.Collections.Generic;

    public interface IBaseRepository<T> where T : class, new()
    {
        T Get(int id = default);

        List<T> GetAll();

        bool Save(T entity);

        bool Delete(int id = default);

        //bool AddData();

        //bool DeleteData();
    }
}
