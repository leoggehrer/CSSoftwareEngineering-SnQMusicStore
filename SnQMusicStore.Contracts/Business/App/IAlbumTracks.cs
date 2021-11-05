namespace SnQMusicStore.Contracts.Business.App
{
    public interface IAlbumTracks : IOneToMany<Persistence.App.IAlbum, Persistence.App.ITrack>, ICopyable<IAlbumTracks>
    {
    }
}
