﻿//@CodeCopy
//MdStart
#if ACCOUNT_ON

namespace SnQMusicStore.Contracts.Persistence.Account
{
    [ContractInfo]
    public partial interface IUser : IVersionable, ICopyable<IUser>
    {
        [ContractPropertyInfo(IsUnique = true)]
        int IdentityId { get; set; }
        [ContractPropertyInfo(MaxLength = 64)]
        string Firstname { get; set; }
        [ContractPropertyInfo(MaxLength = 64)]
        string Lastname { get; set; }
    }
}
#endif
//MdEnd
