using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remoting_study.Common
{
    [Serializable]
    class Person
    {
        private string name;
        private string sex;
        private int age;

        public string Name {
            get {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Sex
        {
            get
            {
                return this.sex;
            }

            set
            {
                this.sex = value;
            }
        }

        public int Age {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }
    }
}
