using SnQMusicStore.AspMvc.Models.Persistence.App;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQMusicStore.AspMvc.Controllers.Persistence.App
{
    partial class AlbumsController
    {
        protected override async Task<Album> BeforeViewAsync(Album model, Action action)
        {
            if (action == Action.Create || action == Action.Edit || action == Action.Delete)
            {
                var sessionToken = SessionWrapper.LoginSession.SessionToken;
                using var artistCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IArtist>(sessionToken);

                model.Artists = await artistCtrl.GetAllAsync().ConfigureAwait(false);
                model.Artist = model.Artists.FirstOrDefault(e => e.Id == model.ArtistId);
            }
            return await base.BeforeViewAsync(model, action).ConfigureAwait(false);
        }
        protected override async Task<IEnumerable<Album>> BeforeViewAsync(IEnumerable<Album> models, Action action)
        {
            var sessionToken = SessionWrapper.LoginSession.SessionToken;
            using var artistCtrl = Adapters.Factory.Create<Contracts.Persistence.App.IArtist>(sessionToken);
            var artists = await artistCtrl.GetAllAsync().ConfigureAwait(false);
            var result = new List<Album>();

            foreach (var model in models)
            {
                model.Artist = artists.FirstOrDefault(e => e.Id == model.ArtistId);
                result.Add(model);
            }
            return await base.BeforeViewAsync(result, action).ConfigureAwait(false);
        }
    }
}
