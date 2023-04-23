using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace BCR.PageObjects
{
    public class RegisterPage
    {
        private readonly AppiumDriver<IWebElement> _driver;

        public RegisterPage(AppiumDriver<IWebElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver,this);
        }
        
        #region Elements

        #region Form elements
        [FindsBy(How = How.XPath, Using = "//*[@id=\"username\"]")]
        private IWebElement usernameField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"firstName\"]")]
        private IWebElement firstnameField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"lastName\"]")]
        private IWebElement lastNameField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"password\"]")]
        private IWebElement passwordField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"confirmPassword\"]")]
        private IWebElement confirmPasswordField { get; set; }

        

        #endregion
        
        #region Buttons
         
        [FindsBy(How = How.XPath, Using = "//button[text()=\"Register\"]")]
        private IWebElement registerBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div" +
                                          "/main/my-register/div/div/form/a")]
        private IWebElement cancelBtn { get; set; }
        

        #endregion


        #region System Messages
        
        [FindsBy(How = How.XPath, Using ="/html/body/my-app/div/main/my-register/div/div/form/div[6]" )]
        private IWebElement systemMsg { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-register/div/div/form/div[1]/div[1]")]
        private IWebElement loginErrorMsg { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-register/div/div/form/div[2]/div")]
        private IWebElement firstNameErrorMsg { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-register/div/div/form/div[3]/div")]
        private IWebElement lastNameErrorMsg { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-register/div/div/form/div[4]/div")]
        private IWebElement passwordErrorMsg { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-register/div/div/form/div[5]/div")]
        private IWebElement confpasswordErrorMsg { get; set; }

        

        #endregion
       
        
        #endregion

        #region Methods
        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void EnterRegistrationDetails(string username ,string firstName,string lastName,string password,
            string confirmPassword, bool isGenerateValidationMsg =false)
        {
            usernameField.SendKeys(username);
            firstnameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            passwordField.SendKeys(password);
            confirmPasswordField.SendKeys(confirmPassword);

            if (!isGenerateValidationMsg) return;
            usernameField.SendKeys("");
            usernameField.SendKeys(Keys.Backspace);
            firstnameField.SendKeys("");
            firstnameField.SendKeys(Keys.Backspace);
            lastNameField.SendKeys("");
            lastNameField.SendKeys(Keys.Backspace);
            passwordField.SendKeys("");
            passwordField.SendKeys(Keys.Backspace);
            confirmPasswordField.SendKeys("");
            confirmPasswordField.SendKeys(Keys.Backspace);
        }
        
       
        
        public IWebElement RegisterBtn()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(ElementToBeClickable(registerBtn));
           
        }

        public string SystemMessage()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(ElementToBeClickable(systemMsg)).Text;
        }

        public IWebElement LoginFieldValidationMsg()
        {
            return loginErrorMsg;
        }
        
        public IWebElement FirstNameFieldValidationMsg()
        {
            return firstNameErrorMsg;
        }
        public IWebElement LastNameFieldValidationMsg()
        {
            return lastNameErrorMsg;
        }
        public IWebElement PasswordFieldValidationMsg()
        {
            return passwordErrorMsg;
        }
        public IWebElement ConfirmPasswordFieldValidationMsg()
        {
            return confpasswordErrorMsg;
        }
        
        public void CancelBtn()
        {
            cancelBtn.Click();
        }

        public void Close()
        {
            _driver.Quit();
        }
        
        #endregion
       

      
    }
}
