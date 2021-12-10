using SnQMusicStore.AspMvc.Models;
using SnQMusicStore.AspMvc.Models.Modules.View;
using System;
using System.Collections.Generic;

namespace SnQMusicStore.AspMvc.Modules.View
{
    partial class ViewModelCreator
    {
        static partial void BeforeCreateIndexViewModel(ViewBagWrapper viewBagInfo, IEnumerable<IdentityModel> models, Type modelType, Type displayType, ref IndexViewModel result, ref bool handled)
        {
            if (modelType.Equals(typeof(Models.Business.App.AlbumTracks)))
            {
                handled = true;
                result = new AlbumTracksIndexViewModel(viewBagInfo, models, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Persistence.App.Track)))
            {
                handled = true;
                result = new TrackIndexViewModel(viewBagInfo, models, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Persistence.App.Album)))
            {
                handled = true;
                result = new AlbumIndexViewModel(viewBagInfo, models, modelType, displayType);
            }
        }
        static partial void BeforeCreateDisplayViewModel(ViewBagWrapper viewBagInfo, ModelObject model, Type modelType, Type displayType, ref DisplayViewModel result, ref bool handled)
        {
            if (modelType.Equals(typeof(Models.Business.App.TrackAlbumGenre)))
            {
                handled = true;
                result = new TrackAlbumGenreDisplayViewModel(viewBagInfo, model, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Business.App.AlbumTracks)))
            {
                handled = true;
                result = new AlbumDisplayViewModel(viewBagInfo, model, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Persistence.App.Track)))
            {
                handled = true;
                result = new TrackDisplayViewModel(viewBagInfo, model, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Persistence.App.Album)))
            {
                handled = true;
                result = new AlbumDisplayViewModel(viewBagInfo, model, modelType, displayType);
            }
        }
        static partial void BeforeCreateEditViewModel(ViewBagWrapper viewBagInfo, IdentityModel model, Type modelType, Type displayType, ref EditViewModel result, ref bool handled)
        {
            if (modelType.Equals(typeof(Models.Persistence.App.Album)))
            {
                handled = true;
                result = new AlbumEditViewModel(viewBagInfo, model, modelType, displayType);
            }
        }
    }
}
