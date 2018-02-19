Feature: Company logo is visible on every page

Scenario: Look up for company logo on "Home" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Home' menu button
Then the company logo is visible on the opened page

Scenario: Look up for company logo on "Form" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Form' menu button
Then the company logo is visible on the opened page

Scenario: Look up for company logo on "UI Testing" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'UI Testing' menu button
Then the company logo is visible on the opened page