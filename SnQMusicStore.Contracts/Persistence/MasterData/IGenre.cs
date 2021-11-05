using CommonBase.Attributes;

namespace SnQMusicStore.Contracts.Persistence.MasterData
{
    [ContractInfo(ContextType = ContextType.Table)]
	public interface IGenre : Modules.Base.INameable, IVersionable, ICopyable<IGenre>
	{

	}
}
