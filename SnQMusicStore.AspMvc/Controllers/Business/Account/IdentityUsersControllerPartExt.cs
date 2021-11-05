﻿//@CodeCopy
//MdStart
#if ACCOUNT_ON
using CommonBase.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = SnQMusicStore.AspMvc.Models.Business.Account.IdentityUser;

namespace SnQMusicStore.AspMvc.Controllers.Business.Account
{
    public partial class IdentityUsersController
    {
        protected override IActionResult ReturnCreateView(Model model)
        {
            return RedirectToAction("Create", "Identities");
        }

        #region Export and Import
        protected override string[] CsvHeader => new string[] 
        {
            "Id", 
            $"{nameof(Model.AnotherItem)}.Id",
            $"{nameof(Model.OneItem)}.Name",
            $"{nameof(Model.OneItem)}.Email",
            $"{nameof(Model.AnotherItem)}.Firstname",
            $"{nameof(Model.AnotherItem)}.Lastname",
            $"{nameof(Model.OneItem)}.Password",
            $"{nameof(Model.OneItem)}.AccessFailedCount",
            $"{nameof(Model.OneItem)}.EnableJwtAuth" 
        };

        [ActionName("Export")]
        public async Task<FileResult> ExportAsync()
        {
            var fileName = "IdentityUsers.csv";
            using var ctrl = CreateController();
            var entities = (await ctrl.GetAllAsync().ConfigureAwait(false)).Select(e => ToModel(e));

            return ExportDefault(CsvHeader, entities, fileName);
        }

        [ActionName("Import")]
        public ActionResult ImportAsync(string error = null)
        {
            var model = new Models.Modules.Csv.ImportProtocol() { BackController = ControllerName };

            if (error.HasContent())
                LastError = error;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Import")]
        public async Task<IActionResult> ImportAsync()
        {
            var index = 0;
            var model = new Models.Modules.Csv.ImportProtocol() { BackController = ControllerName };
            var logInfos = new List<Models.Modules.Csv.ImportLog>();
            var importModels = ImportDefault<Model>(CsvHeader);
            using var ctrl = CreateController();

            foreach (var item in importModels)
            {
                index++;
                try
                {
                    if (item.Action == Models.Modules.Csv.ImportAction.Insert)
                    {
                        var entity = await ctrl.CreateAsync();

                        CopyModels(CsvHeader, item.Model, entity);
                        await ctrl.InsertAsync(entity);
                    }
                    else if (item.Action == Models.Modules.Csv.ImportAction.Update)
                    {
                        var entity = await ctrl.GetByIdAsync(item.Id);

                        CopyModels(CsvHeader, item.Model, entity);
                        await ctrl.UpdateAsync(entity);
                    }
                    else if (item.Action == Models.Modules.Csv.ImportAction.Delete)
                    {
                        await ctrl.DeleteAsync(item.Id);
                    }
                    logInfos.Add(new Models.Modules.Csv.ImportLog
                    {
                        IsError = false,
                        Prefix = $"Line: {index} - {item.Action}",
                        Text = "OK",
                    });
                }
                catch (Exception ex)
                {
                    logInfos.Add(new Models.Modules.Csv.ImportLog
                    {
                        IsError = true,
                        Prefix = $"Line: {index} - {item.Action}",
                        Text = ex.GetError(),
                    });
                }
            }
            model.LogInfos = logInfos;
            return View(model);
        }
        #endregion Export and Import
    }
}
#endif
//MdEnd
