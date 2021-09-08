using System;
using SplashKitSDK;

public class Program
{
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
    public static void Main()
    {
        int numberOfValues = ReadInteger($"Enter how many values you want to store: ");
        double[] values = new double[numberOfValues];
        for (int i = 0; i < numberOfValues; i++)
        {   
            if( i == 0 )
            {
                values[i] = ReadDouble($"Enter the {i + 1}st value: ");
            }
            else if( i == 1)
            {
                values[i] = ReadDouble($"Enter the {i + 1}nd value: ");
            }
            else if( i == 2)
            {
                values[i] = ReadDouble($"Enter the {i + 1}rd value: ");
            }
            else
            {
            values[i] = ReadDouble($"Enter the {i + 1}th value: ");
            }
        }
        for (int i = 0; i < numberOfValues; i++)
        {
            if( i == 0 )
            {
            Console.WriteLine($"The {i+1}st value is: {values[i]}");
            }
            else if( i == 1 )
            {
            Console.WriteLine($"The {i+1}nd value is: {values[i]}");
            }
            else if( i == 2 )
            {
            Console.WriteLine($"The {i+1}rd value is: {values[i]}");
            }
            else
            {
            Console.WriteLine($"The {i+1}th value is: {values[i]}");
            }
        }
        
        double sum = 0;
        for(int i = 0; i < numberOfValues; i++)
        {
            sum+=values[i];
        }
        Console.WriteLine($"The sum is:{sum}");
            
        
    }
}
