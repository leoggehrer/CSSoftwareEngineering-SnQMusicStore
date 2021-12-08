//@GeneratedCode
namespace SnQMusicStore.AspMvc.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TContract = Contracts.Persistence.Account.IUser;
    using TModel = AspMvc.Models.Persistence.Account.User;
    public partial class UsersController : AspMvc.Controllers.GenericController<TContract, TModel>
    {
        static UsersController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public UsersController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
