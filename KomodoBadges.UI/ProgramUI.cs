using KomodoBadges.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KomodoBadges.UI
{
    public class ProgramUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();
       
        bool continueToRun = true;
        public void Menu()
        {
            ManagerAccess();

            while (continueToRun)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("Select the following option:\n" +
                        "1. Add a badge\n" +
                        "2. Edit a badge\n" +
                        "3. List all badges\n" +
                        "4. Exit\n");

                    int selection = Convert.ToInt32(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            AddNewBadge();
                            break;
                        case 2:
                            EditBadge();
                            break;
                        case 3:
                            ListAllBadges();
                            break;
                        case 4:
                            continueToRun = false;
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception)
                    {
                        Console.WriteLine("Please enter a valid key which a number");
                        Console.ReadKey();
                    }
            }

        }

        public void AddNewBadge()
        {
            SortedDictionary<int, List<string>> badgesNumber = _badgesRepo.GetAllBadges();
            Console.Write("What is the number on the badge:  ");
            int number = Convert.ToInt32(Console.ReadLine());

            try
            {
                if (badgesNumber.ContainsKey(number))
                {
                    Console.Clear();
                    Console.WriteLine($"\n\nThe badge number {number} is already exist");
                    Console.ReadKey();
                }
                else
                {
                    bool run = true;

                    Console.WriteLine("List a door that it needs to access to:  ");
                    string doorAccess = Console.ReadLine().ToUpper();
                    Badge badge = new Badge(number);
                    badge.DoorName.Add(doorAccess); // Save door access name

                    while (run)
                    {
                        Console.WriteLine("\n\nAny other doors need to access(y/n)?  ");
                        string answer = Console.ReadLine().ToLower();

                        switch (answer)
                        {
                            case "y":
                                Console.WriteLine("Which door would like to add?");
                                string addtionalDoor = Console.ReadLine().ToUpper();
                                badge.DoorName.Add(addtionalDoor); // Save additional door access name
                                break;
                            case "n":


                                _badgesRepo.AddBadge(badge); // Save all of them
                                run = false;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid key");
                                break;
                        }

                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid key which a number");
                Console.ReadKey();
            }

        }
        public void ListAllBadges()
        {
            Console.Clear();
            SortedDictionary<int, List<string>> badges = _badgesRepo.GetAllBadges();
            Console.WriteLine("Badge#       Room Access");

            foreach(KeyValuePair<int, List<string>> badge in badges)
            {
                Console.Write($"\n{badge.Key}         ");
                foreach(string door in badge.Value)
                {
                    Console.Write($"{door} ");
                }
            }

            Console.WriteLine("");

            Console.WriteLine("\nPlease press any key to continue...");
            
            Console.ReadKey();
        }

        public void EditBadge()
        {
            Console.Clear();
            ListAllBadges();
            
            SortedDictionary<int, List<string>> badgesNumber = _badgesRepo.GetAllBadges();
            Console.Write("What is the badge number to update?  ");
            int numberToUpdate = Convert.ToInt32(Console.ReadLine());
            Badge badge = new Badge(numberToUpdate);
            Badge badge1 = new Badge(numberToUpdate);

            if (badgesNumber.ContainsKey(numberToUpdate))
            {
                Console.Clear();
                Console.Write($"Badge# {numberToUpdate} has access to doors ");
               
                
                    foreach (string door in badgesNumber[numberToUpdate])
                    {
                        Console.Write($"{door} ");
                    }
                                  
                
                Console.WriteLine("\n\nWhat would like to do?");
                Console.WriteLine("1. Remove a door\n" +
                                  "2. Add a door\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                
                if (choice == 1)
                {
                    Console.Write("Which door would like to remove? ");
                    string removeDoorAccess = Console.ReadLine().ToUpper();
                    Console.Clear();
                    Console.WriteLine($"\nThe door {removeDoorAccess} has removed.");
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the door it needs to access");
                    string addDoorAccess = Console.ReadLine().ToUpper();
                    
                    badge1.DoorName.Add(addDoorAccess);
                    Console.Clear();
                    Console.WriteLine($"Door {addDoorAccess} has added");
                   
                    Console.WriteLine($"The badge# {numberToUpdate} has access to door {addDoorAccess} now.");
                    Console.ReadKey();
                    
                    foreach (string door in badgesNumber[numberToUpdate])
                    {
                        Console.Write($"{door} ");
                    }

                   // _badgesRepo.AddBadge(badge);

                }
                else
                {
                    Console.WriteLine("Please enter a valid key(1 or 2)");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("Please enter a valid key");
                Console.ReadKey();
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
