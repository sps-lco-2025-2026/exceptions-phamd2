Console.Write("Enter a number: ");
int n = int.Parse(Console.ReadLine()!);
try
{
    Console.WriteLine(100 / n);
}
catch (DivideByZeroException e)
{
    Console.WriteLine("Cannot divide by zero");
}
catch (OverflowException e)
{
    Console.WriteLine("The number was too large: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Something unexpected went wrong: {e.Message}");
}
finally
{
    Console.WriteLine("Division completed");
}