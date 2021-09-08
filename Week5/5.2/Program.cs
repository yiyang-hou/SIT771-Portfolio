using System;
using SplashKitSDK;
using System.Collections.Generic;

public class Program
{   
    private static List<double> _values = new List<double>();
    public static int ReadInteger(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valid integer");
            }
        }
    }
    public static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            try
            {
                return double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valid double number");
            }
        }
    }

    public enum UserOption
    {
        NewValue,
        Sum,
        Print,
        Quit
    }
    public static void AddValueToList()
    {
        double addValue = ReadDouble("Enther the number that you want to add to the list: ");
        _values.Add(addValue);
        Console.WriteLine($"{addValue} is added to the list");
    }
    public static void Print()
    {
        Console.WriteLine("The list contains:");
        foreach( double listElement in _values)
        {
            Console.WriteLine(listElement);
        }
    }

    public static void Sum()
    {
        double sum = 0;
        foreach( double listElement in _values)
        {
            sum += listElement;
        }
        Console.WriteLine($"The sum of the list is: {sum}");
    }

    public static UserOption ReadUserOption()
    {
        Console.WriteLine("Enter 0 to add a value");
        Console.WriteLine("Enter 1 to print a sum of all values");
        Console.WriteLine("Enter 2 to print all values");
        Console.WriteLine("Enter 3 to quit");

        int option = 3;
        Int32.TryParse(Console.ReadLine(), out option);

        return (UserOption)option;
    }
    public static void Main()
    {
        UserOption userOption;
        do
        {   
            userOption = ReadUserOption();
            switch(userOption)
            {
                case UserOption.NewValue:
                AddValueToList();
                break;

                case UserOption.Sum:
                Sum();
                break;

                case UserOption.Print:
                Print();
                break;

                case UserOption.Quit:
                Console.WriteLine("Quit!");
                break;
            }
        }
        while( userOption != UserOption.Quit);
    }
}
