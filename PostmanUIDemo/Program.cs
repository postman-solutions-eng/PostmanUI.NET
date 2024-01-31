using PostmanUI;
using PostmanUIDemo;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorComponents();
builder.Services.AddSwaggerGen();

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