using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestUkrNet.Pages
{
    public class UkrNetMailPage : UkrNetBasePage
    {
        public UkrNetMailPage(IWebDriver driver) : base (driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='screens']/div/div[2]/section[1]/div[1]/div[4]/input[2]")]
        public IWebElement sendToField;

        [FindsBy(How = How.XPath, Using = "//*[@id='screens']/div/div[2]/section[1]/div[4]/div[2]/input")]
        public IWebElement letterThemeField;

        [FindsBy(How = How.XPath, Using = "//*[@id='tinymce']")]
        public IWebElement letterTextField;

        [FindsBy(How = How.CssSelector, Using = "[class='default send']")]
        public IWebElement sendButton;

        [FindsBy(How = How.CssSelector, Using = "[class='sendmsg__ads-ready']")]
        public IWebElement letterWasSentMsg;
        
    }
}
