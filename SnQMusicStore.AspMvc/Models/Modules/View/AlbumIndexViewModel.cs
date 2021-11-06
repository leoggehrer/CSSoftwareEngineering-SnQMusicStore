using SnQMusicStore.AspMvc.Models.Persistence.App;
using System.Collections.Generic;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class AlbumIndexViewModel : IndexViewModel
    {
        public AlbumIndexViewModel(IEnumerable<IdentityModel> models, string[] hiddenNames, string[] ignoreNames, string[] displayNames) 
            : base(models, hiddenNames, ignoreNames, displayNames)
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
