using InfoTycoon.Fwk.TestAutomation;
using InfoTycoon.Fwk.TestAutomation.Helpers;
using OpenQA.Selenium.Support.PageObjects;

namespace InfoTycoon.ProjectToTest
{
    public static class Pages
    {
        public static Login Login
        {
            get
            {
                return PageFactoryHelper.InitElements<Login>();
            }
        }

        public static Companies Companies
        {
            get
            {
                return PageFactoryHelper.InitElements<Companies>();
            }
        }

        public static Properties Properties
        {
            get
            {
                return PageFactoryHelper.InitElements<Properties>();
            }
        }

        public static PropertyActivity PropertyActivity
        {
            get
            {
                return PageFactoryHelper.InitElements<PropertyActivity>();
            }
        }

        public static CreateProperty CreateProperty
        {
            get
            {
                return PageFactoryHelper.InitElements<CreateProperty>();
            }
        }

        public static PropertyDetails PropertyDetails
        {
            get
            {
                return PageFactoryHelper.InitElements<PropertyDetails>();
            }
        }

        public static GeneralItems GeneralItems
        {
            get
            {
                return PageFactoryHelper.InitElements<GeneralItems>();
            }
        }

        public static CreateGeneralItems CreateGeneralItems
        {
            get
            {
                return PageFactoryHelper.InitElements<CreateGeneralItems>();
            }
        }
    }
}
