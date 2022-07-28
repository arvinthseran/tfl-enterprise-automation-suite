[![Build Status](https://seraninfotech.visualstudio.com/BubbaSolution/_apis/build/status/arvinthseran.tfl-enterprise-automation-test-suite?branchName=journeyplanner_tests)](https://seraninfotech.visualstudio.com/BubbaSolution/_build/latest?definitionId=2&branchName=journeyplanner_tests)

# tfl-enterprise-automation-suite

This is a SpecFlow-Selenium functional UI testing framework created using Selenium WebDriver with NUnit and C# (.Net core) in SpecFlow BDD methodology and Page Object Pattern.

## Prerequisites to run the application:
1. Visual Studio (2022 with V17.2 or higher)
2. Browsers (Chrome or Firefox)

## Framework:

```Tfl.ConfigurationBuilder``` project is responsible for constructing configs from multiple json files.
 - User secrets are used for sensitive test data

```Tfl.Framework``` project is responsible for supporting test execution.
 - Support for Chrome and Firefox
 - Support for screen shots 
 - Support for both local (dev machine) and cloud (Azure devops) execution
 
## SpecFlow Tests:
```Tfl.JourneyPlannerTests:``` 
 - Acceptance tests are written in feature files under ```/Tests/Features/``` folder using standard Gherkin language using Given, When, Then, But format with an associated step definition for each test step. Test steps in the scenarios explains the business conditions/behaviour and the associated step definition defines how the scenario steps are automated.
 - Support for parallel execution

## Build and Release process:

### Build 
Every commit made (merge to master or a push to remote branch) will trigger a build process under `arvinthseran.tfl-enterprise-automation-test-suite` pipeline.

### Release 
Every release pipeline would be picking up the build artifact from `arvinthseran.tfl-enterprise-automation-test-suite` build

## Parallel Test Execution Limitations:

This framework supports Feature Level parallelization (tests under different feature file will run in parallel) not Scenario Level parallelization (tests under same feature file will not execute in parallel).

## Latest test execution results
![image](https://user-images.githubusercontent.com/11176423/181393084-13b88905-3a29-4ce1-a60d-7366e08c2153.png)

