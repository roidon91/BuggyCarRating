using Autofac;
using BCR.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace BCR.MobileTests
{
    [TestFixture]
    public class LoginTests
    {
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            AutofacConfig.Configure();
            var driver = AutofacConfig.Container.Resolve<AppiumDriver<IWebElement>>();
            _loginPage = AutofacConfig.Container.Resolve<LoginPage>(
                new TypedParameter(typeof(AppiumDriver<IWebElement>), driver));
        }

        [Test]
        public void InvalidUsernamePassword()
        {
            const string url = "https://buggy.justtestit.org/";
            var login = _loginPage;
            login.GoToUrl(url);
            login.EnterLoginDetails("invalid", "invalid");
            login.LoginBtn().Click();
            Assert.AreEqual("Invalid username/password" ,
                login.LoginWarningMsg().Text);
            login.Close();
        }
        
        [Test]
        public void InvalidUsername()
        {
            const string url = "https://buggy.justtestit.org/";
            var login = _loginPage;
            login.GoToUrl(url);
            login.EnterLoginDetails("invalid", "John@123");
            login. LoginBtn().Click();
            Assert.AreEqual("Invalid username/password" ,
                login.LoginWarningMsg().Text);
            login.Close();
        }
        
        [Test]
        public void InvalidPassword()
        {
            const string url = "https://buggy.justtestit.org/";
            var login = _loginPage;
            login.GoToUrl(url);
            login.EnterLoginDetails("John87", "Invalid");
            login. LoginBtn().Click();
            Assert.AreEqual("Invalid username/password" ,
                login.LoginWarningMsg().Text);
            login.Close();
        }
        
        [Test]
        [Description("User should not be able to login when blank fields are set")]
        public void BlankUsernamePassword()
        {
            const string url = "https://buggy.justtestit.org/";
            var login = _loginPage;
            login.GoToUrl(url);
            login. LoginBtn().Click();
            var test = login.ValidationMsg();
            Assert.IsTrue(login.ValidationMsg().Displayed);
            login.Close();
        }
        
        [Test]
        public void SuccessfulLogin()
        {
            const string url = "https://buggy.justtestit.org/";
            var login = _loginPage;
            login.GoToUrl(url);
            login.EnterLoginDetails("John87", "John@123");
            login.LoginBtn().Click();
            Assert.AreEqual("Logout" ,
                login.Logout().Text);
            login.Close();
        }
    }
}