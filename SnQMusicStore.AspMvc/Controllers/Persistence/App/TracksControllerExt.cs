﻿using Microsoft.AspNetCore.Mvc;
using SnQMusicStore.AspMvc.Models.Modules.Common;
using SnQMusicStore.AspMvc.Models.Persistence.App;
using SnQMusicStore.AspMvc.Modules.View;
using System.Collections.Generic;
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
                model.Genre = model.Genres.FirstOrDefault(e => e.Id == model.GenreId);
                model.Albums = await albumCtrl.GetAllAsync().ConfigureAwait(false);
                model.Album = model.Albums.FirstOrDefault(e => e.Id == model.AlbumId);
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
                model.Genre = genres.FirstOrDefault(e => e.Id == model.GenreId);
                model.Album = albums.FirstOrDefault(e => e.Id == model.AlbumId);
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
            var sessionToken = SessionInfo.LoginSession.SessionToken;
            var result = await LoadModelsReferencesAsync(sessionToken, models).ConfigureAwait(false);

            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }

        public override async Task<IActionResult> DetailsAsync(int id)
        {
            var viewBagWrapper = new ViewBagWrapper(ViewBag);
            using var ctrl = CreateController<Contracts.Business.App.ITrackAlbumGenre>();
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
            var model = Models.Business.App.TrackAlbumGenre.Create(entity);

            if (model != null)
            {
                await LoadModelReferencesAsync(SessionInfo.LoginSession.SessionToken, model.ConnectorModel, ActionMode.Details).ConfigureAwait(false);
                await AlbumsController.LoadModelReferencesAsync(SessionInfo.LoginSession.SessionToken, model.OneModel, ActionMode.Details).ConfigureAwait(false);
            }
            viewBagWrapper.CommandMode = Models.Modules.Common.CommandMode.None;
            return View("Composite", model);
        }

    }
}
