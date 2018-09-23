namespace KnowledgeManagementSystem.DAL.Repositories.Question
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Task10;

    //Не доделала
    class QuestionRepository : IQuestionRepository
    {
        public SqlConnection connection = null;

        private string connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=KnowledgeManagementSystemDB;Integrated Security=True";

        public bool AddData()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id = default)
        {
            try
            {
                string sqlRequest = string.Format("DELETE FROM KnowledgeBase.[dbo].[Question] WHERE Id = {0}", id);

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

        public Question Get(int id = default)
        {
            try
            {
                Question quest = new Question();

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT * FROM KnowledgeBase.dbo.[Question] WHERE Id = {0} ", id);
                    SqlParameter IdParam = new SqlParameter("@IdParam", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        quest.Id = (int)dr["Id"];
                        quest.Name = dr["Name"].ToString();

                        return quest;
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
            List<Question> AllQuestions = new List<Test>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeBase.[dbo].[Question]";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Question question = new Question();
                        question.Id = (int)reader["Id"];
                        question.Name = reader["Name"].ToString();

                        AllQuestions.Add(question);
                    }
                }
                return AllQuestions;
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
                    command.CommandText = string.Format("UPDATE KnowledgeBase.dbo.[Question] SET " +
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
                    command.CommandText = string.Format("INSERT INTO  KnowledgeBase.[dbo].[Question]" +
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
    }
}
