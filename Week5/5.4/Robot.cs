using SplashKitSDK;

public class Robot
{
    public double X { get; set; }
    public double Y { get; set; }
    private Vector2D Velocity { get; set; }
    public Color MainColor { get; set; }
    public int Width
    {
        get{ return 50; }
    }
    public int Height
    {
        get{ return 50; }
    }
    public Circle CollisionCircle
    {
        get{ return SplashKit.CircleAt( X + 25, Y + 25, 35.36); }
    }

    public Robot( Window gameWindow, Player player )
    {    
        MainColor = Color.RandomRGB(200);
        if (SplashKit.Rnd() < 0.5 )
        {
            X = SplashKit.Rnd(gameWindow.Width);

            if (SplashKit.Rnd() < 0.5) Y = -Height;
            else Y = gameWindow.Height;
        }
        else
        {
            Y = SplashKit.Rnd(gameWindow.Height);
            
            if (SplashKit.Rnd() < 0.5 ) X = -Width;
            else X = gameWindow.Width;
        }

        const int SPEED = 4;

        Point2D fromPt = new Point2D()
        {
            X = X, Y = Y
        };

        Point2D toPt = new Point2D()
        {
            X= player.X, Y = player.Y
        };

        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint( fromPt, toPt ));
        
        Velocity = SplashKit.VectorMultiply( dir, SPEED );
           
    }
    public void Draw()
    {
        double leftX, rightX;
        double eyeY, mouthY;

        leftX = X + 12;
        rightX = X + 27;
        eyeY = Y + 10;
        mouthY = Y + 30;
        SplashKit.FillRectangle( Color.Gray, X, Y, Width, Height);
        SplashKit.FillRectangle( MainColor, leftX, eyeY, 10, 10);
        SplashKit.FillRectangle( MainColor, rightX, eyeY, 10, 10);
        SplashKit.FillRectangle( MainColor, leftX, mouthY, 25, 10);
        SplashKit.FillRectangle( MainColor, leftX + 2, mouthY + 2, 21, 6);
    }

    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }

    public bool IsOffscreen( Window screen )
    {
        while( X < -Width || X > screen.Width || Y < -Height || Y > screen.Height )
        {
            return true;
        }
        return false;

    }
}