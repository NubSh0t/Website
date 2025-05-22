using System;

Directory.CreateDirectory("/app/Data");

string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "logins.txt");

if (!System.IO.File.Exists(filePath))
{
    string[] initialContent = { "admin,admin@gmail.com,admin123", "Laibah Basham,LaibahBasham@gmail.com,laibah123" };
    System.IO.File.WriteAllLines(filePath, initialContent);
}

filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cards.txt");

if (!System.IO.File.Exists(filePath))
{
    string[] initialContent = { "0011543444,10000,000011112222333344","0011494335,30000,001149432517525535" };
    System.IO.File.WriteAllText(filePath, initialContent);
}


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