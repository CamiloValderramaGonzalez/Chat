using Bot.Application.Services;
using Bot.Domain.EventHandlers;
using Bot.Domain.Events;
using Bot.Domain.Interfaces;
using Bot.Infrastructure.Repository;
using Bus.Domain.Bus;
using Bus.Infrastructure;
using Bus.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddTransient<IChatRepository, ChatRepository>();
builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddTransient<IEventHandler<PostCreatedEvent>, PostEventHandler>();

builder.Services.AddTransient<PostEventHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<PostCreatedEvent, PostEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
