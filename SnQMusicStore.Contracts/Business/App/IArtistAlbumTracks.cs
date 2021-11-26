namespace SnQMusicStore.Contracts.Business.App
{
    public interface IArtistAlbumTracks : IOneToMany<Persistence.App.IArtist, Business.App.IAlbumTracks>, ICopyable<IArtistAlbumTracks>
    {
    }
}
