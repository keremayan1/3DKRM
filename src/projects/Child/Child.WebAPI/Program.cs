using Child.Application;
using Child.Infrasructure;
using Child.Persistance;
using MassTransit;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMassTransit(x =>
{

    x.UsingRabbitMq((context, config) =>
    {
        config.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
        {
            host.Username("admin");
            host.Password("123456");
        });
        config.UseRawJsonSerializer();
        config.ReceiveEndpoint("create-child-queue", e =>
        {

            e.Bind("Child", x =>
            {
                x.Durable = false;
                x.ExchangeType = ExchangeType.Direct;
                x.RoutingKey = "createChild";
            });
        });
    });
});
// Add services to the container.
builder.Services.AddInfrasructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
