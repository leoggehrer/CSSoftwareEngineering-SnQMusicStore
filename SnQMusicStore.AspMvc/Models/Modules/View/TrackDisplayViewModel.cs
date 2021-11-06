using SnQMusicStore.AspMvc.Models.Persistence.App;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class TrackDisplayViewModel : DisplayViewModel
    {
        public TrackDisplayViewModel(IdentityModel model, string[] hiddenNames, string[] ignoreNames, string[] displayNames) 
            : base(model, hiddenNames, ignoreNames, displayNames)
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
