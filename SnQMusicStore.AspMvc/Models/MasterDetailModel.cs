//@CodeCopy
//MdStart

namespace SnQMusicStore.AspMvc.Models
{
    public partial class MasterDetailModel : ModelObject
	{
        public IdentityModel Master { get; set; }
        public IdentityModel Detail { get; set; }
    }
}
//MdEnd
