using Application.Features.Children.Consumers;
using MassTransit;
using Persistance;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateChildMessageConsumer>();
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
            
            e.ConfigureConsumer<CreateChildMessageConsumer>(context);
        });

    });
});
// Add services to the container.
builder.Services.AddPersistanceServices();
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
