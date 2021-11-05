//@CodeCopy

using SnQMusicStore.Contracts;

namespace SnQMusicStore.Logic.Entities
{
	internal abstract partial class VersionEntity : IdentityEntity, IVersionable
	{
		public byte[] RowVersion { get; set; }
	}
}
