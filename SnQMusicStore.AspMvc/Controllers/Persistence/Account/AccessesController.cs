//@GeneratedCode
namespace SnQMusicStore.AspMvc.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TContract = Contracts.Persistence.Account.IAccess;
    using TModel = AspMvc.Models.Persistence.Account.Access;
    public partial class AccessesController : AspMvc.Controllers.GenericController<TContract, TModel>
    {
        static AccessesController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public AccessesController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
