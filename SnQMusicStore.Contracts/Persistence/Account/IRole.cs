//@CodeCopy
//MdStart
#if ACCOUNT_ON

namespace SnQMusicStore.Contracts.Persistence.Account
{
    [ContractInfo]
    public partial interface IRole : IVersionable, ICopyable<IRole>
    {
        [ContractPropertyInfo(IsUnique = true, Required = true, MaxLength = 64, DefaultValue = "string.Empty")]
        string Designation { get; set; }
        [ContractPropertyInfo(MaxLength = 256, DefaultValue = "string.Empty")]
        string Description { get; set; }
    }
}
#endif
//MdEnd
