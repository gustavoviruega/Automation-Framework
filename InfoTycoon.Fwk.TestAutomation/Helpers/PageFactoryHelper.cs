using OpenQA.Selenium.Support.PageObjects;

namespace InfoTycoon.Fwk.TestAutomation.Helpers
{
    public class PageFactoryHelper
    {
        public static T InitElements<T>() where T : PageBase, new()
        {
            T page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }
    }
}
