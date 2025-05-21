using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System;

namespace Website.Pages;

public class SignupModel : PageModel
{
    private readonly ILogger<SignupModel> _logger;
    [BindProperty]
    public string Email { get; set; }="";
    [BindProperty]
    public string FullName { get; set; }="";
    [BindProperty]
    public string Password { get; set; }="";
    [BindProperty]
    public string ConfirmPassword { get; set; }="";

    public string? Message { get; set; }

    public SignupModel(ILogger<SignupModel> logger)
    {
        _logger = logger;
    }

    public void OnPost()
    {
        if (Password!=ConfirmPassword){
            Message="Password and Confirm Password are not the same";
            return;
        }
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "logins.txt");

        if (!System.IO.File.Exists(filePath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
        }


        string line = $"{FullName},{Email},{Password},";
        System.IO.File.AppendAllText(filePath, line + Environment.NewLine);

        Message = "Login saved!";

    }

    public void OnGet()
    {

    }
}
