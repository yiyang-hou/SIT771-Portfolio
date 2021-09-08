using SplashKitSDK;


public class Player
{
    private Bitmap _PlayerBitmap;

    public double X {get;set;}
    public double Y {get;set;}

    public bool Quit {get; private set;}
    

    public int Width
    {
        get
        {
            return _PlayerBitmap.Width;
        }
    }

     public int Height
    {
        get
        {
            return _PlayerBitmap.Height;
        }
    }
    
    public Player(Window windowObject)
    {
        _PlayerBitmap = new Bitmap("Player", "Player.png");
        Quit = false;
        
        X = (windowObject.Width - Width) / 2;
        Y = (windowObject.Height - Height) / 2;
    }

    public void Draw()
    {
        _PlayerBitmap.Draw(X, Y);
    }

    public void HandleInput()
    {
        int speed = 5;

        SplashKit.ProcessEvents();

        if(SplashKit.KeyReleased(KeyCode.EscapeKey)) Quit = true;

        if(SplashKit.KeyDown(KeyCode.LeftShiftKey) || SplashKit.KeyDown(KeyCode.RightShiftKey))
        {
            speed = 15;
        }

        if(SplashKit.KeyDown(KeyCode.WKey) || SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= speed;
        }

        if(SplashKit.KeyDown(KeyCode.SKey) || SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += speed;
        }

        if(SplashKit.KeyDown(KeyCode.AKey) || SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X -= speed;
        }

        if(SplashKit.KeyDown(KeyCode.DKey) || SplashKit.KeyDown(KeyCode.RightKey))
        {
            X += speed;
        }

    }

    public void StayOnWindow(Window limit)
    {
        const int GAP = 10;
        if( X < GAP)
        {
            X = GAP;
        }
        if( X + Width > limit.Width - GAP)
        {
            X = limit.Width - GAP - Width;
        }

        if( Y < GAP)
        {
            Y = GAP;
        }

        if( Y + Height > limit.Height - GAP)
        {
            Y = limit.Height - GAP - Height;
        }
    }

    public bool CollidedWith(Robot other)
    {
        return _PlayerBitmap.CircleCollision(X,Y, other.CollisionCircle);
    }
    
}