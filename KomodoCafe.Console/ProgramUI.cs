using KomodoCafe.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe.UI
{
    public class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();
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
                        "1. See all menu items\n" +
                        "2. Add a new menu item\n" +
                        "3. Delete a menu item\n" +
                        "4. Exit\n");

                    int selection = Convert.ToInt32(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            SeeAllMenuItem();
                            break;
                        case 2:
                            AddNewMenuItem();
                            break;
                        case 3:
                            DeleteMenuByNumber();
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

        public void SeeAllMenuItem()
        {
            Console.Clear();
            SortedDictionary<int, Menu> menu = _menuRepo.GetAllMenuItems();

            foreach (KeyValuePair<int, Menu> meal in menu)
            {
                Console.Write($"{meal.Key}. {meal.Value.MealName}\nDescription: {meal.Value.Description}\nIngredients: {meal.Value.Ingredients}\nPrice:$ {meal.Value.Price}\n\n\n");
                Console.WriteLine("----------------------------------------------------------------------------------\n");
            }
            Console.WriteLine("Please press any key to continue...");
            Console.ReadLine();



        }

        public void AddNewMenuItem()
        {
            try
            {
                Console.Clear();
                SortedDictionary<int, Menu> mealNumber = _menuRepo.GetAllMenuItems();
                Console.WriteLine("Enter a meal number:");
                int number = Convert.ToInt32(Console.ReadLine());
                if (mealNumber.ContainsKey(number))
                {
                    Console.Clear();
                    Console.WriteLine("The meal number is already exist");
                    Console.ReadKey();
                }
                else
                {


                    Console.WriteLine("Enter a new meal name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter a description of a new meal:");
                    string description = Console.ReadLine();
                    Console.WriteLine("Enter ingredients for a new meal:");
                    string ingredients = Console.ReadLine();
                    Console.WriteLine("Enter the price for a new meal:");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Menu menu = new Menu(number);
                    menu.MealName = name;
                    menu.Description = description;
                    menu.Ingredients = ingredients;
                    menu.Price = price;
                    _menuRepo.AddMenu(menu);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid key which is a number");
               Console.ReadKey();
            }  
        }

       private void DeleteMenuByNumber()
        {
            Console.Clear();
            SeeAllMenuItem();
            try
            {
                Console.WriteLine("Enter the menu number you want to delete.");
            int numberToDelete = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"Are you sure you want to delete number {numberToDelete} menu? (y/n)");
            string confirmToDelete = Console.ReadLine().ToLower();
           
                if (confirmToDelete == "yes" || confirmToDelete == "y")
                {
                    Console.Clear();
                    _menuRepo.DeleteMenu(numberToDelete); // Delete the menu by a number

                    Console.WriteLine($"Menu number {numberToDelete} has been deleted successfully. Press any key to continue...");
                    Console.ReadKey();

                }
                else if (confirmToDelete == "no" || confirmToDelete == "n")
                {
                    SeeAllMenuItem();
                }
                else
                {
                    Console.WriteLine("Please type a valid key.");
                    Console.ReadKey();
                }
            }
            catch (Exception)
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

