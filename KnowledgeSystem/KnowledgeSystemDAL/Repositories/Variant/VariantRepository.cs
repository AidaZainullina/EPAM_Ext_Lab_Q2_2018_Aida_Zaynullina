namespace KnowledgeSystemDAL.Repositories.Variant
{
    using KnowledgeSystemDAL.Repositories.Question;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using KnowledgeSystemDAL.Models;

    public class VariantRepository : IVariantRepository
    {
        private readonly string connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=KnowledgeManagementSystemDB;User ID=sa;Password=12345678";

        public SqlConnection connect = null;

        public VariantRepository()
        {
            connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;User ID=sa;Password=12345678;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";//ConfigurationManager.ConnectionStrings.ToString();
            connect = new SqlConnection(connectionString);
        }

        readonly QuestionRepository qr = new QuestionRepository();

        public static DateTime date = new DateTime();
        DateTime duration = date.AddMinutes(30);


        public bool AddData()
        {
            throw new NotImplementedException();
        }


        public int GetCount()
        {
            string sql = string.Format("SELECT Id FROM KnowledgeManagementSystemDB.[dbo].[Variant]");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                connect.Open();
                int i = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        i++;
                    }
                }
                connect.Close();
                return i;
            }
        }

        public bool Delete(int id = default)
        {
            try
            {
                string sqlRequest = string.Format("DELETE FROM KnowledgeManagementSystemDB.[dbo].[Variant] WHERE Id = @Id");

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

        public Variant Get(int id = default)
        {
            try
            {
                Variant variant = new Variant();

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT * FROM KnowledgeManagementSystemDB.dbo.[Variant] WHERE Id = @Id");
                    SqlParameter IdParam = new SqlParameter("@IdParam", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        variant.Id = (int)dr["Id"];
                        variant.Text = dr["Text"].ToString();
                        variant.IsRight = (int)dr["IsRight"];
                        variant.QuestionId = (int)dr["QuestionId"];

                        return variant;
                    }
                    else return null;
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public List<Variant> GetAllByQuestionId(int QuestionId)
        {
            List<Variant> AllVariants = new List<Variant>();

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM KnowledgeManagementSystemDB.[dbo].[Variant] where QuestionId = @QuestionId";
                SqlParameter IdParam = new SqlParameter("@QuestionId", QuestionId);
                command.Parameters.Add(IdParam);

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Variant variant = new Variant
                        {
                            Id = (int)dr["Id"],
                            Text = dr["Text"].ToString(),
                            IsRight = (int)dr["IsRight"],
                            QuestionId = (int)dr["QuestionId"]
                        };

                        AllVariants.Add(variant);
                    }
                }
                return AllVariants;
            }
        }

        public List<Variant> GetAll()
        {
            List<Variant> AllVariants = new List<Variant>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeManagementSystemDB.[dbo].[Variant]";

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Variant variant = new Variant
                        {
                            Id = (int)dr["Id"],
                            Text = dr["Text"].ToString(),
                            IsRight = (int)dr["IsRight"],
                            QuestionId = (int)dr["QuestionId"]
                        };

                        AllVariants.Add(variant);
                    }
                }
                return AllVariants;
            }
        }

        public bool Save(Variant entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();

                if (this.Get(entity.Id) != null)
                {
                    command.CommandText = string.Format("UPDATE KnowledgeManagementSystemDB.dbo.[Variant] SET " +
                    "Text = '{0}', " +
                    "IsRight = {1}, " +
                    "QuestionId = {2}, "  +
                    "WHERE Id = {4}",
                    entity.Text,
                    entity.IsRight,
                    entity.QuestionId,
                    entity.Id
                    );

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
                    command.CommandText = string.Format("INSERT INTO  KnowledgeManagementSystemDB.[dbo].[Va]" +
                    "(Text = '{0}', " +
                    "IsRight = {1}, " +
                    "QuestionId = {2}, " +
                    "Id = {3}," +
                    "VALUES ('{0}', '{1}', '{2}', '{3}')",
                    entity.Text,
                    entity.IsRight,
                    entity.QuestionId,
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
            }
        }

        public Variant Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
