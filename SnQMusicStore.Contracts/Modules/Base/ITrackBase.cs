namespace SnQMusicStore.Contracts.Modules.Base
{
    public interface ITrackBase 
    {
        string Title { get; set; }
        [ContractPropertyInfo(MaxLength = 512)]
        string Composer { get; set; }
    }
}
