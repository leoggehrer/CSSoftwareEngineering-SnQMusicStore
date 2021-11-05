//@CodeCopy
//MdStart
using SnQMusicStore.Contracts;

namespace SnQMusicStore.Logic.Entities
{
    internal abstract partial class IdentityEntity : EntityObject, IIdentifiable
	{
		public virtual int Id { get; set; }
    }
}
//MdEnd
