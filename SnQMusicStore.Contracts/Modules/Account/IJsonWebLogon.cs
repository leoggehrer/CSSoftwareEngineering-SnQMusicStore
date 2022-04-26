//@CodeCopy
//MdStart
#if ACCOUNT_ON
namespace SnQMusicStore.Contracts.Modules.Account
{
    public partial interface IJsonWebLogon
    {
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string Token { get; set; }
    }
}
#endif
//MdEnd
