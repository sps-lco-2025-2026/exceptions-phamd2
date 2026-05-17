string[] names = { "Alice", "Bob", "Charlie" };
Console.Write("Enter an index: ");
int i = int.Parse(Console.ReadLine()!);

try
{
    Console.WriteLine(names[i]);
}
catch (IndexOutOfRangeException e)
{
    Console.WriteLine("Index out of range");
}
catch (FormatException e)
{
    Console.WriteLine("Not valid integer");
}




