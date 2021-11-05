//@CodeCopy

namespace SnQMusicStore.Contracts
{
	public partial interface IVersionable : IIdentifiable
	{
		byte[] RowVersion { get; }
	}
}
