using TestMonkeys.ContextManager.Watcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMonkeys.ContextManager
{
    public static class LogWatcher
    {
        private static TestContextLogHandler testContextLogHandler;

        public static void SetContext(TestContext testContext)
        {
            if (testContextLogHandler == null)
            {
                testContextLogHandler = new TestContextLogHandler();
            }
            testContextLogHandler.TestContextInstance = testContext;
        }
    }
}