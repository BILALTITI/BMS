using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DVLD;

namespace DataAccsesLayer
{
     
        public class clsUserData
        {
           

            public static bool GetUserByID(int? UserID, ref string UserName, ref string Password, ref bool isActive, ref int? PersonID,ref int Permetions)
            {
                bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", (object)UserID ??DBNull.Value);

                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    isFound = true;

                                    //UserID = (int)reader["UserID"];
                                    UserName = (string)reader["UserName"];
                                    Password = (string)reader["Password"];

                                PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                isActive = (bool)reader["IsActive"];
                                Permetions = (int)reader["Permetions"];
                            }
                            }
                        }
                        catch (Exception ex)
                        {
                            isFound = false;
                        }
                        finally
                        {
                            //   connection.Close();
                            CLsGlobal.SaveToEventLog("Cant Get Users by User ID  ", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                        }
                    }
                }
                return isFound;
            }
        public static bool GetUserByUserName( string UserName, ref int? UserID, ref string Password, ref bool isActive, ref int? PersonID, ref int Permetions)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                //UserID = (int)reader["UserID"];
                                UserID = (reader["UserID"] != DBNull.Value) ? (int?)reader["UserID"] : null;
                                Password = (string)reader["Password"];

                                PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                isActive = (bool)reader["IsActive"];
                                Permetions = (int)reader["Permetions"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                    }
                    finally
                    {
                        //   connection.Close();
                        CLsGlobal.SaveToEventLog("Cant Get Users by User ID  ", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                    }
                }
            }
            return isFound;
        }
        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password,
          ref int? UserID, ref int? PersonID, ref bool IsActive,ref int Permetions)
            {
                bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))

            {
                string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", UserName);
                        command.Parameters.AddWithValue("@Password", Password);


                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // The record was found
                                    isFound = true;
                                    UserID = (reader["UserID"] != DBNull.Value) ? (int?)reader["UserID"] : null;
                                    PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                    UserName = (string)reader["UserName"];
                                    Password = (string)reader["Password"];
                                    IsActive = (bool)reader["IsActive"];
                                Permetions = (int)reader["Permetions"];

                            }
                                else
                                {
                                    // The record was not found
                                    CLsGlobal.SaveToEventLog("Error, Get User Info By Username And Password", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                                    isFound = false;
                                }

                             //   reader.Close();
                            }

                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine("Error: " + ex.Message);

                            isFound = false;
                        }
                        finally
                        {
                            //connection.Close();
                        }
                    }
                }
                return isFound;
            }

            public static bool GetUserByName(ref int? UserID, ref string UserName, ref string Password, ref bool isActive, ref int ?PersonID, ref int Permetions)
            {
                bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserName = @UserName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserID);
                        {

                            try
                            {
                                connection.Open();
                                SqlDataReader reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    isFound = true;

                                    UserID = (reader["UserID"] != DBNull.Value) ? (int?)reader["UserID"] : null;
                                    UserName = (string)reader["UserName"];
                                    Password = (string)reader["Password"];
                                    PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                    isActive = (bool)reader["IsActive"];


                                }

                            }
                            
                            catch (Exception ex)
                            {
                                CLsGlobal.SaveToEventLog("Error, Get User By Name", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                                isFound = false;
                            } 
                            finally
                            {
                                //       connection.Close();
                            }
                        }
                    }
                
            
                    return isFound = true;
                }
            
            
        }
            public static int AddNewUser(string UserName, string Password, bool isActive, int? PersonID ,int Permetions)
            {
                int UserID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = @"INSERT INTO Users ( UserName,Password,isActive,PersonID,Permetions )
                             VALUES (@UserName,@Password,@isActive,@PersonID,@Permetions);
                             SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@isActive", isActive);
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID??DBNull.Value);

                    command.Parameters.AddWithValue("@Permetions", Permetions);
                    try
                        {
                            connection.Open();

                            object result = command.ExecuteScalar();


                            if (result != null && int.TryParse(result.ToString(), out int insertedID))
                            {
                                UserID = insertedID;
                            }
                        }

                        catch (Exception ex)
                        {
                            //Console.WriteLine("Error: " + ex.Message);
                            CLsGlobal.SaveToEventLog("Error , in Add new User", System.Diagnostics.EventLogEntryType.Error, "Bank.App");


                        }

                        finally
                        {
                            //       connection.Close();
                        }
                    }
                }
                return UserID;


            }

            public static bool UpdateUser(int? UserID, string UserName, string Password, bool isActive, int ?PersonID,int Permetions)

            {

                int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = @"Update  Users  
                            set UserName = @UserName,
                                Password=@Password,
                                isActive=@isActive,
                                PersonID = @PersonID,
                                Permetions=@Permetions
                                Where UserID=@UserID
                             ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@isActive", isActive);
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserID",(object) UserID??DBNull.Value);

                          command.Parameters.AddWithValue("@Permetions", Permetions);

                    try
                        {
                            connection.Open();
                            rowsAffected = command.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine("Error: " + ex.Message);
                            CLsGlobal.SaveToEventLog("error in Update User", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                            return false;
                        }
                    
                    finally
                    {
                    //    connection.Close();
                    }
                } 
            }
                return (rowsAffected > 0);
            }

            public static DataTable GetAllUser()
            {

                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
                { 
                string query = @"SELECT * FROM Users";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        try
                        {
                            connection.Open();

                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)

                            {
                                dt.Load(reader);
                            }

                            reader.Close();


                        }

                        catch (Exception ex)
                        {
                            // Console.WriteLine("Error: " + ex.Message);
                            CLsGlobal.SaveToEventLog("error in Get All User", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                        }
                        finally
                        {
                            //       connection.Close();
                        }
                    }
            }
                return dt;

            }
            public static bool DeleteUser(int ?UserID)
            {

                int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = @"Delete Users 
                                where UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);

                        try
                        {
                            connection.Open();

                            rowsAffected = command.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            // Console.WriteLine("Error: " + ex.Message);
                            CLsGlobal.SaveToEventLog("Error In Delete User", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                        }
                        finally
                        {

                            //       connection.Close();

                        }
                    }
                }
                return (rowsAffected > 0);

            }
            public static bool IsUserExsist(int? ID)
            {
                bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    { 

                        command.Parameters.AddWithValue("@UserID", (object)ID ?? DBNull.Value);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        isFound = reader.HasRows;

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                            //Console.WriteLine("Error: " + ex.Message);
                            CLsGlobal.SaveToEventLog("Error in User Exsist !", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                            isFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                } 
            }
                return isFound;
            }
            public static bool IsUserExsistbyUserNAme(string UserName)
            {
                bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    { 

                        command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        isFound = reader.HasRows;

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                            //Console.WriteLine("Error: " + ex.Message);
                            CLsGlobal.SaveToEventLog("Error , In user exsist By User Name", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                            isFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                } 
            }
                return isFound;
            }
            public static bool IsUserExsistbyPersonID(int? PersonID)
            {
                bool isFound = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                isFound = reader.HasRows;

                        //        reader.Close();
                            }
                        }
                    catch (Exception ex)
                        {
                            //Console.WriteLine("Error: " + ex.Message);
                            CLsGlobal.SaveToEventLog("Error In User Exsist", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                            isFound = false;
                        }
                        finally
                        {
                            //            connection.Close();
                        }
                    }
                
            }
                return isFound;
            }
            public static bool ChangePassword(int? UserID, string NewPassword)


            {
                int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = @"Update  Users  
                            set Password=@Password,
                                 Where UserID=@UserID
                             ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);


                        try
                        {
                            connection.Open();
                            rowsAffected = command.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine("Error: " + ex.Message);
                            CLsGlobal.SaveToEventLog("Cant Get Change the Password", System.Diagnostics.EventLogEntryType.Error, "Bank.App");
                            return false;

                        }

                        finally
                        {
                            //       connection.Close();
                        }
                    }
                }
                return (rowsAffected > 0);

            }

        }
    
}
