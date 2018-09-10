using KnowledgeManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManagementSystem.DAL.Repositories
{
    public class UserRepository<T> : IUserRepository<T> where T : class, new()
    {
        public SqlConnection connection = null;

        public string name = typeof(T).Name;

        public string connectionString;

        public UserRepository()
        {
            connectionString = @"Data Source=(LocalDB)\Database1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
        }


        public bool Delete(int id = default)
        {
            string sqlRequest = string.Format("DELETE FROM '{0}' WHERE ID = '{1}'", name, id);//через параметр

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

        public T Get(int id)
        {
            ModelOfUser User = new ModelOfUser();
            string sqlRequest = string.Format("SELECT * FROM {0} WHERE Id=@IdParam", name);
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = sqlRequest;
                SqlParameter IdParam = new SqlParameter("@IdParam", id);
                command.Parameters.Add(IdParam);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    User.UserId = (int)dr["ID"];
                    User.UserRole = (UserRole)dr["UserRole"];
                    User.UserName = dr["UserName"].ToString();
                    User.UserEmail = dr["UserEmail"].ToString();
                    User.UserPassword = dr["UserPassword"].ToString();
                }
            }

            return User as T;
        }

        public List<T> GetAll()
        {
            List<ModelOfUser> AllUsers = new List<ModelOfUser>();
            string sql = string.Format("SELECT * FROM {0}s", name);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ModelOfUser User = new ModelOfUser();
                        User.UserId = (int)reader["ID"];
                        User.UserRole = (UserRole)reader["UserRole"];
                        User.UserName = reader["UserName"].ToString();
                        User.UserEmail = reader["UserEmail"].ToString();
                        User.UserPassword = reader["UserPassword"].ToString();
                        AllUsers.Add(User);
                    }
                }
                return AllUsers as List<T>; ;
            }
        }

        public bool Save(T entity)
        {
            string names = string.Join(",", GetNames(entity).ToArray());
            string values = string.Join(",", GetValues(entity).ToArray());
            var query = string.Format("INSERT INTO {0} ({1},Status) VALUES ({2},'EXISTS')", name, names, values);
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = query;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Error: this id not found", ex);
                    return false;
                }
                return true;
            }
        }

        public List<string> GetNames(T model)
        {
            List<string> listOfNames = new List<string>();
            foreach (var item in model.GetType().GetProperties())
            {
                if (item.Name != "Id")
                    listOfNames.Add(item.Name);
            }
            return listOfNames;
        }

        public List<string> GetValues(T model)
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
    }
}
