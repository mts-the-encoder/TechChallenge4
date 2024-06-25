namespace Utils.Tests.Hashids
{
    class HashidsBuilder
    {
        private static HashidsBuilder _instance;
        private readonly HashidsNet.Hashids _encryptor;

        private HashidsBuilder()
        {
            _encryptor ??= new HashidsNet.Hashids("mt300PlSSx", 3);
        }

        public static HashidsBuilder Instance()
        {
            _instance = new HashidsBuilder();
            return _instance;
        }

        public HashidsNet.Hashids Build()
        {
            return _encryptor;
        }
    }
}
