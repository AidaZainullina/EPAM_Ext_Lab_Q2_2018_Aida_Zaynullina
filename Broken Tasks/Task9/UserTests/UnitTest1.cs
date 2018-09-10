using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KnowledgeManagementSystem.DAL.Repositories;
using KnowledgeManagementSystem.DAL.Models;

namespace UserTests
{
    [TestClass]
    public class UnitTest1
    {
        private string connection = @"Data Source=(LocalDB)\Database1;Integrated Security=True";

        [TestMethod]
        public void DeleteNotExistingId()
        {
            IUserRepository<ModelOfUser> userRepository = new UserRepository<ModelOfUser>();

            int nonExistId = 999;

            Assert.IsFalse(userRepository.Delete(nonExistId));
        }

        [TestMethod]
        public void DeleteExistingId()
        {
            IUserRepository<ModelOfUser> userRepository = new UserRepository<ModelOfUser>();

            int ExistingId = 1;

            ModelOfUser user = new ModelOfUser();

            user.UserId = 1;
            user.UserName = "Masha";
            user.UserPassword = "12345678";
            user.UserRole = UserRole.Manager;
            user.UserEmail = "afffff";

            userRepository.Save(user);

            Assert.IsTrue(userRepository.Delete(ExistingId));
        }

        [TestMethod]
        public void DeleteWithEmptyID()
        {
            IUserRepository<ModelOfUser> userRepository = new UserRepository<ModelOfUser>();

            Assert.IsFalse(userRepository.Delete(default));
        }
    }
}
