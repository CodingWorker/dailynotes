using System.Configuration;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConnectionStrings
            ConnectionStringSettings c = System.Configuration.ConfigurationManager.ConnectionStrings["entityFramework"];
            string cStr = c.ConnectionString;
        }
    }
}
