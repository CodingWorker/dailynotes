using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using remoting_study.Common;

namespace remoting_study
{
    class ServerObject :MarshalByRefObject
    {
        public Person GetPeopleInfo(string name,string sex,int age)
        {
            Person p = new Person();
            p.Name = name;
            p.Sex = sex;
            p.Age = age;
            return p;
        }
    }
}
