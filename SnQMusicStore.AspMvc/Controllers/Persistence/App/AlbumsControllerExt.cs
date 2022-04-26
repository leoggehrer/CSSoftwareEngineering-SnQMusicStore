using Microsoft.AspNetCore.Mvc;
using SnQMusicStore.AspMvc.Models.Modules.Common;
using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQMusicStore.AspMvc.Controllers.Persistence.App
{
    partial class AlbumsController
    {
        internal static async Task<Album> LoadModelReferencesAsync(string sessionToken, Album model, ActionMode action)
        {
            if (action == ActionMode.Details || action == ActionMode.Create || action == ActionMode.Edit || action == ActionMode.Delete)
            {
                using var artistCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IArtist>(sessionToken);

                model.Artists = (await artistCtrl.GetAllAsync().ConfigureAwait(false)).ToList();

                var artist = model.Artists.FirstOrDefault(e => e.Id == model.ArtistId);

                if (artist != null)
                {
                    model.Artist = artist;
                }
            }
            return model;
        }
        internal static async Task<IEnumerable<Album>> LoadModelsReferencesAsync(string sessionToken, IEnumerable<Album> models)
        {
            using var artistCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IArtist>(sessionToken);
            var artists = await artistCtrl.GetAllAsync().ConfigureAwait(false);
            var result = new List<Album>();

            foreach (var model in models)
            {
                var artist = artists.FirstOrDefault(e => e.Id == model.ArtistId);

                if (artist != null)
                {
                    model.Artist = artist;
                }
                result.Add(model);
            }
            return result;
        }

        protected override async Task<Album> BeforeViewAsync(Album model, ActionMode action)
        {
            var result = await LoadModelReferencesAsync(SessionInfo.SessionToken, model, action).ConfigureAwait(false);

            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }
        protected override async Task<IEnumerable<Album>> BeforeViewAsync(IEnumerable<Album> models, ActionMode action)
        {
            var viewBagWrapper = new ViewBagWrapper(ViewBag);
            var sessionToken = SessionInfo.LoginSession?.SessionToken ?? string.Empty;
            var result = await LoadModelsReferencesAsync(sessionToken, models).ConfigureAwait(false);

            viewBagWrapper.CommandMode |= CommandMode.Details;
            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }

        public override async Task<IActionResult> DetailsAsync(int id)
        {
            var viewBagInfo = new ViewBagWrapper(ViewBag);
            var sessionToken = SessionInfo.LoginSession?.SessionToken ?? string.Empty;
            using var ctrl = CreateController<Contracts.Business.App.IAlbumTracks>();
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
            var model = Models.Business.App.AlbumTracks.Create(entity!);
            var modelType = model.GetType();
            var displayType = modelType;

            await LoadModelReferencesAsync(sessionToken, model.OneModel, ActionMode.Details).ConfigureAwait(false);
            await TracksController.LoadModelsReferencesAsync(sessionToken, model.ManyModels).ConfigureAwait(false);

            viewBagInfo.CommandMode = CommandMode.None;
            return View("Details", ViewModelCreator.CreateDisplayViewModel(viewBagInfo, model, modelType, displayType));
        }
    }
}
