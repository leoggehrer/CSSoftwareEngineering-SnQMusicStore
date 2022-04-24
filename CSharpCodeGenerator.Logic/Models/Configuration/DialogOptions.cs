//@CodeCopy
//MdStart

namespace CSharpCodeGenerator.Logic.Models.Configuration
{
    internal record DialogOptions
    {
        public static string Type => nameof(DialogOptions);
        public bool ShowTitle { get; set; }
        public bool ShowClose { get; set; }
        public string Left { get; set; } = string.Empty;
        public string Top { get; set; } = string.Empty;
        public string Bottom { get; set; } = string.Empty;
        public string Width { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
    }
}
//MdEnd
