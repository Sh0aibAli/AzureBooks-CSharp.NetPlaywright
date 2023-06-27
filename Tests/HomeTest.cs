using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM_Basic.Source.Drivers;
using POM_Basic.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
namespace POM_Basic.Tests
{
    [TestFixture]
    public class HomeTest :Driver
    {
        //private IWebDriver _driver;

        [Test]
        public void SearchBook()
        {

            HomePage homePage = new HomePage();
            homePage.LaunchUrl();
            Assert.True(_driver.Title.Contains("BookCart"));
        }
        
        [Test]
        public async Task Clear_The_Cart()
        {

            //Test Execution Flow steps
            homepage.LaunchUrl();

            await homepage.Click_On_Login_Button();                                     //Click on the login button on the top right
            await loginpage.Login_With_Correct_Credentials();                                         //Enter the valid credentials on the login page

            Assert.IsFalse(homepage.Cart_Count_Is_Zero());


            var isNonZero = homepage.CartCountIsNotZero();             //Creating a variable for the assertion
            Assert.IsTrue(isNonZero);                                        //Verify that cart number is greater than zero

            await cartItemsPage.ClickOnCart();
            Assert.IsTrue(cartItemsPage.CartItemsHeader());

            cartItemsPage.ClickOnClearCart();

            Assert.IsTrue(cartItemsPage.Shopping_Cart_Is_Empty_Header_Is_Visible());

            cartItemsPage.Click_On_Continue_Shopping_Button();
            Assert.IsTrue(homepage.Cart_Count_Is_Zero());

            await homepage.ClickLogOut();                                    //Click on the Logout Button
            Assert.IsTrue(loginpage.LoginHeader());                    //Verify that the User lands on the Login Page
        }
    }
}
