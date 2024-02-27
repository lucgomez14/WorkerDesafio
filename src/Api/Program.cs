using Andreani.Arq.WebHost.Extension;
using Andreani.Arq.Observability.Extensions;
using Api.Services;
using Microsoft.AspNetCore.Builder;
using worker_application.Application.Boopstrap;
using worker_application.Infrastructure.Boopstrap;
using Microsoft.Extensions.DependencyInjection;
using Andreani.Arq.AMQStreams.Extensions;
using Andreani.Scheme.Onboarding;
using worker_application.Services;
using worker_application.Application.Common.Interfaces;
using worker_application.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniWorkerServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddKafka(builder.Configuration)
       .ToConsumer<EventSuscriber, Pedido>("PedidoCreado")
       .ToProducer<Pedido>("PedidoAsignado")
       .Build();

builder.Host.AddObservability();
//builder.Services.AddScoped<IScopedService, ScopedService>();
//builder.Services.AddHostedService<WorkerServices>();


var app = builder.Build();

app.UseObservability();
app.ConfigureAndreaniWorker();

app.Run();

