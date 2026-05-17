// Snippet A
using System.Linq.Expressions;
try
{
    int[] arr = new int[3];
    arr[10] = 5;
}
catch(IndexOutOfRangeException e)
{
    Console.WriteLine("Index out of range");
}



// Snippet B
string s = null!;
try
{
Console.WriteLine(s.Length);
}
catch (NullReferenceException e)
{
    Console.WriteLine("Null reference");
}

// Snippet C
int x = int.MaxValue;
try
{
checked { x = x + 1; }   // checked enforces overflow detection
}
catch (OverflowException e)
{
    Console.WriteLine("Overflow error");
}
