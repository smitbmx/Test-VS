using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServerPerson.DS
{
    public class DSfactory
    {
        static IDS[] Datalst = null;
        public static void Init()
        {
            Datalst = new IDS[] {
                      new DSxml("XMLFile1.xml"), 
                      new DScsv("CSVFile1.csv"),
                      new DSjson("JSONFile1.json"),
                      new DSyaml("YAMLFile1.yaml"), 
                      new DSMock("MOCK"),
                      new DSdb("")};
        }
        public static IDS GetInstance(string param)
        {
            IDS DSt = null;
            if (Datalst == null)
            { Init(); }
            param = param.ToUpper();
            for (int i = 0; i < Datalst.Length; i++)
            {
                if (Datalst[i].CheckType(param) == true)
                { DSt = Datalst[i]; }
            }
            return DSt;
        }
    }
}