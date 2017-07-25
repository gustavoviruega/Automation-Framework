using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System;

namespace InfoTycoon.ProjectToTest
{
    public class PropertyDetails : PageBase
    {
        static string propID = ConfigurationManager.AppSettings["AutomationPropertyID"];
        public PropertyDetails() : base("PROPERTY DETAILS", "https://dev-my.infotycoon.com/#/property/" + propID + "/setup/")
        {
        }

        #region Page Elements

            #region Header
            [FindsBy(How = How.PartialLinkText, Using = "Properties")]
            private IWebElement btnProperties;

            [FindsBy(How = How.PartialLinkText, Using = "Activity")]
            private IWebElement btnActivity;

            [FindsBy(How = How.PartialLinkText, Using = "Inspections")]
            private IWebElement btnInspections;

            [FindsBy(How = How.PartialLinkText, Using = "Lease File Audits")]
            private IWebElement btnLFA;

            [FindsBy(How = How.PartialLinkText, Using = "Setup")]
            private IWebElement btnSetup;

            [FindsBy(How = How.PartialLinkText, Using = "Reports")]
            private IWebElement btnReports;
            #endregion

            #region Body

                #region Side Menu
                [FindsBy(How = How.CssSelector, Using = "ul#collapseSidemenu a.active")]
                private IWebElement btnSideMenuActive;

                [FindsBy(How = How.PartialLinkText, Using = "GENERAL ITEMS")]
                private IWebElement btnGeneralItems;

                [FindsBy(How = How.PartialLinkText, Using = "INTERIOR ITEMS")]
                private IWebElement btnInteriorItems;

                [FindsBy(How = How.PartialLinkText, Using = "EXTERIOR ITEMS")]
                private IWebElement btnExteriorItems;

                [FindsBy(How = How.PartialLinkText, Using = "GENERAL CATEGORIES")]
                private IWebElement btnGeneralCategories;

                [FindsBy(How = How.PartialLinkText, Using = "INTERIOR CATEGORIES")]
                private IWebElement btnInteriorCategories;

                [FindsBy(How = How.PartialLinkText, Using = "EXTERIOR CATEGORIES")]
                private IWebElement btnExteriorCategories;

                [FindsBy(How = How.PartialLinkText, Using = "UNIT CONFIGURATIONS")]
                private IWebElement btnUnitConfigurations;

                [FindsBy(How = How.PartialLinkText, Using = "PHASES")]
                private IWebElement btnPhases;

                [FindsBy(How = How.PartialLinkText, Using = "BUILDINGS")]
                private IWebElement btnBuildings;

                [FindsBy(How = How.PartialLinkText, Using = "SITE AREAS")]
                private IWebElement btnSiteAreas;
                #endregion

            [FindsBy(How = How.PartialLinkText, Using = "Automation Property")]
            private IWebElement brePropertyDetails;

            [FindsBy(How = How.PartialLinkText, Using = "New Gustavo Property")]
            private IWebElement breNewPropertyDetails;

            [FindsBy(How = How.CssSelector, Using = "h3.content-header")]
            private IWebElement headPropertyDetails;

            [FindsBy(How = How.CssSelector, Using = "div[class$='form-group'] > label[for='name']")]
            private IWebElement lblName;

            [FindsBy(How = How.Id, Using = "name")]
            private IWebElement txtPropertyName;

            [FindsBy(How = How.CssSelector, Using = "#address1")]
            private IWebElement txtAddress1;

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.name.$error.required']")]
            private IWebElement msgPropertyName;

            [FindsBy(How = How.Id, Using = "SubmitButton")]
            public IWebElement btnSaveProperty;

            [FindsBy(How = How.ClassName, Using = "toast-title")]
            private IWebElement toastTitle;

            [FindsBy(How = How.ClassName, Using = "toast-message")]
            private IWebElement toastMessage;
            #endregion

        #endregion

        #region Methods

            #region Side Menu
            public void SelectGeneralItemsOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnGeneralItems);
                btnGeneralItems.Click();
            }

            public void SelectInteriorItemsOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnInteriorItems);
                btnInteriorItems.Click();
            }

            public void SelectExteriorItemsOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnExteriorItems);
                btnExteriorItems.Click();
            }

            public void SelectGeneralCategoriesOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnGeneralCategories);
                btnGeneralCategories.Click();
            }

            public void SelectInteriorCategoriesOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnInteriorCategories);
                btnInteriorCategories.Click();
            }

            public void SelectExteriorCategoriesOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnExteriorCategories);
                btnExteriorCategories.Click();
            }

            public void SelectUnitConfigurationsOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnUnitConfigurations);
                btnUnitConfigurations.Click();
            }

            public void SelectPhasesOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnPhases);
                btnPhases.Click();
            }

            public void SelectBuildingsOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnBuildings);
                btnBuildings.Click();
            }

            public void SelectSiteAreasOption()
            {
                WaitForOverlay();
                WaitForElement(lblName);
                WaitForElement(btnSiteAreas);
                btnSiteAreas.Click();
            }
            #endregion

        public void DeletePropertyName()
        {
            WaitForOverlay();
            WaitForElement(lblName);
            txtPropertyName.Clear();
        }

        public void EditProperty(string address1)
        {
            WaitForOverlay();
            WaitForElement(lblName);
            txtAddress1.Clear();
            txtAddress1.SendKeys(address1);
        }

        public void ClickSave()
        {
            WaitForOverlay();
            WaitForElement(lblName);
            btnSaveProperty.Click();
        }

        #endregion

        #region Properties

            #region Header
            public IWebElement PropertiesButton
            {
                get
                {
                    WaitForElement(btnProperties);
                    return btnProperties;
                }
            }

            public IWebElement ActivityButton
            {
                get
                {
                    WaitForElement(btnActivity);
                    return btnActivity;
                }
            }

            public IWebElement InspectionsButton
            {
                get
                {
                    WaitForElement(btnInspections);
                    return btnInspections;
                }
            }

            public IWebElement LFAButton
            {
                get
                {
                    WaitForElement(btnLFA);
                    return btnLFA;
                }
            }

            public IWebElement SetupButton
            {
                get
                {
                    WaitForElement(btnSetup);
                    return btnSetup;
                }
            }

            public IWebElement ReportsButton
            {
                get
                {
                    WaitForElement(btnReports);
                    return btnReports;
                }
            } 
            #endregion

        public string PageHeader
        {
            get
            {
                WaitForElement(headPropertyDetails);
                return headPropertyDetails.Text;
            }
        }

        public string PageBreadCrumb
        {
            get
            {
                WaitForElement(brePropertyDetails);
                return brePropertyDetails.Text;
            }
        }

        public string PageBreadCrumbNew
        {
            get
            {
                WaitForElement(breNewPropertyDetails);
                return breNewPropertyDetails.Text;
            }
        }

        public bool SideMenuActiveButton
        {
            get
            {
                WaitForElement(headPropertyDetails);
                if (btnSideMenuActive.Text.Trim() == "PROPERTY DETAILS")
                {
                    return true;
                }
                return false;
            }
        }

        public string PropertyNameText
        {
            get
            {
                WaitForOverlay();
                WaitForElement(lblName);
                string PropertyName = txtPropertyName.GetAttribute("value");
                return PropertyName;
            }
        }

        public string PropertyNameMsg
        {
            get
            {
                WaitForElement(msgPropertyName);
                return msgPropertyName.Text;
            }
        }

        public bool SaveButtonEnabled
        {
            get
            {
                if (btnSaveProperty != null)
                {
                    return btnSaveProperty.Enabled;
                }
                return false;
            }
        }

        public string ToastTitle
        {
            get
            {
                WaitForElement(toastTitle);
                return toastTitle.Text;
            }
        }

        public string ToastMsg
        {
            get
            {
                WaitForElement(toastMessage);
                return toastMessage.Text;
            }
        }
        #endregion
    }
}
