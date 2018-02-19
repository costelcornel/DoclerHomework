Feature: Validate the Form page and it's elements

Scenario: Check the input box from "Form" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Form' menu button
Then a single input txt field is visible on the opened page

Scenario: Check the 'Go' button from "Form" page
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Form' menu button
Then a single 'Go' button is visible on the opened page

Scenario: Check the "Form" page status
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Form' menu button
Then the value of 'status' attribute of the menu button is 'active'

Scenario: Validate if user land on the "Form" page 
Given The user open the http://uitest.duodecadits.com/ site
When the user clicks on 'Form' menu button
Then the text 'Simple Form Submission' should be visible on the page

  Scenario: Check the Hello page funtionality
    Given The user user clicks on 'Form' menu button
     And the user is typing <value> in the input field
     When clicks on 'Go' button
     Then the user is redirect to Hello page and the following text should appear <result>
     
      | <value> | <result> |
      | John | Hello John! |
      | Sophia | Hello Sophia! |
      | Charlie | Hello Charlie! |
      | Emily | Hello Emily! |


