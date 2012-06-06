using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ClientServerPerson.IConvert
{
    public class ConvPersonDB : Iconv
    {
        public string ToString(Person pers)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=SMIT-PC\SQLEXPRESS;Initial Catalog=ss;Integrated Security=True;");
            string strCom = "INSERT INTO dbo.Employee ([FirstName],[LastName],[Age]) VALUES (@Name,@LastName,@Age)";
            //string strCom2 = "INSERT INTO dbo.Contacts ([Phone] VALUES(@Phone) WHERE UserId=)";
            //надо заинсертить телефон......
            SqlCommand Com = new SqlCommand(strCom, Con);
            Com.Parameters.AddWithValue("@Name", pers.Name);
            Com.Parameters.AddWithValue("@LastName", pers.LastName);
            Com.Parameters.AddWithValue("@Age", pers.Age);
            Com.Parameters.AddWithValue("@Phone", pers.Phone);

            Con.Open();
            Com.ExecuteNonQuery();
            Con.Close();
            return "IDontKnowWhyIMustReturnSomeStringHere";
        }

        public Person FromString(string str)
        {
            Person pers = new Person();
            string[] arr = str.Split(';');
            pers.Name = arr[1];
            pers.LastName = arr[2];
            pers.Age = Convert.ToInt32(arr[3]);
            pers.Phone = arr[4];
            return pers;
        }
    }
}