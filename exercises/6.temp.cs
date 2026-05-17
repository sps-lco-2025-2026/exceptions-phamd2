// program below...
using System.Linq.Expressions;

const double AbsoluteZero = -273.15;


Console.WriteLine("Enter a celsius");
double celsius = double.Parse(Console.ReadLine());

try
{
    if (celsius < AbsoluteZero)
        throw new TemperatureException(celsius);

    return celsius * 9 / 5 + 32;
}
catch (TemperatureException e)
{
    Console.WriteLine($"Temperature error: {e.Message}");
 
}
catch (FormatException e)
{
    Console.WriteLine("Not a valid number");
}




class TemperatureException : Exception
{
    // your constructors here
    private double _temp;

    public double AttemptedTemp => _temp;

    public TemperatureException() : base("Temperature cannot be below 0");

    public TemperatureException(double AttemptedTemp, string message) : base(message)
    {
        _temp = AttemptedTemp;
    }

    public TemperatureException(double AttemptedTemp) : base($"{AttemptedTemp} cannot be below {AbsoluteZero}")
    {
        _temp = AttemptedTemp;
    }
}

