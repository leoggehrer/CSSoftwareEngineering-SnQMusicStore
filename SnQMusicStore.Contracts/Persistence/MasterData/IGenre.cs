//@Ignore
using CommonBase.Attributes;

namespace SnQMusicStore.Contracts.Persistence.MusicStore
{
	[ContractInfo(ContextType = ContextType.Table)]
	public interface IGenre : Modules.Base.INameable, IVersionable, ICopyable<IGenre>
	{

	}
}
