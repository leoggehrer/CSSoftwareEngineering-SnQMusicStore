//@GeneratedCode
namespace SnQMusicStore.AspMvc.Controllers.Business.Account
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TContract = Contracts.Business.Account.IIdentityUser;
    using TModel = AspMvc.Models.Business.Account.IdentityUser;
    public partial class IdentityUsersController : AspMvc.Controllers.GenericController<TContract, TModel>
    {
        static IdentityUsersController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityUsersController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
