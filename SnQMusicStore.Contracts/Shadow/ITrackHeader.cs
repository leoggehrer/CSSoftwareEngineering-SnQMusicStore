namespace SnQMusicStore.Contracts.Shadow
{
    public interface ITrackHeader : IIdentifiable, Modules.Base.ITrackBase, IShadow<Persistence.App.ITrack>, ICopyable<ITrackHeader>
    {
    }
}
