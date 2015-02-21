using System.Collections.Generic;

namespace TestMonkeys.CoreUI.Html
{
    public class HtmlTable<T> : HtmlControl where T : HtmlRow, new()
    {
        private string rowFilterXpath = "descendant::tr";

        public HtmlTable(HtmlControl control)
        {
            WebElement = control.WebElement;
        }

        public string RowFilterXpath
        {
            get { return rowFilterXpath; }
            set { rowFilterXpath = value; }
        }

        public int TopRowsToIgnore { get; set; }
        public int BottomRowsToIgnore { get; set; }

        public List<T> Rows
        {
            get
            {
                List<T> rows = FindElementsByXpath<T>(rowFilterXpath);
                rows.RemoveRange(0, TopRowsToIgnore);
                rows.RemoveRange(rows.Count - BottomRowsToIgnore, BottomRowsToIgnore);
                return rows;
            }
        }

        public T GetRow(int position)
        {
            return Rows[position];
        }
    }
}