//@CodeCopy
//MdStart
using System;

namespace SnQMusicStore.ConApp
{
    internal partial class Program
    {
        #region Class-Constructors
        static Program()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        #endregion Class-Constructors

        private static void Main(/*string[] args*/)
        {
            Console.WriteLine("SnQMusicStore");
            Console.WriteLine(DateTime.Now);

            BeforeRun();

            AfterRun();
            Console.WriteLine(DateTime.Now);
        }

        static partial void BeforeRun();
        static partial void AfterRun();
    }
}
//MdEnd
