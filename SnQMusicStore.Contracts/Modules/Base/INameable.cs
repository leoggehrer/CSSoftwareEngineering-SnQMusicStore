//@Ignore
using CommonBase.Attributes;

namespace SnQMusicStore.Contracts.Modules.Base
{
    public partial interface INameable
    {
        [ContractPropertyInfo(Required = true, MaxLength = 256, IsUnique = true, DefaultValue = "string.Empty")]
        string Name { get; set; }
    }
}
