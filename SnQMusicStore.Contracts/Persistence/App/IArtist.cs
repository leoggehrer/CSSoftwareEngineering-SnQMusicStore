using CommonBase.Attributes;

namespace SnQMusicStore.Contracts.Persistence.App
{
    [ContractInfo(ContextType = ContextType.Table)]
	public interface IArtist : Modules.Base.INameable, IVersionable, ICopyable<IArtist>
	{
	}
}
