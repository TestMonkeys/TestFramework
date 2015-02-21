namespace TestMonkeys.CoreUI.Html
{
    public class HtmlCheckBox : HtmlControl
    {
        public bool Checked
        {
            get { return IsSelected; }
        }
    }
}