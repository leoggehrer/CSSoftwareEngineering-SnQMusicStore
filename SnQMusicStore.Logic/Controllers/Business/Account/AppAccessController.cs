//@GeneratedCode
namespace SnQMusicStore.Logic.Controllers.Business.Account
{
    [Logic.Modules.Security.Authorize("SysAdmin", "AppAdmin")]
    sealed partial class AppAccessController : GenericOneToManyController<SnQMusicStore.Contracts.Business.Account.IAppAccess, Entities.Business.Account.AppAccess, SnQMusicStore.Contracts.Persistence.Account.IIdentity, SnQMusicStore.Logic.Entities.Persistence.Account.Identity, SnQMusicStore.Contracts.Persistence.Account.IRole, SnQMusicStore.Logic.Entities.Persistence.Account.Role>
    {
        static AppAccessController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public AppAccessController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            oneEntityController = new SnQMusicStore.Logic.Controllers.Persistence.Account.IdentityController(this);
            manyEntityController = new SnQMusicStore.Logic.Controllers.Persistence.Account.RoleController(this);
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public AppAccessController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            oneEntityController = new SnQMusicStore.Logic.Controllers.Persistence.Account.IdentityController(this);
            manyEntityController = new SnQMusicStore.Logic.Controllers.Persistence.Account.RoleController(this);
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
        private SnQMusicStore.Logic.Controllers.Persistence.Account.RoleController manyEntityController = null;
        protected override GenericController<SnQMusicStore.Contracts.Persistence.Account.IRole, SnQMusicStore.Logic.Entities.Persistence.Account.Role> ManyEntityController
        {
            get => manyEntityController;
            set => manyEntityController = value as SnQMusicStore.Logic.Controllers.Persistence.Account.RoleController;
        }
    }
}
