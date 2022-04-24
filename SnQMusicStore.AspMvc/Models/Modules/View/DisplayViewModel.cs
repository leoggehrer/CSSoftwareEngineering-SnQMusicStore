//@CodeCopy
//MdStart
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public partial class DisplayViewModel : ViewModel, IDisplayViewModel
    {
        static DisplayViewModel()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();

        private ModelObject? displayModel;
        private IEnumerable<PropertyInfo>? displayProperties;

        public ModelObject Model { get; set; }
        public ModelObject DisplayModel
        {
            get => displayModel ?? Model;
            set => displayModel = value;
        }
        public IEnumerable<PropertyInfo> DisplayProperties
        {
            get => displayProperties ?? Array.Empty<PropertyInfo>();
            set => displayProperties = value ?? displayProperties;
        }

        public DisplayViewModel(ViewBagWrapper viewBagInfo, ModelObject model, Type modelType, Type displayType)
            : base(viewBagInfo, modelType, displayType)
        {
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
        public virtual object? GetValue(PropertyInfo? propertyInfo)
        {
            return propertyInfo != null ? GetValue(Model, propertyInfo) : null;
        }
        public virtual string GetDisplayValue(PropertyInfo? propertyInfo)
        {
            return propertyInfo != null ? GetDisplayValue(Model, propertyInfo) : string.Empty;
        }
    }
}
//MdEnd
