// exercise 3

Console.WriteLine("Enter a number:");


try
{
    int n = int.Parse(Console.ReadLine());
    bool check = n%2 == 0;
    if (check == true)
        Console.WriteLine("Even");
    else
        Console.WriteLine("Odd");
}
catch (FormatException e)
{
    Console.WriteLine("Enter a whole number");
}
catch(OverflowException e)
{
    Console.WriteLine("Your number is too big");
}
finally
{
    Console.WriteLine("Thank you for using the program");
}