//@CodeCopy
//MdStart
using SnQMusicStore.Contracts.Modules.Common;

namespace SnQMusicStore.Contracts.ThirdParty
{
    [ContractInfo]
    public interface ITranslation : IVersionable, ICopyable<ITranslation>
    {
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string AppName { get; set; }
        LanguageCode KeyLanguage { get; set; }
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string Key { get; set; }
        LanguageCode ValueLanguage { get; set; }
        [ContractPropertyInfo(DefaultValue = "string.Empty")]
        string Value { get; set; }
    }
}
//MdEnd
