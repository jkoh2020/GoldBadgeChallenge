using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe.Repo
{
    public class MenuRepo
    {
        
        private SortedDictionary<int, Menu> _dictionaryMenu = new SortedDictionary<int, Menu> { }; // create an empty library to add menu
        public void AddMenu(Menu content)
        {
            _dictionaryMenu.Add(content.MealNumber, content);
        }
                   
        public SortedDictionary<int, Menu> GetAllMenuItems()
        {
            return _dictionaryMenu;
        }

        public bool DeleteMenu(int number)
        {
            if (_dictionaryMenu == null)
            {
                Console.WriteLine("It is empty");
                Console.ReadKey();
            }
            return _dictionaryMenu.Remove(number);
        }       
    }
}
