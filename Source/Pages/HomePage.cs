using Microsoft.Playwright;
namespace Playwright_CSharp_Dotnet.Source.Pages;
public class HomePage 
{
    private IPage _page;
    public HomePage(IPage page) => _page = page;                //_page is the Instance of class HomePage.cs
    ReadJson json = new ReadJson();

    

    //Declaration of Locators
    private ILocator _lnkLogin => _page.Locator("text=Login");
    private ILocator _searchBar => _page.Locator("//*[@type='search']");
    private ILocator _bookIem => _page.Locator("//*[text()=' Roomies ']");
    private ILocator _addToCart => _page.GetByRole(AriaRole.Button, new() { Name = "Add to Cart" });
    private ILocator _cartCount => _page.Locator("#mat-badge-content-0");
    private ILocator _userDropDown => _page.Locator("//button/*/*[text()='arrow_drop_down']");
    private ILocator _lnkLogout => _page.GetByRole(AriaRole.Menuitem, new() { Name = "Logout" });



    // Action Methods
    public async Task ClickLogin() => await _lnkLogin.ClickAsync();                                 //Click on Header Login
    public async Task EnterBookNameAndSelect(string bookname)
    {
        await _searchBar.FillAsync(bookname);       //Enter the book name in the search bar
        await _bookIem.ClickAsync();
    }
    public async Task AddToCartButton()
    {
        await _addToCart.ClickAsync();                           //Click on Add to cart Button
        Thread.Sleep(1000);
    }

    public async Task LaunchUrl() => await _page.GotoAsync(json.ReadData("url"));
    public async Task<bool> CartCountIsNotZero()                                                    //Verify that cart count is not zero
    {
        string cartCount = await _cartCount.TextContentAsync();
        Console.WriteLine("There are " + cartCount + " books added in the cart.");
        int num = Int32.Parse(cartCount);
        return num > 0;
    }
    public async Task ClickLogOut()                                                                 //Click on the Logout button
    {
        await _userDropDown.ClickAsync();
        await _lnkLogout.ClickAsync();
    }
}