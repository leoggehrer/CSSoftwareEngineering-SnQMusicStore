using SnQMusicStore.AspMvc.Models.Persistence.App;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class AlbumDisplayViewModel : DisplayViewModel
    {
        public AlbumDisplayViewModel(IdentityModel model, string[] hiddenNames, string[] ignoreNames, string[] displayNames) 
            : base(model, hiddenNames, ignoreNames, displayNames)
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
