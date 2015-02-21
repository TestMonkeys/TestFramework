using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMonkeys.Auditing;
using TestMonkeys.Auditing.Events;

namespace TestMonkeys.ContextManager.Watcher
{
    internal class TestContextLogHandler : AuditWatcher
    {

        private int imageCount;
        internal TestContext TestContextInstance { get; set; }



        protected override void OnMessageLogged(object sender, MessageLoggedEventArgs e)
        {
            WriteLogMessage(e.Level,e.Sender,e.Message);
        }

        protected override void OnImageLogged(object sender, ImageLoggedEventArgs e)
        {
            if (!Directory.Exists(TestContextInstance.TestResultsDirectory))
                Directory.CreateDirectory(TestContextInstance.TestResultsDirectory);
            imageCount++;
            var fileName = string.Format("{0}\\{1}_{2}_{3}.png",
                                         TestContextInstance.TestResultsDirectory,e.Level, e.Message, imageCount);
            e.Image.Save(fileName);
            TestContextInstance.AddResultFile(fileName);
            WriteLogMessage(e.Level,e.Sender,"Attaching Image: "+e.Message+imageCount);
        }

        private void WriteLogMessage(Level level, object sender, string message)
        {
            string time = DateTime.Now.ToString("HH-mm-ss.fff");
            if (sender != null)
                Console.WriteLine("{0} : {1} : {2} : {3}", time, level, sender, message);
            else
                Console.WriteLine("{0} : {1} : {2}", time, level, message);
        }
    }
}