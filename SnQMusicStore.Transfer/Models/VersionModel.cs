//@CodeCopy

using System;

namespace SnQMusicStore.Transfer.Models
{
    public partial class VersionModel : IdentityModel, Contracts.IVersionable
	{
		public byte[] RowVersion { get; set; } = Array.Empty<byte>();
	}
}
