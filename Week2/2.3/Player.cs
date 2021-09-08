using SplashKitSDK;


public class Player
{
    private Bitmap _PlayerBitmap;

    double X {get;set;}
    double Y {get;set;}

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
        
        X = (windowObject.Width - Width) / 2;
        Y = (windowObject.Height - Height) / 2;
        
       
    }

    public void Draw()
    {
        SplashKit.DrawBitmap(_PlayerBitmap, X, Y);
    }
    
}