//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQMusicStore.BlazorServerApp.Models.Modules.Account;
using SnQMusicStore.BlazorServerApp.Models.Modules.Session;

namespace SnQMusicStore.BlazorServerApp.Services.Modules.Authentication
{
    public interface IAccountService
    {
        event EventHandler<AuthorizationSession> AuthorizationChanged;
        AuthorizationSession CurrentAuthorizationSession { get; }

        Task InitAuthorizationSessionAsync();

        Task<AuthorizationSession> LogonAsync(LoginModel loginModel);
        Task<bool> IsSessionAliveAsync(string sessionToken);
        Task ChangePasswordAsync(string oldPassword, string newPassword);
        Task ChangePasswordForAsync(string email, string newPassword);
        Task LogoutAsync();
    }
}
#endif
//MdEnd
