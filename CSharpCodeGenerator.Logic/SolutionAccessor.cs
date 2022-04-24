//@CodeCopy
//MdStart
using System;
using System.IO;
using System.Linq;
using CommonStaticLiterals = CommonBase.StaticLiterals;

namespace CSharpCodeGenerator.Logic
{
    public static partial class SolutionAccessor
    {
        public static string GetCurrentSolutionPath(string solutionProjectName)
        {
            int endPos = AppContext.BaseDirectory
                                   .IndexOf($"{solutionProjectName}", StringComparison.CurrentCultureIgnoreCase);

            return AppContext.BaseDirectory[..endPos];
        }
        public static string GetSolutionNameByFile(string solutionPath)
        {
            var fileInfo = new DirectoryInfo(solutionPath).GetFiles()
                                                          .SingleOrDefault(f => f.Extension.Equals(CommonStaticLiterals.SolutionFileExtension, StringComparison.CurrentCultureIgnoreCase));

            return fileInfo != null ? Path.GetFileNameWithoutExtension(fileInfo.Name) : string.Empty;
        }
    }
}
//MdEnd
