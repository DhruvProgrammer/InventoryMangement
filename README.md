<!DOCTYPE html>
<html>
<head>
  <meta charset="UTF-8">
  <title>Inventory Management System - C#</title>
</head>
<body>
  <h1>📦 Inventory Management System (C#)</h1>

  <p>This is a simple console-based Inventory Management System built in <strong>C#</strong>. It allows users to <strong>add</strong>, <strong>view</strong>, <strong>update</strong>, and <strong>delete</strong> inventory items. The data is stored in a local text file to provide persistence between runs.</p>

  <h2>🛠️ Features</h2>
  <ul>
    <li>Add new inventory items with unique ID</li>
    <li>View all existing items</li>
    <li>Update item name and quantity</li>
    <li>Delete items by ID</li>
    <li>Save and load data from a file (persistence)</li>
    <li>Exception handling to prevent crashes from invalid input</li>
  </ul>

  <h2>📁 Project Structure</h2>
  <ul>
    <li><code>Program</code>: Entry point, handles menu and user interaction</li>
    <li><code>InventoryItem</code>: Model class representing an item (ID, Name, Quantity)</li>
    <li><code>InventoryManager</code>: Contains logic for add/view/update/delete operations and file I/O</li>
    <li><code>inventory.txt</code>: File where item data is stored</li>
  </ul>

  <h2>🧠 Core Logic</h2>
  <ul>
    <li><code>AddItem()</code>: Gets input from the user and adds an item after checking for duplicate ID</li>
    <li><code>ViewItems()</code>: Lists all items in a readable format</li>
    <li><code>UpdateItem()</code>: Finds item by ID and updates its name and quantity</li>
    <li><code>DeleteItem()</code>: Deletes item from list based on ID</li>
    <li><code>LoadFromFile()</code>: Loads items from the text file into memory at startup</li>
    <li><code>SaveToFile()</code>: Saves all items back into the text file before exiting</li>
  </ul>

  <h2>🚀 How to Run</h2>
  <ol>
    <li>Clone or download the repository</li>
    <li>Open the project in Visual Studio or any C# compatible IDE</li>
    <li>Build and run the project</li>
    <li>Follow the on-screen instructions to manage inventory</li>
  </ol>

  <h2>📝 Sample Menu</h2>
  <pre>
--- Inventory Management System ---
1. Add Item
2. View All Items
3. Update Item
4. Delete Item
5. Exit
Select an option:
  </pre>

  <h2>💾 File Format</h2>
  <p>Each item in <code>inventory.txt</code> is saved as:</p>
  <pre>
ID,Name,Quantity
Example: 101,Mouse,25
  </pre>

  <h2>📌 Summary</h2>
  <ol>
    <li>On startup, data is loaded from <code>inventory.txt</code></li>
    <li>User is shown a menu for actions</li>
    <li>Each operation updates the in-memory list</li>
    <li>On exit, data is saved back to the file</li>
    <li>All input is handled with exception safety</li>
  </ol>

  <h2>📃 License</h2>
  <p>This project is for educational/demo purposes. You may modify and use it as needed.</p>
</body>
</html>
