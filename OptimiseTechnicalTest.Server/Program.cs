using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptimiseTechnicalTest.Server;
using OptimiseTechnicalTest.Server.Endpoints;
using OptimiseTechnicalTest.Server.Models;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlServerDbContext<OptimiseDbContext>("sql");

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapDefaultEndpoints();
app.MapProductEndpoints();
app.UseExceptionHandler("/Error", createScopeForErrors: true);
app.UseHsts();

app.UseFileServer();

app.Run();