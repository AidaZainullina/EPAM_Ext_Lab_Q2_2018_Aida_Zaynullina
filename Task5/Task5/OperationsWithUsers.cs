namespace Task5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OperationsWithUsers<T> : IBaseService<T> where T : class, new()
    {
        private T GetUser;

        public List<User> BaseOfUsers = new List<User>()
        {
            new User(){ Id = 1 },

            new User(){ Id = 2 },

            new User(){ Id = 3 },

            new User(){ Id = 4 },

            new User(){ Id = 5 },

            new User(){ Id = 6 },

            new User(){ Id = 7 },

            new User(){ Id = 8 },

            new User(){ Id = 9 },

            new User(){ Id = 10 },
        };

        public bool Delete(int id = default)
        {
            try
            {
                foreach (var usr in BaseOfUsers)
                {
                    if (usr.Id == id)
                    {
                        BaseOfUsers.Remove(usr);

                        return true;
                    }
                }

                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public T Get(int id = default)
        {
            foreach (var user in BaseOfUsers)
            {
                if (user.Id == id)
                {
                    GetUser = user as T;
                }
                else
                {
                    GetUser = null;
                }
            }

            return GetUser;
        }


        public List<T> GetAll()
        {
            return BaseOfUsers as List<T>;
        }

        public bool Save(T entity = default)
        {
            if (entity as User == null)
            {
                return false;
            }
            else
            {
                BaseOfUsers.Add(entity as User);

                return true;
            }
        }
    }
}
