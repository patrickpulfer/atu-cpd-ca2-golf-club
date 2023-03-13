using Golf_Club_Management.Data;
using Golf_Club_Management.dbcontext;
using Golf_Club_Management.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<AppDbContext>();

builder.Services.AddSingleton<IGolfersService, GolfersService>();
builder.Services.AddSingleton<GolferViewService>();

builder.Services.AddSingleton<ITeeTimeService, TeeTimeService>();
builder.Services.AddSingleton<TeeTimeBookingService, TeeTimeBookingService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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