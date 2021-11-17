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
                result = new TrackIndexViewModel(viewBagWrapper, models);
            }
            else if (viewTypeName.Equals(typeof(List<Models.Persistence.App.Track>).FullName))
            {
                handled = true;
                result = new TrackIndexViewModel(viewBagWrapper, models);
            }
            else if (viewTypeName.Equals(typeof(List<Models.Persistence.App.Album>).FullName))
            {
                handled = true;
                result = new AlbumIndexViewModel(viewBagWrapper, models);
            }
        }
        partial void BeforeCreateDisplayViewModel(string viewTypeName, IdentityModel model, ViewBagWrapper viewBagWrapper, ref DisplayViewModel result, ref bool handled)
        {
            if (viewTypeName.Equals(typeof(Models.Business.App.TrackAlbumGenre).FullName))
            {
                handled = true;
                result = new TrackAlbumGenreDisplayViewModel(viewBagWrapper, model);
            }
            else if (viewTypeName.Equals(typeof(Models.Business.App.AlbumTracks).FullName))
            {
                handled = true;
                result = new AlbumDisplayViewModel(viewBagWrapper, model);
            }
            else if (viewTypeName.Equals(typeof(Models.Persistence.App.Track).FullName))    
            {
                handled = true;
                result = new TrackDisplayViewModel(viewBagWrapper, model);
            }
            else if (viewTypeName.Equals(typeof(Models.Persistence.App.Album).FullName))
            {
                handled = true;
                result = new AlbumDisplayViewModel(viewBagWrapper, model);
            }
        }
    }
}
