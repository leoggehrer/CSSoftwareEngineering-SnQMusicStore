using SnQMusicStore.AspMvc.Models.Persistence.App;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQMusicStore.AspMvc.Controllers.Persistence.App
{
    partial class TracksController
    {
        internal static async Task<Track> LoadReferenceDataAsync(string sessionToken, Track model, Action action)
        {
            if (action == Action.Display || action == Action.Create || action == Action.Edit || action == Action.Delete)
            {
                if (action == Action.Create || action == Action.Edit || action == Action.Delete)
                {
                    using var genreCtrl = Adapters.Factory.Create<Contracts.Persistence.MasterData.IGenre>(sessionToken);
                    using var albumCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IAlbum>(sessionToken);

                    model.Genres = await genreCtrl.GetAllAsync().ConfigureAwait(false);
                    model.Genre = model.Genres.FirstOrDefault(e => e.Id == model.GenreId);
                    model.Albums = await albumCtrl.GetAllAsync().ConfigureAwait(false);
                    model.Album = model.Albums.FirstOrDefault(e => e.Id == model.AlbumId);
                }
            }
            return model;
        }
        internal static async Task<IEnumerable<Track>> LoadReferenceDataAsync(string sessionToken, IEnumerable<Track> models)
        {
            using var genreCtrl = Adapters.Factory.Create<Contracts.Persistence.MasterData.IGenre>(sessionToken);
            using var albumCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IAlbum>(sessionToken);
            var genres = await genreCtrl.GetAllAsync().ConfigureAwait(false);
            var albums = await albumCtrl.GetAllAsync().ConfigureAwait(false);
            var result = new List<Track>();

            foreach (var model in models)
            {
                model.Genre = genres.FirstOrDefault(e => e.Id == model.GenreId);
                model.Album = albums.FirstOrDefault(e => e.Id == model.AlbumId);
                result.Add(model);
            }
            return result;
        }

        protected override async Task<Track> BeforeViewAsync(Track model, Action action)
        {
            var result = await LoadReferenceDataAsync(SessionWrapper.SessionToken, model, action).ConfigureAwait(false);

            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }
        protected override async Task<IEnumerable<Track>> BeforeViewAsync(IEnumerable<Track> models, Action action)
        {
            var sessionToken = SessionWrapper.LoginSession.SessionToken;
            var result = await LoadReferenceDataAsync(sessionToken, models).ConfigureAwait(false);

            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }
    }
}
