# GloboTicket ASP.NET Core Microservices Sample Application

GloboTicket is a sample ASP.NET Core Microservices application that you can learn about in the Pluralsight <a href="https://app.pluralsight.com/paths/skills/net-microservices">.NET Microservices Learning</a> path. This path consists of the following courses:

| Title | Author | level | length | date |
| :---- | :----- | :---- | :----- | :--- |
| <a href='https://app.pluralsight.com/library/courses/microservices-big-picture/'>Microservices: The Big Picture</a>|Antonio Goncalves|Beginner|1h 45m|Apr 16, 2018|
| <a href='https://app.pluralsight.com/library/courses/getting-started-asp-dot-net-core-microservices/'>ASP.NET Core 3 Microservices: Getting Started</a>|Roland Guijt|Beginner|1h 21m|Sep 24, 2020|
| <a href='https://app.pluralsight.com/library/courses/microservices-communication-asp-dot-net-core'>Microservices Communication in ASP.NET Core 3</a>|Gill Cleeren|Intermediate|3h 16m|Sep 30, 2020|
| <a href='https://app.pluralsight.com/library/courses/implementing-data-management-strategy-asp-dot-net-core-microservices-architecture'>Implementing a Data Management Strategy for an ASP.NET Core Microservices Architecture</a>|Neil Morrissey|Intermediate|1h 53m|Dec 11, 2020|
| <a href='https://app.pluralsight.com/library/courses/securing-microservices-asp-dot-net-core'>Securing Microservices in ASP.NET Core</a>|Kevin Dockx|Advanced|3h 37m|Nov 30, 2020|
| <a href='https://app.pluralsight.com/library/courses/versioning-evolving-microservices-asp-dot-net-core'>Versioning and Evolving Microservices in ASP.NET Core 3</a>|Mark Heath|Intermediate|1h 41m|Sep 22, 2020|
| <a href='https://app.pluralsight.com/library/courses/deploying-asp-dot-net-core-microservices-kubernetes-aks'>Deploying ASP.NET Core 3 Microservices Using Kubernetes and AKS</a>|Marcel de Vries|Advanced|2h 7m|Nov 13, 2020|
| <a href='https://app.pluralsight.com/library/courses/implementing-cross-cutting-concerns-asp-dot-net-core-microservices'>Implementing Cross-cutting Concerns for ASP.NET Core 3 Microservices</a>|Steve Gordon|Intermediate|2h 8m|Nov 13, 2020|
| <a href='https://app.pluralsight.com/library/courses/strategies-microservice-scalability-availability-asp-dot-net-core'>Strategies for Microservice Scalability and Availability in ASP.NET Core</a>|Rag Dhiman|Advanced|1h 55m|Nov 25, 2020|

### Prerequisites

In order to build and run the sample GloboTicket application, it is recommended that you have the following installed.

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download). You can test that you have it installed by entering the command `dotnet --list-sdks`
- [Entity Framework Command Line Tools](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet). You can install these as a global tool with the command `dotnet tool install --global dotnet-ef`
- [SQL Server Express](https://docs.microsoft.com/en-us/sql/sql-server/editions-and-components-of-sql-server-version-15?view=sql-server-ver15).
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (Community Edition or Greater) or [Visual Studio Code](https://code.visualstudio.com/)

### Building the Code

You can either load `GloboTicket\GloboTicket.sln` in Visual Studio 2019 and build from within Visual Studio, or from the command line, in the same folder as `GloboTicket.sln`, enter the `dotnet build` command.

### Running the Migrations
Before you run GloboTicket for the first time, you need to run the database migrations for all microservices that have a SQL database. These are the **event catalog** microservice, and the **shopping basket** microservice.

First, navigate into the `GloboTicket\GloboTicket.Services.EventCatalog` folder and run the `dotnet ef database update` command.

Then, navigate into the `\GloboTicket\GloboTicket.Services.ShoppingBasket` folder and run the `dotnet ef database update` command.

### Running the Application from Visual Studio 2019
You can run the GloboTicket application directly from within **Visual Studio**. To do this, first right click on each of the three projects individually and view the project properties. In the **Debug** tab for each of the three projects, ensure that the **Launch** setting is set to **Project** (and not **IIS Express**). This will ensure that each microservice runs on the expected ports. 

Then right-click on the solution file and select **Set Startup Projects**, and configure all three projects to either **Start** or **Start without Debugging** as desired. Now, when you run the project from within Visual Studio, all three projects will start up.

### Running the Application from the Command Line
Alternatively, you can run the GloboTicket application from the command line. You will need to open three separate command prompts, one for each `csproj` file. For each project, navigate into the folder containing the `.csproj` file and run the command `dotnet run`.

**Note:** You may be asked to trust the .NET Core developer certificates. Make sure you do so, in order to use HTTPS to access the services.

### Launch in a browser
If you have followed the instructions, the GloboTicket client application (website) will be running on port 5000, which you can access in the browser at [https://localhost:5000](https://localhost:5000).

The Event Catalog microservice will be running on port 5001 and you can view the API documentation at [https://localhost:5001/swagger](https://localhost:5001/swagger)

The Shopping Basket microservice will be running on port 5002 and you can view the API documentation at [https://localhost:5002/swagger](https://localhost:5002/swagger)




