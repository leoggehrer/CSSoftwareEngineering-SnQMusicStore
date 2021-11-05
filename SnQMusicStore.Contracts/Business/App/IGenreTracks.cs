namespace SnQMusicStore.Contracts.Business.App
{
    public interface IGenreTracks : IOneToMany<Persistence.MasterData.IGenre, Persistence.App.ITrack>, ICopyable<IGenreTracks>
    {
    }
}
