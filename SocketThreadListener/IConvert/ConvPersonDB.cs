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
            string strCom = "INSERT INTO dbo.Employee ([FirstName],[LastName],[Age],[ImageName]) VALUES (@Name,@LastName,@Age,@ImageName)";
            SqlCommand Com = new SqlCommand(strCom, Con);
            Com.Parameters.AddWithValue("@Name", pers.Name);
            Com.Parameters.AddWithValue("@LastName", pers.LastName);
            Com.Parameters.AddWithValue("@Age", pers.Age);

            Com.Parameters.AddWithValue("@ImageName", pers.Photo64);

            Con.Open();
            Com.ExecuteNonQuery();
            Com.Parameters.Clear();
            Com.CommandText = "SELECT @@IDENTITY";
            int insertID = Convert.ToInt32(Com.ExecuteScalar());
            Com.Dispose();
            Com = null;

            //Com2  - inserting phone
            string strCom2 = string.Format("INSERT INTO dbo.Contacts ([Phone],[UserId]) VALUES(@Phone,{0})", insertID);
            SqlCommand Com2 = new SqlCommand(strCom2, Con);
            Com2.Parameters.AddWithValue("@Phone", pers.Phone);
            Com2.ExecuteNonQuery();

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
            pers.Photo64 = arr[5];
            return pers;
        }
    }
}