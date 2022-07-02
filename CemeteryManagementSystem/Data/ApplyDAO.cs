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
                string sqlQuery = "SELECT * FROM CUSTOMER";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                connect.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        ApplyModel applymodel = new ApplyModel();
                        applymodel.Id = read.GetInt32(0);
                        applymodel.lastName = read.GetString(1);
                        applymodel.firstName = read.GetString(2);
                        applymodel.middleName = read.GetString(3);
                        applymodel.birthDay = read.GetDateTime(4);
                        //apply.birthDay = read.GetString(4);
                        applymodel.gender = read.GetString(5);
                        applymodel.deathDay = read.GetDateTime(6);
                        //apply.deathDay = read.GetString(6);
                        applymodel.contact = read.GetString(7);

                        returnlist.Add(applymodel);

                    }
                }
            }

            return returnlist;
        }

        public ApplyModel getAData(int Id)
        {

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM CUSTOMER WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;
                connect.Open();
                SqlDataReader read = cmd.ExecuteReader();

                ApplyModel applymodel = new ApplyModel();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        applymodel.Id = read.GetInt32(0);
                        applymodel.lastName = read.GetString(1);
                        applymodel.firstName = read.GetString(2);
                        applymodel.middleName = read.GetString(3);
                        applymodel.birthDay = read.GetDateTime(4);
                        applymodel.gender = read.GetString(5);
                        applymodel.deathDay = read.GetDateTime(6);
                        applymodel.contact = read.GetString(7);

                    }
                }

                return applymodel;
            }
        }

        public int insertData(ApplyModel applymodel)
        {

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if(applymodel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO CUSTOMER VALUES (@lastName, @firstName, @middleName, @birthDay, @gender, @deathDay, @contact)";
                }
                else
                {
                    sqlQuery = "UPDATE CUSTOMER SET lastName = @lastName, firstName = @firstName, middleName = @middleName, birthDay = @birthDay, gender = @gender, deathDay = @deathDay, contact = @contact WHERE Id = @Id";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Text).Value = applymodel.Id;
                cmd.Parameters.Add("@lastName", System.Data.SqlDbType.Text).Value = applymodel.lastName;
                cmd.Parameters.Add("@firstName", System.Data.SqlDbType.Text).Value = applymodel.firstName;
                cmd.Parameters.Add("@middleName", System.Data.SqlDbType.Text).Value = applymodel.middleName;
                cmd.Parameters.Add("@birthDay", System.Data.SqlDbType.Date).Value = applymodel.birthDay;
                cmd.Parameters.Add("@gender", System.Data.SqlDbType.Text).Value = applymodel.gender;
                cmd.Parameters.Add("@deathDay", System.Data.SqlDbType.Date).Value = applymodel.deathDay;
                cmd.Parameters.Add("@contact", System.Data.SqlDbType.VarChar, 12).Value = applymodel.contact;
                connect.Open();
                
                int new1 = cmd.ExecuteNonQuery();

                return new1;
            }
        }
    }
}