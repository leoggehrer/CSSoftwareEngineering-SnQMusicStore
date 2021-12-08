using SnQMusicStore.AspMvc.Models;
using SnQMusicStore.AspMvc.Models.Modules.View;
using System;
using System.Collections.Generic;

namespace SnQMusicStore.AspMvc.Modules.View
{
    partial class ViewModelCreator
    {
        static partial void BeforeCreateIndexViewModel(ViewBagWrapper viewBagWrapper, IEnumerable<IdentityModel> models, Type modelType, Type displayType, ref IndexViewModel result, ref bool handled)
        {
            if (modelType.Equals(typeof(Models.Business.App.AlbumTracks)))
            {
                handled = true;
                result = new AlbumTracksIndexViewModel(viewBagWrapper, models, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Persistence.App.Track)))
            {
                handled = true;
                result = new TrackIndexViewModel(viewBagWrapper, models, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Persistence.App.Album)))
            {
                handled = true;
                result = new AlbumIndexViewModel(viewBagWrapper, models, modelType, displayType);
            }
        }
        static partial void BeforeCreateDisplayViewModel(ViewBagWrapper viewBagWrapper, ModelObject model, Type modelType, Type displayType, ref DisplayViewModel result, ref bool handled)
        {
            if (modelType.Equals(typeof(Models.Business.App.TrackAlbumGenre)))
            {
                handled = true;
                result = new TrackAlbumGenreDisplayViewModel(viewBagWrapper, model, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Business.App.AlbumTracks)))
            {
                handled = true;
                result = new AlbumDisplayViewModel(viewBagWrapper, model, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Persistence.App.Track)))
            {
                handled = true;
                result = new TrackDisplayViewModel(viewBagWrapper, model, modelType, displayType);
            }
            else if (modelType.Equals(typeof(Models.Persistence.App.Album)))
            {
                handled = true;
                result = new AlbumDisplayViewModel(viewBagWrapper, model, modelType, displayType);
            }
        }
        static partial void BeforeCreateEditViewModel(ViewBagWrapper viewBagWrapper, IdentityModel model, Type modelType, Type displayType, ref EditViewModel result, ref bool handled)
        {
            if (modelType.Equals(typeof(Models.Persistence.App.Album)))
            {
                handled = true;
                result = new AlbumEditViewModel(viewBagWrapper, model, modelType, displayType);
            }
        }
    }
}
