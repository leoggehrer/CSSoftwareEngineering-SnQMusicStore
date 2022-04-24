//@CodeCopy
//MdStart

namespace SnQMusicStore.BlazorServerApp.Models
{
    public interface IThreePartView
    {
        IdentityModel FirstModel { get; }
        IdentityModel SecondModel { get; }
        IdentityModel ThirdModel { get; }
    }
}
//MdEnd
