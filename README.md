# PostmanUI

# Steps to run locally

1. Able to run .NET8
2. Clone repository
3. Open in VS Code, Run Task > Watch (Install https cert if needed)
4. Change Razor components in PostmanUI project, hot reload will pick up changes instantly


# Documentation

- PostmanBuilderExtensions : Extension method adds a Minimal API endpoint which serves staticly rendered HTML + JS + TailwindCSS through the Razor templating engine.

- Usage
    - User installs Nuget Package in Startup Project (insert name here)
    - User calls UsePostmanUI() in the Program.cs/Startup of their application.
    - launchSettings.json should be changed to start /postman when dotnet launches



# Contributions
- Please create a merge request via this repository. A Github Actions pipeline will release to NuGet.