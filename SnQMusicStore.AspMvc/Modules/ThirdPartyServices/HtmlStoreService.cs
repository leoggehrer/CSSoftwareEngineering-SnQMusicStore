﻿//@CodeCopy
//MdStart
using CommonBase.Extensions;
using CommonBase.Modules.Configuration;
using SnQMusicStore.AspMvc.Models.ThirdParty;
using SnQMusicStore.AspMvc.Modules.Handler;
using SnQMusicStore.Contracts.Modules.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SnQMusicStore.AspMvc.Modules.ThirdPartyServices

{
    public partial class HtmlStoreService
    {
        public static StaticPage GetPageContent(string pageName)
        {
            return GetPageContent(nameof(SnQMusicStore), pageName);
        }
        public static StaticPage GetPageContent(string appName, string pageName)
        {
            var result = default(StaticPage);
            var htmlStoreServer = AppSettings.Configuration[StaticLiterals.EnvironmentHtmlStoreServerKey];

            if (htmlStoreServer.HasContent())
            {
                var ctrl = Adapters.Factory.CreateThridParty<Contracts.ThirdParty.IStaticPage>(htmlStoreServer);
                var predicate = $"{nameof(StaticPage.AppName)} == \"{appName}\" AND {nameof(StaticPage.Key)} == \"{pageName}\" AND {nameof(StaticPage.State)} == \"{State.Active}\"";

                try
                {
                    var qry = Task.Run(async () =>
                    {
                        return await ctrl.QueryAllAsync(predicate).ConfigureAwait(false);
                    }).Result;

                    if (qry.Any())
                    {
                        result = StaticPage.Create(qry.ElementAt(0));
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.LastLogicError = $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {ex.GetError()}";
                    System.Diagnostics.Debug.WriteLine(ErrorHandler.LastLogicError);
                }
            }
            return result;
        }

        public static string GetHtmlElement(string key, string defaultContent)
        {
            return GetHtmlElement(nameof(SnQMusicStore), key, defaultContent);
        }
        public static string GetHtmlElement(string appName, string key, string defaultContent)
        {
            var result = defaultContent;
            var htmlStoreServer = AppSettings.Configuration[StaticLiterals.EnvironmentHtmlStoreServerKey];

            if (htmlStoreServer.HasContent())
            {
                var ctrl = Adapters.Factory.CreateThridParty<Contracts.ThirdParty.IHtmlElement>(htmlStoreServer);
                var predicate = $"{nameof(StaticPage.AppName)} == \"{appName}\" AND {nameof(StaticPage.Key)} == \"{key}\" AND {nameof(StaticPage.State)} == \"{State.Active}\"";

                try
                {
                    var qry = Task.Run(async () =>
                    {
                        return await ctrl.QueryAllAsync(predicate).ConfigureAwait(false);
                    }).Result;

                    if (qry.Any())
                    {
                        result = qry.ElementAt(0).Content;
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.LastLogicError = $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {ex.GetError()}";
                    System.Diagnostics.Debug.WriteLine(ErrorHandler.LastLogicError);
                }
            }
            return result;
        }

        public static string GetHtmlAttribute(string key, string defaultContent)
        {
            return GetHtmlAttribute(nameof(SnQMusicStore), key, defaultContent);
        }
        public static string GetHtmlAttribute(string appName, string key, string defaultContent)
        {
            var result = defaultContent;
            var htmlStoreServer = AppSettings.Configuration[StaticLiterals.EnvironmentHtmlStoreServerKey];

            if (htmlStoreServer.HasContent())
            {
                var ctrl = Adapters.Factory.CreateThridParty<Contracts.ThirdParty.IHtmlAttribute>(htmlStoreServer);
                var predicate = $"{nameof(StaticPage.AppName)} == \"{appName}\" AND {nameof(StaticPage.Key)} == \"{key}\" AND {nameof(StaticPage.State)} == \"{State.Active}\"";

                try
                {
                    var qry = Task.Run(async () =>
                    {
                        return await ctrl.QueryAllAsync(predicate).ConfigureAwait(false);
                    }).Result;

                    if (qry.Any())
                    {
                        result = qry.ElementAt(0).Content;
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.LastLogicError = $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {ex.GetError()}";
                    System.Diagnostics.Debug.WriteLine(ErrorHandler.LastLogicError);
                }
            }
            return result;
        }
    }
}
//MdEnd
