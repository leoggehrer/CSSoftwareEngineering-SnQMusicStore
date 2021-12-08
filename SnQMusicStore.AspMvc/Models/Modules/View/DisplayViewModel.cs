﻿//@CodeCopy
//MdStart
using CommonBase.Extensions;
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public partial class DisplayViewModel : ViewModel, IDisplayViewModel
    {
        private ModelObject model;
        private ModelObject displayModel;
        private IEnumerable<PropertyInfo> displayProperties;

        public ModelObject Model
        {
            get => model;
            set => model = value ?? model;
        }
        public ModelObject DisplayModel
        {
            get => displayModel ?? model;
            set => displayModel = value;
        }
        public IEnumerable<PropertyInfo> DisplayProperties
        {
            get => displayProperties;
            set => displayProperties = value ?? displayProperties;
        }

        public DisplayViewModel(ViewBagWrapper viewBagInfo, ModelObject model, Type modelType, Type displayType)
            : base(viewBagInfo, modelType, displayType)
        {
            model.CheckArgument(nameof(model));

            Constructing();
            Model = model;
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        public virtual IEnumerable<PropertyInfo> GetHiddenProperties()
        {
            return GetHiddenProperties(DisplayType);
        }
        public virtual IEnumerable<PropertyInfo> GetDisplayProperties()
        {
            return displayProperties ??= GetDisplayProperties(DisplayType);
        }
        public virtual object GetValue(PropertyInfo propertyInfo)
        {
            return GetValue(Model, propertyInfo);
        }
        public virtual string GetDisplayValue(PropertyInfo propertyInfo)
        {
            return GetDisplayValue(Model, propertyInfo);
        }
    }
}
//MdEnd
