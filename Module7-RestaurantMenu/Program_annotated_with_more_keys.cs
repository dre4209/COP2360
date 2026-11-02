// Restaurant Menu Dictionary
// COP2360 Module 7 Group Assignment
//
// This program stores a restaurant menu in a Dictionary.


using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantMenuDictionary
{
    class Program
    {
        // The dictionary that holds the whole restaurant menu.

        static Dictionary<string, List<string>> menu =
            new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        static void Main(string[] args)
        {
            
            bool running = true;

            
            while (running)
            {
                ShowMainMenu();

                
                Console.Write("Enter your choice (1 to 7): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Please enter a number from 1 to 7.\n");
                    continue;
                }

                
                // SWITCH STATEMENT: runs the task the user picked
                
                switch (choice)
                {
                    case 1:
                        PopulateDictionary();        // Person 1
                        break;
                    case 2:
                        DisplayDictionary();         // Person 2
                        break;
                    case 3:
                        RemoveKey();                 // Person 3 CC
                        break;
                    case 4:
                        AddNewKeyAndValue();         // Person 3 CC
                        break;
                    case 5:
                        AddValueToExistingKey();     // Person 3 CC
                        break;
                    case 6:
                        SortKeys();                  // Person 2
                        break;
                    case 7:
                        Console.WriteLine("Thank you for using the Restaurant Menu program. Goodbye!");
                        running = false;
                        break;
                    default:
                        // Runs when the number is not between 1 and 7
                        Console.WriteLine("Invalid choice. Please pick a number from 1 to 7.");
                        break;
                }

                Console.WriteLine();
            }
        }

        
        // ShowMainMenu
     
        static void ShowMainMenu()
        {
            Console.WriteLine("===== RESTAURANT MENU MANAGER =====");
            Console.WriteLine("1. Populate the Dictionary");
            Console.WriteLine("2. Display Dictionary Contents");
            Console.WriteLine("3. Remove a Category (Key)");
            Console.WriteLine("4. Add a New Category and Dish");
            Console.WriteLine("5. Add a Dish to an Existing Category");
            Console.WriteLine("6. Sort the Categories (Keys)");
            Console.WriteLine("7. Exit");
            Console.WriteLine("===================================");
        }

        
        // Case 1: PopulateDictionary
        // Clears the dictionary and fills it with our starting menu.
        // Each category (key) gets a List of dishes (values).
       
        static void PopulateDictionary()
        {
            // Start fresh so running this twice does not cause duplicate key errors
            menu.Clear();

            menu.Add("Appetizers", new List<string> { "Mozzarella Sticks", "Chicken Wings", "Loaded Nachos" });
            menu.Add("Entrees", new List<string> { "Grilled Salmon", "Chicken Alfredo", "Ribeye Steak" });
            menu.Add("Sides", new List<string> { "French Fries", "Mac and Cheese", "Garden Salad" });
            menu.Add("Desserts", new List<string> { "Cheesecake", "Chocolate Cake", "Key Lime Pie" });
            menu.Add("Drinks", new List<string> { "Lemonade", "Iced Tea", "Coffee" });

            // Additional dictionary keys (categories) added for the expanded restaurant menu CC, added new categories 
            menu.Add("Breakfast", new List<string> { "Pancakes", "French Toast", "Omelet" });
            menu.Add("Seafood", new List<string> { "Shrimp Scampi", "Fish and Chips", "Lobster Tail" });
            menu.Add("Soups", new List<string> { "Tomato Soup", "Chicken Noodle Soup", "Clam Chowder" });
            menu.Add("Sandwiches", new List<string> { "Club Sandwich", "BLT", "Philly Cheesesteak" });

            Console.WriteLine($"The menu has been populated with {menu.Count} categories.");
        }

        
        // Case 2: DisplayDictionary
       
        static void DisplayDictionary()
        {
            // Let the user know if there is nothing to show yet
            if (menu.Count == 0)
            {
                Console.WriteLine("The menu is empty. Choose option 1 to populate it first.");
                return;
            }

            Console.WriteLine("\n--- Current Restaurant Menu ---");

            // Each pair holds one key (the category) and its value (the list of dishes)
            foreach (KeyValuePair<string, List<string>> pair in menu)
            {
                Console.WriteLine($"{pair.Key}:");

                // Loop through every dish stored in this category's list
                foreach (string dish in pair.Value)
                {
                    Console.WriteLine($"   * {dish}");
                }
            }
        }

       
        // CC part's dictionary-editing task: remove a category (dictionary key).
        // Case 3: RemoveKey
        // Asks for a category name and removes it along with its dishes.
        
        static void RemoveKey()
        {
            Console.Write("Enter the category to remove: ");
            string category = Console.ReadLine()?.Trim();

            // Remove returns true if the key was found and deleted, false if not
            if (!string.IsNullOrEmpty(category) && menu.Remove(category))
            {
                Console.WriteLine($"\"{category}\" was removed from the menu.");
            }
            else
            {
                Console.WriteLine($"\"{category}\" was not found on the menu.");
            }
        }

        
        // CC part's dictionary-editing task: add a new category key and its first dish value. CC
        // Case 4: AddNewKeyAndValue
        // Creates a brand new category with its first dish.
        
        static void AddNewKeyAndValue()
        {
            Console.Write("Enter the new category name: ");
            string category = Console.ReadLine()?.Trim();

            // Make sure the user typed something
            if (string.IsNullOrEmpty(category))
            {
                Console.WriteLine("Category name cannot be blank.");
                return;
            }

            // A dictionary cannot hold the same key twice, so check first
            if (menu.ContainsKey(category))
            {
                Console.WriteLine($"\"{category}\" already exists. Use option 5 to add a dish to it.");
                return;
            }

            Console.Write($"Enter the first dish for {category}: ");
            string dish = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(dish))
            {
                Console.WriteLine("Dish name cannot be blank.");
                return;
            }

            // Add the new key with a new list that holds the first dish
            menu.Add(category, new List<string> { dish });
            Console.WriteLine($"Added \"{category}\" with \"{dish}\".");
        }

        // Person 3's dictionary-editing task: add another dish value to an existing category key. CC
        // Case 5: AddValueToExistingKey
        // Adds another dish to a category that already exists.
        
        static void AddValueToExistingKey()
        {
            Console.Write("Enter the existing category: ");
            string category = Console.ReadLine()?.Trim();

            // TryGetValue checks for the key and gives us its list in one step
            if (string.IsNullOrEmpty(category) || !menu.TryGetValue(category, out List<string> dishes))
            {
                Console.WriteLine($"\"{category}\" was not found. Use option 4 to create it.");
                return;
            }

            Console.Write($"Enter the dish to add to {category}: ");
            string dish = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(dish))
            {
                Console.WriteLine("Dish name cannot be blank.");
                return;
            }

            // Append the new dish to the end of this category's list
            dishes.Add(dish);
            Console.WriteLine($"Added \"{dish}\" to {category}. It now has {dishes.Count} dishes.");
        }

        // Case 6: SortKeys
        // Sorts the categories alphabetically and rebuilds the
       
        static void SortKeys()
        {
            if (menu.Count == 0)
            {
                Console.WriteLine("The menu is empty. Choose option 1 to populate it first.");
                return;
            }

            // OrderBy sorts the pairs by key (A to Z).
            // ToDictionary builds a new dictionary in that sorted order.
            menu = menu.OrderBy(pair => pair.Key)
                       .ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("\n--- Categories Sorted A to Z ---");

            // Enumerate only the keys to show the new order
            foreach (string category in menu.Keys)
            {
                Console.WriteLine(category);
            }
        }
    }
}
