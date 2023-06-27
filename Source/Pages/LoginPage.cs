using Microsoft.Playwright;
namespace Playwright_CSharp_Dotnet.Source.Pages;
public class LoginPage
{
    private IPage _page;
    public LoginPage(IPage page) => _page = page;                //_page is the Instance of class LoginPage.cs
    ReadJson json = new ReadJson();
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

     public async Task Login()                                //Enter the login Credentials
    {
        await _txtUserName.FillAsync(json.ReadData("validUserName"));
        await _txtPassword.FillAsync(json.ReadData("validPassword"));
        await _btnLogin.ClickAsync();
        Thread.Sleep(5000);
    }
    public async Task<bool> LoginHeader() => await _loginHeader.IsVisibleAsync();           //Verify that login header is visible
    public async Task<bool> AlertMessage()                                                  //Verify that Alert message is visible
    {
        Console.WriteLine("The " + await _alertMessage.TextContentAsync());
        Thread.Sleep(5000);
        return await _alertMessage.IsVisibleAsync();
    }
}