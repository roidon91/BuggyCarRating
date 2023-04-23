using Autofac;
using BCR.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace BCR.MobileTests
{
    public class UserProfileTests
    {
        private UserProfilePage _userProfilePage;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            AutofacConfig.Configure();
            var driver = AutofacConfig.Container.Resolve<AppiumDriver<IWebElement>>();
            _userProfilePage = AutofacConfig.Container.Resolve<UserProfilePage>(
                new TypedParameter(typeof(AppiumDriver<IWebElement>), driver));
            _loginPage = AutofacConfig.Container.Resolve<LoginPage>(
                new TypedParameter(typeof(AppiumDriver<IWebElement>), driver));
        }

        [Test]
        public void SuccessfulProfileSave()
        {
            const string url = "https://buggy.justtestit.org/";
            var login = _loginPage;
            var userProfile = _userProfilePage;
            login.GoToUrl(url);
            login.EnterLoginDetails("John87", "John@123");
            login.LoginBtn().Click();
            userProfile.ProfileBtn().Click();

            userProfile.EnterBasicDetails("new Name", "New lAs Name");
            userProfile.EnterAdditionalInfo("Male", "31", "test\ntest", "Jogging");
            userProfile.SaveBtn().Click();

            Assert.AreEqual("The profile has been saved successful",
                userProfile.SystemMessage().Text);

            userProfile.Close();
        }

        [Test]
        public void ErrorMessagesProfileSave()
        {
            const string url = "https://buggy.justtestit.org/";
            var login = _loginPage;
            var userProfile = _userProfilePage;
            login.GoToUrl(url);
            login.EnterLoginDetails("John87", "John@123");
            login.LoginBtn().Click();
            userProfile.ProfileBtn().Click();
            
            userProfile.EnterAdditionalInfo("Male", "3131", "test\ntest", "Jogging");
            userProfile.EnterBasicDetails("q","q",true);
            
            Assert.AreEqual("Age must be in the range from 0 to 95",
                userProfile.AgeValidationMessage().Text);
            Assert.AreEqual("First Name is required",
                userProfile.FirstNameValidationMessage().Text);
            Assert.AreEqual("Last Name is required",
                userProfile.LastNameValidationMessage().Text);

            userProfile.Close();

        }
    }
}