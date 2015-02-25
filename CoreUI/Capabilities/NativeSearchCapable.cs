using OpenQA.Selenium;

namespace TestMonkeys.CoreUI.Capabilities
{
    public abstract class NativeSearchCapable
    {
        internal abstract IWebElement NativeFindBy(By by);
    }
}