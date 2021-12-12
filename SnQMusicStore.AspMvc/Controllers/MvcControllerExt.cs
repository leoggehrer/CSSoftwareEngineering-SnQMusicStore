namespace SnQMusicStore.AspMvc.Controllers
{
    partial class MvcController
    {
        static partial void ClassConstructed()
        {
#if DEBUG
            Adapters.Factory.Adapter = Adapters.AdapterType.Service;
            Adapters.Factory.BaseUri = "http://localhost:34795/api";
            //Adapters.Factory.BaseUri = "https://localhost:5003/api";
#endif
        }
    }
}
