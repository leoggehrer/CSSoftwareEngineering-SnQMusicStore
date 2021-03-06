using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class AlbumTracksIndexViewModel : IndexViewModel
    {
        public AlbumTracksIndexViewModel(ViewBagWrapper viewBagWrapper, IEnumerable<IdentityModel> models, Type modelType, Type displayType) 
            : base(viewBagWrapper, models, modelType, displayType)
        {
        }

        public override string GetDisplayValue(object model, PropertyInfo propertyInfo)
        {
            string? result;

            if (propertyInfo.Name.Equals(nameof(Album.ArtistId)))
            {
                result = ((Album)model).Artist?.Name;
            }
            else
            {
                result = base.GetDisplayValue(model, propertyInfo);
            }
            return result ?? string.Empty;
        }
        public override IndexDisplayViewModel CreateDisplayViewModel(ModelObject model)
        {
            return new AlbumIndexDisplayViewModel(ViewBagInfo, ModelType, DisplayType, model, GetDisplayProperties());
        }
    }
}
