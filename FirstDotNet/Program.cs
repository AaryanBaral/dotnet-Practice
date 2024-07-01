using FirstDotNet.Data;
using FirstDotNet.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();
app.MapFirstEndpoints();
app.MigrateDb();
app.MapGet("/", () => "Hello World baby");


app.Run();
