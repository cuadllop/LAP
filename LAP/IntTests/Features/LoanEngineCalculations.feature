Feature: LoanEngineCalculations
	In order to avoid silly mistakes
	As the Loan Engine
	I want to be able to approve the loan or not
	based on the credit score&loan amount 
	So that I can refer it to the underwriter decision or not

	The Loan Engine implemented has the following logic:
	1. It sends the loan request to the Score Driver configured (currently only one)
	2. If the score is higher than 5, the application gets Approved
		otherwise, the application gets Pending status

@LoanEngineCalculation
Scenario: Loan Engine approves a loan application
	Given The Loan Type with basic configuration is already configured
	And I am logged as an applicant into LAP
	And I chose the basic configuration template to fill
	And I filled the form and submit to the server with amount 20 pounds
	And the Score Unit has already been provided from a third paty Score System a score to the loan application
	When The loan engine analyzes it
	Then the application must be approved

@LoanEngineCalculation
Scenario: Loan Engine denies a loan application
	Given The Loan Type with basic configuration is already configured
	And I am logged as an applicant into LAP
	And I chose the basic configuration template to fill
	And I filled the form and submit to the server with amount 20000 pounds
	And the Score Unit has already been provided from a third paty Score System a score to the loan application
	When The loan engine analyzes it
	Then the application must be denied
