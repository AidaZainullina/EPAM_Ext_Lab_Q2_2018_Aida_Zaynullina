namespace Task5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IBaseService<T> where T : class, new()
    {
        T Get(int id = default);

        List<T> GetAll();

        bool Save(T entity = default);

        bool Delete(int id = default);
    }
}
