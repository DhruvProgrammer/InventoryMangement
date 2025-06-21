using System;
using System.Collections.Generic;
using System.IO;

namespace inven
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            InventoryManager manager = new InventoryManager("inventory.txt");
            manager.LoadFromFile();

            while (true)
            {
                Console.WriteLine("\n--- Inventory Management System ---");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. View All Items");
                Console.WriteLine("3. Update Item");
                Console.WriteLine("4. Delete Item");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            manager.AddItem();
                            break;
                        case 2:
                            manager.ViewItems();
                            break;
                        case 3:
                            manager.UpdateItem();
                            break;
                        case 4:
                            manager.DeleteItem();
                            break;
                        case 5:
                            manager.SaveToFile();
                            return;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }

    class InventoryItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public InventoryItem(int id, string name, int quantity)
        {
            ID = id;
            Name = name;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{ID},{Name},{Quantity}";
        }

        public static InventoryItem FromString(string data)
        {
            string[] parts = data.Split(',');
            return new InventoryItem(int.Parse(parts[0]), parts[1], int.Parse(parts[2]));
        }
    }

    class InventoryManager
    {
        private List<InventoryItem> items = new List<InventoryItem>();
        private string filePath;

        public InventoryManager(string filePath)
        {
            this.filePath = filePath;
        }

        public void AddItem()
        {
            try
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                if (items.Exists(x => x.ID == id))
                {
                    Console.WriteLine("Item with this ID already exists.");
                    return;
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                items.Add(new InventoryItem(id, name, quantity));
                Console.WriteLine("Item added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding item: {ex.Message}");
            }
        }

        public void ViewItems()
        {
            Console.WriteLine("\n--- Inventory Items ---");
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Quantity: {item.Quantity}");
            }
            if (items.Count == 0)
                Console.WriteLine("No items in inventory.");
        }

        public void UpdateItem()
        {
            try
            {
                Console.Write("Enter ID to update: ");
                int id = int.Parse(Console.ReadLine());

                var item = items.Find(x => x.ID == id);
                if (item == null)
                {
                    Console.WriteLine("Item not found.");
                    return;
                }

                Console.Write("Enter new name: ");
                item.Name = Console.ReadLine();

                Console.Write("Enter new quantity: ");
                item.Quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Item updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating item: {ex.Message}");
            }
        }

        public void DeleteItem()
        {
            try
            {
                Console.Write("Enter ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                var item = items.Find(x => x.ID == id);
                if (item == null)
                {
                    Console.WriteLine("Item not found.");
                    return;
                }

                items.Remove(item);
                Console.WriteLine("Item deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting item: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(filePath))
                    return;

                string[] lines = File.ReadAllLines(filePath);
                items.Clear();
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        items.Add(InventoryItem.FromString(line));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading inventory: {ex.Message}");
            }
        }

        public void SaveToFile()
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (var item in items)
                {
                    lines.Add(item.ToString());
                }

                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving inventory: {ex.Message}");
            }
        }
    }
}
// //INTRO
// “This is a console-based Inventory Management System built in C#.
//  It allows a user to add, view, update, and delete items,
//  and it also saves this data to a file so it's persistent between runs.”

//ARCITCURE

// Program class – the main entry point which shows the menu and handles user input.

// InventoryItem class – represents each item in the inventory.

// InventoryManager class – handles the business logic like adding, viewing, updating, deleting items and saving or loading from file.”

//LOGIC

// AddItem(): Takes input from user, checks for duplicate ID, and adds item.

// ViewItems(): Displays all items in a readable format.

// UpdateItem(): Finds item by ID and updates its name and quantity.

// DeleteItem(): Finds item by ID and removes it.

// LoadFromFile(): Reads the text file and loads inventory into the list.

// SaveToFile(): Writes all items from the list to the text file.

// //SUMMARY
// 1.When the program starts, it loads items from a file.

// 2.Shows a menu to the user (Add, View, Update, Delete, Exit).

// 3.Based on what user selects, it performs the action.

// 4.When the user exits, it saves all the data back to the file.

// 5.It uses exception handling to avoid crashing due to user input mistakes.