using CommonBase.Attributes;

namespace SnQMusicStore.Contracts.Persistence.App
{
    [ContractInfo(ContextType = ContextType.Table)]
	public partial interface IAlbum : IVersionable, ICopyable<IAlbum>
	{
		int ArtistId { get; set; }
		[ContractPropertyInfo(Required = true, MaxLength = 1024, IsUnique = true, DefaultValue = "string.Empty")]
		string Title { get; set; }
	}
}
