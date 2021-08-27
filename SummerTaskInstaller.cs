using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SummerTask.Parsers;
using SummerTask.Serializers;

namespace SummerTask
{
    internal class SummerTaskInstaller : IWindsorInstaller
    {
        public SummerTaskInstaller()
        {
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
            container.Register(Component.For<IDocumentConverter>().ImplementedBy<DocumentConverter>());
            container.Register(Component.For<IFileHelper>().ImplementedBy<FileHelper>());
            container.Register(Component.For<IParser>().ImplementedBy<Parser>().LifestyleSingleton());
            container.Register(Component.For<ISerializer>().ImplementedBy<Serializer>().LifestyleTransient());
            container.Register(Component.For<ISerializeStrategyFactory>().ImplementedBy<SerializeStrategyFactory>());
            container.Register(Component.For<ISerializeStrategy>().ImplementedBy<XmlSerializeStrategy>().Named(nameof(XmlSerializeStrategy)));
            container.Register(Component.For<ISerializeStrategy>().ImplementedBy<JsonSerializeStrategy>().Named(nameof(JsonParsingStrategy)));
            container.Register(Component.For<ISerializeStrategy>().ImplementedBy<DefaultSerializeStrategy>().Named(nameof(DefaultSerializeStrategy)));
        }
    }
}