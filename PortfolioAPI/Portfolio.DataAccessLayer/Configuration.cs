using Microsoft.Extensions.Configuration;

namespace Portfolio.DataAccessLayer
{
    public class Configuration
    {
        private readonly string _connectionString;

        public Configuration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();

            _connectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
    }
}
