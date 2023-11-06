using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Core;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools.V117.WebAuthn;

namespace POM
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        IWebElement nameInput => wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id=\"user-name\"]")));
        IWebElement passwordInput => wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id=\"password\"]")));
        IWebElement loginButton => wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id=\"login-button\"]")));
        IWebElement emptyNameInputErrorMessage => wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(text(), 'Username is required')]")));
        IWebElement emptyPasswordInputErrorMessage => wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(text(), 'Password is required')]")));

        public void NavigateToLoginPage()
        {
            var url = ConfigurationManager.GetLoginPageUrl();
            driver.Navigate().GoToUrl(url);
        }

        public void InputName()
        {
            nameInput.SendKeys(CredentialsManager.GetName());            
        }

        public void InputPassword()
        {
            passwordInput.SendKeys(CredentialsManager.GetPassword());
        }

        public void ClearNameInput()
        {
            nameInput.Clear();
        }

        public void ClearPasswordInput()
        {
            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            action.SendKeys(Keys.Delete).Build().Perform();
        }

        public bool WaitUntilNameInputIsEmpty()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                return wait.Until(driver =>
                {
                    string value = nameInput.GetAttribute("value");
                    return string.IsNullOrEmpty(value);
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public void Submit()
        {
            
                loginButton.Click();
            

        }

        public void SendEmptyStringToName()
        {
            nameInput.SendKeys("");
        }

        public void SendEmptyStringToPassword()
        {
            passwordInput.SendKeys("");
        }

        public bool CheckEmptyNameInputError()
        {
            if (emptyNameInputErrorMessage.Displayed)
            {
                return true;
            }

            return false;
        }

        public bool CheckEmptyPasswordInputError()
        {
            if (emptyPasswordInputErrorMessage.Displayed)
            {
                return true;
            }

            return false;
        }

        public bool CheckSuccessfulLogin()
        {

        }
    }
}