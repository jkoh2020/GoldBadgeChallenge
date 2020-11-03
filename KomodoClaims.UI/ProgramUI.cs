using KomodoClaims.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.UI
{
    public class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();
        bool continueToRun = true;
        
        public void Menu()
        {
            ManagerAccess();
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Select the following option:\n" +
                    "1. See all claims\n\n" +
                    "2. Take care of next claim\n\n" +
                    "3. Enter a new claim\n\n" +
                    "4. Exit");

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                       TakeCareOfNextClaim();
                        break;
                    case "3":
                       AddNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void SeeAllClaims()
        {
            Console.Clear();
            SortedDictionary<int, Claims> claims = _claimRepo.GetAllClaims();

                Console.Write("ClaimId      Type    Description             Amount      DateOfAccident         DateOfClaim          IsValid\n");
            foreach (KeyValuePair<int, Claims> claim in claims)
            {
                Console.Write($"   {claim.Key}         {claim.Value.ClaimType}      {claim.Value.Description}         $ {claim.Value.ClaimAmount}        {claim.Value.DateOfIncident}       {claim.Value.DateOfClaim}         {claim.Value.IsValid}\n");
            }
            Console.WriteLine("");
            Console.WriteLine("Please press any key to continue...");
            Console.ReadLine();
        }

        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            SortedDictionary<int, Claims> claims = _claimRepo.GetAllClaims();

            
            foreach (KeyValuePair<int, Claims> claim in claims)
            {
                Console.WriteLine($"Claim ID: {claim.Key}\nType: {claim.Value.ClaimType}\nDescription: {claim.Value.Description}\nAmount: ${claim.Value.ClaimAmount}\nDate Of Accident: {claim.Value.DateOfIncident}\nDate Of Claim: {claim.Value.DateOfClaim}\nIsValid: {claim.Value.IsValid}\n");
            }
            Console.WriteLine("");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string dealClaim = Console.ReadLine().ToLower();

                if (dealClaim == "y" || dealClaim == "yes")
                 {
                Console.WriteLine("jlj");
                 }
                else if (dealClaim == "n" || dealClaim == "no")
                 {
                
                 }
                else
                 {
                Console.WriteLine("Please enter a valid key");
                 }
        }

        public void AddNewClaim()
        {
            Console.Clear();
            SortedDictionary<int, Claims> duplicateId = _claimRepo.GetAllClaims();
            Console.WriteLine("Enter the claim id:\n");
            int id= Convert.ToInt32(Console.ReadLine());
            if (duplicateId.ContainsKey(id))
            {
                Console.WriteLine($"Claim id: {id} is already existed. Please enter different claim id number.\nPress any key to continue...");
            }
            else
            {
                Console.WriteLine("Enter the claim type(Car, Home, Theft):\n");
                string type = Console.ReadLine();
                Console.WriteLine("Enter a claim description:\n");
                string description = Console.ReadLine();
                Console.WriteLine("Amount of Damage:\n");
                double amount = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Date Of Accident:\n");
                DateTime accidentDate = Convert.ToDateTime(Console.ReadLine());            
                Console.WriteLine("Date of claim:\n");
                DateTime claimDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Is this claim valid?");
                bool ans = Convert.ToBoolean(Console.ReadLine());          
                Claims claim = new Claims(id);
                claim.ClaimID = id;
                claim.ClaimType = type;
                claim.Description = description;
                claim.ClaimAmount = amount;
                claim.DateOfIncident = accidentDate;
                claim.DateOfClaim = claimDate;
                claim.IsValid = ans;
                
                _claimRepo.AddClaim(claim);
            }
        }

        private void ManagerAccess()
        {
            Console.Clear();

            Console.WriteLine("Are you a manager? (y or no)");
            string ans = Console.ReadLine().ToLower();

            if (ans == "y")
            {
                Console.WriteLine("Please enter your manager ID number");
                int idNumber = Convert.ToInt32(Console.ReadLine());

                if (idNumber == 1234)
                {
                    Console.Clear();
                    
                }
                else
                {
                    Console.WriteLine("Sorry, you are not a manager. You can't access this application");
                    continueToRun = false;
                    Console.ReadKey();
                }
            }

            else if (ans == "n")
            {
                Console.WriteLine("Sorry, you are not authorized to access this application. Only manager can access this application.");
                continueToRun = false;
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Please enter the valid key");
                Console.ReadKey();
            }

        }



    }
}
