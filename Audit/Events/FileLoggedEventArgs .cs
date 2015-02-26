using System.IO;

namespace TestMonkeys.Auditing.Events
{
    public class FileLoggedEventArgs : MessageLoggedEventArgs
    {
        public FileInfo File { get; internal set; }
    }
}