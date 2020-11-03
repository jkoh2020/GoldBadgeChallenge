using KomodoClaims.Repo;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

namespace KomodoClaims.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllClaims_ShouldReturnTrue()
        {
            // Arrange
            ClaimRepo _repo = new ClaimRepo();
            SortedDictionary<int, Claims> repo = new SortedDictionary<int, Claims> { };
            Claims number = new Claims(1);

            // Act
            int numOfObject = repo.Count;
            bool addNumber = false;
            repo.Add(1, number);

            if (repo.Count == 1)
            {
                addNumber = true;
            }

            // Assert
            Assert.IsTrue(addNumber);
        }

        [TestMethod]
        public void AddClaim_AreEqual()
        {
            // Arrange
            Claims claimId = new Claims(1);
            ClaimRepo repo = new ClaimRepo();
            SortedDictionary<int, Claims> _repo = repo.GetAllClaims();


            // Act
            repo.AddClaim(claimId);
            int number = repo.GetAllClaims().Count;

            // Assert
            Assert.AreEqual(1, number);
        }
    }

}
