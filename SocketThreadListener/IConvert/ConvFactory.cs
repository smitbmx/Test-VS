using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServerPerson.IConvert
{
    public class ConvFactory
    {
        static Iconv[] convlst = new Iconv[] {
            new ConvPersonXML(),
            new ConvPersonCSV(),
            new ConvPersonJSON(),
            new ConvPersonYAML(),
            new ConvPersonDB() };
        public static Iconv GetInstance(string format)
        {
            Iconv convPerson = null;
            if (format == "XML")
            { convPerson = convlst[0]; }
            else if (format == "CSV")
            { convPerson = convlst[1]; }
            else if (format == "JSON")
            { convPerson = convlst[2]; }
            else if (format == "YAML" )
            { convPerson = convlst[3]; }
            else if (format == "DB")
            { convPerson = convlst[4]; }
            else
            { throw new Exception("Wrong format!"); }
            return convPerson;
        }
    }
}