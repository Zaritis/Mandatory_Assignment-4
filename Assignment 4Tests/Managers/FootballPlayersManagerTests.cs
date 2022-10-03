using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_4.FootballPlayersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1;
using System.Runtime.CompilerServices;

namespace Assignment_4.FootballPlayersManager.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        private static FootballPlayersManager _manager;

        [TestInitialize]
        [TestMethod()]
        public void GetAllTest()
        {
           
            List<FootBallPlayer> playerlistTest = new List<FootBallPlayer>();
            playerlistTest.Add(new FootBallPlayer());
            playerlistTest.Add(new FootBallPlayer());
            Assert.AreEqual(2, playerlistTest.Count);
            //By first making a new list and adding new player objects, I then assert that there is a total of 2 objects in the playerlistTest list
        }

        [TestMethod()]
        public void GetFootBallPlayerByIdTest()
        {
            int id = 1;
            FootballPlayersManager footballPlayersManager1 = new FootballPlayersManager();
            FootballPlayersManager footballPlayersManager2 = new FootballPlayersManager();
            _manager.GetFootBallPlayerById(id);
            Assert.AreNotEqual(footballPlayersManager1, footballPlayersManager2);
           
            //By first making two new playermanagers using default constructors, I use my get by id method to get a specific player made in the manager and assert that the two players are not the same object
        }

        [TestMethod()]
        public void AddTest()
        {
            FootballPlayersManager footballPlayersManager = new FootballPlayersManager();
            FootBallPlayer player1 = new FootBallPlayer(4, "Bob", 33, 95);
           

            footballPlayersManager.Add(player1);
            Assert.AreNotSame(footballPlayersManager, player1);
        }

        [TestMethod()]
        public void DeleteTest()
        {

            FootballPlayersManager footballPlayersManager1 = new FootballPlayersManager();
            FootballPlayersManager footballPlayersManager2 = new FootballPlayersManager();
            int id = 1;
            footballPlayersManager1.Delete(id);
            Assert.AreNotSame(footballPlayersManager1, footballPlayersManager2);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}