# MembersRegistration
This project must be done in ASP.NET with MVC 5.0. 
 While creating the controller, implement Custom Controller Factory for maintaining 
SessionStateBehavior.
 Implement – Dependency Injection for classes.
Create 2 types of roles
1. Admin:- Should be able to use create and search options(Note by default have one admin user 
and password initially.)
2. Applicant: - Should be able to use only create option.
(DB table must contain Username,Emailid,Password,Usertype, depending on which user has 
logged in, should open the application)
First time the applicant should register with Username,Emailid,Password and confirmPassword.
Once it is registered, should be able to login 
Screen 1: Home Page (Admin)
1. The home page of the application would look like above
2. When User clicks on Create application button he will be redirected to Create Application Page
3. When User Clicks on Search Application Button he will be redirected to Search Application Page
Screen 1: Home Page (Applicant)
Screen 2: Household Info 
Do not save the data into database when “add Member” is clicked. Must use the session variables to 
store those details 
This screen allows the user to capture the Family member details and is expected to enter the head of 
the family as the 1st member. 
 Key features of the screen:
a. The user should be able to add 1 member at a time and can proceed to other member 
only after mandatory fields of the earlier member have been completed
b. The user should be able remove an already added member
c. User should not be able to Save & Exit after entering partial data
 i. User should be able to Save & Exit after he completes 
entering at-least 1 member and all mandatory checks for this member 
 ii. User should NOT be able to Save & Exit if he does not 
enter all mandatory fields for any member on the screen
d. If the user comes back to this screen it should be prepopulated with previously saved 
data
e. Application number should be generated only after user has clicked “Save & Exit” or and 
when there are no validation errors.
f. Each time user has to enter a new member, the user must click on “Add Member”
g. Once the user enters all member the user must click on “Next” to go to Relationship 
screen.
h. When the user enter few family member details, and click on “Save & Exit” an 
Application number must be generated, and later if the user search the application 
number it must populated the family member details and should allow us to continue 
entering remaining family member details.
 
Add Member: - When user clicks add member he would be able to add another member and additional 
grid containing the First Name ,Last Name.MI,Suffix, DOB and Gender is populated below.
Validation Rules
a. Name text boxes should allow “alphabets”, special character’s “*, -, ‘“
b. Length of name cannot be more than 32
c. Age should be numeric and cannot be more than 125 years
d. Age of every member should be less than the Age specified for 1st member
e. Family cannot have more than 5 members
f. First Name ,Last Name, DOB,Gender are mandatory fields.
 Navigation Rules
a. User once he clicks “Save & Exit” should be taken to Home screen
b. User once he clicks “Back” should be taken to Home Screen
c. User once he clicks “Next” should result in saving of all data and user should be taken to 
Relationship screen 
Screen 3: Relationship Info screen
This screen allows the user to capture the relationships between the entered Family members and is 
used to specific relationship of each member with the other member. 
Key features of the screen:
a. The user should be able to specify relationship of 1 member at a time add 1 member at a 
time and can proceed to other member only after mandatory fields of the earlier member 
have been completed
b. User should be able to Save & Exit from the screen 
c. If user comes back to the screen it should be pre-populated with previously saved data
Validation Rules:
a. Relation values are limited to “Father”, “Mother”, Son”, “Daughter”
b. User should be able to specify relationships in the order in which the Family members 
are added
c. User should not be able to click a different tab without completing the mandatory fields 
on the current tab
d. User should not be able to edit relationship if it is derived based on the value specified 
on other screen
Navigation Rules:
a. User once he clicks “Save & Exit” should be taken to Search application screen
b. User once he clicks “Back” should be taken to Household Info screen
c. User once he clicks “Submit” should result in data being saved and should be taken to 
Confirmation screen 
Screen 3: Confirmation Screen
After submitting the application, the user should be able to down load the receipt with 
ApplicationId and Family details with relations.
Use MessageContract with all the details of the family. Send the details client.
Client should be able to download the file in the form of PDF.
Note:- When the user clicks on Save and Exit. It must call a WCF service method and the save the 
Family members details into the database, and return the Application number. The application should 
not be connected to database. It should be done only through WCF service only. 
The Application must be developed using MVC Framework. For the saving, retrieving and any other 
database operations must be done using Entity Framework.
Where ever required use the session variables/cookies 
Screen 4: Search Application
This screen allows the user to search for already submitted application to view/make changes to it. 
Key features of the screen:
a. The user should be able to search by “First Name”, “Last Name”, “DOB”, “Application 
ID”, “Application Status” [should act as an And search]
b. Search Functionality
i. At-least 1 search condition is mandatory
ii. The user should be able see all application in the system in the form of table in 
bottom portion
iii. The user should be able to sort by any column [Non CS guys should be ajax 
based client side sorting]
iv. The user should be able to see 5 records per page
v. The search result should support pagination [Non CS guys should be client side 
pagination]
vi. The search result should allow user to View/Edit the application in the result set
vii. The search should not return more than 100 records and if more than 100 
records are present
viii. It should display message that says please refine your search criteria, more than 
100 results are found
c.
2. Navigation Rule
 User once he clicks “View/Edit” should be taken to Household Screen for the selected 
Application Id
Note:- When the user clicks on Search button after making appropriate selection. It must call a WCF 
service method and return all the Family members details from the database. The application should 
not be connected to database. It should be done only through WCF service only. 
