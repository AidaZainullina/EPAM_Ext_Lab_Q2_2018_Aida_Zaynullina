namespace KnowledgeSystemDAL.Repositories.Role
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using KnowledgeSystemDAL.Models;

    public class RoleRepository : IRoleRepository
    {
        public SqlConnection connection = null;

        private readonly string connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=KnowledgeManagementSystemDB;User ID=sa;Password=12345678";

        public bool AddData()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id = default)
        {
            try
            {
                string sqlRequest = string.Format("DELETE FROM KnowledgeSystemDB.[dbo].[Role] WHERE Id = @Id");

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
        
        public Role Get(int id = default)
        {
            try
            {
                Role role = new Role();

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT * FROM KnowledgeSystemDB.dbo.[Role] WHERE Id = @Id ");
                    SqlParameter IdParam = new SqlParameter("@Id", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        role.Id = (int)dr["Id"];
                        role.Name = dr["Name"].ToString();

                        return role;
                    }
                    else return null;
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public List<Role> GetAll()
        {
            List<Role> AllRoles = new List<Role>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeSystemDB.[dbo].[Role]";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Role role = new Role
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString()
                        };

                        AllRoles.Add(role);
                    }
                }
                return AllRoles;
            }
        }

        public bool Save(Role entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();

                if (this.Get(entity.Id) != null)
                {
                    command.CommandText = string.Format("UPDATE KnowledgeSystemDB.dbo.[Role] SET " +
                    "Name = '{0}', " +
                    "WHERE Id = {1}",
                    entity.Name,
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
                    command.CommandText = string.Format("INSERT INTO  KnowledgeSystemDB.[dbo].[Role]" +
                    "(Id," +
                    "Name) " +
                    "VALUES ('{0}', '{1}')",
                    entity.Id,
                    entity.Name);

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

        public Role Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
