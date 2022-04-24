//@CodeCopy

using SnQMusicStore.Contracts;
using System;

namespace SnQMusicStore.Logic.Entities
{
	internal abstract partial class VersionEntity : IdentityEntity, IVersionable
	{
		public virtual byte[] RowVersion { get; set; } = Array.Empty<byte>();
	}
}
