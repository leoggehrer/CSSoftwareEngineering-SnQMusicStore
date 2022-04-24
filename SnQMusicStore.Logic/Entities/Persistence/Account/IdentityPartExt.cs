//@CodeCopy
//MdStart
#if ACCOUNT_ON

namespace SnQMusicStore.Logic.Entities.Persistence.Account
{
    internal partial class Identity
    {
        public byte[] PasswordHash { get; set; } = System.Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = System.Array.Empty<byte>();

        public void CopyProperties(Identity identity)
        {
            CopyProperties(identity as Contracts.Persistence.Account.IIdentity);

            PasswordHash = identity.PasswordHash;
            PasswordSalt = identity.PasswordSalt;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
#endif
//MdEnd
