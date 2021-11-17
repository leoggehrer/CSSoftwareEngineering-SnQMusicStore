
using SnQMusicStore.AspMvc.Modules.View;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class TrackAlbumGenreDisplayViewModel : DisplayViewModel
    {
        public TrackAlbumGenreDisplayViewModel(ViewBagWrapper viewBagWrapper, IdentityModel model) 
            : base(viewBagWrapper, model)
        {
            IgnoreNames.AddRange(new string[]
            {
                "ArtistId",
                "AlbumId",
                "GenreId",
            });
        }
    }
}
