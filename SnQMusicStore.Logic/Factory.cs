//@CodeCopy
using SnQMusicStore.Contracts.Client;

namespace SnQMusicStore.Logic
{
    public static partial class Factory
    {
        static Factory()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();

        internal static DataContext.IContext CreateContext()
        {
            return new DataContext.ProjectDbContext();
        }

        public static IControllerAccess<C> Create<C>()
            where C : Contracts.IIdentifiable
        {
            var result = default(IControllerAccess<C>);

            CreateController(ref result);
            return result ?? throw new Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
        }
        public static IControllerAccess<C> Create<C>(object controllerObject)
            where C : Contracts.IIdentifiable
        {
            var result = default(IControllerAccess<C>);

            CreateController(controllerObject, ref result);
            return result ?? throw new Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
        }
#if ACCOUNT_ON
        public static IControllerAccess<C> Create<C>(string sessionToken)
            where C : Contracts.IIdentifiable
        {
            var result = default(IControllerAccess<C>);

            CreateController(sessionToken, ref result);
            return result ?? throw new Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
        }

        public static IAccountManager CreateAccountManager() => new Modules.Account.AccountManagerWrapper();
#endif
        static partial void CreateController<C>(ref IControllerAccess<C>? controller)
            where C : Contracts.IIdentifiable;
        static partial void CreateController<C>(object sharedController, ref IControllerAccess<C>? controller)
            where C : Contracts.IIdentifiable;
    }
}
