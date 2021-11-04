//@GeneratedCode
namespace SnQMusicStore.Logic.Controllers.Persistence.MusicStore
{
    sealed partial class ArtistController : GenericPersistenceController<SnQMusicStore.Contracts.Persistence.MusicStore.IArtist, Entities.Persistence.MusicStore.Artist>
    {
        static ArtistController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal ArtistController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal ArtistController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
