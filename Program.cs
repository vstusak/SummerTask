using Castle.Windsor;
using SummerTask.Writing;
using System;
using System.IO;

namespace SummerTask
{
    class Program
    {
        static void Main(string[] args)
        {

            var container = new WindsorContainer();
            container.Install(new SummerTaskInstaller());
            var converter = container.Resolve<IConverter>();

            //Create example files
            //Finally: Load from args instead
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

            //Pick parser based on source file
            //Pick serializer based on source file
            converter.Convert(sourceFileName, targetFileName);
        }
    }
}
