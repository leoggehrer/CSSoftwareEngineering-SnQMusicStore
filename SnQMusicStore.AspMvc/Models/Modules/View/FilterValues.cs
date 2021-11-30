﻿//@CodeCopy
//MdStart
using CommonBase.Extensions;
using System.Collections.Generic;
using System.Text;

namespace SnQMusicStore.AspMvc.Models.Modules.View
{
    public class FilterValues : Dictionary<string, string>
    {
        public string CreatePredicate()
        {
            var result = new StringBuilder();

            foreach (var item in this)
            {
                if (item.Key.EndsWith($"{StaticLiterals.TypeOperationPostfix}") == false)
                {
                    if (TryGetValue($"{item.Key}.{StaticLiterals.TypeOperationPostfix}", out string op))
                    {
                        if (result.Length > 0)
                        {
                            result.Append(" AND ");
                        }
                        result.Append(CreatePredicate(item.Key, op, item.Value));
                    }
                }
            }
            return result.ToString();
        }
        public static string CreatePredicate(string name, string operation, string value)
        {
            var result = default(string);

            if (operation.Equals(StaticLiterals.OperationEquals))
            {
                result = $"{name} == \"{value}\"";
            }
            else if (operation.Equals(StaticLiterals.OperationNotEquals))
            {
                result = $"{name} != \"{value}\"";
            }
            else if (operation.Equals(StaticLiterals.OperationContains))
            {
                result = $"{name} != null && {name}.ToLower().Contains(\"{value?.ToLower()}\")";
            }
            else if (operation.Equals(StaticLiterals.OperationStartsWith))
            {
                result = $"{name} != null && {name}.ToLower().StartsWith(\"{value.ToLower()}\")";
            }
            else if (operation.Equals(StaticLiterals.OperationEndsWith))
            {
                result = $"{name} != null && {name}.ToLower().EndsWith(\"{value.ToLower()}\")";
            }
            else if (operation.Equals(StaticLiterals.OperationNumEquals))
            {
                result = $"{name} == {value}";
            }
            else if (operation.Equals(StaticLiterals.OperationNumIsGreater))
            {
                result = $"{name} > {value}";
            }
            else if (operation.Equals(StaticLiterals.OperationNumIsLess))
            {
                result = $"{name} < {value}";
            }
            return result;
        }
    }
}
//MdEnd
