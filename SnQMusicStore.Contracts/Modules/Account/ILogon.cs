//@CodeCopy
//MdStart
#if ACCOUNT_ON
namespace SnQMusicStore.Contracts.Modules.Account
{
    public partial interface ILogon
    {
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string Email { get; set; }
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string Password { get; set; }
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string OptionalInfo { get; set; }
    }
}
#endif
//MdEnd
