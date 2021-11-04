//@GeneratedCode
namespace SnQMusicStore.WebApi.Controllers.Persistence.MusicStore
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.MusicStore.IAlbum;
    using TModel = Transfer.Models.Persistence.MusicStore.Album;
    [ApiController]
    [Route("Controller")]
    public partial class AlbumsController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
