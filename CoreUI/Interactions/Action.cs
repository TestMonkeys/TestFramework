namespace TestMonkeys.CoreUI.Interactions
{
    internal class Action : IAction
    {
        private readonly OpenQA.Selenium.Interactions.IAction action;

        internal Action(OpenQA.Selenium.Interactions.IAction action)
        {
            this.action = action;
        }

        public void Perform()
        {
            action.Perform();
        }
    }
}