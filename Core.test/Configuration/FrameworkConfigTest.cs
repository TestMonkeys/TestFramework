using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMonkeys.Configuration;

namespace TestMonkeys.Core.test.Configuration
{
    [TestClass]
    public class FrameworkConfigTest
    {
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void Config_Framework_ReadValue()
        {
            var auditConfig = new Audit(Environment.CurrentDirectory + "\\FrameworkConfig.ini");
            int value = auditConfig.LogLevel;
            Assert.AreEqual(1, value, "Config log level");
        }
    }
}