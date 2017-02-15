using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteObject
{
    public class MyObject:MarshalByRefObject
    {
        public List<Num> numList { get; set; }
        public int sum = 0;
        public int Add(int a,int b)
        {
            this.sum += a + b;
            return this.sum;
        }

        public MyObject()
        {
            this.numList = new List<Num>();
            for(int i = 1; i < 100; i++)
            {
                numList.Add(new Num(i));
            }
        }

    }

    [Serializable]
    public class Num {
        public List<int> var { get; set; }
        public Num(int count)
        {
            this.var = new List<int>();
            for(int i = 0; i < count; i++)
            {
                var.Add(i);
            }
        }
    }

}
