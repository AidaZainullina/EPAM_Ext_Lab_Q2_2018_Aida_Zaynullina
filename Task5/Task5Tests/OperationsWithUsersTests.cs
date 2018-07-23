namespace Task5.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task5;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass()]
    public class OperationsWithUsersTests
    {
        private OperationsWithUsers<User> ListOfUsers = new OperationsWithUsers<User>();

        private List<int> ListOfUsersID = new List<int>();

        private Random random = new Random();

        private User ExpectedEntity;

        private int Minimum = default, Maximum = 100;

        public void FillListOfID()
        {
            foreach (var user in ListOfUsers.BaseOfUsers)
            {
                ListOfUsersID.Add(user.Id);
            }
        }

        [TestMethod]
        public void IsDeleteByExistingID()
        {
            FillListOfID();

            var ID = ListOfUsersID[random.Next(0, ListOfUsersID.Count)];

            var expected = ListOfUsers.Delete(ID);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void IsDeleteByNonExistingID()
        {
            FillListOfID();

            int ID = random.Next(ListOfUsersID.Count + 1, ListOfUsersID.Count * 2);

            var expected = ListOfUsers.Delete(ID);

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void IsDeleteWithoutID()
        {
            Assert.IsFalse(ListOfUsers.Delete());
        }

        
        [TestMethod]
        public void GetExpectedResult()
        {
            FillListOfID();

            var randomID = ListOfUsersID[random.Next(Minimum, ListOfUsersID.Count - 1)];

            var actual = ListOfUsers.Get(randomID);

            foreach (var user in ListOfUsers.BaseOfUsers)
            {
                if (user.Id == randomID)
                {
                    ExpectedEntity = user;

                    return;
                }
            }

            Assert.AreEqual(ExpectedEntity, actual);
        }

        [TestMethod]
        public void GetUnexpectedResult()
        {
            FillListOfID();

            var randomID = random.Next(ListOfUsersID.Count + 1, Maximum);

            Assert.IsNull(ListOfUsers.Get(randomID));
        }

        [TestMethod]
        public void GetNullResult()
        {
            Assert.IsNull(ListOfUsers.Get());
        }

        
        [TestMethod]
        public void IsGetAllFromDataBaseWithSameData()
        {
            Assert.AreEqual(ListOfUsers.GetAll(), ListOfUsers.BaseOfUsers);
        }

        [TestMethod]
        public void IsGetAllFromDataBaseWithSameHashCode()
        {
            Assert.AreEqual(ListOfUsers.BaseOfUsers.GetHashCode(), ListOfUsers.GetAll().GetHashCode());
        }

        [TestMethod]
        public void IsGetAllFromDataBaseWithSameNumberOfElements()
        {
            Assert.AreEqual(ListOfUsers.BaseOfUsers.Count, ListOfUsers.GetAll().Count);
        }

        [TestMethod]
        public void Saved()
        {
            int randomID = random.Next(Minimum, Maximum);

            bool expected = ListOfUsers.Save(new User() { Id = randomID });

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void CheckEqualsOfSavedEntity()
        {
            int randomID = random.Next(Minimum, Maximum);

            ListOfUsers.Save(new User() { Id = randomID });

            FillListOfID();

            Assert.IsTrue(ListOfUsersID[ListOfUsersID.Count - 1].Equals(randomID));
        }

        [TestMethod]
        public void CheckNonEqualsOfSavedEntity()
        {
            int randomID = random.Next(Minimum, Maximum);

            ListOfUsers.Save(new User() { Id = randomID + 1 });

            FillListOfID();

            Assert.IsFalse(ListOfUsersID[ListOfUsersID.Count - 1].Equals(randomID));
        }

        [TestMethod]
        public void IsSavedNull()
        {
            Assert.IsFalse(ListOfUsers.Save());
        }
    }
}