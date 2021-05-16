# Basic Monthly Premium Calculator application built using .NET Core with React
An basic monthly premium calculator project using C#, .NET Core, React, JavaScript, Materail-ui, HTML5, CSS3, xUnit.net, Moq and InMemoryDatabase for more efficient unit testing.

Application is hosted in Azure - Pending

## Table of contents
<!--ts-->
   * [Application Screenshots](#application-screenshots)
   * [Installation](#installation)
   * [Features](#features)
   * [Application Results](#application-results)
	 * [Application User Stories](#application-user-stories)
	 * [Test Data](#test-data)
<!--te-->

## Application Screenshots
- Monthly Premium Screen - Basic screen to calculate Monthly Premium based on user input
![Monthly Premium Screen]()

## Installation
**Steps of installation**
- Import project into Visual Studio (or alternative IDE Visual Studio Code)
- Build the Whoel Monthly Premium Solution, it will resolve backend and forntend dependencies. VS code need to have install depencies manually or use command "dotnet build" in terminal of the Web Project path.
- Select the Web Project as the startup Project 
- Run the Application (Visual Studio - preferably VS 2019 Community edition). VS code use "dotnet run"


## Features
**Monthly Premium Calculator feature**
- Screens - Monthly Premium.
- Built 5 different projects libraries
- Web - responsible for the UI (i.e Client application - React SPA, Materail-UI) coordinated by controllers which execute around 2 different User stories.
- Domain - This is the Domain centric with no implementation and just Entities.
- Services - Application Service layer which implements contracts and abstracts calls to Repository layer.
- Repository - A Persitence layer with the idea of abstracting the data access concerns and option to use preferred data access technology. 
- Tests - Unit Test using xUnit.net, Moq and InMemoryDatabase for more efficient unit testing and used TestHost for TestFixture. Unit test for React app is pending.
- Application deployed in Azure (Pending) 

## Application Results
Application structure results in following:
- Independent of Frameworks - Core should not be dependent on external frameworks such as Entity Framework
- Testable - The logic within Core can be tested independently of anything external, such as UI, databases, servers. Without external dependencies, the tests are very simple to write.
- Independent of UI - It is easy to swap out the Web UI for a Console UI, or Angular for Vue. Logic is contained within Core, so changing the UI will not impact logic.
- Independent of Database - You might choose SQL Server or Oracle, but as of now am using InMemoryDatabase for more efficient unit testing
- Independent of anything agency - Core simply doesn't know anything about the outside world

## Application User Stories
### User Story 1:
- As a Member I would like to have an ability to choose various options on the screen So that I can view the monthly premiums calculated and displayed on the screen
	Acceptance Criteria:
	1. User can input all the values like Name, Date of Birth (DOB), Death Sum Insured and Occupation. For MVP, there is no upper limit	the Sum Insured.
	2. When User should be allowed DOB right from age 1 to till 120 years.
	3. User can input any amount of Sum Insured with no upper limit

### User Story 2:
- User is provided with very selective Occupations and based on those occupations there are Rating and Factors to calculate the monthly Premium, based on Test Data shown (TestData Image) at the bottom
	1. Once the user selects Occupation along with other valid inputs and submits Calculate button
		Given User selects "Doctor" as occupation 
		When User clicks Calculate button 
		Then In the backend the Doctor's rating i.e Professional and Factor of 1.0 teh calulation is done
    When All input is validated the formula used is "Death Premium = (Death Cover amount * Occupation Rating Factor * Age) /1000 * 12"
    Then The calculated premium is return ed back to UI to user 


## Test Data
- All User stories are based on this test data and application is built using this test data
![TestData]()
		     


