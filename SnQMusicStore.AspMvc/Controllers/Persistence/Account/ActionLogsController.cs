//@GeneratedCode
namespace SnQMusicStore.AspMvc.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TContract = Contracts.Persistence.Account.IActionLog;
    using TModel = AspMvc.Models.Persistence.Account.ActionLog;
    public partial class ActionLogsController : AspMvc.Controllers.GenericController<TContract, TModel>
    {
        static ActionLogsController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public ActionLogsController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
