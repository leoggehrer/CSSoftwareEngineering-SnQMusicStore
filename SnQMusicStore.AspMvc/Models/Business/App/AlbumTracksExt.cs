namespace SnQMusicStore.AspMvc.Models.Business.App
{
    partial class AlbumTracks
    {
        public override string ToString()
        {
            return $"{OneModel.Artist?.Name}";
        }
    }
}
