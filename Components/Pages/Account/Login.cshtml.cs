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
        string email, string password, string confirmPassword, string returnUrl = "/")
    {
        // Backend validation
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.'))
        {
            var error = Uri.EscapeDataString("Please enter a valid email address.");
            return Redirect($"/Signin?error={error}&mode=register");
        }

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
        {
            var error = Uri.EscapeDataString("Password must be at least 6 characters.");
            return Redirect($"/Signin?error={error}&mode=register");
        }

        if (password != confirmPassword)
        {
            var error = Uri.EscapeDataString("Passwords do not match.");
            return Redirect($"/Signin?error={error}&mode=register");
        }

        var user = new ApplicationUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return LocalRedirect(returnUrl);
        }

        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
        return Redirect($"/Signin?error={Uri.EscapeDataString(errors)}&mode=register");
    }

    public async Task<IActionResult> OnPostLogoutAsync()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/Signin");
    }

    public async Task<IActionResult> OnPostDeleteAccountAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            await _signInManager.SignOutAsync();
            await _userManager.DeleteAsync(user);
        }
        return Redirect("/Signin");
    }

    public async Task<IActionResult> OnPostChangePasswordAsync(
        string currentPassword, string newPassword, string confirmNewPassword)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return Redirect("/Signin");

        if (newPassword != confirmNewPassword)
        {
            var error = Uri.EscapeDataString("New passwords do not match.");
            return Redirect($"/Signin?error={error}");
        }

        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        if (result.Succeeded)
        {
            await _signInManager.RefreshSignInAsync(user);
            return Redirect("/?message=Password changed successfully.");
        }

        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
        return Redirect($"/Signin?error={Uri.EscapeDataString(errors)}");
    }
}