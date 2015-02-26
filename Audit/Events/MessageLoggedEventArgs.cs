using System;

namespace TestMonkeys.Auditing.Events
{
    public class MessageLoggedEventArgs : EventArgs
    {
        public object Sender { get; internal set; }
        public string Message { get; internal set; }
        public Level Level { get; internal set; }
    }
}