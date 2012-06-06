using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;

namespace ClientServerPerson.DS
{
    public class DSdb : IDS
    {
        string path;
        public DSdb(string path)
        {
            this.path = path;
        }
        public void Save(List<Person> persons)
        {
            foreach (Person p in persons)
            {
                IConvert.ConvFactory.GetInstance("DB").ToString(p);
            }
        }

        public List<Person> Load()
        {
            List<Person> Lpers = new List<Person>();
            SqlConnection Con = new SqlConnection(@"Data Source=SMIT-PC\SQLEXPRESS;Initial Catalog=ss;Integrated Security=True;");
            string strCom = "SELECT * FROM dbo.Employee E LEFT JOIN dbo.Contacts C ON E.Id=C.UserId";
            SqlCommand Com = new SqlCommand(strCom, Con);

            Con.Open();
            using (SqlDataReader reader = Com.ExecuteReader())
            {
                string test = string.Empty;
                while (reader.Read())
                {
                    string id = reader["id"].ToString();
                    string name = reader["FirstName"].ToString();
                    string lastName = reader["LastName"].ToString();
                    string age = reader["Age"].ToString();
                    string phone = reader["Phone"].ToString();
                    string str = string.Concat(id, ";", name, ";", lastName, ";", age, ";", phone);
                    Lpers.Add(IConvert.ConvFactory.GetInstance("DB").FromString(str));
                }
                reader.Close();
            }
            Con.Close();
            return Lpers;
        }

        public bool CheckType(string x)
        {
            string type = "DB";
            bool ret;
            if (x == type)
                ret = true;
            else
                ret = false;
            return ret;
        }
    }
}