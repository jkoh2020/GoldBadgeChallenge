using System;
using KomodoBadges.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;

namespace KomodoBadges.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllBadges_ShouldReturnTrue()
        {
            // Arrange
            BadgesRepo badgesRepo = new BadgesRepo();
            SortedDictionary<int, List<string>> _dictionaryBadge = new SortedDictionary<int, List<string>>();
            _dictionaryBadge = badgesRepo.GetAllBadges();
            Badge badge = new Badge(1);

            // Act
            int numberOfObjectsInDictionary = _dictionaryBadge.Count;
            bool result = false;
            _dictionaryBadge.Add(1, badge.DoorName);
            
            if(_dictionaryBadge.Count == 1)
            {
                result = true;
            }

            // Assert

            Assert.IsTrue(result);
             

        }

        [TestMethod]
        public void AddBadge_AreEqual()
        {
            // Arrange
            Badge badge = new Badge(1);
            BadgesRepo badgeRepo = new BadgesRepo();
            SortedDictionary<int, List<string>> _dictionaryBadge = new SortedDictionary<int, List<string>>();

            // Act
            badgeRepo.AddBadge(badge);
            int number = badgeRepo.GetAllBadges().Count;

            // Assert
            Assert.AreEqual(1, number);
        }
    }
}
