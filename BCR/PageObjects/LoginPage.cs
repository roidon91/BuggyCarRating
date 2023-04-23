using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace BCR.PageObjects
{
    public class LoginPage
    {
        private readonly AppiumDriver<IWebElement> _driver;

        public LoginPage(AppiumDriver<IWebElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver,this);
        }


        #region Elements
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/header/nav" +
                                          "/div/my-login/div/form/div/input[1]")]
        private IWebElement usernameField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/header/nav" +
                                          "/div/my-login/div/form/div/input[2]")]
        private IWebElement passwordField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/header" +
                                          "/nav/div/my-login/div/form/button")]
        private IWebElement loginBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/header/nav/div/my-login/div/ul/li[3]/a")]
        private IWebElement logout { get; set; }

        #region System messages

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/header/nav/div/my-login/div/form/div/span")]
        private IWebElement loginWarningMsg { get; set; }

        #endregion
        
        #endregion

        #region Methods
        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        
        public void EnterLoginDetails(string username,string password)
        {
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
        }
        
        public IWebElement LoginBtn()
        {
          return  loginBtn;
        }

        public void Close()
        {
            _driver.Quit();
        }

        public IWebElement LoginWarningMsg()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(ElementToBeClickable(loginWarningMsg));
        }
        
        public IWebElement Logout()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(ElementToBeClickable(logout));
        }

        public IWebElement ValidationMsg()
        {
            return usernameField;
        }
        

        #endregion
       
    }
}