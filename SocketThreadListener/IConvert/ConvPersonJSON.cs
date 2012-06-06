﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ClientServerPerson.IConvert
{
    public class ConvPersonJSON : Iconv
    {
        public string ToString(Person pers)
        {
            string str = "Person";
            str += String.Format(" \"Name\" : \"{0}\", \"LastName\" : \"{1}\", \"Age\" : \"{2}\" ", pers.Name,pers.LastName,pers.Age);
            return str;
        }

        public Person FromString(string str)
        {
           Person pers = new Person();
            string pn = ("\"");
            string[] arr = Regex.Split(str, pn);
            pers.Name = arr[3];
            pers.LastName= arr[7];
            pers.Age = Convert.ToInt32(arr[11]);
            return pers;
        }
    }
}