using TicketManagement.CleanArchitecture.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

builder.Configuration.AddUserSecrets<Program>();

//await app.ResetDatabaseAsync();

app.Run();
