using SnQMusicStore.AspMvc.Models.Business.App;
using SnQMusicStore.AspMvc.Models.Modules.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQMusicStore.AspMvc.Controllers.Business.App
{
    public partial class AlbumTracksController
    {
        internal static async Task<AlbumTracks> LoadModelReferencesAsync(string sessionToken, AlbumTracks model, ActionMode action)
        {
            if (action == ActionMode.Details || action == ActionMode.Create || action == ActionMode.Edit || action == ActionMode.Delete)
            {
                using var artistCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IArtist>(sessionToken);

                model.OneModel.Artists = await artistCtrl.GetAllAsync().ConfigureAwait(false);
                model.OneModel.Artist = model.OneModel.Artists.FirstOrDefault(e => e.Id == model.ArtistId);
            }
            return model;
        }
        internal static async Task<IEnumerable<AlbumTracks>> LoadModelsReferencesAsync(string sessionToken, IEnumerable<AlbumTracks> models)
        {
            using var artistCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IArtist>(sessionToken);
            var artists = await artistCtrl.GetAllAsync().ConfigureAwait(false);
            var result = new List<AlbumTracks>();

            foreach (var model in models)
            {
                model.OneModel.Artist = artists.FirstOrDefault(e => e.Id == model.ArtistId);
                result.Add(model);
            }
            return result;
        }
        protected override async Task<AlbumTracks> BeforeViewAsync(AlbumTracks model, ActionMode action)
        {
            model = await LoadModelReferencesAsync(SessionInfo.LoginSession.SessionToken, model, action);

            return await base.BeforeViewAsync(model, action).ConfigureAwait(false);
        }
        protected override async Task<IEnumerable<AlbumTracks>> BeforeViewAsync(IEnumerable<AlbumTracks> models, ActionMode action)
        {
            models = await LoadModelsReferencesAsync(SessionInfo.LoginSession.SessionToken, models);

            return await base.BeforeViewAsync(models, action).ConfigureAwait(false);
        }

        protected override async Task<IEnumerable<AlbumTracks>> QueryModelPageListAsync(int pageIndex, int pageSize, bool applyFilter)
        {
            var result = new List<AlbumTracks>();
            var searchValue = SessionInfo.GetSearchValue(ControllerName)?.ToLower();

            result.AddRange(await base.QueryModelPageListAsync(pageIndex, pageSize, applyFilter).ConfigureAwait(false));

            if (searchValue.HasContent() && result.Count < pageSize)
            {
                var counter = 0;
                var models = default(IEnumerable<AlbumTracks>);

                do
                {
                    models = await base.QueryModelPageListAsync(pageIndex + counter++, pageSize, false).ConfigureAwait(false);

                    foreach (var model in models)
                    {
                        if (model.ToString().ToLower().Contains(searchValue))
                        {
                            if (result.Any(e => e.Id == model.Id) == false)
                            {
                                result.Add(model);
                            }
                        }
                    }
                } while (models.Any());
                SetSessionPageData(result.Count, pageIndex, pageSize);
            }
            return result.Take(pageSize);
        }
    }
}
