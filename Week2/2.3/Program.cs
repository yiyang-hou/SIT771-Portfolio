using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {   
        Window gameWindow = new Window("Robot Dodge", 1333, 999);
        Player plr = new Player(gameWindow);
        gameWindow.Clear(Color.White);
        gameWindow.Refresh(60);
        plr.Draw();
        gameWindow.Refresh(60);
        SplashKit.Delay(5000);




    }
}

