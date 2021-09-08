using System;
using SplashKitSDK;

public class Program
{
    public static void Main(string[] args)
    {
        // House drawing.
        
        Window shapesWindow = new Window("Shapes by Yiyang", 800, 600);                

        shapesWindow.Clear(Color.White);
        shapesWindow.FillEllipse(Color.BrightGreen, 0, 400, 800, 400);      
        shapesWindow.FillRectangle(Color.Gray, 300, 300, 200, 200);           
        shapesWindow.FillTriangle(Color.Red, 250, 300, 400, 150, 550, 300);
        shapesWindow.MoveTo(500,300);
        shapesWindow.Refresh();

        // My own shapes. 

        Window myWindow = new Window("Yiyang's attampt to draw a guitar", 1000, 1000);

        myWindow.Clear(Color.Gray);
        myWindow.FillEllipse(Color.BurlyWood, 300, 600, 400, 300);                          // Lower part of the body.
        myWindow.FillEllipse(Color.BurlyWood, 375, 500, 250, 150);                          // Higher part of the body.
        myWindow.FillCircle(Color.Black, 500, 725, 50);                                     // Sound Hole.
        myWindow.FillRectangle(Color.Black, 480, 155, 40, 350);                             // FretBoard.
        myWindow.FillRectangle(Color.BurlyWood, 465, 100, 70, 100);                         // Head stock.
        // Left side tuning pegs.
        myWindow.FillCircle(Color.Silver, 455, 120, 10);                    
        myWindow.FillCircle(Color.Silver, 455, 153, 10); 
        myWindow.FillCircle(Color.Silver, 455, 186, 10); 
        // Right side tuning pegs.
        myWindow.FillCircle(Color.Silver, 545, 120, 10);                    
        myWindow.FillCircle(Color.Silver, 545, 153, 10); 
        myWindow.FillCircle(Color.Silver, 545, 186, 10); 
        myWindow.MoveTo(1300,300);

        myWindow.Refresh();

        SplashKit.Delay(10000);
    }
}
