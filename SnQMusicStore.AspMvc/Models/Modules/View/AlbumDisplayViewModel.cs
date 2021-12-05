using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class AlbumDisplayViewModel : DisplayViewModel
    {
        public AlbumDisplayViewModel(ViewBagWrapper viewBagWrapper, ModelObject model, Type modelType, Type displayType) 
            : base(viewBagWrapper, model, modelType, displayType)
        {
        }

        public override string GetDisplayValue(PropertyInfo propertyInfo)
        {
            string result;

            if (propertyInfo.Name.Equals(nameof(Album.ArtistId)))
            {
                result = ((Album)Model).Artist?.Name;
            }
            else
            {
                result = base.GetDisplayValue(propertyInfo);
            }
            return result;
        }
    }
}
