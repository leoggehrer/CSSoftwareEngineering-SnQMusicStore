//@CodeCopy
//MdStart

namespace SnQMusicStore.Adapters
{
    public static partial class Factory
    {
        static Factory()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();

        /// <summary>
        /// The base url like https://localhost:5001/api
        /// </summary>
        public static string BaseUri { get; set; } = string.Empty;

        public static AdapterType Adapter { get; set; } = AdapterType.Controller;
    }
}
//MdEnd
