using CommonBase.Attributes;

namespace SnQMusicStore.Contracts.Persistence.App
{
    [ContractInfo]
    public interface ITrack : IVersionable, ICopyable<ITrack>
    {
        int AlbumId { get; set; }
        int GenreId { get; set; }
        [ContractPropertyInfo(Required = true, MinLength = 2, MaxLength = 1024, HasIndex = true, DefaultValue = "string.Empty")]
        string Title { get; set; }
        [ContractPropertyInfo(MaxLength = 512, DefaultValue = "string.Empty")]
        string Composer { get; set; }
        long Milliseconds { get; set; }
        long Bytes { get; set; }
        double UnitPrice { get; set; }
    }
}
