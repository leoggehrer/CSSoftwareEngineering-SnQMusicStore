//@GeneratedCode
namespace SnQMusicStore.Adapters
{
    public static partial class Factory
    {
        public static Contracts.Client.IAdapterAccess<C> CreateThridParty<C>(string baseUri)
        {
            Contracts.Client.IAdapterAccess<C> result = null;
            if (typeof(C) == typeof(SnQMusicStore.Contracts.ThirdParty.IHtmlItem))
            {
                result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.ThirdParty.IHtmlItem, Transfer.Models.ThirdParty.HtmlItem>(baseUri, "HtmlItems")
                as Contracts.Client.IAdapterAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.ThirdParty.ITranslation))
            {
                result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.ThirdParty.ITranslation, Transfer.Models.ThirdParty.Translation>(baseUri, "Translations")
                as Contracts.Client.IAdapterAccess<C>;
            }
            return result;
        }
        public static Contracts.Client.IAdapterAccess<C> Create<C>(string baseUri, string sessionToken)
        {
            Contracts.Client.IAdapterAccess<C> result = null;
            if (typeof(C) == typeof(SnQMusicStore.Contracts.ThirdParty.IHtmlItem))
            {
                result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.ThirdParty.IHtmlItem, Transfer.Models.ThirdParty.HtmlItem>(sessionToken, baseUri, "HtmlItems") as Contracts.Client.IAdapterAccess<C>;
            }
            else if (typeof(C) == typeof(SnQMusicStore.Contracts.ThirdParty.ITranslation))
            {
                result = new Service.GenericServiceAdapter<SnQMusicStore.Contracts.ThirdParty.ITranslation, Transfer.Models.ThirdParty.Translation>(sessionToken, baseUri, "Translations") as Contracts.Client.IAdapterAccess<C>;
            }
            return result;
        }
    }
}
