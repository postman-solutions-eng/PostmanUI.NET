using System.Reflection;
using PostmanUI;
using PostmanUIDemo;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorComponents();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

    var modelAssembly = typeof(Program).Assembly;
    var modelsXmlDocPath = Path.Combine(AppContext.BaseDirectory, $"{modelAssembly.GetName().Name}.xml");
    c.IncludeXmlComments(modelsXmlDocPath);
});

// Needed for Postman UI to make API Call
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}
app.UseHttpsRedirection();


app.MapEndpoints();
app.UsePostmanBuilder();

app.Run();