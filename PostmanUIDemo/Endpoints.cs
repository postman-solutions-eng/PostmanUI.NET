using Microsoft.AspNetCore.OpenApi;
using PostmanUI;


namespace PostmanUIDemo
{
    public static class Endpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapPost("/user", () =>
            {
                return Results.Ok(new Person()
                {
                    Name = "Test",
                    Age = 1
                });
            })
            .WithOpenApi()
            .WithName("Create User")
            .WithSummary("Create a new user")
            .WithDescription("Create a new user with the given name and age")
            ;
        }
    }
}
