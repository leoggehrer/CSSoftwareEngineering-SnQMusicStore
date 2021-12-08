//@GeneratedCode
namespace SnQMusicStore.AspMvc.Controllers.Business.Account
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TContract = Contracts.Business.Account.IAppAccess;
    using TModel = AspMvc.Models.Business.Account.AppAccess;
    public partial class AppAccessesController : AspMvc.Controllers.GenericController<TContract, TModel>
    {
        static AppAccessesController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public AppAccessesController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
