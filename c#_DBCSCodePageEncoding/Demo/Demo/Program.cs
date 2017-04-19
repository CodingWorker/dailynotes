using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string testStr = "DBCSCodePageEncoding, 于是对于这种编码很是奇怪,参考：http://www.cnblogs.com/sunshore/p/3548154.html";

            byte[] u8Bytes = Encoding.UTF8.GetBytes(testStr);
            string decodeStr = Encoding.UTF8.GetString(u8Bytes);

            Console.WriteLine(decodeStr);
            if (Encoding.GetEncoding(65001) == Encoding.UTF8)
            {
                Console.WriteLine("pagingEncoding-65001==utf-8");
            }
            Console.WriteLine("Encoding.Default:DisplayName:{1}--CodePage:{0}", Encoding.Default.EncodingName,Encoding.Default.CodePage);
            foreach (EncodingInfo info in Encoding.GetEncodings())
            {
                Console.WriteLine("{0} ==> {1}",info.CodePage,info.DisplayName);
            }
        }
    }
}
