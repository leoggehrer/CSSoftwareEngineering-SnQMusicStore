//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQMusicStore.Contracts.Persistence.Account;

namespace SnQMusicStore.Contracts.Business.Account
{
    public partial interface IIdentityUser : IOneToAnother<IIdentity, IUser>, ICopyable<IIdentityUser>
    {
    }
}
#endif
//MdEnd
