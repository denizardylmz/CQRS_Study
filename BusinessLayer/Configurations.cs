using System.Dynamic;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer;

public class Configurations
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../UI_API"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("CQRSDb");
        }
    }
}