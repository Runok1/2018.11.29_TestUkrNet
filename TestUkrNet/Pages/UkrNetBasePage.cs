using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;

namespace TestUkrNet.Pages
{
    public class UkrNetBasePage
    {
        public UkrNetBasePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
