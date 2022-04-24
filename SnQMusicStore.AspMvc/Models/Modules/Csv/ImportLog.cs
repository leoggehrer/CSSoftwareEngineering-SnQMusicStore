//@CodeCopy
//MdStart

namespace SnQMusicStore.AspMvc.Models.Modules.Csv
{
    public class ImportLog
    {
        public bool IsError { get; set; }
        public string Prefix { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
//MdEnd
