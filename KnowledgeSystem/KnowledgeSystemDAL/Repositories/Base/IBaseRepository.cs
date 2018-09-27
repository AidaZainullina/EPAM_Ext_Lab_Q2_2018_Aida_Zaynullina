namespace KnowledgeSystemDAL.Repositories.Base
{
    using System.Collections.Generic;

    public interface IBaseRepository<T> where T : class, new()
    {
        T Get(int id = default);

        T Get(string name);

        List<T> GetAll();

        bool Save(T entity);

        bool Delete(int id = default);

        //bool AddData();

        //bool DeleteData();
    }
}
