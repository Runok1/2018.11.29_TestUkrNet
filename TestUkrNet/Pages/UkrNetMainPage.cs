using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestUkrNet.Pages
{
    public class UkrNetMainPage : UkrNetBasePage
    {
        public UkrNetMainPage(IWebDriver driver) : base (driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='search-input']")]
        public IWebElement searchField;

        [FindsBy(How = How.XPath, Using = "//*[@id='id-input-login']")]
        public IWebElement loginField;

        [FindsBy(How = How.XPath, Using = "//*[@id='id-input-password']")]
        public IWebElement passwordField;

        [FindsBy(How = How.CssSelector, Using = "[class='form__submit']")]
        public IWebElement submitButton;

        //[FindsBy(How = How.XPath, Using = "/html/body/div[2]/a")]
        //public IWebElement inboxButton;

        [FindsBy(How = How.CssSelector, Using = "[class='service__entry service__entry_mail']")]
        public IWebElement inboxButton;

        [FindsBy(How = How.CssSelector, Using = "[class='form__error form__error_wrong form__error_visible']")]
        public IWebElement loginDataErrorMessage;

        //[FindsBy(How = How.XPath, Using = "//*[@id='act-lang']")]
        //public IWebElement languageDropdown;

       
    }
}
