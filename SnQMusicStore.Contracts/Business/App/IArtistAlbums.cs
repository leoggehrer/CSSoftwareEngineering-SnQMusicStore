namespace SnQMusicStore.Contracts.Business.App
{
    public interface IArtistAlbums : IOneToMany<Persistence.App.IArtist, Business.App.IAlbumTracks>, ICopyable<IArtistAlbums>
    {
    }
}
