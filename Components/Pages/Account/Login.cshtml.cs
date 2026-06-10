using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Filters;
using cse325_team4_project.Models;

namespace cse325_team4_project.Components.Pages.Account;

[IgnoreAntiforgeryToken]
public class LoginModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginModel(SignInManager<ApplicationUser> signInManager,
                      UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<IActionResult> OnPostLoginAsync(
        string email, string password, string returnUrl = "/")
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
        return result.Succeeded
            ? LocalRedirect(returnUrl)
            : Redirect($"/Signin?error=invalid&mode=login");
    }

    public async Task<IActionResult> OnPostRegisterAsync(
        string email, string password, string returnUrl = "/")
    {
        var user = new ApplicationUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return LocalRedirect(returnUrl);
        }

        var errors = string.Join("|", result.Errors.Select(e => e.Description));
        return Redirect($"/Signin?error={Uri.EscapeDataString(errors)}&mode=register");
    }

    public async Task<IActionResult> OnPostLogoutAsync()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/Signin");
    }
}