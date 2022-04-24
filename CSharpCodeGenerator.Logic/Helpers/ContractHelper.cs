//@CodeCopy
//MdStart
using CommonBase.Attributes;
using CSharpCodeGenerator.Logic.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpCodeGenerator.Logic.Helpers
{
    internal partial class ContractHelper
    {
        public static string BusinessLabel => "Business";
        public static string ModulesLabel => "Modules";
        public static string PersistenceLabel => "Persistence";
        public static string ShadowLabel => "Shadow";

        public Type Type { get; }
        private ContractInfoAttribute? Info { get; }

        public bool IsVersionable { get; }
        public bool IsIdentifiable { get; }
        public bool IsCopyable { get; }
        public bool IsOneToMany { get; }
        public string EntityType { get; }
        public string EntityName { get; }
        public string EntityFieldName => $"{char.ToLower(EntityName[0])}{EntityName[1..]}";

        public ContextType ContextType
        {
            get
            {
                var result = ContextType.Table;

                if (Info != null)
                    result = Info.ContextType;

                return result;
            }
        }
        public string SchemaName
        {
            get
            {
                var result = Info?.SchemaName;

                return result ?? GetModuleNameFromInterface(Type);
            }
        }
        public string ContextName
        {
            get
            {
                var result = Info?.ContextName;

                return result ?? GeneratorObject.CreateEntityNameFromInterface(Type);
            }
        }
        public string KeyName
        {
            get
            {
                var result = Info?.KeyName;

                return result ?? "Id";
            }
        }
        public Type? DelegateType => Info?.DelegateType;
        public bool HasLogicAccess => Info == null || Info.HasLogicAccess;
        public bool HasWebApiAccess => Info == null || Info.HasWebApiAccess;

        public ContractHelper(Type type)
        {
            Type = type;
            Info = Type.GetCustomAttribute<ContractInfoAttribute>();

            var subNameSpace = CreateSubNamespaceFromType(Type);
            var entityNameSpace = $"{StaticLiterals.EntitiesFolder}.{subNameSpace}";
            var typeInterfaces = GeneratorObject.GetInterfaces(type);

            IsVersionable = typeInterfaces.Any(e => e.Name.Equals(StaticLiterals.IVersionableName));
            IsIdentifiable = typeInterfaces.Any(e => e.Name.Equals(StaticLiterals.IIdentifiableName));
            IsCopyable = typeInterfaces.FirstOrDefault(e => e.IsGenericType
                                                         && e.Name.Equals(StaticLiterals.ICopyableName)
                                                         && e.GetGenericArguments()[0].Name.Equals(type.Name)) != null;
            IsOneToMany = HasOneToMany(type);

            EntityName = GeneratorObject.CreateEntityNameFromInterface(Type);
            EntityType = $"{entityNameSpace}.{EntityName}";
        }
        public IEnumerable<PropertyInfo> GetAllProperties() => GetAllProperties(Type);

        #region Interface/Contract Helpers
        public static bool IsBusinessType(Type type)
        {
            type.CheckInterface(nameof(type));

            return type.FullName != null && type.FullName.Contains(StaticLiterals.BusinessSubName);
        }
        public static bool IsOneToManyType(Type type)
        {
            type.CheckInterface(nameof(type));

            return type.FullName != null && type.GetInterfaces().Any(i => i.FullName != null && i.FullName.Contains(StaticLiterals.IOneToManyName));
        }
        public static bool IsOneToAnotherType(Type type)
        {
            type.CheckInterface(nameof(type));

            return type.GetInterfaces().Any(i => i.FullName != null && i.FullName.Contains(StaticLiterals.IOneToAnotherName));
        }
        public static bool IsCompositeType(Type type)
        {
            type.CheckInterface(nameof(type));

            return type.GetInterfaces().Any(i => i.FullName != null && i.FullName.Contains(StaticLiterals.ICompositeName));
        }
        public static bool IsModulesType(Type type)
        {
            type.CheckInterface(nameof(type));

            return type.FullName != null && type.FullName.Contains(StaticLiterals.ModulesSubName);
        }
        public static bool IsPersistenceType(Type type)
        {
            type.CheckInterface(nameof(type));

            return type.FullName != null && type.FullName.Contains(StaticLiterals.PersistenceSubName);
        }
        public static bool IsShadowType(Type type)
        {
            type.CheckInterface(nameof(type));

            return type.FullName != null && type.FullName.Contains(StaticLiterals.ShadowSubName);
        }
        public static bool IsThirdPartyType(Type type)
        {
            type.CheckInterface(nameof(type));

            return type.FullName != null && type.FullName.Contains(StaticLiterals.ThirdPartySubName);
        }

        public static IEnumerable<Type> GetBaseInterfaces(Type type)
        {
            type.CheckInterface(nameof(type));

            var result = new List<Type>();

            static void GetInterfacesRec(Type type, List<Type> interfaces)
            {
                foreach (var item in type.GetInterfaces())
                {
                    if (interfaces.Contains(item) == false)
                    {
                        interfaces.Add(item);
                    }
                    GetInterfacesRec(item, interfaces);
                }
            }
            GetInterfacesRec(type, result);
            return result;
        }
        public static Type? GetPersistenceBaseInterface(Type type)
        {
            type.CheckInterface(nameof(type));

            return type.GetInterfaces().FirstOrDefault(e => e.IsGenericType == false
                                                         && e.FullName != null && e.FullName.Contains(StaticLiterals.PersistenceSubName));
        }

        public static IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            type.CheckInterface(nameof(type));

            var result = new List<PropertyInfo>();

            foreach (var item in type.GetProperties())
            {
                result.Add(item);
            }
            return result;
        }
        public static IEnumerable<PropertyInfo> GetAllProperties(Type type)
        {
            type.CheckInterface(nameof(type));

            var propertyInfos = new List<PropertyInfo>();

            var queue = new Queue<Type>();
            var considered = new List<Type>
                {
                    type
                };
            queue.Enqueue(type);
            while (queue.Count > 0)
            {
                var subType = queue.Dequeue();
                foreach (var subInterface in subType.GetInterfaces())
                {
                    if (considered.Contains(subInterface)) continue;

                    considered.Add(subInterface);
                    queue.Enqueue(subInterface);
                }

                var typeProperties = subType.GetProperties(
                    BindingFlags.FlattenHierarchy
                    | BindingFlags.Public
                    | BindingFlags.Instance);

                var newPropertyInfos = typeProperties
                    .Where(x => !propertyInfos.Contains(x));

                propertyInfos.InsertRange(0, newPropertyInfos);
            }

            return propertyInfos;
        }
        public static IEnumerable<PropertyInfo> GetAllProperties(Type type, params Type[] ignoreInterfaces)
        {
            type.CheckInterface(nameof(type));

            static IEnumerable<Type> FlattenInterfaces(IEnumerable<Type> types)
            {
                var result = new List<Type>();

                foreach (var type in types)
                {
                    if (type.IsInterface
                        && result.Contains(type) == false)
                    {
                        result.Add(type);
                        FlattenInterfacesRec(type, result);
                    }
                }
                return result;
            }
            static void FlattenInterfacesRec(Type type, List<Type> types)
            {
                foreach (var itf in type.GetInterfaces())
                {
                    if (types.Contains(itf) == false)
                    {
                        types.Add(itf);
                        FlattenInterfacesRec(itf, types);
                    }
                }
            }

            var result = new List<PropertyInfo>();

            if (ignoreInterfaces.Contains(type) == false)
            {
                result.AddRange(GetProperties(type));
                var interfaces = FlattenInterfaces(type.GetInterfaces());

                foreach (var item in interfaces)
                {
                    if (ignoreInterfaces.Contains(item) == false)
                    {
                        foreach (var pi in GetProperties(item))
                        {
                            if (result.Find(p => p.Name.Equals(pi.Name)) == null)
                            {
                                result.Add(pi);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public static IEnumerable<PropertyInfo> GetEntityProperties(Type type)
        {
            var baseType = GetPersistenceBaseInterface(type);
            var typeProperties = GetAllProperties(type);
            var baseProperties = baseType != null ? GetAllProperties(baseType) : Array.Empty<PropertyInfo>();

            return FilterPropertiesForGeneration(type, typeProperties.Except(baseProperties));
        }
        public static IEnumerable<string> VersionProperties => new[] { "Id", "RowVersion" };
        public static IEnumerable<PropertyInfo> FilterPropertiesForGeneration(Type type, IEnumerable<PropertyInfo> properties)
        {
            return properties.Select(e => new ContractPropertyHelper(type, e))
                             .Where(e => e.Property.DeclaringType != null
                                      && e.Property.DeclaringType.Name.Equals(StaticLiterals.IVersionableName) == false
                                      && e.Property.DeclaringType.Name.Equals(StaticLiterals.IIdentifiableName) == false
                                      && e.Property.DeclaringType.Name.Equals(StaticLiterals.ICompositeName) == false
                                      && e.Property.DeclaringType.Name.Equals(StaticLiterals.IOneToAnotherName) == false
                                      && e.Property.DeclaringType.Name.Equals(StaticLiterals.IOneToManyName) == false
                                      && e.Property.DeclaringType.Name.Equals(StaticLiterals.IShadowName) == false
                                      && e.HasImplementation == false)
                             .OrderBy(e => e.Order)
                             .Select(e => e.Property);
        }
        public static IEnumerable<PropertyInfo> FilterShadowPropertiesForGeneration(Type type, IEnumerable<PropertyInfo> properties)
        {
            return FilterPropertiesByForGeneration(type, properties, new string[] {
                                                                                    StaticLiterals.IIdentifiableName,
                                                                                    StaticLiterals.IShadowName,
                                                                                  });
        }
        public static IEnumerable<PropertyInfo> FilterPropertiesByForGeneration(Type type, IEnumerable<PropertyInfo> properties, params string[] excludeDeclaringTypes)
        {
            return properties.Select(e => new ContractPropertyHelper(type, e))
                             .Where(e => excludeDeclaringTypes.Any(dt => e.Property.DeclaringType != null 
                                                                      && e.Property.DeclaringType.Name.Equals(dt)) == false
                                      && e.HasImplementation == false)
                             .OrderBy(e => e.Order)
                             .Select(e => e.Property);
        }

        public IEnumerable<Models.Relation> GetMasterTypes(IEnumerable<Type> types)
        {
            var result = new List<Models.Relation>();
            IEnumerable<PropertyInfo> properties = Array.Empty<PropertyInfo>();

            if (IsOneToMany)
            {
                var (one, _) = GetOneToManyTypes(Type);

                if (one != null)
                {
                    properties = GetAllProperties(one);
                }
            }
            else
            {
                properties = GetAllProperties();
            }

            foreach (var pi in properties)
            {
                int idx;

                if (pi.Name.EndsWith("Id"))
                {
                    var masterName = pi.Name[0..^2];
                    var masterReference = types.FirstOrDefault(e => new ContractHelper(e).EntityName.Equals(masterName));

                    if (masterReference != null)
                    {
                        result.Add(new Models.Relation(masterReference, Type, pi));
                    }
                }
                else if ((idx = pi.Name.IndexOf("Id_")) > -1)
                {
                    var masterName = pi.Name[..idx];
                    var masterReference = types.FirstOrDefault(e => new ContractHelper(e).EntityName.Equals(masterName));

                    if (masterReference != null)
                    {
                        result.Add(new Models.Relation(masterReference, Type, pi));
                    }
                }
            }
            return result;
        }
        public IEnumerable<Models.Relation> GetDetailTypes(IEnumerable<Type> types)
        {
            var result = new List<Models.Relation>();
            var entityName = EntityName;

            if (IsOneToMany)
            {
                var (one, _) = GetOneToManyTypes(Type);

                if (one != null)
                {
                    entityName = GeneratorObject.CreateEntityNameFromInterface(one);
                }
            }

            foreach (var other in types)
            {
                var otherHelper = new ContractHelper(other);

                foreach (var pi in otherHelper.GetAllProperties())
                {
                    if (pi.Name.Equals($"{entityName}Id"))
                    {
                        result.Add(new Models.Relation(Type, other, pi));
                    }
                    else if (pi.Name.StartsWith($"{entityName}Id_"))
                    {
                        result.Add(new Models.Relation(Type, other, pi));
                    }
                }
            }
            return result;
        }

        public static bool HasCopyable(Type type)
        {
            return type.GetInterfaces().FirstOrDefault(e => e.IsGenericType
                                                         && e.Name.Equals(StaticLiterals.ICopyableName)
                                                         && e.GetGenericArguments()[0].Name.Equals(type.Name)) != null;
        }
        public static bool HasOneToMany(Type type)
        {
            return type.GetInterfaces().FirstOrDefault(e => e.IsGenericType
                                                         && e.Name.Equals(StaticLiterals.IOneToManyName)) != null;
        }
        public static bool HasOneToAnother(Type type)
        {
            return type.GetInterfaces().FirstOrDefault(e => e.IsGenericType
                                                         && e.Name.Equals(StaticLiterals.IOneToAnotherName)) != null;
        }
        public static (Type? one, Type? many) GetOneToManyTypes(Type type)
        {
            var oneToMany = type.GetInterfaces()
                                .FirstOrDefault(e => e.IsGenericType
                                                  && e.Name.Equals(StaticLiterals.IOneToManyName));
            return (oneToMany?.GetGenericArguments()[0], oneToMany?.GetGenericArguments()[1]);
        }
        public static (Type? one, Type? many) GetOneToAnotherTypes(Type type)
        {
            var oneToAnother = type.GetInterfaces()
                                .FirstOrDefault(e => e.IsGenericType
                                                  && e.Name.Equals(StaticLiterals.IOneToAnotherName));
            return (oneToAnother?.GetGenericArguments()[0], oneToAnother?.GetGenericArguments()[1]);
        }
        public static Type? GetShadowtype(Type type)
        {
            var shadowType = type.GetInterfaces()
                                 .FirstOrDefault(e => e.IsGenericType
                                                   && e.Name.Equals(StaticLiterals.IShadowName));
            return shadowType?.GetGenericArguments()[0];
        }
        public static bool HasPersistenceBaseInterface(Type type)
        {
            return GetPersistenceBaseInterface(type) != null;
        }
        #endregion Interface/Contract Helpers

        /// <summary>
        /// Diese Methode ermittelt den Teilnamensraum aus einem Typ.
        /// </summary>
        /// <param name="type">Typ</param>
        /// <returns>Teil-Namensraum</returns>
        public static string CreateSubNamespaceFromType(Type type)
        {
            var result = string.Empty;
            var data = type.Namespace?.Split('.');

            for (var i = 2; i < data?.Length; i++)
            {
                if (string.IsNullOrEmpty(result))
                {
                    result = $"{data[i]}";
                }
                else
                {
                    result = $"{result}.{data[i]}";
                }
            }
            return result;
        }
        /// <summary>
        /// Diese Methode ermittelt den Modulenamen aus seinem Schnittstellen Typ.
        /// </summary>
        /// <param name="type">Schnittstellen-Typ</param>
        /// <returns>Schema der Entitaet.</returns>
        public static string GetModuleNameFromInterface(Type type)
        {
            var result = string.Empty;
            var data = type.Namespace?.Split('.');
            var idx = data != null ? data.FindIndex(i => i.Equals(BusinessLabel)) : -1;

            if (idx == -1)
            {
                idx = data != null ? data.FindIndex(i => i.Equals(ModulesLabel)) : -1;
            }

            if (idx == -1)
            {
                idx = data != null ? data.FindIndex(i => i.Equals(PersistenceLabel)) : -1 ;
            }

            if (idx > -1)
            {
                var separator = string.Empty;

                for (var i = idx + 1; i < data?.Length; i++)
                {
                    result = $"{result}{separator}{data[i]}";
                    separator = ".";
                }
            }
            return result;
        }
    }
}
//MdEnd
