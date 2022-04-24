using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class TrackIndexViewModel : IndexViewModel
    {
        public TrackIndexViewModel(ViewBagWrapper viewBagInfo, IEnumerable<IdentityModel> models, Type modelType, Type displayType)
            : base(viewBagInfo, models, modelType, displayType)
        {
            ViewBagInfo.IgnoreFilters.AddRange(new string[] { "AlbumId", "GenreId" });
            ViewBagInfo.IgnoreOrders.AddRange(new string[] { "AlbumId", "GenreId" });
        }

        public override string GetDisplayValue(object model, PropertyInfo propertyInfo)
        {
            string? result;

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
            return result ?? string.Empty;
        }
        public override IndexDisplayViewModel CreateDisplayViewModel(ModelObject model)
        {
            return new TrackIndexDisplayViewModel(ViewBagInfo, ModelType, DisplayType, model, GetDisplayProperties());
        }
    }
}
