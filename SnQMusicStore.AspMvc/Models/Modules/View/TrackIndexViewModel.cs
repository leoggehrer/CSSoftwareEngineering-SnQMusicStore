using SnQMusicStore.AspMvc.Models.Persistence.App;
using System.Collections.Generic;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class TrackIndexViewModel : IndexViewModel
    {
        public TrackIndexViewModel(IEnumerable<IdentityModel> models, string[] hiddenNames, string[] ignoreNames, string[] displayNames) 
            : base(models, hiddenNames, ignoreNames, displayNames)
        {
        }

        public override string GetDisplayValue(object model, PropertyInfo propertyInfo)
        {
            string result;

            if (propertyInfo.Name.Equals(nameof(Track.GenreId)))
            {
                result = ((Track)model).Genre?.Name;
            }
            else if (propertyInfo.Name.Equals(nameof(Track.AlbumId)))
            {
                result = ((Track)model).Album?.Title;
            }
            else
            {
                result = base.GetDisplayValue(model, propertyInfo);
            }
            return result;
        }
    }
}
