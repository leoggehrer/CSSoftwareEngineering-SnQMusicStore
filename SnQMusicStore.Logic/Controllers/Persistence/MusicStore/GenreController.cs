//@GeneratedCode
namespace SnQMusicStore.Logic.Controllers.Persistence.MusicStore
{
    sealed partial class GenreController : GenericPersistenceController<SnQMusicStore.Contracts.Persistence.MusicStore.IGenre, Entities.Persistence.MusicStore.Genre>
    {
        static GenreController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal GenreController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal GenreController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
