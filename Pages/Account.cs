using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System;
using Website.Pages;

namespace Website.Pages;

public class AccountModel : PageModel
{
    private readonly ILogger<AccountModel> _logger;
    [BindProperty]
    public string Id { get; set; }="";
    [BindProperty]
    public string Mon { get; set; }="";

    public bool b=false;

    public string Message { get; set; } = "";

    public AccountModel(ILogger<AccountModel> logger)
    {
        _logger = logger;
    }

    public void OnPost()
    {
        b=false;
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cards.txt");

        if (!System.IO.File.Exists(filePath))
        {
            Message = "User database not found.";
            return;
        }

        var lines = System.IO.File.ReadAllLines(filePath);

        foreach (var line in lines)
        {

            var parts = line.Split(',');

            var code = parts[0];
            var money = parts[1];

            Mon=money;

            if (code==Id)
            {
                b=true;
                return;
            }
        }

        if (b==false){
            string line = $"{Id},0";
            System.IO.File.AppendAllText(filePath, line + Environment.NewLine);
        }

        Message = "Card is not in the database, registering right now";
    }

    public void OnGet()
    {

    }
}
