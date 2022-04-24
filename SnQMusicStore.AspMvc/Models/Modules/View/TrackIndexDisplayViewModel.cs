using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class TrackIndexDisplayViewModel : IndexDisplayViewModel
    {
        public TrackIndexDisplayViewModel(ViewBagWrapper viewBagWrapper, Type modelType, Type displayType, ModelObject model, IEnumerable<PropertyInfo> displayProperties) 
            : base(viewBagWrapper, modelType, displayType, model, displayProperties)
        {
        }
        public override string GetDisplayValue(PropertyInfo? propertyInfo)
        {
            string? result = null;

            if (propertyInfo != null)
            {
                if (propertyInfo.Name.Equals(nameof(Track.GenreId)))
                {
                    result = ((Track)Model).Genre?.Name;
                }
                else if (propertyInfo.Name.Equals(nameof(Track.AlbumId)))
                {
                    result = ((Track)Model).Album?.Title;
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
