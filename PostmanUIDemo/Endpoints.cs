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
            .Produces<Person>()
            .WithName("Create User")
            .WithSummary("Create a new user")
            .WithDescription("Create a new user with the given name and age");

            app.MapGet("/user/{id}", (Guid id) =>
            {
                return Results.Ok(new Person()
                {
                    Name = "Test",
                    Age = 1
                });
            })
            .WithOpenApi()
            .Produces<Person>()
            .WithName("Get User by ID")
            .WithSummary("Get User by ID")
            .WithDescription("Get User by ID with the given name and age");

            app.MapPost("/firm", () =>
            {
                return Results.Ok(new Firm()
                {
                    Name = "Test",
                });
            })
            .WithOpenApi()
            .Produces<Firm>()
            .WithName("Create Firm")
            .WithSummary("Create a new Firm")
            .WithDescription("Create a new Firm with the given name and age");

            app.MapGet("/firm/{id}", (Guid id) =>
            {
                return Results.Ok(new Firm()
                {
                    Name = "Test",
                });
            })
            .WithOpenApi()
            .Produces<Firm>()
            .WithName("Get Firm by ID")
            .WithSummary("Get Firm by ID")
            .WithDescription("Get Firm by ID with the given name and age");
        }
    }
}
