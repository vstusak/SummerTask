namespace SummerTask.Serializers
{
    public class Serializer : ISerializer
    {
        private ISerializeStrategy _serializeStrategy;

        public Serializer()
        {
            SetStrategy(new DefaultSerializeStrategy());
        }

        public Serializer(ISerializeStrategy serializeStrategy)
        {
            SetStrategy(serializeStrategy);
        }

        public string SerializeDocument(Document document)
        {
            return _serializeStrategy.Serialize(document);
        }

        public void SetStrategy(ISerializeStrategy strategy)
        {
            _serializeStrategy = strategy ?? new DefaultSerializeStrategy();
        }
    }
}