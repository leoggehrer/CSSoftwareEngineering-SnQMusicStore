namespace SnQMusicStore.Contracts.Business.App
{
    public interface IArtistAlbums : IOneToMany<Persistence.App.IArtist, Persistence.App.IAlbum>, ICopyable<IArtistAlbums>
    {
    }
}
