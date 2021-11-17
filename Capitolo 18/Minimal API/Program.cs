
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/{id}", async (http) =>
{
    if(http.Request.RouteValues.TryGetValue("id", out var id))
    {
        //ricavo un entità per esempio da un db e restituisco come json
        await http.Response.WriteAsJsonAsync(new { Nome = "Antonio", Id = id });
    }
    else http.Response.StatusCode = 404;
});

app.Run();


