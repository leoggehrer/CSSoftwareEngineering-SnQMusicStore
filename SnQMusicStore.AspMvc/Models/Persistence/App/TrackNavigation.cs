using SnQMusicStore.Contracts.Persistence.App;
using SnQMusicStore.Contracts.Persistence.MasterData;
using System.Collections.Generic;

namespace SnQMusicStore.AspMvc.Models.Persistence.App
{
    partial class Track
    {
        public IGenre Genre { get; set; }
        public IEnumerable<IGenre> Genres { get; set; }
        public IAlbum Album { get; set; }
        public IEnumerable<IAlbum> Albums { get; set; }
    }
}
