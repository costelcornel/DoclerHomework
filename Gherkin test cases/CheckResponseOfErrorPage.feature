Feature: Validate the "Error" page

Scenario: Check the response of "Error" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Error' menu button
Then the page response is a 404 HTTP response code