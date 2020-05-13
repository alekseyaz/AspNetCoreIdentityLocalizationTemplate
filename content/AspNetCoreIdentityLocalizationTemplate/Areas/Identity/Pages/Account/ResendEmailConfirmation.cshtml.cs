using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AspNetCoreIdentityLocalization.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Localization;

namespace AspNetCoreIdentityLocalization.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public abstract class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IStringLocalizer _sharedLocalizer;

        public ResendEmailConfirmationModel(UserManager<IdentityUser> userManager, IEmailSender emailSender, IStringLocalizerFactory factory)
        {
            _userManager = userManager;
            _emailSender = emailSender;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "EMAIL_REQUIRED")]
            [EmailAddress(ErrorMessage = "EMAIL_INVALID")]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, _sharedLocalizer["STATUS_UPDATE_PROFILE_EMAIL_SEND"]);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(Input.Email, _sharedLocalizer["CONFIRM_YOUR_EMAIL"],
                _sharedLocalizer["CONFIRM_YOUR_EMAIL_TEXT", HtmlEncoder.Default.Encode(callbackUrl)]);
            ModelState.AddModelError(string.Empty, _sharedLocalizer["STATUS_UPDATE_PROFILE_EMAIL_SEND"]);
            return Page();
        }
    }
}
