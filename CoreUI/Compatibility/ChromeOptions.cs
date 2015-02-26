using System.Collections.Generic;
using OpenQA.Selenium;

namespace TestMonkeys.CoreUI.Compatibility
{
    public class ChromeOptions
    {
        public ChromeOptions()
        {
            Options = new OpenQA.Selenium.Chrome.ChromeOptions();
        }

        internal OpenQA.Selenium.Chrome.ChromeOptions Options { get; set; }

        public IReadOnlyCollection<string> Arguments
        {
            get { return Options.Arguments; }
        }

        public string BinaryLocation
        {
            get { return Options.BinaryLocation; }
            set { Options.BinaryLocation = value; }
        }

        public string DebuggerAddress
        {
            get { return Options.DebuggerAddress; }
            set { Options.DebuggerAddress = value; }
        }

        public IReadOnlyCollection<string> Extensions
        {
            get { return Options.Extensions; }
        }

        public bool LeaveBrowserRunning
        {
            get { return Options.LeaveBrowserRunning; }
            set { Options.LeaveBrowserRunning = value; }
        }

        public string MinidumpPath
        {
            get { return Options.MinidumpPath; }
            set { Options.MinidumpPath = value; }
        }

        public Proxy Proxy
        {
            get { return new Proxy(Options.Proxy); }
            set { Options.Proxy = value.SeleniumProxy; }
        }

        public void AddAdditionalCapability(string capabilityName, object capabilityValue, bool isGlobalCapability)
        {
            Options.AddAdditionalCapability(capabilityName, capabilityValue, isGlobalCapability);
        }

        public void AddAdditionalCapability(string capabilityName, object capabilityValue)
        {
            Options.AddAdditionalCapability(capabilityName, capabilityValue);
        }

        public void AddArgument(string argument)
        {
            Options.AddArgument(argument);
        }

        public void AddArguments(IEnumerable<string> arguments)
        {
            Options.AddArguments(arguments);
        }

        public void AddArguments(params string[] arguments)
        {
            Options.AddArguments(arguments);
        }

        public void AddEncodedExtension(string extension)
        {
            Options.AddEncodedExtension(extension);
        }

        public void AddEncodedExtensions(IEnumerable<string> extensions)
        {
            Options.AddEncodedExtensions(extensions);
        }

        public void AddEncodedExtensions(params string[] extensions)
        {
            Options.AddEncodedExtensions(extensions);
        }

        public void AddExcludedArgument(string argument)
        {
            Options.AddExcludedArgument(argument);
        }

        public void AddExcludedArguments(IEnumerable<string> arguments)
        {
            Options.AddExcludedArguments(arguments);
        }

        public void AddExcludedArguments(params string[] arguments)
        {
            Options.AddExcludedArguments(arguments);
        }

        public void AddExtension(string extension)
        {
            Options.AddExtension(extension);
        }

        public void AddExtensions(IEnumerable<string> extensions)
        {
            Options.AddExtensions(extensions);
        }

        public void AddExtensions(params string[] extensions)
        {
            Options.AddExtensions(extensions);
        }

        public void AddLocalStatePreference(string preferenceName, object preferenceValue)
        {
            Options.AddLocalStatePreference(preferenceName, preferenceValue);
        }

        public void AddUserProfilePreference(string preferenceName, object preferenceValue)
        {
            Options.AddUserProfilePreference(preferenceName, preferenceValue);
        }

        internal ICapabilities ToCapabilities()
        {
            return Options.ToCapabilities();
        }
    }
}