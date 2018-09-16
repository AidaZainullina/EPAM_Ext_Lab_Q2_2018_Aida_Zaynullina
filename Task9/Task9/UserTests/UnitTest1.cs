using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KnowledgeManagementSystem.DAL.Repositories;
using KnowledgeManagementSystem.DAL.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace UserTests
{
    
    [TestClass]
    public class UnitTest1
    {
        public SqlConnection connection = null;

        public string connectionString;

        [TestMethod]
        public void DeleteNotExistingId()
        {
            IUserRepository<UserModel> userRepository = new UserRepository<UserModel>();

            userRepository.AddData();

            int nonExistId = 999;

            Assert.IsFalse(userRepository.Delete(nonExistId));
        }

        [TestMethod]
        public void DeleteExistingId()
        {
            IUserRepository<UserModel> userRepository = new UserRepository<UserModel>();

            userRepository.DeleteData();

            userRepository.AddData();

            int ExistingId = 2;

            Assert.IsTrue(userRepository.Delete(ExistingId));
        }

        [TestMethod]
        public void DeleteWithEmptyID()
        {
            IUserRepository<UserModel> userRepository = new UserRepository<UserModel>();

            userRepository.DeleteData();

            userRepository.AddData();

            Assert.IsFalse(userRepository.Delete());
        }

        [TestMethod]
        public void GetByExistingID()
        {
            IUserRepository<UserModel> userRepository = new UserRepository<UserModel>();

            userRepository.DeleteData();

            userRepository.AddData();

            int ExistingId = 4;

            Assert.IsNotNull(userRepository.Get(ExistingId));
        }

        [TestMethod]
        public void GetByNotExistingID()
        {
            IUserRepository<UserModel> userRepository = new UserRepository<UserModel>();

            userRepository.DeleteData();

            userRepository.AddData();

            int NotExistingId = 100;

            Assert.IsNull(userRepository.Get(NotExistingId));
        }

        [TestMethod]
        public void GetByNullID()
        {
            IUserRepository<UserModel> userRepository = new UserRepository<UserModel>();

            userRepository.DeleteData();

            userRepository.AddData();

            Assert.IsNull(userRepository.Get());
        }

        [TestMethod]
        public void GetAllTest()
        {
            IUserRepository<UserModel> userRepository = new UserRepository<UserModel>();

            userRepository.DeleteData();

            userRepository.AddData();

            connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=Database1;Integrated Security=True";

            List<UserModel> users = userRepository.GetAll();

            int count = users.Count;
            
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Database1.[dbo].[User]";
                command.CommandType = CommandType.Text;
                int count_ = (int)command.ExecuteScalar();

                if (count != count_)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void SaveEqualTest()
        {
            IUserRepository<UserModel> userRepository = new UserRepository<UserModel>();

            userRepository.DeleteData();

            userRepository.AddData();

            connectionString = @"Data Source=LAPTOP-4GR3EOJP\SQLEXPRESS_AIDA;Initial Catalog=Database1;Integrated Security=True";

            int Id = 111;

            userRepository.Delete(Id);

            UserModel user = new UserModel();
            user.UserId = Id;
            user.UserName = "Vlad";
            user.UserPassword = "125432";
            user.UserEmail = "email";
            user.UserRole = UserRoleID.Programmer;

            if (!userRepository.Save(user))
            {
                Assert.Fail("Not saved");
            }

            if (user.Equals(userRepository.Get(user.UserId)))
            {
                Assert.Fail("Not equal");
            }

            userRepository.Delete(Id);
        }
    }
}
