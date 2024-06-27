using FirstDotNet.Dtos;
using FirstDotNet.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapFirstEndpoints();

app.MapGet("/", () => "Hello World baby");


app.Run();
