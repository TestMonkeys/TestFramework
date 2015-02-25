using System.Collections.Generic;
using TestMonkeys.CoreUI.Html;
using TestMonkeys.CoreUI.Search;

namespace TestMonkeys.CoreUI.Capabilities
{
    public interface ICanFindElements
    {
        HtmlControl FindElement(By by);

        T FindElement<T>(By by) where T : HtmlControl, new();

        List<HtmlControl> FindElements(By by); 

        List<T> FindElements<T>(By by) where T : HtmlControl, new();
    }
}