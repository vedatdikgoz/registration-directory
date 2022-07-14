using Microsoft.AspNetCore.Builder;
using ProjectWorkerService;
using RabbitMQ.Client;
using WebAppAPI.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var builder = WebApplication.CreateBuilder(args);
        services.AddHostedService<Worker>();
        services.AddSingleton(sp => new ConnectionFactory() { Uri = new Uri(builder.Configuration.GetConnectionString("RabbitMQ")), DispatchConsumersAsync = true });
        services.AddSingleton<RabbitMQClientService>();
        services.AddSingleton<RabbitMQPublisher>();
    })
    .Build();


await host.RunAsync();
