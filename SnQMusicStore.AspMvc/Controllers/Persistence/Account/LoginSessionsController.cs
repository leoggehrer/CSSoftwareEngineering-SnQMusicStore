//@GeneratedCode
namespace SnQMusicStore.AspMvc.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TContract = Contracts.Persistence.Account.ILoginSession;
    using TModel = AspMvc.Models.Persistence.Account.LoginSession;
    public partial class LoginSessionsController : AspMvc.Controllers.GenericController<TContract, TModel>
    {
        static LoginSessionsController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public LoginSessionsController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
