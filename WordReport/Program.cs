using System.IO.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordReport;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<IFileSystem, FileSystem>();
builder.Services.AddTransient<IWordReportService, WordReportService>();
using IHost host = builder.Build();

await host.RunAsync();
