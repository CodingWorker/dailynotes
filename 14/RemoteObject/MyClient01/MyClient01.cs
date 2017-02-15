using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClient01
{
    class MyClient01
    {
        static void Main(string[] args)
        {
            RemoteObject.MyObject app =
            (RemoteObject.MyObject)Activator.GetObject(typeof(RemoteObject.MyObject), System.Configuration.ConfigurationSettings.AppSettings["ServiceURL"]);
            Console.WriteLine(app.Add(2, 123));
            Console.ReadLine();
        }
    }
}
