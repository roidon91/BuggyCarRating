using System;
using System.Drawing;
using Autofac;
using Autofac.Core;
using BCR.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace BCR
{
    public class AutofacConfig
    {
        public static IContainer Container { get; private set; }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.Register(c =>
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("platformName", "Android");
                appiumOptions.AddAdditionalCapability("platformVersion", "11.0");
                appiumOptions.AddAdditionalCapability("deviceName", "Pixel 3 API 30");
                appiumOptions.AddAdditionalCapability("browserName", "Chrome");
                appiumOptions.AddAdditionalCapability("ignoreUnimportantViews", true);
                appiumOptions.AddAdditionalCapability("chromedriverExecutable", "path to chrome driver");
                appiumOptions.AddAdditionalCapability("chromedriverExecutableDir", "path to chrome driver directory");
                return appiumOptions;
            }).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var driverOptions = c.Resolve<AppiumOptions>();
                var driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), driverOptions);
                driver.Orientation = ScreenOrientation.Landscape;
                return driver;
            }).As<AppiumDriver<IWebElement>>().SingleInstance();
            
            builder.RegisterType<LoginPage>()
                .AsSelf();
            
            
            builder.RegisterType<RegisterPage>()
                .AsSelf();
            builder.RegisterType<UserProfilePage>()
                .AsSelf();

            Container = builder.Build();
        }
    }
}