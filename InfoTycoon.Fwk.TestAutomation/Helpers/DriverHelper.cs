using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;

namespace InfoTycoon.Fwk.TestAutomation.Helpers
{
    public static class DriverHelper
    {
        public static IWebDriver FactoryDriver()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["DriversPath"];
            var type = ConfigurationManager.AppSettings["WebDriverType"];
            switch (type)
            {
                case "FireFox":
                    return new FirefoxDriver();
                case "IExplorer":
                    return new InternetExplorerDriver(path);
                case "Chrome":
                    return new ChromeDriver(path);
                case "Edge":
                    return new EdgeDriver(path);
                default:
                    throw new Exception("El driver no existe. Ingrese uno de los siguientes: FireFox, IExplorer, Chrome");
            }
        }
    }
}
