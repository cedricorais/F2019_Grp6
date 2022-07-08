using CemeteryManagementSystem.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace CemeteryManagementSystem.Data
{
    internal class ApplyDAO
    {
        private string connectionString = @"workstation id=Cem-Sys.mssql.somee.com;packet size=4096;user id=cedricorais_SQLLogin_1;pwd=rdpc31n8xx;data source=Cem-Sys.mssql.somee.com;persist security info=False;initial catalog=Cem-Sys"; // cemsys

        public int insertApplicantData(ApplyModel applyModel)
        {

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if (applyModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO APPLICANT VALUES (@applicantLastName, @applicantFirstName, @applicantMiddleName, @applicantBirthDate, @selectedApplicantGender, @contact, @selectedPaymentMethod); INSERT INTO OSSUARY VALUES (@deadLastName, @deadFirstName, @deadMiddleName, @deadBirthDate, @selectedDeadGender, @deathDate, @selectedLocation, @selectedFloorNSection)";

                    SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = applyModel.Id;
                    cmd.Parameters.Add("@applicantLastName", System.Data.SqlDbType.Text).Value = applyModel.applicantLastName;
                    cmd.Parameters.Add("@applicantFirstName", System.Data.SqlDbType.Text).Value = applyModel.applicantFirstName;
                    cmd.Parameters.Add("@applicantMiddleName", System.Data.SqlDbType.Text).Value = applyModel.applicantMiddleName;
                    cmd.Parameters.Add("@applicantBirthDate", System.Data.SqlDbType.Date).Value = applyModel.applicantBirthDate;
                    cmd.Parameters.Add("@selectedApplicantGender", System.Data.SqlDbType.Text).Value = applyModel.selectedApplicantGender;
                    cmd.Parameters.Add("@contact", System.Data.SqlDbType.VarChar, 12).Value = applyModel.contact;
                    cmd.Parameters.Add("@selectedPaymentMethod", System.Data.SqlDbType.Text).Value = applyModel.selectedPaymentMethod;

                    cmd.Parameters.Add("@deadLastName", System.Data.SqlDbType.VarChar, 50).Value = applyModel.deadLastName;
                    cmd.Parameters.Add("@deadFirstName", System.Data.SqlDbType.VarChar, 50).Value = applyModel.deadFirstName;
                    cmd.Parameters.Add("@deadMiddleName", System.Data.SqlDbType.VarChar, 50).Value = applyModel.deadMiddleName;
                    cmd.Parameters.Add("@deadBirthDate", System.Data.SqlDbType.Date).Value = applyModel.deadBirthDate;
                    cmd.Parameters.Add("@selectedDeadGender", System.Data.SqlDbType.Text).Value = applyModel.selectedDeadGender;
                    cmd.Parameters.Add("@deathDate", System.Data.SqlDbType.Date).Value = applyModel.deathDate;
                    cmd.Parameters.Add("@selectedLocation", System.Data.SqlDbType.VarChar, 10).Value = applyModel.selectedLocation;
                    cmd.Parameters.Add("@selectedFloorNSection", System.Data.SqlDbType.VarChar, 10).Value = applyModel.selectedFloorNSection;
                    connect.Open();

                    int newId = cmd.ExecuteNonQuery();

                    return newId;
                }
                else
                {
                    sqlQuery = "UPDATE APPLICANT SET lastName = @applicantLastName, firstName = @applicantFirstName, middleName = @applicantMiddleName, birthDate = @applicantBirthDate, gender = @selectedApplicantGender, contact = @contact, paymentMethod = @selectedPaymentMethod WHERE applicantId = @Id";

                    SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = applyModel.Id;
                    cmd.Parameters.Add("@applicantLastName", System.Data.SqlDbType.Text).Value = applyModel.applicantLastName;
                    cmd.Parameters.Add("@applicantFirstName", System.Data.SqlDbType.Text).Value = applyModel.applicantFirstName;
                    cmd.Parameters.Add("@applicantMiddleName", System.Data.SqlDbType.Text).Value = applyModel.applicantMiddleName;
                    cmd.Parameters.Add("@applicantBirthDate", System.Data.SqlDbType.Date).Value = applyModel.applicantBirthDate;
                    cmd.Parameters.Add("@selectedApplicantGender", System.Data.SqlDbType.Text).Value = applyModel.selectedApplicantGender;
                    cmd.Parameters.Add("@contact", System.Data.SqlDbType.VarChar, 12).Value = applyModel.contact;
                    cmd.Parameters.Add("@selectedPaymentMethod", System.Data.SqlDbType.Text).Value = applyModel.selectedPaymentMethod;
                    connect.Open();

                    int newId = cmd.ExecuteNonQuery();

                    return newId;
                }
            }
        }

        public int insertOssuaryData(ApplyModel applyModel)
        {

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE OSSUARY SET lastName = @deadLastName, firstName = @deadFirstName, middleName = @deadMiddleName, birthDate = @deadBirthDate, gender = @selectedDeadGender, deathDate = @deathDate, location = @selectedLocation, floorNSection = @selectedFloorNSection WHERE deceasedId = @Id";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = applyModel.Id;
                cmd.Parameters.Add("@deadLastName", System.Data.SqlDbType.VarChar, 50).Value = applyModel.deadLastName;
                cmd.Parameters.Add("@deadFirstName", System.Data.SqlDbType.VarChar, 50).Value = applyModel.deadFirstName;
                cmd.Parameters.Add("@deadMiddleName", System.Data.SqlDbType.VarChar, 50).Value = applyModel.deadMiddleName;
                cmd.Parameters.Add("@deadBirthDate", System.Data.SqlDbType.Date).Value = applyModel.deadBirthDate;
                cmd.Parameters.Add("@selectedDeadGender", System.Data.SqlDbType.Text).Value = applyModel.selectedDeadGender;
                cmd.Parameters.Add("@deathDate", System.Data.SqlDbType.Date).Value = applyModel.deathDate;
                cmd.Parameters.Add("@selectedLocation", System.Data.SqlDbType.VarChar, 10).Value = applyModel.selectedLocation;
                cmd.Parameters.Add("@selectedFloorNSection", System.Data.SqlDbType.VarChar, 10).Value = applyModel.selectedFloorNSection;
                connect.Open();

                int newId = cmd.ExecuteNonQuery();

                return newId;
            }
        }

        public List<ApplyModel> getApplicantTable()
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

        public List<ApplyModel> getOssuaryTable()
        {
            List<ApplyModel> returnList = new List<ApplyModel>();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM OSSUARY";

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
                        applyModel.selectedLocation = read.GetString(7);
                        applyModel.selectedFloorNSection = read.GetString(8);

                        returnList.Add(applyModel);

                    }
                }
            }

            return returnList;
        }

        //public List<ApplyModel> combineOssuaryTable()
        //{
        //    List<ApplyModel> returnList = new List<ApplyModel>();

        //    using (SqlConnection connect = new SqlConnection(connectionString))
        //    {
        //        string sqlQuery = "SELECT CONCAT(FIRSTNAME, ' ', LEFT(MIDDLENAME, 1), ' ', LASTNAME) AS Name, CONVERT(VARCHAR(20), BIRTHDATE) + ' to ' + CONVERT(VARCHAR(20), DEATHDATE) AS Lived, CONCAT(LOCATION, ' - ', FLOORNSECTION) AS 'Location - Floor & Section' FROM OSSUARY";

        //        SqlCommand cmd = new SqlCommand(sqlQuery, connect);
        //        connect.Open();
        //        SqlDataReader read = cmd.ExecuteReader();

        //        if (read.HasRows)
        //        {
        //            while (read.Read())
        //            {
        //                ApplyModel applyModel = new ApplyModel();
        //                applyModel.Name = read.GetString(0);
        //                applyModel.Lived = read.GetString(1);
        //                applyModel.Area = read.GetString(2);

        //                returnList.Add(applyModel);

        //            }
        //        }
        //    }

        //    return returnList;
        //}

        //public List<ApplyModel> getOssuaryTable(int page)
        //{
        //    List<ApplyModel> returnList = new List<ApplyModel>();

        //    using (SqlConnection connect = new SqlConnection(connectionString))
        //    {
        //        string sqlQuery = "";

        //        switch (page)
        //        {
        //            case 1:
        //                sqlQuery = "SELECT * FROM [OSSUARY I]";
        //                break;
        //            case 2:
        //                sqlQuery = "SELECT * FROM [OSSUARY II]";
        //                break;
        //            case 3:
        //                sqlQuery = "SELECT * FROM [OSSUARY III]";
        //                break;
        //            case 4:
        //                sqlQuery = "SELECT * FROM [OSSUARY IV]";
        //                break;
        //            case 5:
        //                sqlQuery = "SELECT * FROM [OSSUARY V]";
        //                break;
        //            case 6:
        //                sqlQuery = "SELECT * FROM [OSSUARY VI]";
        //                break;
        //            case 7:
        //                sqlQuery = "SELECT * FROM [OSSUARY VII]";
        //                break;
        //            case 8:
        //                sqlQuery = "SELECT * FROM [OSSUARY VIII]";
        //                break;
        //            case 9:
        //                sqlQuery = "SELECT * FROM [OSSUARY IX]";
        //                break;
        //            case 10:
        //                sqlQuery = "SELECT * FROM [OSSUARY X]";
        //                break;
        //            default:
        //                sqlQuery = "";
        //                break;
        //        }

        //        SqlCommand cmd = new SqlCommand(sqlQuery, connect);
        //        connect.Open();
        //        SqlDataReader read = cmd.ExecuteReader();

        //        if (read.HasRows)
        //        {
        //            while (read.Read())
        //            {
        //                ApplyModel applyModel = new ApplyModel();
        //                applyModel.Id = read.GetInt32(0);
        //                applyModel.deadLastName = read.GetString(1);
        //                applyModel.deadFirstName = read.GetString(2);
        //                applyModel.deadMiddleName = read.GetString(3);
        //                applyModel.deadBirthDate = read.GetDateTime(4);
        //                applyModel.selectedDeadGender = read.GetString(5);
        //                applyModel.deathDate = read.GetDateTime(6);
        //                applyModel.floorNSection = read.GetString(7);

        //                returnList.Add(applyModel);

        //            }
        //        }
        //    }

        //    return returnList;
        //}

        public ApplyModel get1ApplicantData(int Id)
        {

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM APPLICANT WHERE applicantId = @applicantId";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@applicantId", System.Data.SqlDbType.Int).Value = Id;
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

        public ApplyModel get1OssuaryData(int Id)
        {

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM OSSUARY WHERE deceasedId = @deceasedId";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@deceasedId", System.Data.SqlDbType.Int).Value = Id;
                connect.Open();
                SqlDataReader read = cmd.ExecuteReader();

                ApplyModel applyModel = new ApplyModel();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        applyModel.Id = read.GetInt32(0);
                        applyModel.deadLastName = read.GetString(1);
                        applyModel.deadFirstName = read.GetString(2);
                        applyModel.deadMiddleName = read.GetString(3);
                        applyModel.deadBirthDate = read.GetDateTime(4);
                        applyModel.selectedDeadGender = read.GetString(5);
                        applyModel.deathDate = read.GetDateTime(6);
                        applyModel.selectedLocation = read.GetString(7);
                        applyModel.selectedFloorNSection = read.GetString(8);

                    }
                }

                return applyModel;
            }
        }

        internal int deleteApplicant(int Id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM APPLICANT WHERE applicantId = @applicantId";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@applicantId", System.Data.SqlDbType.Int).Value = Id;
                connect.Open();
                int deleteId = cmd.ExecuteNonQuery();

                return deleteId;
            }
        }

        internal int deleteOssuary(int Id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM OSSUARY WHERE deceasedId = @deceasedId";

                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add("@deceasedId", System.Data.SqlDbType.Int).Value = Id;
                connect.Open();
                int deleteId = cmd.ExecuteNonQuery();

                return deleteId;
            }
        }

        internal List<ApplyModel> searchForName(string searchTerm)
        {
            List<ApplyModel> returnList = new List<ApplyModel>();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM OSSUARY WHERE LASTNAME + FIRSTNAME + MIDDLENAME LIKE @searchFor";

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
                        applyModel.deadLastName = read.GetString(1);
                        applyModel.deadFirstName = read.GetString(2);
                        applyModel.deadMiddleName = read.GetString(3);
                        applyModel.deadBirthDate = read.GetDateTime(4);
                        applyModel.selectedDeadGender = read.GetString(5);
                        applyModel.deathDate = read.GetDateTime(6);
                        applyModel.selectedLocation = read.GetString(7);
                        applyModel.selectedFloorNSection = read.GetString(8);

                        returnList.Add(applyModel);

                    }
                }
            }

            return returnList;
        }

    }
}