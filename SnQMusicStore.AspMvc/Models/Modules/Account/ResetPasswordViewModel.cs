//@CodeCopy
//MdStart
#if ACCOUNT_ON
using System.ComponentModel.DataAnnotations;

namespace SnQMusicStore.AspMvc.Models.Modules.Account
{
    public partial class ResetPasswordViewModel : ModelObject
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
#endif
//MdEnd
