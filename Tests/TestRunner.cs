using Microsoft.Playwright;
using Playwright_CSharp_Dotnet.Pages;
namespace Playwright_CSharp_Dotnet;

public class TestRunner
{       
    [Test]
    public async Task Login_Should_Not_Be_Success()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser Headed Mode
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        //Page
        var page = await browser.NewPageAsync();
       
        //Declaration of Classes
        var homePage = new HomePage(page);
        var loginPage = new LoginPage(page);

        //Test Execution Flow steps
        await homePage.LaunchUrl();
        await homePage.ClickLogin();                                        //Click on the login button on the top right
        await loginPage.Login("prekksha", "Pass1234");                         //Enter the credentials on the login page

        Assert.IsTrue(await loginPage.AlertMessage());                      //Verify that incorrect cresentials message is visible.
    }

    [Test]
    public async Task Login_Should_Be_Success()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser Headed Mode
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        //Page
        var page = await browser.NewPageAsync();

        //Declaration of Classes
        var homePage = new HomePage(page);
        var loginPage = new LoginPage(page);

        //Test Execution Flow steps
        await homePage.LaunchUrl();
       
        await homePage.ClickLogin();                                     //Click on the login button on the top right
        await loginPage.Login();                                         //Enter the valid credentials on the login page

        await homePage.EnterBookNameAndSelect("Roomies");                //Enter the book name in the search bar
        await homePage.AddToCartButton();                                //Add Book to the Cart

        var isNonZero = await homePage.CartCountIsNotZero();             //Creating a variable for the assertion
        Assert.IsTrue(isNonZero);                                        //Verify that cart number is greater than zero

        await homePage.ClickLogOut();                                    //Click on the Logout Button
        Assert.IsTrue(await loginPage.LoginHeader());                    //Verify that the User lands on the Login Page
    }
}