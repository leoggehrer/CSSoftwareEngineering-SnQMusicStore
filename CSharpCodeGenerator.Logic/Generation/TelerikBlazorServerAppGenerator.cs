//@CodeCopy
//MdStart

namespace CSharpCodeGenerator.Logic.Generation
{
    internal partial class TelerikBlazorServerAppGenerator : ModelGenerator
    {
        internal TelerikBlazorServerAppGenerator(SolutionProperties solutionProperties)
            : base(solutionProperties)
        {
        }
        public new static TelerikBlazorServerAppGenerator Create(SolutionProperties solutionProperties)
        {
            return new TelerikBlazorServerAppGenerator(solutionProperties);
        }

        public override Common.UnitType UnitType => Common.UnitType.TelerikBlazorServerApp;
        public override string AppPostfix => SolutionProperties.TelerikBlazorServerAppPostfix;
        public override string AppModelsNameSpace => $"{SolutionProperties.TelerikBlazorServerAppProjectName}.{StaticLiterals.ModelsFolder}";
        public override string ModelsFolder => StaticLiterals.ModelsFolder;
    }
}
//MdEnd
