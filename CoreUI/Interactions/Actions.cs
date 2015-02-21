using TestMonkeys.CoreUI.Html;

namespace TestMonkeys.CoreUI.Interactions
{
    public class Actions : IAction
    {
        private readonly OpenQA.Selenium.Interactions.Actions actions;

        public Actions(Browser browser)
        {
            actions = new OpenQA.Selenium.Interactions.Actions(browser.WebDriver);
        }

        internal Actions(OpenQA.Selenium.Interactions.Actions actions)
        {
            this.actions = actions;
        }

        public void Perform()
        {
            actions.Perform();
        }

        public IAction Build()
        {
            return new Action(actions.Build());
        }

        public Actions Click()
        {
            return new Actions(actions.Click());
        }

        public Actions Click(HtmlControl control)
        {
            return new Actions(actions.Click(control.WebElement));
        }

        public Actions ClickAndHold()
        {
            return new Actions(actions.ClickAndHold());
        }

        public Actions ClickAndHold(HtmlControl control)
        {
            return new Actions(actions.ClickAndHold(control.WebElement));
        }

        public Actions ContextClick()
        {
            return new Actions(actions.ContextClick());
        }

        public Actions ContextClick(HtmlControl control)
        {
            return new Actions(actions.ContextClick(control.WebElement));
        }

        public Actions DoubleClick()
        {
            return new Actions(actions.DoubleClick());
        }

        public Actions DoubleClick(HtmlControl control)
        {
            return new Actions(actions.DoubleClick(control.WebElement));
        }

        public Actions DragAndDrop(HtmlControl source, HtmlControl destination)
        {
            return new Actions(actions.DragAndDrop(source.WebElement, destination.WebElement));
        }

        public Actions DragAndDropToOffset(HtmlControl source, int offsetX, int offsetY)
        {
            return new Actions(actions.DragAndDropToOffset(source.WebElement, offsetX, offsetY));
        }

        public Actions KeyDown(HtmlControl control, string theKey)
        {
            return new Actions(actions.KeyDown(control.WebElement, theKey));
        }

        public Actions KeyDown(string theKey)
        {
            return new Actions(actions.KeyDown(theKey));
        }

        public Actions KeyUp(HtmlControl control, string theKey)
        {
            return new Actions(actions.KeyUp(control.WebElement, theKey));
        }

        public Actions KeyUp(string theKey)
        {
            return new Actions(actions.KeyUp(theKey));
        }

        public Actions MoveByOffset(int offsetX, int offsetY)
        {
            return new Actions(actions.MoveByOffset(offsetX, offsetY));
        }

        public Actions MoveToElement(HtmlControl control, int offsetX, int offsetY)
        {
            return new Actions(actions.MoveToElement(control.WebElement, offsetX, offsetY));
        }

        public Actions MoveToElement(HtmlControl control)
        {
            return new Actions(actions.MoveToElement(control.WebElement));
        }

        public Actions Release(HtmlControl onControl)
        {
            return new Actions(actions.Release(onControl.WebElement));
        }

        public Actions Release()
        {
            return new Actions(actions.Release());
        }

        public Actions SendKeys(HtmlControl control, string keysToSend)
        {
            return new Actions(actions.SendKeys(control.WebElement, keysToSend));
        }

        public Actions SendKeys(string keysToSend)
        {
            return new Actions(actions.SendKeys(keysToSend));
        }
    }
}