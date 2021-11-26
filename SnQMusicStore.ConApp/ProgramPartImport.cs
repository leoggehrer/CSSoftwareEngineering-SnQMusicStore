using CommonBase.Extensions;
using SnQMusicStore.Transfer.Models.Persistence.App;
using SnQMusicStore.Transfer.Models.Persistence.MasterData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnQMusicStore.ConApp
{
    partial class Program
    {
        private static async Task ImportDataAsync()
        {
            using var genreCtrl = Create<Contracts.Persistence.MasterData.IGenre>();
            using var artistCtrl = Create<Contracts.Persistence.App.IArtist>();
            using var albumCtrl = Create<Contracts.Persistence.App.IAlbum>();
            using var trackCtrl = Create<Contracts.Persistence.App.ITrack>();
            using var artistAlbumTracksCtrl = Create<Contracts.Business.App.IArtistAlbumTracks>();
            var genreData = File.ReadAllLines("Data\\Genre.csv", Encoding.Default).Skip(1).Select(l =>
            {
                var data = l.Split(';');
                return new { Data = data, Id = Int32.Parse(data[0]), Entity = new Genre { Name = data[1] } };
            });
            var artistData = File.ReadAllLines("Data\\Artist.csv", Encoding.Default).Skip(1).Select(l =>
            {
                var data = l.Split(';');
                return new { Data = data, Id = Int32.Parse(data[0]), Entity = new Artist { Name = data[1] } };
            });
            var albumData = File.ReadAllLines("Data\\Album.csv", Encoding.Default).Skip(1).Select(l =>
            {
                var data = l.Split(';');
                return new { Data = data, Id = Int32.Parse(data[0]), Entity = new Album { Title = data[1], ArtistId = Int32.Parse(data[2]) } };
            });
            var trackData = File.ReadAllLines("Data\\Track.csv", Encoding.Default).Skip(1).Select(l =>
            {
                var data = l.Split(';');
                return new { Data = data, Id = Int32.Parse(data[0]), Entity = new Track { Title = data[1], AlbumId = Int32.Parse(data[2]), GenreId = Int32.Parse(data[3]), Composer = data[4].Equals("<NULL>") ? null : data[4], Milliseconds = Int32.Parse(data[5]), Bytes = Int32.Parse(data[6]), UnitPrice = Double.Parse(data[7]) } };
            });
            var genres = new List<Contracts.Persistence.MasterData.IGenre>();

            // import genre
            genres.AddRange(await genreCtrl.InsertAsync(genreData.Select(e => e.Entity)));

            var artistAlbumsList = new List<Contracts.Business.App.IArtistAlbumTracks>();
            var artistAlbumsUpdateList = new List<Contracts.Business.App.IArtistAlbumTracks>();

            foreach (var item in artistData)
            {
                var artistAlbumTracks = await artistAlbumTracksCtrl.CreateAsync();
                var artist = artistAlbumTracks.OneItem;

                artist.CopyProperties(item.Entity);
                foreach (var item2 in albumData.Where(e => e.Entity.ArtistId == item.Id))
                {
                    var albumTracks = artistAlbumTracks.CreateManyItem();
                    var album = albumTracks.OneItem;

                    album.CopyProperties(item2.Entity);
                    foreach (var item3 in trackData.Where(e => e.Entity.AlbumId == item2.Id))
                    {
                        var track = albumTracks.CreateManyItem();
                        var idx = genreData.FindIndex(e => e.Id == item3.Entity.GenreId);

                        if (idx > -1)
                        {
                            item3.Entity.GenreId = genres[idx].Id;
                        }

                        track.CopyProperties(item3.Entity);
                        albumTracks.AddManyItem(track);
                    }
                    artistAlbumTracks.AddManyItem(albumTracks);
                }
                artistAlbumsUpdateList.Add(artistAlbumTracks);
            }
            artistAlbumsList.AddRange(await artistAlbumTracksCtrl.InsertAsync(artistAlbumsUpdateList));
        }
    }
}
