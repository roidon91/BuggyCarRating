using System;
using System.Security.Cryptography;
using Autofac;
using BCR.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace BCR.MobileTests
{
    [TestFixture]
    public class RegisterTests
    {
        private RegisterPage _registerPage;
        
        [SetUp]
        public void Setup()
        {
            AutofacConfig.Configure();
            var driver = AutofacConfig.Container.Resolve<AppiumDriver<IWebElement>>();
            _registerPage = AutofacConfig.Container.Resolve<RegisterPage>(
                new TypedParameter(typeof(AppiumDriver<IWebElement>), driver));
        }
        
        [Test]
        public void WeakPassword()
        {
            const string url = "https://buggy.justtestit.org/register";
            var register = _registerPage;
            register.GoToUrl(url);
            register.EnterRegistrationDetails("John87","John",
                "John","1","1");
            register.RegisterBtn().Click();;
            Assert.AreEqual("InvalidParameter: 1 validation error(s) found. - minimum field size of 6, SignUpInput.Password." ,
                register.SystemMessage());
            
            register.Close();
        }
        
        [Test]
        public void SuccessfulRegistration()
        {
            const string url = "https://buggy.justtestit.org/register";
            var register = _registerPage;
            var rnd = new Random();
            register.GoToUrl(url);
            register.EnterRegistrationDetails("John87" + rnd.Next(),"John",
                "John","John@123","John@123");
            register.RegisterBtn().Click();;
            Assert.AreEqual("Registration is successful" ,
                register.SystemMessage());
            
            register.Close();
        }
        
        [Test]
        public void ExistingUsernameRegistration()
        {
            const string url = "https://buggy.justtestit.org/register";
            var register = _registerPage;
            register.GoToUrl(url);
            register.EnterRegistrationDetails("John87","John",
                "John","John@123","John@123");
            register.RegisterBtn().Click();;
            Assert.AreEqual("UsernameExistsException: User already exists" ,
                register.SystemMessage());
            
            register.Close();
        }
        
        [Test]
        [Description("Error messages should appear when fields are blank")]
        public void MissingFieldsRegistration()
        {
            const string url = "https://buggy.justtestit.org/register";
            var register = _registerPage;
            register.GoToUrl(url);
            
            register.EnterRegistrationDetails("q","q","q","q","q",true);
          
            Assert.AreEqual("Login is required" ,
                register.LoginFieldValidationMsg().Text);
            Assert.AreEqual("First Name is required" ,
                register.FirstNameFieldValidationMsg().Text);
            Assert.AreEqual("Last Name is required" ,
                register.LastNameFieldValidationMsg().Text);
            Assert.AreEqual("Password is required" ,
                register.PasswordFieldValidationMsg().Text);
            Assert.AreEqual("Passwords do not match" ,
                register.ConfirmPasswordFieldValidationMsg().Text);
            
            
            register.Close();
        }
    }
}