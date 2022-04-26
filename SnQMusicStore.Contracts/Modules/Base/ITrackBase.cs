namespace SnQMusicStore.Contracts.Modules.Base
{
    public interface ITrackBase 
    {
        [ContractPropertyInfo(Required = true, MinLength = 2, MaxLength = 1024, HasIndex = true, DefaultValue = "string.Empty")]
        string Title { get; set; }
        [ContractPropertyInfo(MaxLength = 512, DefaultValue = "string.Empty")]
        string Composer { get; set; }
    }
}
