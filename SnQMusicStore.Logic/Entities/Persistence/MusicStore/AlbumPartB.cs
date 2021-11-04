//@GeneratedCode
namespace SnQMusicStore.Logic.Entities.Persistence.MusicStore
{
    partial class Album
    {
        public System.Collections.Generic.ICollection<SnQMusicStore.Logic.Entities.Persistence.MusicStore.Track> Tracks
        {
            get;
            set;
        }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ArtistId")]
        public SnQMusicStore.Logic.Entities.Persistence.MusicStore.Artist Artist
        {
            get;
            set;
        }
    }
}
