namespace KnowledgeSystemDAL.Repositories.Question
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using KnowledgeSystemDAL.Models;

    public class QuestionRepository
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
                string sqlRequest = string.Format("DELETE FROM KnowledgeSystemDB.[dbo].[Question] WHERE Id = @Id");

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

        public Question Get(int id = default)
        {
            try
            {
                Question question = new Question();

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT * FROM KnowledgeBase.dbo.[Question] WHERE Id = @Id");
                    SqlParameter IdParam = new SqlParameter("@Id", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        question.Id = (int)dr["Id"];
                        question.TestID = (int)dr["Id"];
                        question.Text = (string)dr["Text"];
                        return question;
                    }
                    else return null;
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public List<Question> GetAll()
        {
            List<Question> AllQuestions = new List<Question>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeBase.[dbo].[Question]";

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Question question = new Question
                        {
                            Id = (int)dr["Id"],
                            TestID = (int)dr["Id"],
                            Text = (string)dr["Text"]
                        };

                        AllQuestions.Add(question);
                    }
                }
                return AllQuestions;
            }
        }

        public List<Question> GetAllQuestionByTestId(int TestId)
        {
            List<Question> AllQuestions = new List<Question>();

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM KnowledgeManagementSystemDB.[dbo].[Question] where TestId = @TestId";
                SqlParameter IdParam = new SqlParameter("@TestId", TestId);
                command.Parameters.Add(IdParam);

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Question question = new Question
                        {
                            Id = (int)dr["Id"],
                            TestID = (int)dr["Id"],
                            Text = (string)dr["Text"]
                        };

                        AllQuestions.Add(question);
                    }
                }
                return AllQuestions;
            }
        }

        public bool Save(Question entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();

                if (this.Get(entity.Id) != null)
                {
                    command.CommandText = string.Format("UPDATE KnowledgeBase.dbo.[Question] SET " +
                    "Id = '{0}', " + 
                    "TestId = '{1}', " +
                    "Text = '{2}', " +
                    "WHERE Id  = {3} ",
                    entity.Id,
                    entity.TestID,
                    entity.Text,
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
                    command.CommandText = string.Format("INSERT INTO  KnowledgeBase.[dbo].[Question]" +
                   "(Id, " +
                    "TestId, " +
                    "Text) " +
                    "VALUES ('{0}', '{1}', '{2}')",
                    entity.Id,
                    entity.TestID,
                    entity.Text);

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
    }
}
