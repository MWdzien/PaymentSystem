using Microsoft.EntityFrameworkCore;
using PaymentSystem.Context;
using PaymentSystem.Repositories.ClientRepositories;
using PaymentSystem.Repositories.ContractRepositories;
using PaymentSystem.Repositories.PaymentRepositories;
using PaymentSystem.Repositories.RevenueRepositories;
using PaymentSystem.Repositories.SoftwareRepositories;
using PaymentSystem.Repositories.SubscriptionRepositories;
using PaymentSystem.Services.ClientServices;
using PaymentSystem.Services.ContractServices;
using PaymentSystem.Services.PaymentServices;
using PaymentSystem.Services.RevenueServices;
using PaymentSystem.Services.SubscriptionServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IRevenueService, RevenueService>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<ISoftwareRepository, SoftwareRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IRevenueRepository, RevenueRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

