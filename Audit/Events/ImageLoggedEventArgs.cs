using System.Drawing;

namespace TestMonkeys.Auditing.Events
{
    public class ImageLoggedEventArgs:MessageLoggedEventArgs
    {
        public Bitmap Image { get; internal set; }
    }
}