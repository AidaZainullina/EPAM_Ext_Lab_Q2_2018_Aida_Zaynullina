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
        public SqlConnection connection = null;
        readonly QuestionRepository qr = new QuestionRepository();

        private readonly string connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=KnowledgeManagementSystemDB;User ID=sa;Password=12345678";

        public bool AddData()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id = default)
        {
            try
            {
                string sqlRequest = string.Format("DELETE FROM KnowledgeSystemDB.[dbo].[Test] WHERE Id = @Id");

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
                    command.CommandText = string.Format("SELECT * FROM KnowledgeSystemDB.dbo.[Test] WHERE Id = @Id");
                    SqlParameter IdParam = new SqlParameter("@IdParam", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        test.Id = (int)dr["Id"];
                        test.Name = dr["Name"].ToString();
                        test.Duration = (DateTime)dr["Duration"];
                        //test.Questions = qr.Get((int)dr["TestId"]); //Список вопросов

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

        public List<Test> GetAll()
        {
            List<Test> AllTests = new List<Test>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeSystemDB.[dbo].[Test]";

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Test test = new Test
                        {
                            Id = (int)dr["Id"],
                            Name = dr["Name"].ToString(),
                            Duration = (DateTime)dr["Duration"]
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
                    command.CommandText = string.Format("UPDATE KnowledgeSystemDB.dbo.[Test] SET " +
                    "Name = '{0}', " +
                    "Durations = '{1}', " +
                    "Questions = {2}, " +
                    "WHERE Id = {3}",
                    entity.Name,
                    entity.Duration,
                    //entity.Questions,
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
                    command.CommandText = string.Format("INSERT INTO  KnowledgeSystemDB.[dbo].[Test]" +
                    "(Id = '{3},' +" +
                    "Name = '{0}', " +
                    "Durations = '{1}', " +
                    "Questions = '{2}' )" +
                    "VALUES ('{0}', '{1}', '{2}', '{3}')",
                    entity.Name,
                    entity.Duration,
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

        public Test Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
