using System.IO;
using System;


string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cards.txt");
Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "logins.txt");
Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSession();

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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();