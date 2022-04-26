//@CodeCopy
//MdStart
namespace SnQMusicStore.Logic.Modules.Exception
{
    public enum ErrorType : int
    {
#if ACCOUNT_ON
        InitAppAccess,
        InvalidAccount,
        InvalidIdentityName,

        InvalidToken,
        InvalidSessionToken,
        InvalidJsonWebToken,

        InvalidEmail,
        InvalidPassword,
        NotLogedIn,
        NotAuthorized,
        AuthorizationTimeOut,
#endif
        InvalidId,
        InvalidPageSize,

        InvalidEntityInsert,
        InvalidEntityUpdate,
        InvalidEntityContent,

        InvalidControllerType,
        InvalidControllerObject,
        InvalidOperation,
    }
}
//MdEnd
