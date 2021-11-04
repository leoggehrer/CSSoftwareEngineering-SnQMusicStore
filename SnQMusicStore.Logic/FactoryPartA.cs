//@GeneratedCode
namespace SnQMusicStore.Logic
{
    public static partial class Factory
    {
        static partial void CreateController<C>(ref Contracts.Client.IControllerAccess<C> controller) where C : Contracts.IIdentifiable
        {
            if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum))
            {
                controller = new Controllers.Persistence.MusicStore.AlbumController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist))
            {
                controller = new Controllers.Persistence.MusicStore.ArtistController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack))
            {
                controller = new Controllers.Persistence.MusicStore.TrackController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre))
            {
                controller = new Controllers.Persistence.MusicStore.GenreController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IAccess))
            {
                controller = new Controllers.Persistence.Account.AccessController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IActionLog))
            {
                controller = new Controllers.Persistence.Account.ActionLogController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentity))
            {
                controller = new Controllers.Persistence.Account.IdentityController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole))
            {
                controller = new Controllers.Persistence.Account.IdentityXRoleController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.ILoginSession))
            {
                controller = new Controllers.Persistence.Account.LoginSessionController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IRole))
            {
                controller = new Controllers.Persistence.Account.RoleController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IUser))
            {
                controller = new Controllers.Persistence.Account.UserController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IAppAccess))
            {
                controller = new Controllers.Business.Account.AppAccessController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IIdentityUser))
            {
                controller = new Controllers.Business.Account.IdentityUserController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else
            {
                throw new Logic.Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
            }
        }
        static partial void CreateController<C>(object sharedController, ref Contracts.Client.IControllerAccess<C> controller) where C : Contracts.IIdentifiable
        {
            if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum))
            {
                controller = new Controllers.Persistence.MusicStore.AlbumController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist))
            {
                controller = new Controllers.Persistence.MusicStore.ArtistController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack))
            {
                controller = new Controllers.Persistence.MusicStore.TrackController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre))
            {
                controller = new Controllers.Persistence.MusicStore.GenreController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IAccess))
            {
                controller = new Controllers.Persistence.Account.AccessController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IActionLog))
            {
                controller = new Controllers.Persistence.Account.ActionLogController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentity))
            {
                controller = new Controllers.Persistence.Account.IdentityController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole))
            {
                controller = new Controllers.Persistence.Account.IdentityXRoleController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.ILoginSession))
            {
                controller = new Controllers.Persistence.Account.LoginSessionController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IRole))
            {
                controller = new Controllers.Persistence.Account.RoleController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IUser))
            {
                controller = new Controllers.Persistence.Account.UserController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IAppAccess))
            {
                controller = new Controllers.Business.Account.AppAccessController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IIdentityUser))
            {
                controller = new Controllers.Business.Account.IdentityUserController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else
            {
                throw new Logic.Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
            }
        }
#if ACCOUNT_ON
        public static void CreateController<C>(string sessionToken, ref Contracts.Client.IControllerAccess<C> controller) where C : Contracts.IIdentifiable
        {
            if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum))
            {
                controller = new Controllers.Persistence.MusicStore.AlbumController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist))
            {
                controller = new Controllers.Persistence.MusicStore.ArtistController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack))
            {
                controller = new Controllers.Persistence.MusicStore.TrackController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre))
            {
                controller = new Controllers.Persistence.MusicStore.GenreController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IAccess))
            {
                controller = new Controllers.Persistence.Account.AccessController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IActionLog))
            {
                controller = new Controllers.Persistence.Account.ActionLogController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentity))
            {
                controller = new Controllers.Persistence.Account.IdentityController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole))
            {
                controller = new Controllers.Persistence.Account.IdentityXRoleController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.ILoginSession))
            {
                controller = new Controllers.Persistence.Account.LoginSessionController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IRole))
            {
                controller = new Controllers.Persistence.Account.RoleController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IUser))
            {
                controller = new Controllers.Persistence.Account.UserController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IAppAccess))
            {
                controller = new Controllers.Business.Account.AppAccessController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IIdentityUser))
            {
                controller = new Controllers.Business.Account.IdentityUserController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else
            {
                throw new Logic.Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
            }
        }
#endif
    }
}
