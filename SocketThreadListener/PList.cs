using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientServerPerson.DS;

namespace ClientServerPerson
{
    public class PList
    {
        public List<Person> pList { get; set; }
        IDS DSt;
        public PList()
        {
            pList = new List<Person>();
        }
        public void Save(string param)
        {
            DSfactory.GetInstance(param).Save(pList);
        }
        public void Load(string param)
        {
            pList = DSfactory.GetInstance(param).Load();
        }
    }
}
