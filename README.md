# PlaywrightAI

This project is a sample automation framework using Playwright, SpecFlow, C#, and NUnit. It demonstrates BDD with SpecFlow, browser automation with Playwright, API testing, and test organization using the Page Object Model.

## Structure
- **PlaywrightAI.Core**: Page objects and core logic
- **PlaywrightAI.Tests**: NUnit tests
- **PlaywrightAI.Specs**: SpecFlow feature files and step definitions

## How to Run
1. Restore dependencies: `dotnet restore`
2. Build the solution: `dotnet build`
3. Run all tests: `dotnet test PlaywrightAI.Specs/PlaywrightAI.Specs.csproj`

## Running with Filters and Parallelism
- **Run only UI scenarios (tagged @UI):**
  ```
  dotnet test PlaywrightAI.Specs/PlaywrightAI.Specs.csproj --filter "Category=UI"
  ```
- **Run only API scenarios (tagged @API):**
  ```
  dotnet test PlaywrightAI.Specs/PlaywrightAI.Specs.csproj --filter "Category=API"
  ```
- **Run with custom parallelism (e.g., 2 workers):**
  ```
  dotnet test PlaywrightAI.Specs/PlaywrightAI.Specs.csproj --filter "Category=UI" -- NUnit.NumberOfTestWorkers=2
  ```
  (You can use `Category=API` or `Category=UI` or omit the filter to run all.)

## Sample Scenarios
- Launches www.google.com and verifies the page title (UI)
- Launches www.amazon.com and verifies the page title (UI)
- Calls the Petstore API and verifies the response (API)

## Test Reports
NUnit and SpecFlow generate test results in the output directory after running tests.

### LivingDoc (SpecFlow+ LivingDocPlugin)
- After running your tests, a LivingDoc HTML report is generated at the root of the project as `LivingDoc.html`.
- This report shows your feature files, scenarios, and steps in a Cucumber-style (Gherkin) format.
- **Note:** When using NUnit, LivingDoc will only show the feature/scenario structure, not the execution results (pass/fail), due to current SpecFlow+ limitations. To see execution results in LivingDoc, you must use SpecFlow+ Runner or a compatible CI integration.
- To view the report, open `LivingDoc.html` in your browser.

Other test results (such as `.trx` files) are available in the `PlaywrightAI.Specs/TestResults/` directory.

## Framework Responsibilities
| Capability         | Framework/Package Used                | Notes/Limitations                                                                 |
|-------------------|--------------------------------------|-----------------------------------------------------------------------------------|
| **BDD**               | SpecFlow                             | Feature files in Gherkin syntax, step definitions in C#                            |
| **Test Runner**       | NUnit                                | Parallelism and filtering supported; works with .NET 9                             |
| **UI Automation**| Microsoft.Playwright                 | UI automation via Playwright C#                                                    |
| **API Testing**       | Microsoft.Playwright (APIRequest)    | API scenarios supported in step definitions                                       |
| **Reporting**         | SpecFlow.Plus.LivingDocPlugin        | LivingDoc HTML report (Cucumber-style). **Limitation:** With NUnit, execution results (pass/fail) are NOT shown. LivingDoc does NOT support execution results for .NET 9 or NUnit. Use SpecFlow+ Runner and .NET 6/7/8 for full reporting. |

## Notes
- Parallelism is set in `AssemblyInfo.cs` but can be overridden at runtime with the `NUnit.NumberOfTestWorkers` option.
- Use tags (`@UI`, `@API`) in your feature files to organize and filter tests.
- **Reporting Limitation:** LivingDoc HTML report generated with SpecFlow.Plus.LivingDocPlugin and NUnit will only show feature/scenario structure, not execution results (pass/fail), especially on .NET 9. For execution results in LivingDoc, use SpecFlow+ Runner and .NET 6/7/8.

---

## Credits
This project was created by kothasumanth.
