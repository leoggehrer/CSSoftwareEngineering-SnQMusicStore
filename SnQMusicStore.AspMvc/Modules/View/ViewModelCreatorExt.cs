using SnQMusicStore.AspMvc.Models;
using SnQMusicStore.AspMvc.Models.Modules.View;
using System.Collections.Generic;

namespace SnQMusicStore.AspMvc.Modules.View
{
    partial class ViewModelCreator
    {
        partial void BeforeCreateIndexViewModel(string viewTypeName, IEnumerable<IdentityModel> models, ViewBagWrapper viewBagWrapper, ref IndexViewModel result, ref bool handled)
        {
            if (viewTypeName.Equals(typeof(Models.Business.App.AlbumTracks).FullName))
            {
                handled = true;
                result = new TrackIndexViewModel(models, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
            else if (viewTypeName.Equals(typeof(List<Models.Persistence.App.Track>).FullName))
            {
                handled = true;
                result = new TrackIndexViewModel(models, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
            else if (viewTypeName.Equals(typeof(List<Models.Persistence.App.Album>).FullName))
            {
                handled = true;
                result = new AlbumIndexViewModel(models, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
        }
        partial void BeforeCreateDisplayViewModel(string viewTypeName, IdentityModel model, ViewBagWrapper viewBagWrapper, ref DisplayViewModel result, ref bool handled)
        {
            if (viewTypeName.Equals(typeof(Models.Business.App.TrackAlbumGenre).FullName))
            {
                handled = true;
                result = new TrackAlbumGenreDisplayViewModel(model, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
            else if (viewTypeName.Equals(typeof(Models.Business.App.AlbumTracks).FullName))
            {
                handled = true;
                result = new AlbumDisplayViewModel(model, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
            else if (viewTypeName.Equals(typeof(Models.Persistence.App.Track).FullName))
            {
                handled = true;
                result = new TrackDisplayViewModel(model, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
            else if (viewTypeName.Equals(typeof(Models.Persistence.App.Album).FullName))
            {
                handled = true;
                result = new AlbumDisplayViewModel(model, viewBagWrapper.HiddenNames, viewBagWrapper.IgnoreNames, viewBagWrapper.DisplayNames);
            }
        }
    }
}
