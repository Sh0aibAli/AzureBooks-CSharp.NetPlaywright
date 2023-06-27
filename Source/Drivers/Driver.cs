using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using POM_Basic.Source.Pages;
using OpenQA.Selenium.Support.UI;

namespace POM_Basic.Source.Drivers
{
    public class Driver
    {
        public static IWebDriver _driver;
        public static Pages.HomePage homepage;
        public static Pages.LoginPage loginpage;
        public static Pages.CartItemsPage cartItemsPage;
        [SetUp]
        public void InitSetup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            homepage = new Pages.HomePage();
            loginpage = new Pages.LoginPage();
            cartItemsPage = new Pages.CartItemsPage();
        }
        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }

    }
}
