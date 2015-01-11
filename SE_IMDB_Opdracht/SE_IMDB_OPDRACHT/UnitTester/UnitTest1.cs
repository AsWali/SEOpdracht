using System;
using SE_IMDB_OPDRACHT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTester
{
    [TestClass]
    public class UnitTest1
    {
        DatabaseConnection dbconn = new DatabaseConnection();

        [TestMethod]
        public void CorrectLogIn()
        {
            Assert.IsTrue(dbconn.TryLogin("asrorwali@hotmail.nl", "ontwikkel"));
        }

        [TestMethod]
        public void IncorrectLogIn()
        {
            Assert.IsFalse(dbconn.TryLogin("asrorwali@hotmail.nl", "password"));
        }

        [TestMethod]
        public void EmailInUse()
        {
            Assert.IsFalse(dbconn.EmailAvailable("asrorwali@hotmail.nl"));
        }

        [TestMethod]
        public void PageNummer()
        {
            Assert.AreEqual(2, dbconn.GetPageNmr("American History X"));
        }

        [TestMethod]
        public void PageImage()
        {
            Assert.AreEqual("American.Jpg", dbconn.GetImage(2));
        }

        [TestMethod]
        public void GetRating()
        {
            Assert.AreEqual(6, dbconn.AlreadyRated(3,"asrorwali@hotmail.nl"));
        }

        

    }
}
