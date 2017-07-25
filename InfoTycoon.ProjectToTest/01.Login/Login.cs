using InfoTycoon.Fwk.TestAutomation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace InfoTycoon.ProjectToTest
{
    public class Login : PageBase
    {
        public Login() : base("LOG IN", "https://dev-my.infotycoon.com/#/account/login/")
        {
        }

        #region Page elements
        [FindsBy(How = How.ClassName, Using = "modal-title")]
        private IWebElement headLogin;

        [FindsBy(How = How.CssSelector, Using = "img[src='https://infotycoondev.blob.core.windows.net/files/logo_medium.png']")]
        private IWebElement imgLogo;

        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement txtEmail;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement txtPassword;

        [FindsBy(How = How.CssSelector, Using = "a[href='/#/account/forgot/']")]
        private IWebElement btnForgotPass;

        [FindsBy(How = How.Id, Using = "SubmitButton")]
        private IWebElement btnSignIn;

        [FindsBy(How = How.ClassName, Using = "toast-title")]
        private IWebElement toastTitle;

        [FindsBy(How = How.ClassName, Using = "toast-message")]
        private IWebElement toastMessage;
        #endregion

        #region Methods
        public void SingIn(string userName, string password)
        {
            WaitForOverlay();
            WaitForElement(btnSignIn);
            txtEmail.SendKeys(userName);
            txtPassword.SendKeys(password);
            btnSignIn.Click();
        }
        #endregion

        #region Properties

        public string PageHeader
        {
            get
            {
                WaitForElement(headLogin);
                return headLogin.Text.Trim();
            }
        }

        public IWebElement LogoImage
        {
            get
            {
                WaitForElement(imgLogo);
                return imgLogo;
            }
        }

        public IWebElement EmailTextBox
        {
            get
            {
                WaitForElement(txtEmail);
                return txtEmail;
            }
        }

        public IWebElement PasswordTextBox
        {
            get
            {
                WaitForElement(txtPassword);
                return txtPassword;
            }
        }

        public IWebElement ForgotPasswordButton
        {
            get
            {
                WaitForElement(btnForgotPass);
                return btnForgotPass;
            }
        }
        
        public IWebElement SignInButton
        {
            get
            {
                WaitForElement(btnSignIn);
                return btnSignIn;
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

        public string ToastMessage
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
