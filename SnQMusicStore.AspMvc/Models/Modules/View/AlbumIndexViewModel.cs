using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class AlbumIndexViewModel : IndexViewModel
    {
        public AlbumIndexViewModel(ViewBagWrapper viewBagWrapper, IEnumerable<IdentityModel> models, Type modelType, Type displayType) 
            : base(viewBagWrapper, models, modelType, displayType)
        {
        }

        public override string GetDisplayValue(object model, PropertyInfo propertyInfo)
        {
            string result;

            if (propertyInfo.Name.Equals(nameof(Album.ArtistId)))
            {
                result = ((Album)model).Artist?.Name;
            }
            else
            {
                result = base.GetDisplayValue(model, propertyInfo);
            }
            return result;
        }
    }
}
