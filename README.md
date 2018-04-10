# AGL Challenge

AGL Challenge Application demonstrating patterns and practices that I would use to design an application.

### Application Structure
The Application is structured as follows:
Main App is in /App
Services are in /App.Domain
Tests are in /Tests

### Tech Stack
Tech stack used is dotnet core 2.0

### Run the App
- Go to the main app folder /app
- type the following commands
- dotnet restore
- dotnet build
- dotnet run
- if the commands have executed sucessfully, local server will be rnning on localhost:5000

### Run the Tests
- At the moment, there's some problem so .sln file will give erros while runnning tests
- goto unit tests directory /Test/UnitTests
- type dotnet test
- check the results
- goto functional tests directory /Test/FunctionalTests
- type dotnet test
- dotnet build
- check the results