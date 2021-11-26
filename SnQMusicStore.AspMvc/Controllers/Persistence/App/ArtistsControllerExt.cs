using Microsoft.AspNetCore.Mvc;
using SnQMusicStore.AspMvc.Modules.View;
using System.Threading.Tasks;

namespace SnQMusicStore.AspMvc.Controllers.Persistence.App
{
    partial class ArtistsController
    {
        public override async Task<IActionResult> DetailsAsync(int id)
        {
            var viewBagWrapper = new ViewBagWrapper(ViewBag);
            using var ctrl = CreateController<Contracts.Business.App.IArtistAlbums>();
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
            var model = Models.Business.App.ArtistAlbums.Create(entity);

            viewBagWrapper.IgnoreNames.Add("ArtistId");
            return View("Details", model);
        }
    }
}
