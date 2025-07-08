class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        // Part One: Fix the NullReferenceException
        // This will throw a NullReferenceException
        manager.AddItem("Apple");
        manager.AddItem("Banana");

        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method
        manager.RemoveItem("Apple");



        // Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
        // TODO: Implement this part three.
        ItemManager<Fruit> fManager = new ItemManager<Fruit>();
        fManager.AddItem(new Fruit("Durian"));
        fManager.AddItem(new Fruit("Rambutan"));
        fManager.AddItem(new Fruit("Dates"));
        fManager.PrintAllItems();

        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
    }
}

public class ItemManager : IItemManager
{
    private List<string> items;

    //Added constructor to initialize the items list
    public ItemManager()
    {
        items = new List<string>();
    }

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Part Two: Implement the RemoveItem method
    // Succesfully implement remove method
    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"{item} removed successfully.");
        }
        else
        {
            Console.WriteLine($"{item} Item not found.");
        }
    }

    public void ClearAllItems()
    {
        items = new List<string>();
    }
}

public class ItemManager<T>
{
    private List<T> items;

    // Added constructor to initialize the items list
    // This allows ItemManager to be used with any type T
    public ItemManager()
    {
        items = new List<T>();
    }
    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearAllItems()
    {
        items = new List<T>();
    }
}

// Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
public class Fruit
{
    public string Name { get; set; }

    public Fruit(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}


// Part four: Implement an interface IItemManager and make ItemManager implement it.
// This interface defines the methods that ItemManager should implement.
public interface IItemManager
{
    void AddItem(string item);
    void RemoveItem(string item);
    void PrintAllItems();
    void ClearAllItems();
}
