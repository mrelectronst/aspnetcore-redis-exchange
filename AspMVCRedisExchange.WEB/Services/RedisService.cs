using StackExchange.Redis;

namespace AspMVCRedisExchange.WEB.Services
{
    public class RedisService
    {
        private ConnectionMultiplexer multiplexer;

        private readonly string redisHost;

        private readonly string redisPort;

        public RedisService(IConfiguration configuration)
        {
            redisHost = configuration["Redis:Host"];

            redisPort = configuration["Redis:Port"];
        }

        public void Connect()
        {
            var configString = $"{redisHost}:{redisPort}";

            multiplexer = ConnectionMultiplexer.Connect(configString);
        }

        public IDatabase GetDatabase(int database)
        {
            return multiplexer.GetDatabase(database);
        }
    }
}
