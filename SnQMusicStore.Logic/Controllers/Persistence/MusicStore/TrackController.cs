//@GeneratedCode
namespace SnQMusicStore.Logic.Controllers.Persistence.MusicStore
{
    sealed partial class TrackController : GenericPersistenceController<SnQMusicStore.Contracts.Persistence.MusicStore.ITrack, Entities.Persistence.MusicStore.Track>
    {
        static TrackController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal TrackController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal TrackController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
