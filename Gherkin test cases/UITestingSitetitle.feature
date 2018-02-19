Feature: "UI Testing Site" title for every page

Scenario: Check title of "Home" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Home' menu button
Then the title of the page is 'UI Testing Site'

Scenario: Check title of "Form" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Form' menu button
Then the title of the page is 'UI Testing Site'

Scenario: Check title of "UI Testing" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'UI Testing' menu button
Then the title of the page is 'UI Testing Site'