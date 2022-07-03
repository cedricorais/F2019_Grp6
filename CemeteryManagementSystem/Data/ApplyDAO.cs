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
            List<ApplyModel> returnList = new List<ApplyModel>();

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
                        applymodel.birthDate = read.GetDateTime(4);
                        applymodel.gender = read.GetString(5);
                        applymodel.deathDate = read.GetDateTime(6);
                        applymodel.contact = read.GetString(7);

                        returnList.Add(applymodel);

                    }
                }
            }

            return returnList;
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

                ApplyModel applyModel = new ApplyModel();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        applyModel.Id = read.GetInt32(0);
                        applyModel.lastName = read.GetString(1);
                        applyModel.firstName = read.GetString(2);
                        applyModel.middleName = read.GetString(3);
                        applyModel.birthDate = read.GetDateTime(4);
                        applyModel.gender = read.GetString(5);
                        applyModel.deathDate = read.GetDateTime(6);
                        applyModel.contact = read.GetString(7);

                    }
                }

                return applyModel;
            }
        }

        public int insertData(ApplyModel applyModel)
        {

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if(applyModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO CUSTOMER VALUES (@lastName, @firstName, @middleName, @birthDate, @gender, @deathDate, @contact)";
                }
                else
                {
                    sqlQuery = "UPDATE CUSTOMER SET lastName = @lastName, firstName = @firstName, middleName = @middleName, birthDate = @birthDate, gender = @gender, deathDate = @deathDate, contact = @contact WHERE Id = @Id";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Text).Value = applyModel.Id;
                cmd.Parameters.Add("@lastName", System.Data.SqlDbType.Text).Value = applyModel.lastName;
                cmd.Parameters.Add("@firstName", System.Data.SqlDbType.Text).Value = applyModel.firstName;
                cmd.Parameters.Add("@middleName", System.Data.SqlDbType.Text).Value = applyModel.middleName;
                cmd.Parameters.Add("@birthDate", System.Data.SqlDbType.Date).Value = applyModel.birthDate;
                cmd.Parameters.Add("@gender", System.Data.SqlDbType.Text).Value = applyModel.gender;
                cmd.Parameters.Add("@deathDate", System.Data.SqlDbType.Date).Value = applyModel.deathDate;
                cmd.Parameters.Add("@contact", System.Data.SqlDbType.VarChar, 12).Value = applyModel.contact;
                connect.Open();
                
                int new1 = cmd.ExecuteNonQuery();

                return new1;
            }
        }
    }
}