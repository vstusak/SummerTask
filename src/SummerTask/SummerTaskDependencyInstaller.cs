using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FormatConverter;
using FormatConverter.Parsers;

namespace SummerTask
{
    internal class SummerTaskDependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFileConverter>().ImplementedBy<FileConverter>());
            container.Register(Component.For<IFileUtils>().ImplementedBy<FileUtils>());
            container.Register(Component.For<IParser>().ImplementedBy<Parser>());
            container.Register(Component.For<IParsingStrategyFactory>().ImplementedBy<ParsingStrategyFactory>());
        }
    }
}