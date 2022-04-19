using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Wordle.GameSet;
using Wordle;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//await builder.Build().RunAsync();

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<Game>();
builder.Services.AddSingleton<GameInput>();
builder.Services.AddSingleton(
    sp => {
        var httpClient = sp.GetRequiredService<HttpClient>();
        const string filePath = @"C:\Users\Kami\Documents\GitHub\Wordle\Wordle\wwwroot\word-list.txt.txt";
        return new AnswerProvider(httpClient, filePath);
    });
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();



await builder.Build().RunAsync();
