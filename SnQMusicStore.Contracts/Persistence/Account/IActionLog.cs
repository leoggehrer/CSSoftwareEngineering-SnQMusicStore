//@CodeCopy
//MdStart
#if ACCOUNT_ON
using System;

namespace SnQMusicStore.Contracts.Persistence.Account
{
    [ContractInfo]
    public partial interface IActionLog : IVersionable, ICopyable<IActionLog>
    {
        int IdentityId { get; set; }
        DateTime Time { get; set; }
        [ContractPropertyInfo(MaxLength = 256, DefaultValue = "string.Empty")]
        string Subject { get; set; }
        [ContractPropertyInfo(MaxLength = 128, DefaultValue = "string.Empty")]
        string Action { get; set; }
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string Info { get; set; }
    }
}
#endif
//MdEnd
