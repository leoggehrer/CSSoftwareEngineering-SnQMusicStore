using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class TrackDisplayViewModel : DisplayViewModel
    {
        public TrackDisplayViewModel(ViewBagWrapper viewBagWrapper, ModelObject model, Type modelType, Type displayType) 
            : base(viewBagWrapper, model, modelType, displayType)
        {
        }

        public override string GetDisplayValue(PropertyInfo propertyInfo)
        {
            string result;

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
            return result;
        }
    }
}
