//@CodeCopy
//MdStart
using SnQMusicStore.Contracts.Modules.Common;

namespace SnQMusicStore.Contracts.ThirdParty
{
    [ContractInfo]
    public partial interface IStaticPage : IVersionable, ICopyable<IStaticPage>
    {
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string AppName { get; set; }
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string Key { get; set; }
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string Description { get; set; }
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string Content { get; set; }
        State State { get; set; }
    }
}
//MdEnd
