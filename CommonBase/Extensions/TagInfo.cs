﻿//@CodeCopy
//MdStart

namespace CommonBase.Extensions
{
    public partial class TagInfo
    {
        internal class TagHeader
        {
            public TagHeader(string source)
            {
                Source = source;
            }
            public string Source { get; }
        }
        internal TagHeader? Header { get; set; }

        public string Source => Header?.Source ?? string.Empty;
        public string StartTag { get; internal set; } = string.Empty;
        public int StartTagIndex { get; internal set; }
        public string EndTag { get; internal set; } = string.Empty;
        public int EndTagIndex { get; internal set; }
        public int EndIndex => EndTagIndex + EndTag.Length;

        public string FullText => Source?.Partialstring(StartTagIndex, EndTagIndex + EndTag.Length - 1) ?? string.Empty;
        public string InnerText => Source?.Partialstring(StartTagIndex + StartTag.Length, EndTagIndex - 1) ?? string.Empty;

        public string GetText()
        {
            return GetText(InnerText);
        }
        public string GetText(string? innerText)
        {
            return Source?.Partialstring(0, StartTagIndex + StartTag.Length - 1) + innerText + Source?.Partialstring(EndTagIndex, Source.Length - 1);
        }
        public override string ToString()
        {
            return FullText ?? string.Empty;
        }

        public static TagInfo operator -(TagInfo left, TagInfo right)
        {
            return new TagInfo
            {
                Header = left.Header,
                StartTag = left.EndTag,
                StartTagIndex = left.EndTagIndex,
                EndTag = right.StartTag,
                EndTagIndex = right.StartTagIndex
            };
        }
    }
}
//MdEnd
