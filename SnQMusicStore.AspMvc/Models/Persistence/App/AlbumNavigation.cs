using Microsoft.AspNetCore.Mvc.Rendering;
using SnQMusicStore.Contracts.Persistence.App;
using System.Collections.Generic;

namespace SnQMusicStore.AspMvc.Models.Persistence.App
{
    partial class Album
    {
        public IArtist Artist { get; set; }
        public IEnumerable<IArtist> Artists { get; set; }
        public SelectList ArtistList
        {
            get
            {
                return new SelectList(Artists ?? System.Array.Empty<IArtist>(), "Id", "Name");
            }
        }
    }
}
