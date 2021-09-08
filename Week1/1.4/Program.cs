using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window myScene = new Window("Dragon Ball", 500, 360);
        myScene.Clear(Color.White);
        myScene.Refresh(60);

        Bitmap fight = new Bitmap("fight", "fight.jpg");

        myScene.DrawBitmap(fight, 0, 0);
        myScene.Refresh(60);
        SoundEffect fightSound = new SoundEffect("fight5s","fight5s.mp3");
        fightSound.Play();
        SplashKit.Delay(5000);
        

        myScene.Clear(Color.White);
        myScene.Refresh(60);
        Bitmap fight2 = new Bitmap("fight2", "fight2.jpg");
        myScene.Resize(500, 281);
        myScene.DrawBitmap(fight2, 0, 0);
        myScene.Refresh(60);
        SoundEffect fightSound2 = new SoundEffect("fight3s","fight3s.mp3");
        fightSound2.Play();
        SplashKit.Delay(5000);

        myScene.Clear(Color.White);
        myScene.Refresh(60);
        Bitmap superSaiyan = new Bitmap("SuperSaiyan", "Su.jpg");
        myScene.MoveTo(950,300);
        myScene.Resize(640,940);
        myScene.DrawBitmap(superSaiyan, 0, 0);
        myScene.Refresh(60);
        SoundEffect superSaiyanSound = new SoundEffect("supersaiyan","supersaiyan.mp3");
        superSaiyanSound.Play();
        SplashKit.Delay(5000);

        myScene.Clear(Color.White);
        myScene.Refresh(60);
        Bitmap ha = new Bitmap("Ha", "Ha.jpg");
        myScene.MoveTo(950,300);
        myScene.Resize(500,635);
        myScene.DrawBitmap(ha, 0, 0);
        myScene.Refresh(60);
        SoundEffect haSound = new SoundEffect("ha","ha.mp3");
        haSound.Play();
        SplashKit.Delay(5000);

        

    }
}
