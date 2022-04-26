//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQMusicStore.Contracts.Modules.Common;

namespace SnQMusicStore.Contracts.Persistence.Account
{
    [ContractInfo]
    public partial interface IIdentity : IVersionable, ICopyable<IIdentity>
    {
        [ContractPropertyInfo(Required = true, MaxLength = 36, DefaultValue = "string.Empty")]
        string Guid { get; }
        [ContractPropertyInfo(Required = true, MaxLength = 128, IsUnique = true, DefaultValue = "string.Empty")]
        string Name { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 128, IsUnique = true, ContentType = ContentType.EmailAddress, DefaultValue = "string.Empty")]
        string Email { get; set; }
        [ContractPropertyInfo(NotMapped = true, ContentType = ContentType.Password, DefaultValue = "string.Empty")]
        string Password { get; set; }
        [ContractPropertyInfo(DefaultValue = "30")]
        int TimeOutInMinutes { get; set; }
        bool EnableJwtAuth { get; set; }
        int AccessFailedCount { get; set; }
        [ContractPropertyInfo(DefaultValue = "Contracts.Modules.Common.State.Active")]
        State State { get; set; }
    }
}
#endif
//MdEnd
