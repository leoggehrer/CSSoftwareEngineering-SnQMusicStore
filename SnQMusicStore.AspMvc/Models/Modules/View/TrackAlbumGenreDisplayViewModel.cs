
using SnQMusicStore.AspMvc.Modules.View;
using System;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class TrackAlbumGenreDisplayViewModel : DisplayViewModel
    {
        public TrackAlbumGenreDisplayViewModel(ViewBagWrapper viewBagWrapper, ModelObject model, Type modelType, Type displayType) 
            : base(viewBagWrapper, model, modelType, displayType)
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
