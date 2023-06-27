# AzureBooks-CSharp.NetPlaywright
This is the basic project of C#,Selenium and Playwright. I have tried to build a framework based on Page Object Model

## Technology Used
```
  1. C#
  2. .Net
  3. Playwright 
  4. Selenium
  5. Visual Studio
```


## Detailed explanation on Automation Framework
## How To Run
```
Using Visual Studio
1. Open the folder in VS Code
2. After Successful build, Go to TestRunner.cs class inside Tests folder.
3. To Run all tests, select the Run All Tests button above the TestRunner class inside the code.
5. To Run single test , Select the Run Test button above the test method defined in the class TestRunner.cs
```

## Using Terminal
Run command - 
```
dotnet test
```

### Framework type: Page Object Model using Playwright

Contains  UI tests


### Project Structure
Source:- Consist of Pages Package

Pages:-
Contains locators of objects involved in pages of website and their action methods.

Tests:-
This package contains all tests.

Utilities:-
This package contains Json Reader.


## Test generator
## Generate tests with the Playwright Inspector

Use the codegen command to run the test generator followed by the URL of the website you want to generate tests for. The URL is optional and you can always run the command without it and then add the URL directly into the browser window instead.

```
bin/Debug/net7.0/playwright.ps1 codegen google.com
```
Using Playwright Inspector window you can record the steps while performing the events on the Browser window.
