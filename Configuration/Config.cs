using System;

namespace TestMonkeys.Configuration
{
    public class Config
    {
        private static Audit auditConfig;
        private static readonly string frameworkConfigFile;

        static Config()
        {
            frameworkConfigFile = Environment.CurrentDirectory + "\\FrameworkConfig.ini";
        }

        public Audit Audit
        {
            get { return auditConfig ?? (auditConfig = new Audit(frameworkConfigFile)); }
        }
    }
}