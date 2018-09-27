namespace KnowledgeSystemDAL.Repositories.UserTestLog
{
    using System.Data;
    using System.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using KnowledgeSystemDAL.Models;

    public class UserTestLogRepository : IUserTestLogRepository
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
                string sqlRequest = string.Format("DELETE FROM KnowledgeSystemDB.[dbo].[UserTestLog] WHERE Id = @Id");

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

        public Report Get(int id = default)
        {
            try
            {
                Report report = new Report();

                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT * FROM KnowledgeSystemDB.dbo.[UserTestLog] WHERE Id = @Id");
                    SqlParameter IdParam = new SqlParameter("@IdParam", id);
                    command.Parameters.Add(IdParam);

                    IDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        report.Id = (int)dr["Id"];
                        report.UserID = (int)dr["UserId"];
                        report.TestId = (int)dr["TestId"];
                        report.Score = (int)dr["Score"];
                        report.Duration = (DateTime)dr["Duration"];
                        report.Date = (DateTime)dr["Date"];

                        return report;
                    }
                    else return null;
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public List<Report> GetAll()
        {
            List<Report> AllReports = new List<Report>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KnowledgeSystemDB.[dbo].[UserTestLog]";

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Report report = new Report
                        {
                            Id = (int)dr["Id"],
                            UserID = (int)dr["UserId"],
                            TestId = (int)dr["TestId"],
                            Score = (int)dr["Score"],
                            Duration = (DateTime)dr["Duration"],
                            Date = (DateTime)dr["Date"]
                        };

                        AllReports.Add(report);
                    }
                }
                return AllReports;
            }
        }

        public bool Save(Report entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();

                if (this.Get(entity.Id) != null)
                {
                    command.CommandText = string.Format("UPDATE KnowledgeSystemDB.dbo.[UserTestLog] SET " +
                    "UserId = '{0}', " +
                    "TestId = '{1}', " +
                    "Data = {2}, " +
                    "Duration = '{3}', " +
                    "Score = {4}, " +
                    "WHERE Id = {5}",
                    entity.UserID,
                    entity.TestId,
                    entity.Date,
                    entity.Duration,
                    entity.Score,
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
                    command.CommandText = string.Format("INSERT INTO  KnowledgeSystemDB.[dbo].[UserTestLog]" +
                    "(Id = '{0},' +" +
                    "UserId = '{1}', " +
                    "TestId = '{2}', " +
                    "Data = '{3}', " +
                    "Duration = '{4}', " +
                    "Score = {5} )" +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                    entity.Id,
                    entity.UserID,
                    entity.TestId,
                    entity.Date,
                    entity.Duration,
                    entity.Score);

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

        public Report Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}

