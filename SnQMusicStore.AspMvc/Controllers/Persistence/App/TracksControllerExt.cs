using Microsoft.AspNetCore.Mvc;
using SnQMusicStore.AspMvc.Models.Modules.Common;
using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System.Linq;
using System.Threading.Tasks;

namespace SnQMusicStore.AspMvc.Controllers.Persistence.App
{
    partial class TracksController
    {
        internal static async Task<Track> LoadModelReferencesAsync(string sessionToken, Track model, ActionMode action)
        {
            if (action == ActionMode.Details || action == ActionMode.Create || action == ActionMode.Edit || action == ActionMode.Delete)
            {
                using var genreCtrl = Adapters.Factory.Create<Contracts.Persistence.MasterData.IGenre>(sessionToken);
                using var albumCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IAlbum>(sessionToken);

                model.Genres = await genreCtrl.GetAllAsync().ConfigureAwait(false);
                var genre = model.Genres.FirstOrDefault(e => e.Id == model.GenreId);

                if (genre != null)
                {
                    model.Genre = genre;
                }

                model.Albums = await albumCtrl.GetAllAsync().ConfigureAwait(false);
                var album = model.Albums.FirstOrDefault(e => e.Id == model.AlbumId);

                if (album != null)
                {
                    model.Album = album;
                }
            }
            return model;
        }
        internal static async Task<IEnumerable<Track>> LoadModelsReferencesAsync(string sessionToken, IEnumerable<Track> models)
        {
            using var genreCtrl = Adapters.Factory.Create<Contracts.Persistence.MasterData.IGenre>(sessionToken);
            using var albumCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IAlbum>(sessionToken);
            var genres = await genreCtrl.GetAllAsync().ConfigureAwait(false);
            var albums = await albumCtrl.GetAllAsync().ConfigureAwait(false);
            var result = new List<Track>();

            foreach (var model in models)
            {
                var genre = genres.FirstOrDefault(e => e.Id == model.GenreId);

                if (genre != null)
                {
                    model.Genre = genre;
                }

                var album = albums.FirstOrDefault(e => e.Id == model.AlbumId);

                if (album != null)
                {
                    model.Album = album;
                }
                result.Add(model);
            }
            return result;
        }

        protected override async Task<Track> BeforeViewAsync(Track model, ActionMode action)
        {
            var result = await LoadModelReferencesAsync(SessionInfo.SessionToken, model, action).ConfigureAwait(false);

            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }
        protected override async Task<IEnumerable<Track>> BeforeViewAsync(IEnumerable<Track> models, ActionMode action)
        {
            var sessionToken = SessionInfo.LoginSession?.SessionToken ?? string.Empty;
            var result = await LoadModelsReferencesAsync(sessionToken, models).ConfigureAwait(false);

            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }

        public override async Task<IActionResult> DetailsAsync(int id)
        {
            var viewBagWrapper = new ViewBagWrapper(ViewBag);
            var sessionToken = SessionInfo.LoginSession?.SessionToken ?? string.Empty;
            using var ctrl = CreateController<Contracts.Business.App.ITrackAlbumGenre>();
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
            var model = Models.Business.App.TrackAlbumGenre.Create(entity);

            if (model != null)
            {
                await LoadModelReferencesAsync(sessionToken, model.ConnectorModel, ActionMode.Details).ConfigureAwait(false);
                await AlbumsController.LoadModelReferencesAsync(sessionToken, model.OneModel, ActionMode.Details).ConfigureAwait(false);
            }
            viewBagWrapper.CommandMode = CommandMode.None;
            return View("Composite", model);
        }
    }
}
