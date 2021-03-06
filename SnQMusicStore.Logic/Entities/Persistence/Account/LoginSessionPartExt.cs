//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQMusicStore.Contracts.Persistence.Account;
using SnQMusicStore.Logic.Modules.Security;
using System;

namespace SnQMusicStore.Logic.Entities.Persistence.Account
{
    partial class LoginSession
    {
        #region Identity members
        partial void OnIdentityIdReading()
        {
            if (Identity != null)
            {
                _identityId = Identity.Id;
            }
        }
        partial void OnNameReading()
        {
            if (Identity != null)
            {
                _name = Identity.Name;
            }
        }
        partial void OnEmailReading()
        {
            if (Identity != null)
            {
                _email = Identity.Email;
            }
        }
        partial void OnTimeOutInMinutesReading()
        {
            if (Identity != null)
            {
                _timeOutInMinutes = Identity.TimeOutInMinutes;
            }
            else
            {
                _timeOutInMinutes = Authorization.DefaultTimeOutInMinutes;
            }
        }
        internal byte[] PasswordHash
        {
            get => Identity != null ? Identity.PasswordHash : Array.Empty<byte>();
            set
            {
                if (Identity != null)
                    Identity.PasswordHash = value;
            }
        }
        internal byte[] PasswordSalt
        {
            get => Identity != null ? Identity.PasswordSalt : Array.Empty<byte>();
            set
            {
                if (Identity != null)
                    Identity.PasswordSalt = value;
            }
        }
        #endregion Identity members

        partial void OnOriginReading()
        {
            if (_origin == null)
            {
                _origin = nameof(SnQMusicStore);
            }
        }
        partial void OnLastAccessChanging(ref bool handled, DateTime value, ref DateTime _lastAccess)
        {
            if (_lastAccess < value)
            {
                _lastAccess = value;
                HasChanged = true;
            }
            handled = true;
        }

        #region Ignore properties
        internal bool IsActive => IsTimeout == false;
        internal bool IsTimeout
        {
            get
            {
                TimeSpan ts = DateTime.UtcNow - LastAccess;

                return LogoutTime.HasValue || ts.TotalSeconds > TimeOutInMinutes * 60;
            }
        }
        internal bool HasChanged { get; set; }
        internal List<Role> Roles { get; } = new List<Role>();
        #endregion Ignore properties

        partial void AfterCopyProperties(ILoginSession other)
        {
            if (other is LoginSession loginSession)
            {
                PasswordHash = loginSession.PasswordHash;
                PasswordSalt = loginSession.PasswordSalt;

                Roles.Clear();
                Roles.AddRange(loginSession.Roles);
            }
        }
    }
}
#endif
//MdEnd
