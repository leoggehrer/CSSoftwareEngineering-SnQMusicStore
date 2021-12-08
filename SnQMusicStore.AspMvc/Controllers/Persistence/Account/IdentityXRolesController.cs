//@GeneratedCode
namespace SnQMusicStore.AspMvc.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TContract = Contracts.Persistence.Account.IIdentityXRole;
    using TModel = AspMvc.Models.Persistence.Account.IdentityXRole;
    public partial class IdentityXRolesController : AspMvc.Controllers.GenericController<TContract, TModel>
    {
        static IdentityXRolesController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityXRolesController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
