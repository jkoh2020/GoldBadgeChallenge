using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges.Repo
{
    public class BadgesRepo
    {
        private SortedDictionary<int, List<string>> _dictionaryBadge = new SortedDictionary<int, List<string>>(); // create an empty library to add menu


        public void AddBadge(Badge content)
        {
            _dictionaryBadge.Add(content.BadgeId, content.DoorName);
        }

        public SortedDictionary<int, List<string>> GetAllBadges()
        {
            return _dictionaryBadge;
           
        }

        public void DeleteMenu(int number)
        {
            _dictionaryBadge.Remove(number);
        }

    }

    



}
