Feature: UI_LoanTypeAdministration
	In order to avoid silly mistakes
	As the System Administrator of LAP
	I want to upload several types of Loan templates with diffent criteria

@Administration
Scenario: Add a new Loan type with basic configuration
	Given I am logged as a System Administrator of LAP
	When I enter a new Loan Type with Basic configuration
	Then the loan should be saved properly
	And I should see a warning telling that the loan type was saved


@Administration
Scenario: Add a new Loan type with additional fields 
	Given I am logged as a System Administrator of LAP
	When I enter a new Loan Type with Advanced configuration
	Then the loan should be saved properly
	And I should see a warning telling that the loan type was saved