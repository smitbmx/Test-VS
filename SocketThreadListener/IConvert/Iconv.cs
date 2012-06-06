using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServerPerson.IConvert
{
    public interface Iconv
    {
        string ToString(Person pers);
        Person FromString(string str);
    }
}