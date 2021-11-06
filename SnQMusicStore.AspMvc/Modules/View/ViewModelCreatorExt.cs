using SnQMusicStore.AspMvc.Models;
using SnQMusicStore.AspMvc.Models.Modules.View;
using System.Collections.Generic;

namespace SnQMusicStore.AspMvc.Modules.View
{
    partial class ViewModelCreator
    {
        partial void BeforeCreateIndexViewModel(string viewName, IEnumerable<IdentityModel> models, ViewBagWrapper viewBagWrapper, ref IndexViewModel result, ref bool handled)
        {
            if (viewName.Equals("Tracks"))
            {
                handled = true;
                result = new TrackIndexViewModel(models, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
            else if (viewName.Equals("Albums"))
            {
                handled = true;
                result = new AlbumIndexViewModel(models, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
        }
        partial void BeforeCreateDisplayViewModel(string viewName, IdentityModel model, ViewBagWrapper viewBagWrapper, ref DisplayViewModel result, ref bool handled)
        {
            if (viewName.Equals("Tracks"))
            {
                handled = true;
                result = new TrackDisplayViewModel(model, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
            else if (viewName.Equals("Albums"))
            {
                handled = true;
                result = new AlbumDisplayViewModel(model, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
        }
    }
}
