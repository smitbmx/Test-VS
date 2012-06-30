using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientServerPerson
{
    public class Person
    {
        public Person()
        { }
        public Person(string name, string lastName, int age, string phone, string photo64)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
            this.Phone = phone;
            this.Photo64 = photo64;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Photo64 { get; set; }
    }
}
