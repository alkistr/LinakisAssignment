using LD.Assignment.Application.Implementations;
using LD.Assignment.Application.Interfaces;
using LD.Assignment.Data.Context;
using LD.Assignment.Data.Implementations;
using LD.Assignment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<ITitleList, TitleList>();
builder.Services.AddTransient<ILinkList, LinkList>();
builder.Services.AddTransient<ITitlesRepository, TitlesRepository>();
builder.Services.AddTransient<TitleContext>();

builder.Services.AddDbContext<TitleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
