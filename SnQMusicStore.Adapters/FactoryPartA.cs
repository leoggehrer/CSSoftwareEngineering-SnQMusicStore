//@GeneratedCode
namespace SnQMusicStore.Adapters
{
    public static partial class Factory
    {
        public static Contracts.Client.IAdapterAccess<C> Create<C>()
        {
            Contracts.Client.IAdapterAccess<C> result = null;
            if (Adapter == AdapterType.Controller)
            {
                if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IArtist>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.ITrack>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IGenre>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IAccess))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IAccess>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IActionLog))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IActionLog>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentity))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IIdentity>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.ILoginSession))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.ILoginSession>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IRole))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IRole>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IUser))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IUser>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IAppAccess))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.Account.IAppAccess>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IIdentityUser))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.Account.IIdentityUser>() as Contracts.Client.IAdapterAccess<C>;
                }
            }
            else if (Adapter == AdapterType.Service)
            {
                if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum, Transfer.Models.Persistence.MusicStore.Album>(BaseUri, "Albums")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IArtist, Transfer.Models.Persistence.MusicStore.Artist>(BaseUri, "Artists")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.ITrack, Transfer.Models.Persistence.MusicStore.Track>(BaseUri, "Tracks")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IGenre, Transfer.Models.Persistence.MusicStore.Genre>(BaseUri, "Genres")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IAccess))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IAccess, Transfer.Models.Persistence.Account.Access>(BaseUri, "Accesses")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IActionLog))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IActionLog, Transfer.Models.Persistence.Account.ActionLog>(BaseUri, "ActionLogs")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentity))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IIdentity, Transfer.Models.Persistence.Account.Identity>(BaseUri, "Identities")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole, Transfer.Models.Persistence.Account.IdentityXRole>(BaseUri, "IdentityXRoles")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.ILoginSession))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.ILoginSession, Transfer.Models.Persistence.Account.LoginSession>(BaseUri, "LoginSessions")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IRole))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IRole, Transfer.Models.Persistence.Account.Role>(BaseUri, "Roles")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IUser))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IUser, Transfer.Models.Persistence.Account.User>(BaseUri, "Users")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IAppAccess))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.Account.IAppAccess, Transfer.Models.Business.Account.AppAccess>(BaseUri, "AppAccesses")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IIdentityUser))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.Account.IIdentityUser, Transfer.Models.Business.Account.IdentityUser>(BaseUri, "IdentityUsers")
                    as Contracts.Client.IAdapterAccess<C>;
                }
            }
            return result;
        }
#if ACCOUNT_ON
        public static Contracts.Client.IAdapterAccess<C> Create<C>(string sessionToken)
        {
            Contracts.Client.IAdapterAccess<C> result = null;
            if (Adapter == AdapterType.Controller)
            {
                if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IArtist>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.ITrack>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IGenre>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IAccess))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IAccess>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IActionLog))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IActionLog>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentity))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IIdentity>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.ILoginSession))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.ILoginSession>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IRole))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IRole>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IUser))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.Account.IUser>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IAppAccess))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.Account.IAppAccess>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IIdentityUser))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.Account.IIdentityUser>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
            }
            else if (Adapter == AdapterType.Service)
            {
                if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum, Transfer.Models.Persistence.MusicStore.Album>(sessionToken, BaseUri, "Albums") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IArtist, Transfer.Models.Persistence.MusicStore.Artist>(sessionToken, BaseUri, "Artists") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.ITrack, Transfer.Models.Persistence.MusicStore.Track>(sessionToken, BaseUri, "Tracks") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MusicStore.IGenre, Transfer.Models.Persistence.MusicStore.Genre>(sessionToken, BaseUri, "Genres") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IAccess))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IAccess, Transfer.Models.Persistence.Account.Access>(sessionToken, BaseUri, "Accesses") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IActionLog))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IActionLog, Transfer.Models.Persistence.Account.ActionLog>(sessionToken, BaseUri, "ActionLogs") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentity))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IIdentity, Transfer.Models.Persistence.Account.Identity>(sessionToken, BaseUri, "Identities") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IIdentityXRole, Transfer.Models.Persistence.Account.IdentityXRole>(sessionToken, BaseUri, "IdentityXRoles") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.ILoginSession))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.ILoginSession, Transfer.Models.Persistence.Account.LoginSession>(sessionToken, BaseUri, "LoginSessions") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IRole))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IRole, Transfer.Models.Persistence.Account.Role>(sessionToken, BaseUri, "Roles") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.Account.IUser))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.Account.IUser, Transfer.Models.Persistence.Account.User>(sessionToken, BaseUri, "Users") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IAppAccess))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.Account.IAppAccess, Transfer.Models.Business.Account.AppAccess>(sessionToken, BaseUri, "AppAccesses") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.Account.IIdentityUser))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.Account.IIdentityUser, Transfer.Models.Business.Account.IdentityUser>(sessionToken, BaseUri, "IdentityUsers") as Contracts.Client.IAdapterAccess<C>;
                }
            }
            return result;
        }
#endif
    }
}
