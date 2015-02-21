using System.Runtime.InteropServices;
using System.Text;

namespace TestMonkeys.Configuration
{
    public abstract class ConfigModel
    {
        private readonly string configFile;

        protected ConfigModel(string configFile)
        {
            this.configFile = configFile;
        }

        protected abstract string SectionName { get; }

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string applicationName, string keyName, string defaultValue,
                                                          StringBuilder returnString, int nSize, string fileName);

        private static string ReadValue(string sectionName, string keyName, string fileName)
        {
            var sb = new StringBuilder(255);
            GetPrivateProfileString(sectionName, keyName, "", sb, 255, fileName);
            return sb.ToString().Trim();
        }

        protected string ReadValue(string key)
        {
            return ReadValue(SectionName, key, configFile);
        }
    }
}