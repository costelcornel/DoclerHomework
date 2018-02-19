Feature: Validate the Home page and elements

Scenario: Check the text of <h1> element from "Home" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Home' menu button
Then the 'Welcome to the Docler Holding QA Department' text is visible on the opened page

Scenario: Check the text of <p> element from "Home" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Home' menu button
Then the 'This site is dedicated to perform some exercises and demonstrate automated web testing.' text is visible on the opened page

Scenario: Check the "Home" page status
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Home' menu button
Then the value of 'status' attribute of the menu button is 'active'