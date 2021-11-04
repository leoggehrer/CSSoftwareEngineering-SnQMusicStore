//@GeneratedCode
namespace SnQMusicStore.WebApi.Controllers.Persistence.MusicStore
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.MusicStore.IArtist;
    using TModel = Transfer.Models.Persistence.MusicStore.Artist;
    [ApiController]
    [Route("Controller")]
    public partial class ArtistsController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
