//@CodeCopy
//MdStart
using System;
using System.IO;
using System.Linq;

namespace CSharpCodeGenerator.ConApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(nameof(CSharpCodeGenerator));
            var solutionPath = GetCurrentSolutionPath();
            var solutionName = GetSolutionNameByFile(solutionPath);
            var contractsFilePath = GetContractsFilePath(solutionPath);
            var solutionProperties = Logic.Factory.GetSolutionProperties(solutionName, contractsFilePath);
            var appGenerationUnits = Logic.Common.UnitType.AllApps;
            var contractsFileInfo = GetContractsFileInfo(contractsFilePath);
            var generationInfo = ReadGenerationInfo(StaticLiterals.GeneratorInfoFileName);

            if ((generationInfo.GenerationDate.HasValue == false && contractsFileInfo != null)
                || generationInfo.GenerationDate.Value < contractsFileInfo.LastWriteTimeUtc)
            {
                if (generationInfo.GenerationDate.HasValue)
                {
                    Console.WriteLine($"Generation: {generationInfo.GenerationDate}");
                }
                Console.WriteLine($"Contracts: {contractsFileInfo.LastWriteTimeUtc}");

                Logic.Generator.DeleteGenerationFiles(solutionPath);
                var generatedItems = Logic.Generator.Generate(solutionName, contractsFilePath, appGenerationUnits);

                Writer.WriteAll(solutionPath, solutionProperties, generatedItems);

                Console.WriteLine("Excluding Files from Git...");
                Logic.Git.GitIgnoreManager.Run($"{nameof(CSharpCodeGenerator)}.{nameof(ConApp)}");

                generationInfo.GenerationDate = DateTime.UtcNow;
                generationInfo.ContractFilePath = contractsFilePath;
                WriteGenerationInfo(StaticLiterals.GeneratorInfoFileName, generationInfo);
            }
        }
        private static string GetCurrentSolutionPath()
        {
            int endPos = AppContext.BaseDirectory
                                   .IndexOf($"{nameof(CSharpCodeGenerator)}", StringComparison.CurrentCultureIgnoreCase);

            return AppContext.BaseDirectory[..endPos];
        }
        private static string GetCurrentSolutionName()
        {
            var solutionPath = GetCurrentSolutionPath();

            return GetSolutionNameByFile(solutionPath);
        }
        private static string GetCurrentContractsFilePath()
        {
            return GetContractsFilePath(GetCurrentSolutionPath());
        }
        private static string GetSolutionNameByPath(string solutionPath)
        {
            return solutionPath.Split(new char[] { '\\', '/' })
                               .Where(e => string.IsNullOrEmpty(e) == false)
                               .Last();
        }
        private static string GetSolutionNameByFile(string solutionPath)
        {
            var fileInfo = new DirectoryInfo(solutionPath).GetFiles()
                                                          .SingleOrDefault(f => f.Extension.Equals(StaticLiterals.SolutionFileExtension, StringComparison.CurrentCultureIgnoreCase));

            return fileInfo != null ? Path.GetFileNameWithoutExtension(fileInfo.Name) : string.Empty;
        }
        private static string GetContractsFilePath(string solutionPath)
        {
            var result = default(string);
            var solutionName = GetSolutionNameByFile(solutionPath);
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
            return result;
        }
        private static FileInfo GetContractsFileInfo(string filePath)
        {
            var result = default(FileInfo);

            if (File.Exists(filePath))
            {
                result = new FileInfo(filePath);
            }
            return result;
        }
        private static Models.GeneratorInfo ReadGenerationInfo(string filePath)
        {
            var result = default(Models.GeneratorInfo);

            if (File.Exists(filePath))
            {
                var text = File.ReadAllText(filePath);

                result = System.Text.Json.JsonSerializer.Deserialize<Models.GeneratorInfo>(text);
            }
            return result ?? new Models.GeneratorInfo();
        }
        private static void WriteGenerationInfo(string filePath, Models.GeneratorInfo model)
        {
            model.CheckArgument(nameof(model));

            var text = System.Text.Json.JsonSerializer.Serialize(model);

            File.WriteAllText(filePath, text);
        }
    }
}
//MdEnd
