using System.Collections.Generic;
using TestMonkeys.CoreUI.Html;

namespace TestMonkeys.CoreUI.Capabilities
{
    public interface ICanFindElementsByXpath
    {
        HtmlControl FindElementByXpath(string xpath);
        T FindElementByXpath<T>(string xpath) where T : HtmlControl, new();
        List<HtmlControl> FindElementsByXpath(string xpath);
        List<T> FindElementsByXpath<T>(string xpath) where T : HtmlControl, new();
    }
}