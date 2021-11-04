//@GeneratedCode
namespace SnQMusicStore.Logic.Controllers.Business.Account
{
    sealed partial class IdentityUserController : GenericOneToAnotherController<SnQMusicStore.Contracts.Business.Account.IIdentityUser, Entities.Business.Account.IdentityUser, SnQMusicStore.Contracts.Persistence.Account.IIdentity, SnQMusicStore.Logic.Entities.Persistence.Account.Identity, SnQMusicStore.Contracts.Persistence.Account.IUser, SnQMusicStore.Logic.Entities.Persistence.Account.User>
    {
        static IdentityUserController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityUserController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            oneEntityController = new SnQMusicStore.Logic.Controllers.Persistence.Account.IdentityController(this);
            anotherEntityController = new SnQMusicStore.Logic.Controllers.Persistence.Account.UserController(this);
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public IdentityUserController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            oneEntityController = new SnQMusicStore.Logic.Controllers.Persistence.Account.IdentityController(this);
            anotherEntityController = new SnQMusicStore.Logic.Controllers.Persistence.Account.UserController(this);
            Constructed();
        }
        [Attributes.ControllerManagedField]
        private SnQMusicStore.Logic.Controllers.Persistence.Account.IdentityController oneEntityController = null;
        protected override GenericController<SnQMusicStore.Contracts.Persistence.Account.IIdentity, SnQMusicStore.Logic.Entities.Persistence.Account.Identity> OneEntityController
        {
            get => oneEntityController;
            set => oneEntityController = value as SnQMusicStore.Logic.Controllers.Persistence.Account.IdentityController;
        }
        [Attributes.ControllerManagedField]
        private SnQMusicStore.Logic.Controllers.Persistence.Account.UserController anotherEntityController = null;
        protected override GenericController<SnQMusicStore.Contracts.Persistence.Account.IUser, SnQMusicStore.Logic.Entities.Persistence.Account.User> AnotherEntityController
        {
            get => anotherEntityController;
            set => anotherEntityController = value as SnQMusicStore.Logic.Controllers.Persistence.Account.UserController;
        }
    }
}
