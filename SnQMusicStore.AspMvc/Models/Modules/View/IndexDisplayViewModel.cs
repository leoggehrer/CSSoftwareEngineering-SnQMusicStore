//@CodeCopy
//MdStart
using SnQMusicStore.AspMvc.Modules.View;
using System;
using System.Reflection;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public partial class IndexDisplayViewModel : ViewModel, IDisplayViewModel
    {
        static IndexDisplayViewModel()
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

        public IndexDisplayViewModel(ViewBagWrapper viewBagInfo, Type modelType, Type displayType, ModelObject model, IEnumerable<PropertyInfo> displayProperties)
            : base(viewBagInfo, modelType, displayType)
        {
            Constructing();
            Model = model;
            DisplayProperties = displayProperties;
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public virtual IEnumerable<PropertyInfo> GetDisplayProperties()
        {
            return DisplayProperties;
        }

        public virtual object? GetValue(PropertyInfo? propertyInfo)
        {
             var handled = false;
            var result = default(object);

            BeforeGetValue(propertyInfo, ref result, ref handled);
            if (handled == false && propertyInfo != null)
            {
                result = GetValue(DisplayModel, propertyInfo);
            }
            AfterGetValue(result);
            return result;
        }
        partial void BeforeGetValue(PropertyInfo? propertyInfo, ref object? value, ref bool handled);
        partial void AfterGetValue(object? value);
        public virtual string GetDisplayValue(PropertyInfo? propertyInfo)
        {
            var handled = false;
            var result = string.Empty;

            BeforeGetDisplayValue(propertyInfo, ref result, ref handled);
            if (handled == false && propertyInfo != null)
            {
                result = GetDisplayValue(DisplayModel, propertyInfo);
            }
            AfterGetDisplayValue(result);
            return result;
        }
        partial void BeforeGetDisplayValue(PropertyInfo? propertyInfo, ref string value, ref bool handled);
        partial void AfterGetDisplayValue(string value);
    }
}
//MdEnd
