using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using KomodoCafe.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafe.Tests
{
    [TestClass]
    public class MenuRepo_Tests
    {
        [TestMethod]
        public void AddMenu_AreEqual()
        {
            // Arrange
            Menu menuItem = new Menu(1);
            MenuRepo _menuRepo = new MenuRepo();
            SortedDictionary<int, Menu> mealNumber = _menuRepo.GetAllMenuItems();

            // Act

            _menuRepo.AddMenu(menuItem);
            int number = _menuRepo.GetAllMenuItems().Count;

            // Assert

            Assert.AreEqual(1, number);

        }
        [TestMethod]
        public void GetMenuItems_ShouldReturnTrue()
        {
            // Arrange
            MenuRepo _menuRepo = new MenuRepo();
            SortedDictionary<int, Menu> _dictionaryMenu = new SortedDictionary<int, Menu>();
            _dictionaryMenu = _menuRepo.GetAllMenuItems();
            Menu menuItem = new Menu(1);

            // Act
            int numObjectsInDictionary = _dictionaryMenu.Count;
            bool addResult = false;
            _dictionaryMenu.Add(1, menuItem);

            if(_dictionaryMenu.Count == 1)
            {
                addResult = true;
            }
            

            // Assert

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void DeleteMenu_ShouldReturnCorrectBool()
        {
            // Arrange
            MenuRepo _menuRepo = new MenuRepo();
            SortedDictionary<int, Menu> _dictionaryMenu = new SortedDictionary<int, Menu>();
            Menu newMenuItem = new Menu(1);
            _dictionaryMenu.Add(1, newMenuItem);

            // Act
            bool actualResult = _menuRepo.DeleteMenu(1);

            bool expectedResult = false;

            if(_dictionaryMenu.Count == 0)
            {
                expectedResult = true;
            }

            // Assert

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
