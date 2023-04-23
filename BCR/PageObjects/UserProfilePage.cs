using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace BCR.PageObjects
{
    public class UserProfilePage
    {
        private readonly AppiumDriver<IWebElement> _driver;

        public UserProfilePage(AppiumDriver<IWebElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver,this);
        }
        
        #region Elements

        #region Basic
        [FindsBy(How = How.XPath, Using = "//*[@id=\"username\"]")]
        private IWebElement usernameField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"firstName\"]")]
        private IWebElement firstnameField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"lastName\"]")]
        private IWebElement lastNameField { get; set; }
        

        #endregion

        #region Additional Info
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"gender\"]")]
        private IWebElement genderField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"genders\"]")]
        private IWebElement genderOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"age\"]")]
        private IWebElement ageField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"address\"]")]
        private IWebElement addressField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"phone\"]")]
        private IWebElement phoneNosField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"hobby\"]")]
        private IWebElement hobbyField { get; set; }
        

        #endregion

        #region Additional Info Password
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"currentPassword\"]")]
        public IWebElement currentPasswordField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"newPassword\"]")]
        public IWebElement passwordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"newPasswordConfirmation\"]")]
        public IWebElement confirmPasswordField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"language\"]")]
        public IWebElement languageField { get; set; }
        

        #endregion

        #region Buttons
        
        [FindsBy(How = How.XPath, Using = "//button[text()=\"Save\"]")]
        private IWebElement saveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-profile/div/form/div[2]/div/a")]
        private IWebElement cancelBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[text()=\"Profile\"]")]
        private IWebElement profileBtn { get; set; }
        

        #endregion

        #region System Messages

        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-profile/div/form/div[3]/div")]
        private IWebElement systemMsg { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-profile/div/form/div[1]/div[2]/div/div/fieldset[2]/div")]
        private IWebElement ageValidationMsg { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-profile/div/form/div[1]/div[1]/div[1]/div/fieldset[2]/div")]
        private IWebElement firstNameValidationMsg { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/my-app/div/main/my-profile/div/form/div[1]/div[1]/div[1]/div/fieldset[3]/div")]
        private IWebElement lastNameValidationMsg { get; set; }

        #endregion
        
        #endregion

        #region Methods
        
        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void EnterBasicDetails(string firstName, string lastName, bool isGenerateErrorMsg = false)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ElementToBeClickable(firstnameField));
            firstnameField.Clear();
            lastNameField.Clear();
            firstnameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            if (!isGenerateErrorMsg) return;
            firstnameField.SendKeys(Keys.Backspace);
            lastNameField.SendKeys(Keys.Backspace);
        }

        public void EnterChangePassword(string currentPwd, string newPwd, string confirmPwd)
        {
            currentPasswordField.SendKeys(currentPwd);
            passwordField.SendKeys(newPwd);
            confirmPasswordField.SendKeys(confirmPwd);
            
        }
        
        public void EnterAdditionalInfo(string gender, string age, string address,string hobby)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(ElementToBeClickable(ageField));
            genderField.Clear();
            ageField.Clear();
            addressField.Clear();
            genderField.SendKeys(gender);
            ageField.SendKeys(age);
            addressField.SendKeys(address);
            hobbyField.SendKeys(hobby);
          
        }

        public IWebElement SaveBtn()
        {
            return saveBtn;
        }

        public IWebElement ProfileBtn()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(ElementToBeClickable(profileBtn));
        }


        public IWebElement SystemMessage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ElementToBeClickable(systemMsg));
            return systemMsg;
        }
        
        public IWebElement AgeValidationMessage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ElementToBeClickable(ageValidationMsg));
            return ageValidationMsg;
        }
        
        public IWebElement FirstNameValidationMessage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ElementToBeClickable(firstNameValidationMsg));
            return firstNameValidationMsg;
        }
        
        public IWebElement LastNameValidationMessage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ElementToBeClickable(lastNameValidationMsg));
            return lastNameValidationMsg;
        }
        public void Close()
        {
            _driver.Quit();
        }
        #endregion
    }
}