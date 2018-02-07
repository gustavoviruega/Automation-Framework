using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using System.Collections.Generic;

namespace InfoTycoon.Fwk.TestAutomation
{
    public class PageBase
    {
        #region Constructor
        public PageBase(string title, string pageUrl)
        {
            Title = title;
            PageUrl = pageUrl;
        } 
        #endregion

        #region Properties
        public string Title { get; private set; }
        public string PageUrl { get; private set; }
        #endregion

        #region Methods
        [FindsBy(How = How.CssSelector, Using = "#_pendo-close-guide_")]
        private IWebElement btnClosePendo;

        [FindsBy(How = How.CssSelector, Using = "footer")]
        private IWebElement footer;

        public void ClosePendoModal()
        {
            Browser.ClosePendoModal(btnClosePendo);
        }

        protected void ScrollToFooter()
        {
            Browser.ScrollToElement(footer);
        }
        #endregion

        #region Waits
        /// <summary>
        /// Performs an implicit wait on the current page
        /// </summary>
        /// <param name="seconds">Wait interval in seconds, 10 seconds by default</param>
        protected void ImplicitlyWait(int seconds = 10)
        {
            Browser.ImplicitlyWait(seconds);
        }

        /// <summary>
        /// Waits for an element on the current page to be displayed and enabled
        /// </summary>
        /// <param name="element">Web element expected</param>
        /// <param name="seconds">Wait interval in seconds, 10 seconds by default</param>
        protected void WaitForElement(IWebElement element, int seconds = 10)
        {
            Browser.ExplicitWait(seconds, element);
        }

        /// <summary>
        /// Waits for the grid to display only 1 row
        /// </summary>
        /// <param name="element">Grid, collection of TR elements</param>
        /// <param name="seconds">Wait interval in seconds, 10 seconds by default</param>
        protected void WaitFor1RowOnly(IList<IWebElement> elements, int seconds = 10)
        {
            Browser.ExplicitWait1RowOnly(seconds, elements);
        }

        /// <summary>
        /// Waits for an element on the current page to be displayed only
        /// </summary>
        /// <param name="element">Web element expected</param>
        /// <param name="seconds">Wait interval in seconds, 10 seconds by default</param>
        protected void WaitForElementDisplayed(IWebElement element, int seconds = 10)
        {
            Browser.ExplicitWaitDisplayed(seconds, element);
        }

        /// <summary>
        /// Waits for an element on the current page to not be displayed
        /// </summary>
        /// <param name="element">Web element expected</param>
        /// <param name="seconds">Wait interval in seconds, 10 seconds by default</param>
        protected void WaitForElementNotDisplayed(IWebElement element, int seconds = 10)
        {
            Browser.ExplicitWaitNotDisplayed(seconds, element);
        }

        /// <summary>
        /// Wait for the overlay element
        /// </summary>
        /// <param name="seconds">Wait interval in seconds, 10 seconds by default</param>
        public void WaitForOverlay(int seconds = 10)
        {
            Browser.OverlayWait(seconds);
        }

        /// <summary>
        /// Wait for Angular to finished processing
        /// </summary>
        public void WaitForAngular(int seconds = 10)
        {
            Browser.AngularWait(seconds);
        }

        /// <summary>
        /// Wait for Document to be completed
        /// </summary>
        public void WaitForDocument(int seconds = 10)
        {
            Browser.DocumentWait(seconds);
        }
        #endregion
    }
}
