using System;
using System.Data.SqlClient;
using OnlineCollegeAdmission.Entity;

namespace OnlineCollegeAdmission.DAL
{
    public interface IUserRepository
    {
        string Login(string EmailId, string password);
        bool SignUp(User user);
    }
    public class UserRepository : IUserRepository
    {
        public string Login(string EmailId, string password)
        {
            using (SqlConnection sqlConnection = DButils.GetDbconnection())
            {
                string command = "sp_Login";
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@EmailId", EmailId);
                        sqlCommand.Parameters.AddWithValue("@Password", password);
                        sqlConnection.Open();
                        string role = sqlCommand.ExecuteScalar().ToString();
                        return role;
                    }
                    catch (NullReferenceException)
                    {
                        return null;
                    }
                }
            }
        }
        public bool SignUp(User user)
        {
            try
            {
                using (SqlConnection sqlConnection = DButils.GetDbconnection())
                {
                    string command = "sp_InsertUser";
                    using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                    {

                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                        sqlCommand.Parameters.AddWithValue("@SecondName", user.LastName);
                        sqlCommand.Parameters.AddWithValue("@EmailID", user.EmailId);
                        sqlCommand.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                        sqlCommand.Parameters.AddWithValue("@Dob", user.Dob);
                        sqlCommand.Parameters.AddWithValue("@Gender", user.Gender);
                        sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                        sqlCommand.Parameters.AddWithValue("@Role", "User");
                        sqlConnection.Open();
                        int affectedRows = sqlCommand.ExecuteNonQuery();
                        if (affectedRows >= 1)
                            return true;
                        return false;
                    }
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
