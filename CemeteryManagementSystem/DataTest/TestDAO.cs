using mvcnoauth.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace mvcnoauth.DataTest
{
    internal class TestDAO
    {
        private string connectionString = @"Data Source=ZED\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";

        public List<TestModel> getData()
        {
            List<TestModel> returnlist = new List<TestModel>();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM STUDENT";

                SqlCommand cmd = new SqlCommand(query, connect);
                connect.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        TestModel test = new TestModel();
                        test.StudentID = read.GetString(0);
                        test.LastName = read.GetString(1);
                        test.FirstName = read.GetString(2);
                        test.MiddleName = read.GetString(3);

                        returnlist.Add(test);

                    }
                }
            }

            return returnlist;
        }
    }
}