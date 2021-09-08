using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {   
        Window gameWindow = new Window("Robot Dodge", 888, 666);
        RobotDodge game = new RobotDodge(gameWindow);

        while( !(game.Quit || SplashKit.WindowCloseRequested(gameWindow)))
        {     
            game.HandleInput();
            game.Update();
            game.Draw();
        }

        gameWindow.Close();
        gameWindow = null;

    }
}

