//@GeneratedCode
namespace SnQMusicStore.AspMvc.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TContract = Contracts.Persistence.Account.IIdentity;
    using TModel = AspMvc.Models.Persistence.Account.Identity;
    public partial class IdentitiesController : AspMvc.Controllers.GenericController<TContract, TModel>
    {
        static IdentitiesController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentitiesController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
