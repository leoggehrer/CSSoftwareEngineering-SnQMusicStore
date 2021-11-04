//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQMusicStore.Contracts.Persistence.Account;

namespace SnQMusicStore.Contracts.Business.Account
{
    public partial interface IAppAccess : IOneToMany<IIdentity, IRole>, ICopyable<IAppAccess>
    {

    }
}
#endif
//MdEnd
