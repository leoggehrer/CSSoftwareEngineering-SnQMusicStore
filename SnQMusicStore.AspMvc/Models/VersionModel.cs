//@CodeCopy
//MdStart
namespace SnQMusicStore.AspMvc.Models
{
    public class VersionModel : IdentityModel, Contracts.IVersionable
	{
		public byte[] RowVersion { get; set; }
	}
}
//MdEnd
