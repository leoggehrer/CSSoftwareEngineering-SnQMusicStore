using SnQMusicStore.Contracts.Persistence.App;
using System.Collections.Generic;

namespace SnQMusicStore.AspMvc.Models.Persistence.App
{
    partial class Album
    {
        public IArtist Artist { get; set; }
        public IEnumerable<IArtist> Artists { get; set; }
    }
}
