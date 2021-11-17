using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class AlbumDisplayViewModel : DisplayViewModel
    {
        public AlbumDisplayViewModel(ViewBagWrapper viewBagWrapper, IdentityModel model) 
            : base(viewBagWrapper, model)
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
