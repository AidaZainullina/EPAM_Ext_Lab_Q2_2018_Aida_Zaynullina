namespace KnowledgeManagementSystem.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Task10;

    public class UserRepository : IUserRepository
    {
        public SqlConnection connection = null;

        private string connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=KnowledgeManagementSystemDB;Integrated Security=True";

        public bool Delete(int id = default)
        {
            try
            {
                string sqlRequest = string.Format("DELETE FROM KnowledgeBase.[dbo].[User] WHERE Id = {0}", id);

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand c = new SqlCommand();
                    connection.Open();
                    c.Connection = connection;
                    c.CommandText = sqlRequest;
                    int numberOfUpdate = c.ExecuteNonQuery();
                    if (numberOfUpdate > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }

        }

        public User Get(int id = default)
        {
            try
            {
                User User = new User();

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT * FROM KnowledgeBase.dbo.[User] WHERE Id = {0} ", id);
                    SqlParameter IdParam = new SqlParameter("@IdParam", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {

                        User.Id = (int)dr["Id"];
                        User.Name = dr["Name"].ToString();
                        User.Password = dr["Password"].ToString();
                        User.Role = (Role)dr["Role"];
                        User.Email = dr["Email"].ToString();
                        return User;
                    }
                    else return null;
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public List<User> GetAll()
        {
            List<User> AllUsers = new List<User>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeBase.[dbo].[User]";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User User = new User();
                        User.Id = (int)reader["Id"];
                        User.Role = (Role)reader["Role"];
                        User.Name = reader["Name"].ToString();
                        User.Email = reader["Email"].ToString();
                        User.Password = reader["Password"].ToString();

                        AllUsers.Add(User);
                    }
                }
                return AllUsers;
            }
        }

        public bool Save(User entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();

                if (this.Get(entity.Id) != null)
                {
                    command.CommandText = string.Format("UPDATE KnowledgeBase.dbo.[User] SET " +
                    "Name = '{0}', " +
                    "Email = '{1}', " +
                    "Password = '{2}', " +
                    "Role = '{3}' " +
                    "WHERE Id = {4}",
                    entity.Name,
                    entity.Email,
                    entity.Password,
                    entity.Role,
                    entity.Id);

                    var result = command.ExecuteNonQuery();

                    if (result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    command.CommandText = string.Format("INSERT INTO  KnowledgeBase.[dbo].[User]" +
                    "(Id," +
                    "Name, " +
                    "Email, " +
                    "Password, " +
                    "Role) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                    entity.Id,
                    entity.Name,
                    entity.Email,
                    entity.Password,
                    entity.Role);

                    var result = command.ExecuteNonQuery();

                    if (result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public List<string> GetNames(User model)
        {
            List<string> listOfNames = new List<string>();
            foreach (var item in model.GetType().GetProperties())
            {
                if (item.Name != "UserId")
                    listOfNames.Add(item.Name);
            }
            return listOfNames;
        }

        public List<string> GetValues(User model)
        {
            List<string> listOfValues = new List<string>();
            foreach (var item in model.GetType().GetProperties())
            {
                if (item.Name != "Id")
                {
                    listOfValues.Add(item.GetValue(model, null).ToString());
                }
            }
            return listOfValues;
        }

        //public bool AddData()
        //{
        //    IUserRepository userRepository = new UserRepository();

        //    connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=Database1;Integrated Security=True";

        //    using (IDbConnection connection2 = new SqlConnection(connectionString))
        //    {
        //        connection2.Open();
        //        var AddCommand = connection2.CreateCommand();
        //        AddCommand.CommandText = "INSERT INTO Database1.[dbo].[User] values(1, 'Ivan', '11111',  1, 'imail.ru'),(2, 'Petrov', '12324567',  3, 'p@gml.com'),(3, 'Sidorov', '22222',  2, 's@ml.ru'),(4, 'Popov', '123',  1, 'p@x.ru'),(5, 'Chirkova', '123',  2, 'c@ml.ru'),(6, 'Mihaylova', '125543',  3, 'm@yae.ru'),(7, 'Kolchin', '1I8Y623',  3, 'ko@ma.ru'),(8, 'Voron', '1231234554',  3, 'vo@ml.ru'),(9, 'Charikova', '1278753',  2, 'ch@l.com'),(10, 'Gluchova', '178768723',  3, 'g@l.ru')";
        //    }

        //    return true;
        //}

        //public bool DeleteData()
        //{
        //    IUserRepository userRepository = new UserRepository();

        //    connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=Database1;Integrated Security=True";

        //    using (IDbConnection connection1 = new SqlConnection(connectionString))
        //    {
        //        connection1.Open();
        //        var DeleteCommand = connection1.CreateCommand();
        //        DeleteCommand.CommandText = "truncate table Database1.[dbo].[User]";
        //    }
        //    return true;
        //}
    }
}
