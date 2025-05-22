using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System;
using Website.Pages;

namespace Website.Pages;

public class LoginModel : PageModel
{
    public static string NAME="";

    private readonly ILogger<LoginModel> _logger;
    [BindProperty]
    public string Email { get; set; }="";
    [BindProperty]
    public string Password { get; set; }="";

    public string Message { get; set; } = "";

    public LoginModel(ILogger<LoginModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnPost()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "logins.txt");

        if (!System.IO.File.Exists(filePath))
        {
            Message = "User database not found.";
            return Page();
        }

        var lines = System.IO.File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            // Sample format: FullName: Ammar Ahmed, Email: 1ammarahmed23@gmail.com, Password: 1ammar23
            var parts = line.Split(',');

            if (parts.Length < 3) continue;

            var emailPart = parts[1].Trim();
            var passwordPart = parts[2].Trim();

            if (Email == emailPart && Password == passwordPart)
            {
                Message = "Login successful!";
                NAME=parts[0].Trim();
                return RedirectToPage("/Account");
            }
        }

        Message = "Invalid email or password.";
        return Page();
    }

    public void OnGet()
    {

    }
}
