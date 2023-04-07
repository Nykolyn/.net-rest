
namespace Catalog.Settings
{
    public class MongoDbSettings
    {
        private readonly IConfiguration _configuration;

        public MongoDbSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Host => _configuration[nameof(Host)];
        public int Port => int.Parse(_configuration[nameof(Port)]);
        public string User => _configuration[nameof(User)];
        public string Password => _configuration[nameof(Password)];

        public string ConnectionString
        {
            get
            {
                Console.WriteLine("test update console");
                Console.WriteLine("Testing env " + Host + Port + User + Password);
                return $"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
    }
}
