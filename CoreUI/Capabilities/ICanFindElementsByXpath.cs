using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMonkeys.CoreUI.Html;
using TestMonkeys.CoreUI.Search;

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
