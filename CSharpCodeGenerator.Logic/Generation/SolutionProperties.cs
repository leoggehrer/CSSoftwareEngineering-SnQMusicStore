﻿//@CodeCopy
//MdStart
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpCodeGenerator.Logic.Generation
{
    internal partial class SolutionProperties : Contracts.ISolutionProperties
    {
        #region Project-postfixes
        public static string ContractsPostfix => ".Contracts";
        public static string LogicPostfix => ".Logic";
        public static string TransferPostfix => ".Transfer";
        public static string WebApiPostfix => ".WebApi";
        public static string AdaptersPostfix => ".Adapters";
        public static string AngularAppPostfix => ".AngularApp";
        public static string AspMvcPostfix => ".AspMvc";
        public static string BlazorServerAppPostfix => ".BlazorServerApp";
        public static string TelerikBlazorServerAppPostfix => ".TelerikBlazorServerApp";
        public static string ConnectorPostfix => ".Connector";
        #endregion Project-postfixes

        #region ProjectNames
        public IEnumerable<string> ProjectNames => CommonBase.StaticLiterals.ProjectExtensions.Select(e => $"{SolutionName}{e}");
        public string ContractsProjectName => ProjectNames.First(e => e.EndsWith($"{ContractsPostfix}"));

        public string LogicProjectName => ProjectNames.First(e => e.EndsWith($"{LogicPostfix}"));
        public string TransferProjectName => ProjectNames.First(e => e.EndsWith($"{TransferPostfix}"));
        public string WebApiProjectName => ProjectNames.First(e => e.EndsWith($"{WebApiPostfix}"));
        public string AdaptersProjectName => ProjectNames.First(e => e.EndsWith($"{AdaptersPostfix}"));
        public string AngularAppProjectName => ProjectNames.First(e => e.EndsWith($"{AngularAppPostfix}"));
        public string AspMvcAppProjectName => ProjectNames.First(e => e.EndsWith($"{AspMvcPostfix}"));
        public string BlazorServerAppProjectName => ProjectNames.First(e => e.EndsWith($"{BlazorServerAppPostfix}"));
        public string TelerikBlazorServerAppProjectName => ProjectNames.First(e => e.EndsWith($"{TelerikBlazorServerAppPostfix}"));
        public string ConnectorProjectName => ProjectNames.First(e => e.EndsWith($"{ConnectorPostfix}"));
        #endregion ProjectNames

        #region ProjectPaths
        public string SolutionPath { get; }
        public string SolutionName { get; }
        public string ContractsFilePath { get; }

        public string ContractsSubPath => ContractsProjectName;
        public string LogicSubPath => LogicProjectName;
        public string TransferSubPath => TransferProjectName;
        public string WebApiSubPath => WebApiProjectName;
        public string AdaptersSubPath => AdaptersProjectName;
        public string AspMvcAppSubPath => AspMvcAppProjectName;
        public string BlazorServerAppSubPath => BlazorServerAppProjectName;
        public string ConnectorSubPath => ConnectorProjectName;
        #endregion ProjectPaths


        #region Entities
        public string EntitiesSubPath => StaticLiterals.EntitiesFolder;
        public string EntitiesBusinessSubPath => Path.Combine(LogicSubPath, EntitiesSubPath, StaticLiterals.BusinessFolder);
        public string EntitiesModulesSubPath => Path.Combine(LogicSubPath, EntitiesSubPath, StaticLiterals.ModulesFolder);
        public string EntitiesPersitenceSubPath => Path.Combine(LogicSubPath, EntitiesSubPath, StaticLiterals.PersistenceFolder);
        public string EntitiesShadowSubPath => Path.Combine(LogicSubPath, EntitiesSubPath, StaticLiterals.ShadowFolder);
        #endregion Entities

        #region DataContext
        public static string DataContextFolder => "DataContext";
        public string DataContextSubPath => DataContextFolder;
        public string DataContextDbFolder => "Db";
        public string DataContextPersistenceSubPath => Path.Combine(LogicSubPath, DataContextSubPath);
        #endregion DataContext

        #region Controllers
        public string ControllersSubPath => StaticLiterals.ControllersFolder;
        public string ControllersBusinessSubPath => Path.Combine(LogicSubPath, ControllersSubPath, StaticLiterals.BusinessFolder);
        public string ControllersPersistenceSubPath => Path.Combine(LogicSubPath, ControllersSubPath, StaticLiterals.PersistenceFolder);
        public string ControllersShadowSubPath => Path.Combine(LogicSubPath, ControllersSubPath, StaticLiterals.ShadowFolder);
        #endregion Controllers

        #region Logic-Factory
        public string LogicFactorySubPath => Path.Combine(LogicSubPath);
        #endregion Logic-Factory

        #region Transfer
        public string TransferBusinessSubPath => Path.Combine(TransferSubPath, StaticLiterals.BusinessFolder);
        public string TransferModulesSubPath => Path.Combine(TransferSubPath, StaticLiterals.ModulesFolder);
        public string TransferPersistenceSubPath => Path.Combine(TransferSubPath, StaticLiterals.PersistenceFolder);
        public string TransferShadowSubPath => Path.Combine(TransferSubPath, StaticLiterals.ShadowFolder);
        #endregion Transfer

        #region WebApi
        public string WebApiControllersSubPath => Path.Combine(WebApiSubPath, StaticLiterals.ControllersFolder);
        #endregion WebApi

        #region Adapters-Factory
        public string AdaptersFactorySubPath => Path.Combine(AdaptersSubPath);
        #endregion Adapters-Factory

        #region AspMvcApp
        public string AspMvcAppBusinessSubPath => Path.Combine(AspMvcAppSubPath, StaticLiterals.ModelsFolder, StaticLiterals.BusinessFolder);
        public string AspMvcAppModulesSubPath => Path.Combine(AspMvcAppSubPath, StaticLiterals.ModelsFolder, StaticLiterals.ModulesFolder);
        public string AspMvcAppPersistenceSubPath => Path.Combine(AspMvcAppSubPath, StaticLiterals.ModelsFolder, StaticLiterals.PersistenceFolder);
        public string AspMvcAppShadowSubPath => Path.Combine(AspMvcAppSubPath, StaticLiterals.ModelsFolder, StaticLiterals.ShadowFolder);
        #endregion AspMvcApp

        #region BlazorServerApp
        public string BlazorServerAppBusinessSubPath => Path.Combine(BlazorServerAppSubPath, StaticLiterals.ModelsFolder, StaticLiterals.BusinessFolder);
        public string BlazorServerAppModulesSubPath => Path.Combine(BlazorServerAppSubPath, StaticLiterals.ModelsFolder, StaticLiterals.ModulesFolder);
        public string BlazorServerAppPersistenceSubPath => Path.Combine(BlazorServerAppSubPath, StaticLiterals.ModelsFolder, StaticLiterals.PersistenceFolder);
        public string BlazorServerAppShadowSubPath => Path.Combine(BlazorServerAppSubPath, StaticLiterals.ModelsFolder, StaticLiterals.ShadowFolder);
        #endregion BlazorServerApp

        protected SolutionProperties(string solutionPath)
        {
            SolutionPath = solutionPath;
            SolutionName = GetSolutionName(solutionPath);
            ContractsFilePath = GetContractsFilePath(solutionPath);
        }
        protected SolutionProperties(string solutionName, string contactsFilePath)
        {
            SolutionPath = string.Empty;
            SolutionName = solutionName;
            ContractsFilePath = contactsFilePath;
        }

        public static SolutionProperties Create()
        {
            return new SolutionProperties(GetCurrentSolutionPath());
        }
        public static SolutionProperties Create(string solutionPath)
        {
            return new SolutionProperties(solutionPath);
        }
        public static SolutionProperties Create(string solutionName, string contactsFilePath)
        {
            return new SolutionProperties(solutionName, contactsFilePath);
        }

        private static string GetCurrentSolutionPath()
        {
            int endPos = AppContext.BaseDirectory.IndexOf($"{nameof(CSharpCodeGenerator)}", StringComparison.CurrentCultureIgnoreCase);

            return AppContext.BaseDirectory[..endPos];
        }
        private static string GetSolutionName(string solutionPath)
        {
            var fileInfo = new DirectoryInfo(solutionPath).GetFiles().SingleOrDefault(f => f.Extension.Equals(".sln", StringComparison.CurrentCultureIgnoreCase));

            return fileInfo != null ? Path.GetFileNameWithoutExtension(fileInfo.Name) : string.Empty;
        }
        private static string GetContractsFilePath(string solutionPath)
        {
            var result = default(string);
            var solutionName = GetSolutionName(solutionPath);
            var projectName = $"{solutionName}{StaticLiterals.ContractsExtension}";
            var binPath = Path.Combine(solutionPath, projectName, "bin");

            if (Directory.Exists(binPath))
            {
                var fileName = $"{projectName}.dll";
                var fileInfos = new DirectoryInfo(binPath).GetFiles(fileName, SearchOption.AllDirectories)
                                                          .Where(f => f.FullName.EndsWith(fileName))
                                                          .OrderByDescending(f => f.LastWriteTime);

                var fileInfo = fileInfos.Where(f => f.FullName.ToLower().Contains("\\ref\\") == false)
                                        .FirstOrDefault();

                if (fileInfo != null)
                {
                    result = fileInfo.FullName;
                }
            }
            return result ?? string.Empty;
        }

    }
}
//MdEnd
