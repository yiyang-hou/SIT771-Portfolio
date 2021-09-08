using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    { // Variables declaration
        string name, inputText;
        int heightInCM;
        double weightInKG ,heightInMeters, bmi;
        
        //Read in the user's name
        Console.Write("Enter your name: ");
        name = Console.ReadLine();

        Console.WriteLine($"Hello {name}");
        
        //Read their height and weight
        Console.Write("Enter your height in CM: ");
        inputText = Console.ReadLine();
        heightInCM = Convert.ToInt32(inputText); 
        heightInMeters = heightInCM/100.0;
        Console.Write("Enter you weight in KG: ");
        inputText = Console.ReadLine();
        weightInKG = Convert.ToDouble(inputText);

        Console.WriteLine($"Your height is {heightInMeters}m");
        Console.WriteLine($"Your weight is: {weightInKG}kg");

        // Calculate the BMI
        bmi = weightInKG / Math.Pow(heightInMeters,2);  //BMI = kg/m^2
        Console.Write($"Your BMI is {bmi}");

    }
}
