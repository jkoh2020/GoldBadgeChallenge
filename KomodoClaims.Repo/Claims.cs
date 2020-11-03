using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.Repo
{
    public class Claims
    {
        public int ClaimID { get; set; }
        public string ClaimType {get; set;}
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        
        public Claims(int claimId)
        {
            ClaimID = claimId;
        }
        

    }

    
}
