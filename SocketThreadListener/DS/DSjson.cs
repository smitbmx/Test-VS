using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ClientServerPerson.DS
{
    public class DSjson : IDS
    {
        string path;
        public DSjson(string path)
        {
            this.path = path;
        }
        public void Save(List<Person> persons)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Person p in persons)
                {
                    sw.WriteLine(IConvert.ConvFactory.GetInstance("JSON").ToString(p));
                }
                sw.Close();
            }
        }

        public List<Person> Load()
        {
            List<Person> Lpers = new List<Person>();
            using (StreamReader sr = new StreamReader(path))
            {
                string str = sr.ReadLine();
                while (str != null)
                {
                    Lpers.Add(IConvert.ConvFactory.GetInstance("JSON").FromString(str));
                    str = sr.ReadLine();
                }
                sr.Close();
            }
            return Lpers;
        }

        public bool CheckType(string x)
        {
            string type = "JSON";
            bool ret;
            if (x == type)
                ret = true;
            else
                ret = false;
            return ret;
        }
    }
}