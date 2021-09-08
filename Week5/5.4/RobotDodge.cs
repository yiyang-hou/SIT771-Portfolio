using SplashKitSDK;
using System.Collections.Generic;

public class RobotDodge
{
    private Player _Player;
    private Window _GameWindow;
    private List<Robot> _Robots = new List<Robot>();
    public bool Quit
    {
        get
        {
            return _Player.Quit;
        }
    }

    public RobotDodge( Window gameWindow )
    {
        _GameWindow = gameWindow;
        _Player = new Player( gameWindow );
    }

    public void HandleInput()
    {
        _Player.HandleInput();
        _Player.StayOnWindow(_GameWindow);
    }
    
    public void Draw()
    {
        _GameWindow.Clear(Color.White);
        foreach(Robot eachRobot in _Robots)
        {
            eachRobot.Draw();
        }
        _Player.Draw();
        _GameWindow.Refresh(60);
    }

    public void Update()
    {
        foreach(Robot eachRobot in _Robots)
        {
            eachRobot.Update();
        }

        if (SplashKit.Rnd()<0.01)
        {
            Robot newRobot = RandomRobot();
            _Robots.Add(newRobot);           
        }
    
        CheckCollisions();
    }
    public Robot RandomRobot()
    {
        return new Robot(_GameWindow,_Player);
    }

    private void CheckCollisions()
    {
        List<Robot> removeRobots = new List<Robot>();
        foreach(Robot eachRobot in _Robots)
        {
            if (_Player.CollidedWith(eachRobot) || eachRobot.IsOffscreen(_GameWindow))
            {
                removeRobots.Add(eachRobot);
            }
        }
        foreach(Robot eachRemoveRobot in removeRobots)
        {
            _Robots.Remove(eachRemoveRobot);
        }
    }
}