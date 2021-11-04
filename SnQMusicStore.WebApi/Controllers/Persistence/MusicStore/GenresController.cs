//@GeneratedCode
namespace SnQMusicStore.WebApi.Controllers.Persistence.MusicStore
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.MusicStore.IGenre;
    using TModel = Transfer.Models.Persistence.MusicStore.Genre;
    [ApiController]
    [Route("Controller")]
    public partial class GenresController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
