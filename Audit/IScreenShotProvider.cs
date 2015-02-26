using System.Drawing;

namespace TestMonkeys.Auditing
{
    public interface IScreenShotProvider
    {
        Bitmap GetScreenShot();
    }
}