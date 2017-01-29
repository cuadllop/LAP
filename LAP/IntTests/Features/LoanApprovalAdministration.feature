Feature: LoanApprovalAdministration
	In order to avoid silly mistakes
	As an underwriter, 
	I want to see a queue of pending applications
	so that I can approve or reject them

@ApprovalAdministration
Scenario Template: Underwriter approves the decision made by the Loan Engine
	Given The Loan Type with <LoanTypeName> is already configured
	And I am logged as an applicant into LAP
	And I chose the <LoanTypeName> template to fill
	And I filled the form and submit to the server with amount <amount> pounds
	And the Score Unit already has already been provided from a third paty Score System a score to the loan application
	And The loan engine analyzed it
	And The loan got <LoanEngineDecision> status
	And I am logged as an underwriter into LAP
	When I <UnderWriterDecision> all the requests
	Then The Loan Engine must send a mail to the customer telling the request was <MailTemplate>

	Examples:
	| LoanTypeName        | amount | LoanEngineDecision | UnderWriterDecision | MailTemplate |
	| basic configuration | 20000  | denied             | deny                | denied       |
	| basic configuration | 20000  | denied             | approve             | approved     |
	| basic configuration | 20     | approved           | deny                | denied       |
	| basic configuration | 20     | approved           | approve             | approved     |

