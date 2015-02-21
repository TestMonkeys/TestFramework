namespace TestMonkeys.Configuration
{
    public class Audit : ConfigModel
    {
        public Audit(string configFile) : base(configFile)
        {
        }

        protected override string SectionName
        {
            get { return "Audit"; }
        }

        public int LogLevel
        {
            get { return int.Parse(ReadValue("LogLevel")); }
        }
    }
}