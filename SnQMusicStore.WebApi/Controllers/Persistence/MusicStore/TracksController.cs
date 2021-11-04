//@GeneratedCode
namespace SnQMusicStore.WebApi.Controllers.Persistence.MusicStore
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.MusicStore.ITrack;
    using TModel = Transfer.Models.Persistence.MusicStore.Track;
    [ApiController]
    [Route("Controller")]
    public partial class TracksController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
