using System.Collections.Generic;
using TestMonkeys.CoreUI.Html;
using TestMonkeys.CoreUI.Search;

namespace TestMonkeys.CoreUI.Capabilities
{
    public interface ICanFindElements
    {
        T FindElement<T>(By by) where T : HtmlControl, new();

        HtmlControl FindElementByXpath(string xpath);

        T FindElementByXpath<T>(string xpath) where T : HtmlControl, new();

        List<T> FindElements<T>(By by) where T : HtmlControl, new();

        List<HtmlControl> FindElementsByXpath(string xpath);

        List<T> FindElementsByXpath<T>(string xpath) where T : HtmlControl, new();
    }
}