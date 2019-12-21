using System;
using System.IO;
using Framework.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Framework.PageObject;
using Framework.Driver;
using NUnit.Framework.Interfaces;
using log4net;
using log4net.Config;

namespace Framework.Test
{
    public class TestConfig
    {
        protected IWebDriver Driver { get; set; }

        
        [SetUp]
        public void Setter()
        {
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("https://www.rentalcars.com/");
        }


        [TearDown]
        public void ClearDriver()
        {
            DriverSingleton.CloseDriver();
        }
    }
}
