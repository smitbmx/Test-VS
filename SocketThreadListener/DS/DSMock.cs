using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServerPerson.DS
{
    public class DSMock:IDS
    {
        string path;
        List<Person> LstP = new List<Person>();
        public DSMock(string path)
        {
            this.path = path;
        }
        public void Save(List<Person> persons)
        {
            foreach (Person p in LstP)
            {
                this.LstP.Add(p);
            }
        }

        public List<Person> Load()
        {
            return LstP;
        }

        public bool CheckType(string x)
        {
            string type = "MOCK";
            bool ret;
            if (x == type)
                ret = true;
            else
                ret = false;
            return ret;
        }
    }
}