namespace KnowledgeSystemDAL.Repositories.User
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using KnowledgeSystemDAL.Models;

    public class UserRepository : IUserRepository
    {
        public SqlConnection connection = null;

        public readonly string connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=KnowledgeManagementSystemDB;User ID=sa;Password=12345678";

        public bool Delete(int id = default)
        {
            try
            {
                string sqlRequest = string.Format("DELETE FROM KnowledgeManagementSystemDB.[dbo].[User] WHERE Id = @Id");

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand c = new SqlCommand();
                    connection.Open();
                    c.Connection = connection;
                    c.CommandText = sqlRequest;
                    c.Parameters.AddWithValue("@Id", id);
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

        public  User Get(int id = default)
        {
            try
            {
                User User = new User();

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT * FROM KnowledgeManagementSystemDB.dbo.[User] WHERE Id = @Id");
                    SqlParameter IdParam = new SqlParameter("@Id", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {

                        User.Id = (int)dr["Id"];
                        User.Name = dr["Name"].ToString();
                        User.Password = dr["Password"].ToString();
                        User.Role = (int)dr["Role"];
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

        public User Get(string name)
        {
            User User = new User();
            string sql = string.Format("SELECT * FROM KnowledgeManagementSystemDB.dbo.[User] WHERE Name=@NameParam");
            using (connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = sql;
                SqlParameter NameParam = new SqlParameter("@NameParam", name);
                command.Parameters.Add(NameParam);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        User.Id = (int)dr["Id"];
                        User.Name = dr["Name"].ToString();
                        User.Password = dr["Password"].ToString();
                        User.Role = (int)dr["Role"];
                        User.Email = dr["Email"].ToString();
                        return User;
                    }
                }
            }
            return User;
        }

        public List<User> GetAll()
        {
            List<User> AllUsers = new List<User>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeManagementSystemDB.[dbo].[User]";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User User = new User
                        {
                            Id = (int)reader["Id"],
                            Role = (int)reader["Role"],
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Password = reader["Password"].ToString()
                        };

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

                var command = connection.CreateCommand();

                if (this.Get(entity.Id) != null)
                {
                    command.CommandText = "UPDATE KnowledgeManagementSystemDB.dbo.[User] SET " +
                    "Name = @name, Email = @email, Password = @password, Role = @role WHERE Id = @id";

                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@email", entity.Email);
                    command.Parameters.AddWithValue("@password", entity.Password);
                    command.Parameters.AddWithValue("@role", entity.Role);
                    command.Parameters.AddWithValue("@id", entity.Id);

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
                    command.CommandText = "INSERT INTO KnowledgeManagementSystemDB.[dbo].[User]" +
                   "(Name, Email, Password, Role) Values(@name, @email, @password, @role)";

                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@email", entity.Email);
                    command.Parameters.AddWithValue("@password", entity.Password);
                    command.Parameters.AddWithValue("@role", entity.Role);

                    //command.CommandText = string.Format(" " +
                    //"(Name, " +
                    //"Email, " +
                    //"Password, " +
                    //"Role) " +
                    //"VALUES ('{0}', '{1}', '{2}', {3})",
                    //entity.Name,
                    //entity.Email,
                    //entity.Password,
                    //entity.Role);

                    command.CommandType = CommandType.Text;

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

        public int GetCount()
        {
            string sql = string.Format("SELECT COUNT(*) FROM KnowledgeManagementSystemDB.[dbo].[User]");
            var connection = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                connection.Open();
                
                return (int)cmd.ExecuteScalar();
            }
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
