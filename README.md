# Luciano Ciotola TechTest
Hello, I'll leave the explanation of everything done in the project with the following questions answered as well:
1 - What things would you have liked to do but didn't do?
2 - What things did you do but you think could be improved or would be necessary to return to them if the project goes ahead?
3 - What third-party libraries have you used and why.
4 - How much time have you invested in doing the project, what things you have had to research, and what things were new to you?

	The project adheres to the requirements for clean code, thorough testing, and .NET Core standards. 
	It emphasizes readability, maintainability, and extensibility through proper abstractions and error handling.
	The testing approach ensures that the code is correct and serves as a self-explanatory guide to the program's functionality.

Both the testing and the main project are left with a blank .cs file in case specific tests need to be run.

1 - What things would you have liked to do but didn't do?

	* Logging: Proper logging helps in debugging and monitoring the application. 
	Using a logging library like Serilog or NLog would provide better insights into the application�s behavior and issues.

	* Exception Handling and Custom Exceptions: Creating custom exceptions for specific error scenarios improves code readability and error handling.

	* More Robust Testing: Adding more extensive test cases, including edge cases and stress tests, ensures the application can handle a variety of scenarios.

2 - What things did you do that could be improved or would be necessary to return to them if the project goes ahead?

	*  If the project moves ahead, these should be replaced with persistent storage solutions like SQL databases or NoSQL databases. 
	The repository interfaces already provide a good abstraction for this transition.

	* Introduce global exception handling mechanisms and more specific custom exceptions.

	* Increase the breadth and depth of test cases to cover more scenarios and edge cases.

	* Implement a more user-friendly error handling and feedback system, possibly with error codes and localized messages.

3 - What third-party libraries have you used and why?

	*  Moq: Moq is a popular mocking library for .NET that allows you to create mock objects and set up expectations on method calls.
	It's used in the tests to mock the behavior of repository interfaces and isolate the service logic.

	* xUnit: xUnit is a free, open-source, community-focused unit testing tool for .NET. It is used to write and run tests.

4 - How much time we have invested in doing the project what things you have had to research and what things were new to you.

	Regarding how much time was invested in the project, between coding and testing around 2 days. 
	As for the things that I had to investigate, xUnit and Moq were new to me.
	The creation of test cases, dobles, test setup, and most test-related coding.
