using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientServerPerson.DS
{
    public interface IDS
    {
        void Save(List<Person> persons);
        List<Person> Load();
        bool CheckType(string x);
    }
}
