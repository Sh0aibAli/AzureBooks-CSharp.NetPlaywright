using Microsoft.Playwright;
namespace PlaywrightTests.Pages;
public class LoginPage
{
    private IPage _page;
    public LoginPage(IPage page) => _page = page;                //_page is the Instance of class LoginPage.cs

    //Declaration of Locators
    private ILocator _txtUserName => _page.Locator("#mat-input-0");
    private ILocator _txtPassword => _page.Locator("#mat-input-1");
    private ILocator _btnLogin => _page.Locator("(//*/span[text()='Login'])[2]");
    private ILocator _loginHeader => _page.Locator("//h3[text()='Login']");
    private ILocator _alertMessage => _page.Locator("#mat-error-0");


    //Action Methods
    public async Task Login(string username, string password)                                //Enter the login Credentials
    {
        await _txtUserName.FillAsync(username);
        await _txtPassword.FillAsync(password);
        await _btnLogin.ClickAsync();
    }
    public async Task<bool> LoginHeader() => await _loginHeader.IsVisibleAsync();           //Verify that login header is visible
    public async Task<bool> AlertMessage()                                                  //Verify that Alert message is visible
    {
        Console.WriteLine("The " + await _alertMessage.TextContentAsync());
        return await _alertMessage.IsVisibleAsync();
    }
}