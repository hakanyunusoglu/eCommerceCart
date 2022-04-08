Firstly you need .NET 6.0

Install-Package Microsoft.NETCore.Platforms -Version 6.0.2

I used Visual Studio 2022 and Sql Express 2018.

Follow this path for database setup and automatic data fetching.
1) Right-click the eCommerce.UI layer in the Presentation folder and click Set as Startup Project.
2) When you open the project, click "Tools>Nuget Package Manager>Package Manager Console" from the menu above.
3) Select the Infrastructure/eCommerce.Persistence layer as the default project.
4) Write update-database to console (You must be using sql express)
5) If you want to use a different database, you can edit the database connection path in 
ServiceRegistration.cs located in the eCommerce.Persistence layer under the Infrastructure folder.

Default login values:<br/>
Username: hakan<br/>
Password: 123456
