using Microsoft.Playwright;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors( e => e.AddDefaultPolicy( e=> e.AllowAnyOrigin()));
var app = builder.Build();
app.UseCors();
app.MapGet("/gupy", async () => {
    IPlaywright pw = await Playwright.CreateAsync();
    IBrowser browser = await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless =true});
    return await browser.GupyAsync();
});
app.UseCors();
app.MapGet("/chess", async () => {
    IPlaywright pw = await Playwright.CreateAsync();
    IBrowser browser = await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless =false});
    return await browser.ChessAsync();
});
app.MapGet("/lichess", async () => {
    IPlaywright pw = await Playwright.CreateAsync();
    IBrowser browser = await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless =false});
    return await browser.LichessAsync();
});

app.Run();
