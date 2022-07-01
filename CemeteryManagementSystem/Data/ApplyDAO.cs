using CemeteryManagementSystem.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CemeteryManagementSystem.Data
{
    internal class ApplyDAO
    {

        private string connectionString = @"Data Source=ZED\SQLExpress;Initial Catalog=CemSys;User ID=sa"; // cemsys

        public List<ApplyModel> getData()
        {
            List<ApplyModel> returnlist = new List<ApplyModel>();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM CUSTOMER";

                SqlCommand cmd = new SqlCommand(query, connect);
                connect.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        ApplyModel apply = new ApplyModel();
                        apply.Id = read.GetInt32(0);
                        apply.lastName = read.GetString(1);
                        apply.firstName = read.GetString(2);
                        apply.middleName = read.GetString(3);
                        apply.birthDay = read.GetDateTime(4);
                        //apply.birthDay = read.GetString(4);
                        apply.gender = read.GetString(5);
                        apply.deathDay = read.GetDateTime(6);
                        //apply.deathDay = read.GetString(6);
                        apply.contact = read.GetString(7);

                        returnlist.Add(apply);

                    }
                }
            }

            return returnlist;
        }
    }
}