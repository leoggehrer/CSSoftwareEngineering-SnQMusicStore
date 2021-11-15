using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnQMusicStore.Contracts.Business.App
{
    public partial interface ITrackAlbumGenre : IComposite<Persistence.App.ITrack, Persistence.App.IAlbum, Persistence.MasterData.IGenre>, ICopyable<ITrackAlbumGenre>
    {
    }
}
