//@CodeCopy
//MdStart
#if ACCOUNT_ON


namespace SnQMusicStore.AspMvc.Models.Persistence.Account
{
    public partial class Role
    {
        public bool Assigned { get; set; }
        public List<Role> AssignedRoles { get; set; } = new();
    }
}
#endif
//MdEnd
