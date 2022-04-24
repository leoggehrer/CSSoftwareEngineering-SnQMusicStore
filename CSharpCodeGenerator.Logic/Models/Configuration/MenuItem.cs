//@CodeCopy
//MdStart

namespace CSharpCodeGenerator.Logic.Models.Configuration
{
    internal record MenuItem
    {
        public static string Type => nameof(MenuItem);
        public string Text { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int Order { get; set; }
    }
}
//MdEnd
