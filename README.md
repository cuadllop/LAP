# LAP


LAP Application (Loan A Pound Application)

This application corresponds to the logic provided in the State of Work.

	1. Projects description
		The Solution has the following Projects:

		1. LAP
			It contains the application itself, a MVC web application.
			The render of webpages is MVVM oriented, using KnockoutJS as the render engine.

			All use of cases defined in the document have been developed.

			Apart of defining the web application (Views, Controllers, and Models, including the main operations for the models to be saved in DDBB) to complete required use cases,
			it also contains definitions of the service:
			- Service to launch Build Engine actions (calculate loan decission, and send email)
				/Services/LoanEngineService.cs
			Although the Loan Engine is a service inside the main application, inside it calls by reflection to a class name defined configuration resource

			Model definition has been created by using Entity Framework 6.0. From the schema provided, the database is created.
			In order to test this program in local, it is necesary to:
			1. Create a blank Database in local
			2. Check that connection strings configured in app.config of LAP Project are correct
			3. In SQL Server run the script available in "LAP\Models\Models.edmx.sql"
		
		2. LoanEngine		
			It implements the logic defined by the Service definition in LAP project
			It has been considered to do it his way to make easier to divide the logic of the service from the main application
	
			Each Loan Engine may define which is the Score Driver to use. In this case, it calls to a Fake Score driver library that returns a decision for each Loan request.
			It has been decided to use interface definition so integrations done with Score Third Parties are implemented in separate libraries.

			Post-Build event of the build process of this project is configured to copy the dll to bin folder of LAP Project.

		3. Score Drivers, ScoreDrivers\FakeScoreDriver
			It implements the logic defined by the Service definition in LAP project

			The purpose of each Driver is to  implement the integration with the Third Party Score Engine.
	
			Post-Build event of the build process of this project is configured to copy the dll to bin folder of LAP Project.	

		4. IntTests , TESTS\IntTests

			BDD Defined tests, by using Specflow Framework, testing the Controller layer. The development of this application began and finished by implementing and changing the definition and implementation of these tests.
			Before starting to code, I have analyzed the requirements and defined the main tests to be executed that assure the correct behaviour  of the system.

			Once defined: 
			- started implementing each one,
			- creating the Model of the application by using EF6.0 and the database as well
			- building the controllers by calling from tests

			Since the definition of the tests is writing in the domain language of the application, it is easy to follow each one (in BDD, this means that all use cases are defined until the test level).
			Features definition available here: TESTS\IntTests\Features

			In order to see highlighted Gherkin language, please install the plugin Specflow. From Visual Studio Menu, \Tools\Extensions and Updates\Search for Specflow

			After building the the solution, all the tests should appear on Visual Studio Test Explorer WIndow.

		5. UI_Tests, TESTS\UI_Tests

			In order to complement the previous project, it has been implemented tests attacking the UI Layer. 
			This is important, since there is business logic embebed in MVVM patters (decide what to hide, what to show, etc).

			BDD Defined tests, by using Specflow Framework. Implemented with Selenium, following to test the Web Application, following Page Model pattern.

			The definition of the tests was initially the same as for IntTest project. However, in order to ease the development, several tests have merged in one.

			Features definition available here: TESTS\UI_Tests\Features

		6. Endjin.SpecFlow.Selenium.Framework.Net45, TESTS\UTILS\Endjin.SpecFlow.Selenium.Framework.Net45

			This project is the base of UI_Tests, and OpenSource Selenium driven framework and easy to be defined by BDD pattern, developed by Endjin
			It should be referenced by nuget, currently for testing purposes, it is referenced as a Project.

	2. Requirements to run in local the Application

	Summing up, these are the main steps to run in local the solution:

		Model definition has been created by using Entity Framework 6.0. From the schema provided, the database is created.
		In order to test this program in local, it is necesary to:
		1. Create a blank Database in local
		2. Check that connection strings configured in app.config of LAP Project are correct
		3. In SQL Server run the script available in "LAP\Models\Models.edmx.sql"

		In order to see highlighter Gherkin language, please install the plugin Specflow. From Visual Studio Menu, \Tools\Extensions and Updates\Search for Specflow

		Features definition available here: TESTS\UI_Tests\Features
		Features definition available here: TESTS\IntTest\Features

	Needed software:
		1. Visual Studio 2013 or later
		2. SQL Server 2008R2 or later
		3. Specflow plugin installed in Visual Studio
		4. "Nunit 3 Adapter" plugin installed in Visual Studio (in order to see Nunit generated tests in the Test Explorer Window of Visual Studio)