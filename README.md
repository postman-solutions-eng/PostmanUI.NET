# PostmanUI.NET

# What does it do?
- The NuGet package sets up a local Postman UI server for you while your application is running.

- The Postman UI server knows about your swagger.json file (OpenAPI Specification), that is exposed through the     AddSwaggerGen middleware.

- Using the specification, we are able to rapidly build collections on demand using a conversion tool from the OpenAPI format > Postman Collection format.
    - Instead of showing the Swagger UI page, it shows a nice looking OpenAPI viewer, as well as a few other tools to bring productivity closer to your development workflow.

- All endpoints are hosted by you, your Postman data does not leave your local machine. You are able to input your Postman API key to authenticate and automate collection creation to your own workspace, and it will not leave your local machine.

# Steps to run locally

1. .NET8 SDK
2. Clone repository in VS Code, Run Task > Watch (Install https cert if needed)
4. Change Razor components in PostmanUI project, hot reload will pick up changes instantly

# Documentation

- PostmanBuilderExtensions : Extension method adds a Minimal API endpoint which serves staticly rendered HTML + JS + TailwindCSS through the Razor templating engine.

- Usage
    - User installs Nuget Package in Startup Project (insert name here)
    - User calls UsePostmanUI() in the Program.cs/Startup of their application.
    - launchSettings.json should be changed to start /postman when dotnet launches

- Requirements
    - AddHttpClient middleware (View Demo project)
    - AddHttpContextAccessor middleware (pending improvement)

# Contributions
- Please create a merge request via this repository. A Github Actions pipeline will release to NuGet.
