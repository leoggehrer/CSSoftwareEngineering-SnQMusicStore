//@GeneratedCode
namespace SnQMusicStore.Logic.Entities.Persistence.MusicStore
{
    partial class Track
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("AlbumId")]
        public SnQMusicStore.Logic.Entities.Persistence.MusicStore.Album Album
        {
            get;
            set;
        }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("GenreId")]
        public SnQMusicStore.Logic.Entities.Persistence.MusicStore.Genre Genre
        {
            get;
            set;
        }
    }
}
