using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {   
        Window gameWindow = new Window("Robot Dodge", 888, 666);
        Player plr = new Player(gameWindow);

        while( !(plr.Quit || SplashKit.WindowCloseRequested(gameWindow)))
        {     
            plr.HandleInput();
            plr.StayOnWindow(gameWindow);
            gameWindow.Clear(Color.White);
            plr.Draw();
            gameWindow.Refresh(60);
        }

        gameWindow.Close();
        gameWindow = null;

    }
}

