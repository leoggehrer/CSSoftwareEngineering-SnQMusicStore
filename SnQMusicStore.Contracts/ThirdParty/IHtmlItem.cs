//@CodeCopy
//MdStart

using SnQMusicStore.Contracts.Modules.Common;

namespace SnQMusicStore.Contracts.ThirdParty
{
    public partial interface IHtmlItem : IVersionable, ICopyable<IHtmlItem>
    {
        string AppName { get; set; }
        string Key { get; set; }
        string Description { get; set; }
        string Content { get; set; }
        State State { get; set; }
    }
}
//MdEnd
