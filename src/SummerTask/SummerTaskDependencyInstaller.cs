using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
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
            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
            
            container.Register(Component.For<IFileConverter>().ImplementedBy<FileConverter>());
            container.Register(Component.For<IFileUtils>().ImplementedBy<FileUtils>());
            container.Register(Component.For<IParser>().ImplementedBy<Parser>());

            container.Register(Component.For<IParsingStrategy>().ImplementedBy<JsonParsingStrategy>().Named(nameof(JsonParsingStrategy)));
            container.Register(Component.For<IParsingStrategy>().ImplementedBy<XmlParsingStrategy>().Named(nameof(XmlParsingStrategy)));
            container.Register(Component.For<IParsingStrategy>().ImplementedBy<HtmlParsingStrategy>().Named(nameof(HtmlParsingStrategy)));
            //container.Register(Component.For<IParsingStrategy>().ImplementedBy<NullParsingStrategy>()); Initialized in ParsingStrategyFactory
            
            container.Register(Component.For<IParsingStrategyFactory>().ImplementedBy<ParsingStrategyFactory>());
        }
    }
}