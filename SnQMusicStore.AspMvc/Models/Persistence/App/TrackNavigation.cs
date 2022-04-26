using SnQMusicStore.Contracts.Persistence.App;
using SnQMusicStore.Contracts.Persistence.MasterData;

namespace SnQMusicStore.AspMvc.Models.Persistence.App
{
    partial class Track
    {
        public IGenre? Genre { get; set; }
        public List<IGenre> Genres { get; set; } = new();
        public IAlbum? Album { get; set; }
        public List<IAlbum> Albums { get; set; } = new();
    }
}
