using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.Repo
{
    public class ClaimRepo
    {
       
        private SortedDictionary<int, Claims> _repo = new SortedDictionary<int, Claims> { };
        public void AddClaim (Claims claim)  // Create
        {
            _repo.Add(claim.ClaimID, claim);
        }

        public SortedDictionary<int, Claims> GetAllClaims()  // READ
        {
            return _repo;
        }
    }
}
