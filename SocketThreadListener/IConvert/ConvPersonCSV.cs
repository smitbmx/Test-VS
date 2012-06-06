using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServerPerson.IConvert
{
    public class ConvPersonCSV:Iconv
    {
        public string ToString(Person pers)
        {
            string str = "Person;";
            str += String.Format(pers.Name + ";" + pers.LastName + ";" + pers.Age + ";");
            return str;
        }

        public Person FromString(string str)
        {
            Person pers = new Person();
            string[] arr = str.Split(';');
            pers.Name = arr[1];
            pers.LastName =arr[2];
            pers.Age = Convert.ToInt32(arr[3]);
            return pers;
        }
    }
}