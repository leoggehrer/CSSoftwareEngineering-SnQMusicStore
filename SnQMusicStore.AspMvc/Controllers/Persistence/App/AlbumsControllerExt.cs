using Microsoft.AspNetCore.Mvc;
using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQMusicStore.AspMvc.Controllers.Persistence.App
{
    partial class AlbumsController
    {
        internal static async Task<Album> LoadReferenceDataAsync(string sessionToken, Album model, Action action)
        {
            if (action == Action.Display || action == Action.Create || action == Action.Edit || action == Action.Delete)
            {
                using var artistCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IArtist>(sessionToken);

                model.Artists = await artistCtrl.GetAllAsync().ConfigureAwait(false);
                model.Artist = model.Artists.FirstOrDefault(e => e.Id == model.ArtistId);
            }
            return model;
        }
        internal static async Task<IEnumerable<Album>> LoadReferenceDataAsync(string sessionToken, IEnumerable<Album> models)
        {
            using var artistCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IArtist>(sessionToken);
            var artists = await artistCtrl.GetAllAsync().ConfigureAwait(false);
            var result = new List<Album>();

            foreach (var model in models)
            {
                model.Artist = artists.FirstOrDefault(e => e.Id == model.ArtistId);
                result.Add(model);
            }
            return result;
        }

        protected override async Task<Album> BeforeViewAsync(Album model, Action action)
        {
            var result = await LoadReferenceDataAsync(SessionWrapper.SessionToken, model, action).ConfigureAwait(false);

            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }
        protected override async Task<IEnumerable<Album>> BeforeViewAsync(IEnumerable<Album> models, Action action)
        {
            var viewBagWrapper = new ViewBagWrapper(ViewBag);
            var sessionToken = SessionWrapper.LoginSession.SessionToken;
            var result = await LoadReferenceDataAsync(sessionToken, models).ConfigureAwait(false);

            viewBagWrapper.CommandMode = viewBagWrapper.CommandMode | Models.Modules.Common.CommandMode.ShowDetails;
            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }

        public override async Task<IActionResult> DetailsAsync(int id)
        {
            var viewBagWrapper = new ViewBagWrapper(ViewBag);
            using var ctrl = CreateController<Contracts.Business.App.IAlbumTracks>();
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
            var model = Models.Business.App.AlbumTracks.Create(entity);

            if (model != null)
            {
                await LoadReferenceDataAsync(SessionWrapper.LoginSession.SessionToken, model.OneModel, Action.Display).ConfigureAwait(false);
                await TracksController.LoadReferenceDataAsync(SessionWrapper.LoginSession.SessionToken, model.ManyModels).ConfigureAwait(false);
            }
            viewBagWrapper.CommandMode = Models.Modules.Common.CommandMode.None;
            return View("MasterDetails", model);
        }
    }
}
