using System.Configuration;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
           ConnectionStringSettings c = System.Configuration.ConfigurationManager.ConnectionStrings["entityFramework"];
        }
    }
}
