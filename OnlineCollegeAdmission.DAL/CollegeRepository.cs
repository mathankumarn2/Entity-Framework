using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using OnlineCollegeAdmission.Entity;

namespace OnlineCollegeAdmission.DAL
{
    public interface ICollegeRepository
    {
        void AddCollege(College college);
        void UpdateCollege(string CollegeCode, int fee, int seats);
        void DeleteCollege(string collegeCode);
        DataTable GetCollegeTable();
        College GetCollegeByCode(string collegeCode);
        DataTable GetDepartmentByCollege(string collegeCode);
        List<College> GetColleges();
        void AddDepartment(Department department);
        DataTable GetDept();
    }
    public class CollegeRepository : ICollegeRepository
    {
        public void AddCollege(College college)
        {
            using (SqlConnection connection = DButils.GetDbconnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_InsertCollege", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CollegeCode", college.CollegeCode);
                    sqlCommand.Parameters.AddWithValue("@CollegeName", college.CollegeName);
                    sqlCommand.Parameters.AddWithValue("@CollegeWebsite", college.CollegeWebsite);
                    sqlCommand.Parameters.AddWithValue("@AdmissionFee", college.AdmissionFee);
                    sqlCommand.Parameters.AddWithValue("@TotalSeats", college.TotalSeats);
                    connection.Open();
                    int row = sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public void UpdateCollege(string CollegeCode, int fee, int seats)
        {
            using (SqlConnection connection = DButils.GetDbconnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_UpdateCollege", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@AdmissionFee", fee);
                    sqlCommand.Parameters.AddWithValue("@TotalSeats", seats);
                    sqlCommand.Parameters.AddWithValue("@CollegeCode", CollegeCode);
                    connection.Open();
                    int row = sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public void DeleteCollege(string collegeCode)
        {
            using (SqlConnection sqlConnection = DButils.GetDbconnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_DeleteCollege", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CollegeCode", collegeCode);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetCollegeTable()
        {
            using (SqlConnection sqlConnection = DButils.GetDbconnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_DisplayCollege", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdpater = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdpater.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        public List<College> GetColleges()
        {
            CollegeDBContext collegeDBContext = new CollegeDBContext();
            return collegeDBContext.Colleges.ToList();
        }

        public College GetCollegeByCode(string collegeCode)
        {
            using (SqlConnection sqlConnection = DButils.GetDbconnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_GetCollege", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CollegeCode", collegeCode);
                    sqlCommand.Parameters.Add("@collegeName", SqlDbType.VarChar, 50);
                    sqlCommand.Parameters["@collegeName"].Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add("@website", SqlDbType.VarChar, 50);
                    sqlCommand.Parameters["@website"].Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add("@admissionFee", SqlDbType.Int);
                    sqlCommand.Parameters["@admissionFee"].Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add("@totalSeats", SqlDbType.Int);
                    sqlCommand.Parameters["@totalSeats"].Direction = ParameterDirection.Output;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    string collegeName = sqlCommand.Parameters["@collegeName"].Value.ToString();
                    string website = sqlCommand.Parameters["@website"].Value.ToString();
                    int fee = Convert.ToInt32(sqlCommand.Parameters["@admissionFee"].Value);
                    int totalSeats = Convert.ToInt32(sqlCommand.Parameters["@totalSeats"].Value);
                    College college = new College(collegeCode, collegeName, website, fee, totalSeats);
                    return college;
                }
            }
        }
        public void AddDepartment(Department department)
        {
            using (SqlConnection sqlConnection = DButils.GetDbconnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_AddDepartment", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CollegeCode", department.CollegeCode);
                    sqlCommand.Parameters.AddWithValue("@DeptId", department.DeptId);
                    sqlCommand.Parameters.AddWithValue("@Fees", department.Fees);
                    sqlCommand.Parameters.AddWithValue("@Seats", department.Seats);
                    sqlConnection.Open();
                    int row = sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetDepartmentByCollege(string collegeCode)
        {
            using (SqlConnection sqlConnection = DButils.GetDbconnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_GetDepartmentByCollege", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CollegeCode", collegeCode);
                    SqlDataAdapter sqlDataAdpater = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdpater.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        public DataTable GetDept()
        {
            using (SqlConnection sqlConnection = DButils.GetDbconnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_GetDepartmentNames", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdpater = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdpater.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}
