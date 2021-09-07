using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SummerTask.Writing;

namespace SummerTask

{
    internal class SummerTaskInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IConverter>().ImplementedBy<Converter>());
            container.Register(Component.For<IFileReader>().ImplementedBy<FileReader>());
            container.Register(Component.For<IFileWriter>().ImplementedBy<FileWriter>());
            container.Register(Component.For<ISerializerFactory>().ImplementedBy<SerializerFactory>());
            container.Register(Component.For<IParserFactory>().ImplementedBy<ParserFactory>());

            // TODO: cesspool
            container.Register(Component.For<XmlSummerSerializer>().ImplementedBy<XmlSummerSerializer>());
            container.Register(Component.For<JsonSerializer>().ImplementedBy<JsonSerializer>());

            //var serializer = new JsonSerializer();

            //var xmlSummerSerializer = new XmlSummerSerializer();
            //var serializerFactory = new SerializerFactory(xmlSummerSerializer, serializer);
        }
    }
}