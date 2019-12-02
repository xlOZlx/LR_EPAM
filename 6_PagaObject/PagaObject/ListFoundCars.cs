using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace PagaObject
{
    class ListFoundCars
    {

        [FindsBy(How = How.CssSelector, Using = @"div.search-summary__section.search-summary__section--pick-up > div:nth-child(2) > div.search-summary__location")]
        public IWebElement correctInfo;
        [FindsBy(How = How.CssSelector, Using = @"#supplier-filter-content li:nth-child(1) label")]
        public IWebElement selectNameProvider;
        [FindsBy(How = How.CssSelector, Using = @"#supplier-filter-content li:nth-child(1) label div.checkbox")]
        private IWebElement selectProvider;
        public ListFoundCars(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }
        
        public ListFoundCars AutoSelectProvider()
        {
            selectProvider.Click();
            return this;
        }
    }
}
