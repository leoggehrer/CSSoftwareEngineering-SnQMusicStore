//@GeneratedCode
namespace SnQMusicStore.Logic.Controllers.Persistence.MusicStore
{
    sealed partial class AlbumController : GenericPersistenceController<SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum, Entities.Persistence.MusicStore.Album>
    {
        static AlbumController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal AlbumController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal AlbumController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
