//@GeneratedCode
namespace SnQMusicStore.Logic.Entities.Persistence.Account
{
    partial class User
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdentityId")]
        public SnQMusicStore.Logic.Entities.Persistence.Account.Identity Identity
        {
            get;
            set;
        }
    }
}
