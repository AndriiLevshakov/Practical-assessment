using Core.DriverFactory;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using POM;
using Core;

using static Core.DriverFactory.DriverProvider;

namespace Practical_assessment
{
    public class Tests
    {
        IWebDriver driver;
        private LoginPage loginPage;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            var browser = (Drivers)Enum.Parse(typeof(Drivers), Configuration.Model.Browser);
            driver = DriverProvider.GetDriverFactory(browser).CreateDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage();

            //Console.ReadLine();
        }

        [Test]
        public void Test1()
        {
            loginPage.InputName();
            //loginPage.SendEmptyStringToName();
            loginPage.InputPassword();
            loginPage.ClearNameInput();
            loginPage.ClearPasswordInput();
            loginPage.RefreshPage();
            //Console.ReadLine();
            //loginPage.SendEmptyStringToName();
            loginPage.Submit();
            Assert.IsTrue(loginPage.CheckEmptyNameInputError());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}