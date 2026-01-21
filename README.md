# DiagnosticCenterManagement

Requirements
- Visual Studio 2022 or Later
- .NET Framework
- SQL Server LocalDB

How to Run
1. Clone the repository
2. Open the solution in Visual Studio
3. Database will auto attach
4. Right click on the .mdf file in solution explorer then click open. Database will now open in the server explorer tab.
5. Now replace the below connection string under those forms code where string connStr exists.
6. string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DiagnosticCentre.mdf;Integrated Security=True;Connect Timeout=30";
7. Here replace the DataDirectory section with your project directory address.
8. Click **START**

User:
Username: admin  
Password: 1234

Contribution:
1. Fork the repository
2. Create a new branch
3. Commit changes
4. Open a Pull Request
