using CemeteryManagementSystem.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace CemeteryManagementSystem.Data
{
    internal class ApplyDAO
    {

        private string connectionString = @"Data Source=ZED\SQLExpress;Initial Catalog=CemSys;User ID=sa"; // cemsys

        public List<ApplyModel> getApplicantData()
        {
            List<ApplyModel> returnList = new List<ApplyModel>();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM APPLICANT";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                connect.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        ApplyModel applyModel = new ApplyModel();
                        applyModel.Id = read.GetInt32(0);
                        applyModel.applicantLastName = read.GetString(1);
                        applyModel.applicantFirstName = read.GetString(2);
                        applyModel.applicantMiddleName = read.GetString(3);
                        applyModel.applicantBirthDate = read.GetDateTime(4);
                        applyModel.selectedApplicantGender = read.GetString(5);
                        applyModel.contact = read.GetString(6);
                        applyModel.selectedPaymentMethod = read.GetString(7);

                        returnList.Add(applyModel);

                    }
                }
            }

            return returnList;
        }

        public List<ApplyModel> getOssuaryIData()
        {
            List<ApplyModel> returnList = new List<ApplyModel>();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [OSSUARY I]";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                connect.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        ApplyModel applyModel = new ApplyModel();
                        applyModel.Id = read.GetInt32(0);
                        applyModel.deadLastName = read.GetString(1);
                        applyModel.deadFirstName = read.GetString(2);
                        applyModel.deadMiddleName = read.GetString(3);
                        applyModel.deadBirthDate = read.GetDateTime(4);
                        applyModel.selectedDeadGender = read.GetString(5);
                        applyModel.deathDate = read.GetDateTime(6);

                        returnList.Add(applyModel);

                    }
                }
            }

            return returnList;
        }

        internal int Delete(int Id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM APPLICANT WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;
                connect.Open();
                int deleteId = cmd.ExecuteNonQuery();

                return deleteId;
            }
        }

        internal List<ApplyModel> searchForLast(string searchTerm)
        {
            List<ApplyModel> returnList = new List<ApplyModel>();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM APPLICANT WHERE LASTNAME LIKE @searchFor";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@searchFor", System.Data.SqlDbType.Text).Value = "%" + searchTerm + "%";
                connect.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        ApplyModel applyModel = new ApplyModel();
                        applyModel.Id = read.GetInt32(0);
                        applyModel.applicantLastName = read.GetString(1);
                        applyModel.applicantFirstName = read.GetString(2);
                        applyModel.applicantMiddleName = read.GetString(3);
                        applyModel.applicantBirthDate = read.GetDateTime(4);
                        applyModel.selectedApplicantGender = read.GetString(5);
                        applyModel.contact = read.GetString(6);
                        applyModel.selectedPaymentMethod = read.GetString(7);

                        returnList.Add(applyModel);

                    }
                }
            }

            return returnList;
        }

        public ApplyModel get1Data(int Id)
        {

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM APPLICANT WHERE Id = @Id";

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
                        applyModel.applicantLastName = read.GetString(1);
                        applyModel.applicantFirstName = read.GetString(2);
                        applyModel.applicantMiddleName = read.GetString(3);
                        applyModel.applicantBirthDate = read.GetDateTime(4);
                        applyModel.selectedApplicantGender = read.GetString(5);
                        applyModel.contact = read.GetString(6);
                        applyModel.selectedPaymentMethod = read.GetString(7);

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
                    sqlQuery = "INSERT INTO APPLICANT VALUES (@applicantLastName, @applicantFirstName, @applicantMiddleName, @applicantBirthDate, @selectedApplicantGender, @contact, @selectedPaymentMethod); INSERT INTO [OSSUARY I] (Id, lastName, firstName, middleName, birthDate, gender, deathDate) VALUES ((SELECT Id from APPLICANT WHERE Id = APPLICANT.Id), @deadLastName, @deadFirstName, @deadMiddleName, @deadBirthDate, @selectedDeadGender, @deathDate)";
                }
                else
                {
                    sqlQuery = "UPDATE APPLICANT SET lastName = @applicantLastName, firstName = @applicantFirstName, middleName = @applicantMiddleName, birthDate = @applicantBirthDate, gender = @applicantGender, contact = @contact, paymentMethod = @paymentMethod WHERE Id = @Id";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = applyModel.Id;
                cmd.Parameters.Add("@applicantLastName", System.Data.SqlDbType.Text).Value = applyModel.applicantLastName;
                cmd.Parameters.Add("@applicantFirstName", System.Data.SqlDbType.Text).Value = applyModel.applicantFirstName;
                cmd.Parameters.Add("@applicantMiddleName", System.Data.SqlDbType.Text).Value = applyModel.applicantMiddleName;
                cmd.Parameters.Add("@applicantBirthDate", System.Data.SqlDbType.Date).Value = applyModel.applicantBirthDate;
                cmd.Parameters.Add("@selectedApplicantGender", System.Data.SqlDbType.Text).Value = applyModel.selectedApplicantGender;
                cmd.Parameters.Add("@contact", System.Data.SqlDbType.VarChar, 12).Value = applyModel.contact;
                cmd.Parameters.Add("@selectedPaymentMethod", System.Data.SqlDbType.Text).Value = applyModel.selectedPaymentMethod;

                cmd.Parameters.Add("@deadLastName", System.Data.SqlDbType.Text).Value = applyModel.deadLastName;
                cmd.Parameters.Add("@deadFirstName", System.Data.SqlDbType.Text).Value = applyModel.deadFirstName;
                cmd.Parameters.Add("@deadMiddleName", System.Data.SqlDbType.Text).Value = applyModel.deadMiddleName;
                cmd.Parameters.Add("@deadBirthDate", System.Data.SqlDbType.Date).Value = applyModel.deadBirthDate;
                cmd.Parameters.Add("@selectedDeadGender", System.Data.SqlDbType.Text).Value = applyModel.selectedDeadGender;
                cmd.Parameters.Add("@deathDate", System.Data.SqlDbType.Date).Value = applyModel.deathDate;
                connect.Open();
                
                int newId = cmd.ExecuteNonQuery();

                return newId;
            }
        }
    }
}