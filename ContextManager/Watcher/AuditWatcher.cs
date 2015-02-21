using System;
using TestMonkeys.Auditing;
using TestMonkeys.Auditing.Events;

namespace TestMonkeys.ContextManager.Watcher
{
    public abstract class AuditWatcher
    {
        protected AuditWatcher()
        {
            Audit.MessageLogged += OnMessageLogged;
            Audit.ImageLogged +=OnImageLogged;
        }

        protected abstract void OnImageLogged(object sender, ImageLoggedEventArgs imageLoggedEventArgs);

        protected abstract void OnMessageLogged(object sender, MessageLoggedEventArgs e);
    }
}