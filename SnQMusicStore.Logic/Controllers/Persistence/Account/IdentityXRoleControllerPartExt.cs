//@CodeCopy
//MdStart
#if ACCOUNT_ON
using Microsoft.EntityFrameworkCore;
using SnQMusicStore.Logic.Entities.Persistence.Account;
using System.Linq;
using System.Threading.Tasks;

namespace SnQMusicStore.Logic.Controllers.Persistence.Account
{
    partial class IdentityXRoleController
	{
		public async Task<Role[]> QueryIdentityRolesAsync(int identityId)
		{
			var result = new List<Role>();
			var roles = await QueryableSet().Where(e => e.IdentityId == identityId)
											.Include(e => e.Role)
											.Select(e => e.Role)
											.ToArrayAsync();

            foreach (var role in roles)
            {
				if (role != null)
					result.Add(role);
            }
			return result.ToArray();
		}
	}
}
#endif
//MdEnd
