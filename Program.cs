var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var products = new[]
{
    new
    {
        Id = 101,
        Name = "Монстера Деліціоза · API",
        Description = "Каталог отримано з вебсервісу.",
        ImageName = "plant.png",
        UnitPrice = 380m,
        OptionName = "Декоративний горщик",
        OptionPrice = 95m
    },
    new
    {
        Id = 102,
        Name = "Фікус Бенджаміна · API",
        Description = "Дерево з густою кроною для інтер'єру.",
        ImageName = "ficus.png",
        UnitPrice = 310m,
        OptionName = "Керамічний піддон",
        OptionPrice = 70m
    },
    new
    {
        Id = 103,
        Name = "Кактус Опунція · API",
        Description = "Компактний сукулент з рожевою квіткою.",
        ImageName = "cactus.png",
        UnitPrice = 140m,
        OptionName = "Підставка з дерева",
        OptionPrice = 50m
    },
    new
    {
        Id = 104,
        Name = "Алое Вера · API",
        Description = "Лікувальний сукулент, стійкий до посухи.",
        ImageName = "aloe.png",
        UnitPrice = 165m,
        OptionName = "Органічне добриво",
        OptionPrice = 40m
    }
};

app.MapGet("/api/products", () => products);
app.MapGet("/api/empty", () => Array.Empty<object>());
app.MapGet("/api/error", () => Results.StatusCode(503));
app.MapGet("/api/invalid", () => Results.Text("{ invalid json", "application/json"));
app.MapGet("/api/slow", async (CancellationToken token) =>
{
    await Task.Delay(TimeSpan.FromSeconds(15), token);
    return Results.Ok(products);
});

app.MapGet("/favicon.ico", () => Results.NotFound());

// Render.com встановлює ASPNETCORE_HTTP_PORTS=8080 через Dockerfile.
// Локально можна запустити на 5185, на Render — на 8080.
var port = Environment.GetEnvironmentVariable("ASPNETCORE_HTTP_PORTS") ?? "5185";
app.Urls.Add($"http://0.0.0.0:{port}");
app.Run();
