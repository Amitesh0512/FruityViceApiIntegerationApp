# FruityViceApiIntegerationApp

This is a simple C# console application that integrates with the Fruityvice API to retrieve a list of fruits by family name.

## Getting Started

To get started with this application, you'll need to have [.NET Core](https://dotnet.microsoft.com/download) installed on your machine.

1. Clone this repository to your local machine using `git clone https://github.com/Amitesh0512/FruityViceApiIntegerationApp.git`.
2. Open the solution file `FruityviceApiIntegration.sln` in your preferred IDE (e.g. Visual Studio or VS Code).
3. Build the solution to restore any necessary packages and compile the application.
4. Run the application using the debugger or from the command line.

## Usage

When you run the application, it will retrieve a list of fruits from the Fruityvice API based on the specified fruit family name.

To change the fruit family name, modify the `fruitFamily` variable in the `Main` method of the `Program` class in the `Program.cs` file.

## Endpoints

This application implements the following endpoints:

- `GET /api/fruit`: Returns a list of all fruits.
- `POST /api/fruit/family/:family`: Returns a list of all fruits belonging to a fruit family.

## Error Handling

This application includes basic error handling for HTTP requests and JSON deserialization errors. If an error occurs during the request or deserialization process, an error message will be printed to the console.

## Tests

This application includes unit tests and integration tests. To run the tests, open the Test Explorer in Visual Studio or run the `dotnet test` command from the command line.

## License

This application is licensed under the [MIT License](https://opensource.org/licenses/MIT).
