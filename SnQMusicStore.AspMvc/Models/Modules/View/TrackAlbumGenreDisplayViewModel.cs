
namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class TrackAlbumGenreDisplayViewModel : DisplayViewModel
    {
        public TrackAlbumGenreDisplayViewModel(IdentityModel model, string[] hiddenNames, string[] ignoreNames, string[] displayNames) 
            : base(model, hiddenNames, ignoreNames, displayNames)
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
