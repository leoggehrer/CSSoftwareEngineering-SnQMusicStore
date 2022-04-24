using SnQMusicStore.AspMvc.Modules.View;
using System;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class AlbumEditViewModel : EditViewModel
    {
        public AlbumEditViewModel(ViewBagWrapper viewBagWrapper, IdentityModel model, Type modelType, Type displayType) 
            : base(viewBagWrapper, model, modelType, displayType)
        {
            var property = modelType.GetProperty("ArtistList");

            if (property != null)
            {
                ViewBagInfo.AddMappingProperty("ArtistId", property);
            }
        }
    }
}
