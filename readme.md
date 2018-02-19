# Docler UITesting homework

This project is meat to test the http://uitest.duodecadits.com/ website using the latest Chrome. This automation project is using Page Object Design pattern.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for testing purposes.

### Prerequisites

What things you need to open the project and how to run the tests.

```
Microsoft Visual Studio (version 2012 minimum)
.Net Framework 4.5 installed 
Chrome Browser Install on local workstation 
```

## Running the tests

1. Download the project
2. Open Microsoft Visual Studio
3. Open the DoclerUITesting.sln solution in visual studio
4. Build the solution
5. Open Test Explorer window (Choose Tests on the Visual Studio menu and then choose Windows -> Test Explorer)
6. Run automated tests:

To run all the tests in a solution, choose Run All.

To run all the tests in a default group, choose Run... and then choose the group on the menu.

Select the individual tests that you want to run, open the context menu for a selected test and then choose Run Selected Tests.

### Break down into end to end tests

If a page was loaded that means the page status was verified as beeing active. If the loading page fails, the status of the page was not changed as 'active'.

After the tests succesfully run, you can find in the solution path the 'Logs' directory to see what was tested and what test failed.

```
Example of log file:
[INFO] -  ######   START -> CheckStatusOfFormPage    ########## 
[INFO] - ----------------------------------------------------------------------------------------
[INFO] -       -> Home page was loaded.
[INFO] -       -> Form page was loaded.
[INFO] -  ######   -END -> CheckStatusOfFormPage    ########## 
```

## Authors

* **Juncanariu Cornel** -

