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
                if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MasterData.IGenre))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MasterData.IGenre>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.IAlbum))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.App.IAlbum>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.IArtist))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.App.IArtist>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.ITrack))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.App.ITrack>() as Contracts.Client.IAdapterAccess<C>;
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
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IAlbumTracks))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.App.IAlbumTracks>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IArtistAlbums))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.App.IArtistAlbums>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IGenreTracks))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.App.IGenreTracks>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.ITrackAlbumGenre))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.App.ITrackAlbumGenre>() as Contracts.Client.IAdapterAccess<C>;
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
                if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MasterData.IGenre))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MasterData.IGenre, Transfer.Models.Persistence.MasterData.Genre>(BaseUri, "Genres")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.IAlbum))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.App.IAlbum, Transfer.Models.Persistence.App.Album>(BaseUri, "Albums")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.IArtist))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.App.IArtist, Transfer.Models.Persistence.App.Artist>(BaseUri, "Artists")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.ITrack))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.App.ITrack, Transfer.Models.Persistence.App.Track>(BaseUri, "Tracks")
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
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IAlbumTracks))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.App.IAlbumTracks, Transfer.Models.Business.App.AlbumTracks>(BaseUri, "AlbumTracks")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IArtistAlbums))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.App.IArtistAlbums, Transfer.Models.Business.App.ArtistAlbums>(BaseUri, "ArtistAlbums")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IGenreTracks))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.App.IGenreTracks, Transfer.Models.Business.App.GenreTracks>(BaseUri, "GenreTracks")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.ITrackAlbumGenre))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.App.ITrackAlbumGenre, Transfer.Models.Business.App.TrackAlbumGenre>(BaseUri, "TrackAlbumGenres")
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
                if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MasterData.IGenre))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.MasterData.IGenre>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.IAlbum))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.App.IAlbum>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.IArtist))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.App.IArtist>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.ITrack))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Persistence.App.ITrack>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
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
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IAlbumTracks))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.App.IAlbumTracks>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IArtistAlbums))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.App.IArtistAlbums>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IGenreTracks))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.App.IGenreTracks>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.ITrackAlbumGenre))
                {
                    result = new Controller.GenericControllerAdapter<SnQMusicStore.Contracts.Business.App.ITrackAlbumGenre>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
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
                if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.MasterData.IGenre))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.MasterData.IGenre, Transfer.Models.Persistence.MasterData.Genre>(sessionToken, BaseUri, "Genres") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.IAlbum))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.App.IAlbum, Transfer.Models.Persistence.App.Album>(sessionToken, BaseUri, "Albums") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.IArtist))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.App.IArtist, Transfer.Models.Persistence.App.Artist>(sessionToken, BaseUri, "Artists") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Persistence.App.ITrack))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Persistence.App.ITrack, Transfer.Models.Persistence.App.Track>(sessionToken, BaseUri, "Tracks") as Contracts.Client.IAdapterAccess<C>;
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
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IAlbumTracks))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.App.IAlbumTracks, Transfer.Models.Business.App.AlbumTracks>(sessionToken, BaseUri, "AlbumTracks") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IArtistAlbums))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.App.IArtistAlbums, Transfer.Models.Business.App.ArtistAlbums>(sessionToken, BaseUri, "ArtistAlbums") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.IGenreTracks))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.App.IGenreTracks, Transfer.Models.Business.App.GenreTracks>(sessionToken, BaseUri, "GenreTracks") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQMusicStore.Contracts.Business.App.ITrackAlbumGenre))
                {
                    result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.Business.App.ITrackAlbumGenre, Transfer.Models.Business.App.TrackAlbumGenre>(sessionToken, BaseUri, "TrackAlbumGenres") as Contracts.Client.IAdapterAccess<C>;
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
