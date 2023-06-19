using Microsoft.Playwright;
using PlaywrightTests.Pages;
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
        await page.GotoAsync(url: "https://bookcart.azurewebsites.net/");


        //Declaration of Classes
        var homePage = new HomePage(page);
        var loginPage = new LoginPage(page);

        //Test Execution Flow steps
        await homePage.ClickLogin();                            //Click on the login button on the top right
        await loginPage.Login("saifi", "Pass1234");             //Enter the credentials on the login page

        Assert.IsTrue(await loginPage.AlertMessage());          //Verify that incorrect cresentials message is visible.
        Thread.Sleep(5000);
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
        await page.GotoAsync(url: "https://bookcart.azurewebsites.net/");


        //Declaration of Classes
        var homePage = new HomePage(page);
        var loginPage = new LoginPage(page);

        //Test Execution Flow steps
        await homePage.ClickLogin();                            //Click on the login button on the top right
        await loginPage.Login("ortoni11", "Pass1234");          //Enter the credentials on the login page
        Thread.Sleep(5000);

        await homePage.EnterBookName("Roomies");                //Enter the book name in the search bar
        await homePage.SelectBook();                            //Select the book
        await homePage.AddToCartButton();                       //Add Book to the Cart
        Thread.Sleep(5000);

        var isNonZero = await homePage.CartCountIsNotZero();         //Creating a variable for the assertion
        Assert.IsTrue(isNonZero);                               //Verify that cart number is greater than zero

        await homePage.ClickLogOut();                           //Click on the Logout Button
        Thread.Sleep(5000);
        Assert.IsTrue(await loginPage.LoginHeader());           //Verify that the User lands on the Login Page
    }
}