Feature: LoanApplication
	In order to avoid silly mistakes
	As an applicant to a loan
	I want to apply for a online loan
	So I get a decision on money being lent or not

	And to view online the progress of my application

@LoanApplication
Scenario: Apply for a loan
	Given The Loan Type with basic configuration is already configured
	And I am logged as an applicant into LAP
	And I chose the basic configuration template to fill
	When I fill the form and submit to the server with amount 20 pounds
	Then request should be tramitted successfully
	And I should see a warning telling that the request was submitted succesfully
	
@CheckStatusLoan
Scenario Outline: Check the status of the application days later
	Given The Loan Type with basic configuration is already configured
	And I am logged as an applicant into LAP
	And I chose the basic configuration template to fill
	And I filled the form and submit to the server with amount <Amount> pounds
	And the Score Unit has already been provided from a third paty Score System a score to the loan application
	And The loan engine analyzed it
	When I check the status of the application several days later
	Then the status should be <ScreenStatus>

	Examples:
	| Amount | Status    | ScreenStatus |
	| 20     | approving | approved     |
	| 20000  | denying   | denied       |