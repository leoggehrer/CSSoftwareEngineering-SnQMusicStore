using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System.Collections.Generic;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class TrackIndexViewModel : IndexViewModel
    {
        public TrackIndexViewModel(ViewBagWrapper viewBagWrapper, IEnumerable<IdentityModel> models)
            : base(viewBagWrapper, models)
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
