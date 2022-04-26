using Microsoft.AspNetCore.Mvc.Rendering;
using SnQMusicStore.Contracts.Persistence.App;

namespace SnQMusicStore.AspMvc.Models.Persistence.App
{
    partial class Album
    {
        public IArtist? Artist { get; set; }
        public List<IArtist> Artists { get; set; } = new();
        public SelectList ArtistList
        {
            get
            {
                return new SelectList(Artists, "Id", "Name");
            }
        }
    }
}
