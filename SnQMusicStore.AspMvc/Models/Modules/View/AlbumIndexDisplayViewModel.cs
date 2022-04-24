using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class AlbumIndexDisplayViewModel : IndexDisplayViewModel
    {
        public AlbumIndexDisplayViewModel(ViewBagWrapper viewBagWrapper, Type modelType, Type displayType, ModelObject model, IEnumerable<PropertyInfo> displayProperties) 
            : base(viewBagWrapper, modelType, displayType, model, displayProperties)
        {
        }
        public override string GetDisplayValue(PropertyInfo? propertyInfo)
        {
            string? result = null;

            if (propertyInfo != null)
            {
                if (propertyInfo.Name.Equals(nameof(Album.ArtistId)))
                {
                    result = ((Album)Model).Artist?.Name;
                }
                else
                {
                    result = base.GetDisplayValue(propertyInfo);
                }
            }
            return result ?? string.Empty;
        }
    }
}
