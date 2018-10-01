namespace KnowledgeSystemDAL.Repositories.Test
{
    using System.Data;
    using System.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using KnowledgeSystemDAL.Repositories.Question;
    using KnowledgeSystemDAL.Models;

    public  class TestRepository : ITestRepository
    {
        private readonly string connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=KnowledgeManagementSystemDB;User ID=sa;Password=12345678";

        public SqlConnection connect = null;

        public TestRepository()
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
            string sql = string.Format("SELECT Id FROM KnowledgeManagementSystemDB.[dbo].[Test]");
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
                string sqlRequest = string.Format("DELETE FROM KnowledgeManagementSystemDB.[dbo].[Test] WHERE Id = @Id");

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

        public Test Get(int id = default)
        {
            try
            {
                Test test = new Test();

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT * FROM KnowledgeManagementSystemDB.dbo.[Test] WHERE Id = @Id");
                    SqlParameter IdParam = new SqlParameter("@IdParam", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        test.Id = (int)dr["Id"];
                        test.Name = dr["Name"].ToString();
                        test.Duration = duration;
                        test.Description = dr["Description"].ToString();
                        test.UserId = (int)dr["UserId"];
                        return test;
                    }
                    else return null;
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public List<Test> GetAllByQuestionId(int QuestionId)
        {
            List<Test> AllTests = new List<Test>();

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM KnowledgeManagementSystemDB.[dbo].[Test] where QuestionId = @QuestionId";
                SqlParameter IdParam = new SqlParameter("@QuestionId", QuestionId);
                command.Parameters.Add(QuestionId);

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Test test = new Test
                        {
                            Id = (int)dr["Id"],
                            Name = dr["Name"].ToString(),
                            Duration = duration,
                            UserId = (int)dr["UserId"],
                            Description = dr["Description"].ToString()
                    };

                        AllTests.Add(test);
                    }
                }
                return AllTests;
            }
        }

        public List<Test> GetAll()
        {
            List<Test> AllTests = new List<Test>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeManagementSystemDB.[dbo].[Test]";

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Test test = new Test
                        {
                            Id = (int)dr["Id"],
                            Name = dr["Name"].ToString(),
                            Duration = duration,
                            UserId = (int)dr["UserId"],
                            Description = dr["Description"].ToString()
                        };
                        //test.Questions = qr.Get((int)dr["TestId"]); //Список вопросов

                        AllTests.Add(test);
                    }
                }
                return AllTests;
            }
        }

        public bool Save(Test entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();

                if (this.Get(entity.Id) != null)
                {
                    command.CommandText = string.Format("UPDATE KnowledgeManagementSystemDB.dbo.[Test] SET " +
                    "Name = '{0}', " +
                    "Durations = '{1}', " +
                    "Description = '{2}', " +
                    "UserId = {3}, " +
                    "WHERE Id = {4}",
                    entity.Name,
                    duration/*entity.Duration*/,
                    entity.Description,
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
                    command.CommandText = string.Format("INSERT INTO  KnowledgeManagementSystemDB.[dbo].[Test]" +
                    "(Name = '{0}', " +
                    "Durations = '{1}', " +
                    "Description = '{2}', " +
                    "UserId = {3}) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}')",
                    entity.Name,
                    duration,
                    entity.Description,
                    entity.UserId);

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

        public Test GetByUserID(int id)
        {
            try
            {
                Test test = new Test();

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT * FROM KnowledgeManagementSystemDB.dbo.[Test] WHERE UserId = @Id");
                    SqlParameter IdParam = new SqlParameter("@IdParam", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        test.Id = (int)dr["Id"];
                        test.Name = dr["Name"].ToString();
                        test.Duration = duration;
                        test.Description = dr["Description"].ToString();
                        test.UserId = (int)dr["UserId"];
                        return test;
                    }
                    else return null;
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public List<Test> GetAllByUserID(int userid)
        {
            List<Test> AllTests = new List<Test>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeManagementSystemDB.[dbo].[Test] WHERE UserId=@userid";

                SqlParameter IdParam = new SqlParameter("@userid", userid);
                command.Parameters.Add(IdParam);

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Test test = new Test
                        {
                            Id = (int)dr["Id"],
                            Name = dr["Name"].ToString(),
                            Duration = duration,
                            UserId = (int)dr["UserId"],
                            Description = dr["Description"].ToString()
                        };
                        //test.Questions = qr.Get((int)dr["TestId"]); //Список вопросов

                        AllTests.Add(test);
                    }
                }
                return AllTests;
            }
        }

        public Test Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
