using System;
using SplashKitSDK;

public enum MenuOption
{
    TestName, GuessThatNumber, Quit
}
public class Program
{
    public static void Main()
    {
        MenuOption userSelection;

        do{
            userSelection = ReadUserOption();
            
            switch(userSelection)
            {
                case MenuOption.TestName:
                    TestName();
                    break;

                case MenuOption.GuessThatNumber:
                    RunGuessThatNumber();
                    break;

                case MenuOption.Quit:
                    Console.WriteLine("QUIT!");
                    break;
            }
        } while (userSelection != MenuOption.Quit);
    }
    private static MenuOption ReadUserOption()  //User input
    {
        int option = 0;
        string userInput;


        Console.WriteLine("**--Menu--**");
        Console.WriteLine("--1 will run Test Name--");
        Console.WriteLine("--2 will play Guess That Number--");
        Console.WriteLine("--3 will Quit--");

        do
        {
            Console.Write("What is you choice? Give it here:");
            userInput = Console.ReadLine();
            try
            {
                option = Convert.ToInt32(userInput); 
            
                if(option < 1 || option > 3)
                {
                    Console.WriteLine("Invalid number! Try again:");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Because " + userInput + " is not a number! Try again:");
                option = -1;
            } 
        }
        while( option < 1 || option > 3 );

        return (MenuOption)(option - 1);
        
    }

    public static void TestName()  //Name testing
    {
        string userName;
        Console.WriteLine("Please enter you name:");
        userName = Console.ReadLine();
        Console.WriteLine($"Hello {userName}!");
        if( userName.ToLower() == "yiyang")
        {
            Console.WriteLine("Welcome, my master!");
        }
        else if( userName.ToLower() == "freddy")
        {
            Console.WriteLine("Welcome, Yiyang's friend No.1!");
        }
        else if( userName.ToLower() == "doris")
        {
            Console.WriteLine("Welcome, Yiyang's friend No.2!");
        }
        else
        {
            Console.WriteLine("You are not a friend of Yiyang!");
        }
    
    }

    public static void RunGuessThatNumber()
    {
        int guess = 0, target, lowGuess = 1, highGuess = 100;
        
        target = new Random().Next(100) + 1;

        Console.WriteLine($"Guess a number between 1 and 100.");
        //Console.WriteLine($"(Whisper: It is {target})");
        while( guess != target )
        {
            guess = ReadGuess(lowGuess, highGuess);

            if( guess < target)
            {
                Console.WriteLine("Your guess is too low, Try again:");    
                lowGuess = guess;    
            }
            else if( guess > target)
            {
                Console.WriteLine("Your guess is too high, Try again:");   
                highGuess = guess;
            }
            else
            {
                Console.WriteLine("Bingo!");
            }
        }

    }

    private static int ReadGuess(int min, int max)
    {
        int userGuess = 0;
        string userInput;
        
        
        Console.WriteLine($"Enter your guess between {min} and {max}");
        do
        {
            userInput = Console.ReadLine();

            try
            {
                userGuess = Convert.ToInt32(userInput);
                if(userGuess < min || userGuess > max)
                {
                    Console.WriteLine("Input out of range! Try again:");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Because " + userInput + " is not a number! Try again:");
                userGuess = -1;
            }
        }
        while( userGuess < min || userGuess > max );

        return userGuess;
    }
        
}
