using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System;
using Website.Pages;

namespace Website.Pages;

public class AccountModel : PageModel
{
    public static string ID="";
    public static string CARDNUM="";
    public static string MONEY="";

    public ILogger<AccountModel> _logger;
    [BindProperty]
    public string Id { get; set; } = "";
    [BindProperty]
    public string Cardnum { get; set; } = "";
    [BindProperty]
    public string Money { get; set; } = "";

    public string Message { get; set; } = "";

    public bool b = false;

    public AccountModel(ILogger<AccountModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnPost()
    {
        b = false;
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cards.txt");
        string[] lines;

        if (!System.IO.File.Exists(filePath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
            lines = System.IO.File.ReadAllLines(filePath);
        }
        else
        {
            lines = System.IO.File.ReadAllLines(filePath);
        }


        foreach (var line in lines)
        {

            var parts = line.Split(',');

            var code = parts[0];
            var money = parts[1];
            var num = parts[2];

            Money = money;
            Cardnum = num;

            if (code == Id)
            {
                b = true;
                MONEY=money;
                ID = Id;
                CARDNUM = Cardnum;
                return RedirectToPage("/Account2");
            }
        }

        if (b == false)
        {
            string line = $"{Id},0";
            System.IO.File.AppendAllText(filePath, line + Environment.NewLine);
        }

        Message = "Card is not in the database, registering right now";
        return Page();
    }

    public void OnGet()
    {

    }
}
