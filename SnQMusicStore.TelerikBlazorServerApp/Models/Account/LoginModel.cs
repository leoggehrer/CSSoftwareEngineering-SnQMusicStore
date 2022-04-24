﻿//@CodeCopy
//MdStart
#nullable enable
using System.ComponentModel.DataAnnotations;

namespace SnQMusicStore.TelerikBlazorServerApp.Models.Modules.Account
{
    public partial class LoginModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string? OptionalInfo { get; set; }
        public bool RememberMe { get; set; }
    }
}
//MdEnd
