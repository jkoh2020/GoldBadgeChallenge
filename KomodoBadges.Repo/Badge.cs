using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges.Repo
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public List<string> DoorName { get; set; }
        

        public Badge(int badgeId) // constructor
        {

            BadgeId = badgeId;
            DoorName = new List<string>(); // make an empty list
            
        }
        
    }
}
