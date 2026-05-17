// program below...

Dictionary<string, int> inventory = new Dictionary<string, int>{};

void TakeFromInventory(string item, int quantity)
{
    string itemUpper = item.ToUpper();
    if (!inventory.ContainsKey(itemUpper)) //looked on stack overflow for the difference between .contains and .containskey, .containskey is a lot faster compared to .contains.
        throw new ItemNotFoundException(item);

    if (inventory[itemUpper] < quantity)
        throw new InsufficientQuantityException(item, quantity, inventory[itemUpper]);

    inventory[itemUpper] -= quantity;
}

void AddToInventory(string item, int quantity)
{
    string itemUpper = item.ToUpper();
    if (quantity < 0)
        throw new InventoryException("QUANTITY CANNOT BE NEGATIVE");

    if (inventory.ContainsKey(itemUpper))
        inventory[itemUpper] += quantity;
    else
        throw new InventoryException($"CANNOT ADD {itemUpper} TO INVENTORY. ITEM NOT FOUND");
}

void DisplayInventory()
{
    Console.WriteLine("\n=============================");
    Console.WriteLine("      CURRENT INVENTORY      "); // used gemini for all the menu formatting
    Console.WriteLine("=============================");
    foreach (var item in inventory)
    {
        Console.WriteLine($"{item.Key}: {item.Value}");
    }
    Console.WriteLine("=============================");
}

void PlayGame()
{
    inventory = new Dictionary<string, int>
    {
        { "SWORD", 1 },
        { "SHIELD", 1 },
        { "POTION", 10 },
        { "ARMOUR", 2 },
        { "BOW", 1 },
        { "ARROW", 20 }
    };

    Console.WriteLine("\n┌───────────────────────────┐");
        Console.WriteLine("│      INVENTORY SYSTEM     │");
        Console.WriteLine("├───────────────────────────┤");
        Console.WriteLine("│ [TAKE]    Take an item    │");
        Console.WriteLine("│ [ADD]     Add to an item  │");
        Console.WriteLine("│ [DISPLAY] Show inventory  │");
        Console.WriteLine("│ [EXIT]    Close game      │");
        Console.WriteLine("└───────────────────────────┘");
        Console.Write("CHOOSE AN ACTION: ");
    string input = Console.ReadLine().Trim().ToLower();
    while(input != "exit")
    {
        try
        {
            if (input == "take")
            {
                Console.Write("ITEM: ");
                string item = Console.ReadLine();
                Console.Write("QUANTITY: ");
                int quantity = int.Parse(Console.ReadLine());
                TakeFromInventory(item, quantity);
            }
            else if (input == "add")
            {
                Console.Write("ITEM: ");
                string item = Console.ReadLine();
                Console.Write("QUANTITY: ");
                int quantity = int.Parse(Console.ReadLine());
                AddToInventory(item, quantity);
            }
            else if (input == "display")
            {
                DisplayInventory();
            }
            else
            {
                Console.WriteLine("INVALID ACTION");
            }
        }
        catch (InventoryException e)
        {
            Console.WriteLine($"INVENTORY ERROR {e.Message}");
        }
        catch (FormatException e)
        {
            Console.WriteLine("INVALID QUANTITY");
        }

        input = Console.ReadLine();
    }
    Console.WriteLine("EXITING INVENTORY");
}

PlayGame();


class InventoryException : Exception
{
    // your constructors here
    public InventoryException() : base("Inventory error occurred"){}
    public InventoryException(string message) : base(message){}
}

class ItemNotFoundException : InventoryException
{
    public string ItemName { get; }
    public ItemNotFoundException(string ItemName) : base($"{ItemName} NOT FOUND IN INVENTORY")
    {
        ItemName = ItemName;
    }
}

class InsufficientQuantityException : InventoryException
{
    public string ItemName { get; }
    public int RequestedQuantity { get; }
    public int AvailableQuantity { get; }

    public InsufficientQuantityException(string ItemName, int RequestedQuantity, int AvailableQuantity) 
        : base($"NOT ENOUGH {ItemName} IN INVENTORY. REQUESTED: {RequestedQuantity}, AVAILABLE: {AvailableQuantity}")
    {
        ItemName = ItemName;
        RequestedQuantity = RequestedQuantity;
        AvailableQuantity = AvailableQuantity;
    }
}

