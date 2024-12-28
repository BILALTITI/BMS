using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DVLD;

namespace DataAccsesLayer
{
   public class ClsClientData
    {
        public static bool GetClientByClientID(int ?ClientID,ref string AccountID, ref int? PersonID,ref string AccountType, ref decimal Balance,ref DateTime OpenDate,ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = "SELECT * FROM Client WHERE ClientID= @ClientID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID",(object) ClientID??DBNull.Value);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                AccountID = (string)reader["AccountID"];
                                PersonID = (reader["PersonID"]!=DBNull.Value)?(int? )reader["PersonID"]:null;
                                AccountType = (string)reader["AccountType"];
                                Balance = (decimal)reader["Balance"];
                                OpenDate = (DateTime)reader["OpenDate"];
                                IsActive = (bool)reader["IsActive"];

                                //ImagePath: allows null in database so we should handle null

                            }
                        }


                    }


                    catch (Exception ex)
                    {
                        isFound = false;
                        CLsGlobal.SaveToEventLog("Cant Get The Client by ClientID", System.Diagnostics.EventLogEntryType.Error, "Bank.App");
                    }
                    finally
                    {
                        //connection.Close();
                    }

                }
            }
            return isFound;
        }
        public static bool GetClientByAccountID( string AccountID, ref int ?ClientID , ref int ?PersonID, ref string AccountType, ref decimal Balance, ref DateTime OpenDate, ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = "SELECT * FROM Client WHERE AccountID= @AccountID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", AccountID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;

                                ClientID = (reader["ClientID"] != DBNull.Value) ? (int?)reader["ClientID"] : null;
                                AccountType = (string)reader["AccountType"];
                                Balance = (decimal)reader["Balance"];
                                OpenDate = (DateTime)reader["OpenDate"];
                                IsActive = (bool)reader["IsActive"];

                                //ImagePath: allows null in database so we should handle null

                            }
                        }


                    }


                    catch (Exception ex)
                    {
                        isFound = false;
                        CLsGlobal.SaveToEventLog("Cant Get The Client by ClientID", System.Diagnostics.EventLogEntryType.Error, "Bank.App");
                    }
                    finally
                    {
                        //connection.Close();
                    }

                }
            }
            return isFound;
        }
        public static int AddNewClient(string AccountID, int? PersonID, string AccountType, decimal Balance, DateTime OpenDate,bool IsActive)
        {
            int ClientID = -1;



            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {


                string query = @"INSERT INTO Client(PersonID,AccountID,AccountType,Balance,OpenDate,IsActive)
                             VALUES (@PersonID,@AccountID,@AccountType,@Balance,@OpenDate,@IsActive);
                               SELECT SCOPE_IDENTITY();";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID",(object) PersonID??DBNull.Value);
                    command.Parameters.AddWithValue("@AccountID", AccountID);
                    command.Parameters.AddWithValue("@AccountType",AccountType);
                    command.Parameters.AddWithValue("@Balance", Balance);
                    command.Parameters.AddWithValue("@OpenDate", OpenDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);






                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ClientID = insertedID;
                        }
                    }

                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);

                    }

                    finally
                    {
                               //   connection.Close();
                    }
                }
            }
            return ClientID;


        }


        public static bool UpdateCLient(int ?ClientID, string AccountID, int? PersonID, string AccountType, decimal Balance, DateTime OpenDate,bool IsActive)

        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                 string query = @"Update  Client  
                            set AccountID=@AccountID,

                              PersonID = @PersonID,
                                 AccountType = @AccountType, 
                                 Balance = @Balance,
                                   IsActive=@IsActive
                                
                                where ClientID = @ClientID";
                 using (SqlCommand command = new SqlCommand(query, connection))
                {



                    command.Parameters.AddWithValue("@AccountID", AccountID);
                     command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AccountType", AccountType);
                     command.Parameters.AddWithValue("@ClientID", (object)ClientID ?? DBNull.Value);

                    command.Parameters.AddWithValue("@Balance", Balance);
                    command.Parameters.AddWithValue("@OpenDate", OpenDate);

                    command.Parameters.AddWithValue("@IsActive", IsActive);


                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }

                    finally
                    {
                        //           connection.Close();
                    }
                }
            }
            return (rowsAffected > 0);
    
        }
        public static bool UpdateDepositCLient(int? ClientID, decimal Balance)

        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = @"  UPDATE Client SET Balance += @Balance WHERE ClientID = @ClientID";
                                
                 using (SqlCommand command = new SqlCommand(query, connection))
                {


                     
                    command.Parameters.AddWithValue("@ClientID", (object)ClientID ?? DBNull.Value);

                    command.Parameters.AddWithValue("@Balance", Balance);
 

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }

                    finally
                    {
                        //           connection.Close();
                    }
                }
            }
            return (rowsAffected > 0);

        }
        public static bool UpdateDepositCLientByAccountID(string AccountID, decimal Balance)

        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = @"  UPDATE Client SET Balance += @Balance WHERE AccountID = @AccountID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {



                    command.Parameters.AddWithValue("@AccountID", AccountID);

                    command.Parameters.AddWithValue("@Balance", Balance);


                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }

                    finally
                    {
                        //           connection.Close();
                    }
                }
            }
            return (rowsAffected > 0);

        }
        public static bool UpdateWithSrawCLient(int ?ClientID, decimal Balance)

        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = @"  UPDATE Client SET Balance -= @Balance WHERE ClientID = @ClientID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {



                    command.Parameters.AddWithValue("@ClientID", (object)ClientID ?? DBNull.Value);

                    command.Parameters.AddWithValue("@Balance", Balance);


                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }

                    finally
                    {
                        //           connection.Close();
                    }
                }
            }
            return (rowsAffected > 0);

        }
        public static bool UpdateWithSrawCLientByAccountID(string AccountID, decimal Balance)

        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = @"  UPDATE Client SET Balance -= @Balance WHERE AccountID = @AccountID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {



                    command.Parameters.AddWithValue("@AccountID", AccountID);

                    command.Parameters.AddWithValue("@Balance", Balance);


                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }

                    finally
                    {
                        //           connection.Close();
                    }
                }
            }
            return (rowsAffected > 0);

        }
        public static DataTable GetAllCLient()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))

            {

                string query = @" SELECT * FROM Client";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)

                            {
                                dt.Load(reader);
                            }

                            reader.Close();


                        }
                    }

                    catch (Exception ex)
                    {
                        // Console.WriteLine("Error: " + ex.Message);

                        CLsGlobal.SaveToEventLog("Cant Get All  Client ", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                    }
                    finally
                    {
                        //  connection.Close();
                    }
                }
            }
            return dt;

        }
        public static bool DeleteClient(int ?ClientID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = @"Delete Client 
                                where ClientID = @ClientID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ClientID", (object)ClientID ?? DBNull.Value);

                    try
                    {
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine("Error: " + ex.Message);
                    }
                    finally
                    {

                        //   connection.Close();

                    }
                }
            }
            return (rowsAffected > 0);

        }
        public static bool IsClientExsist(int? PersonID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {


                string query = "SELECT Found=1 FROM Client WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

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
                        CLsGlobal.SaveToEventLog("Error in IS Clint Exsist", System.Diagnostics.EventLogEntryType.Error, "Bank.App");
                        isFound = false;
                    }
                    finally
                    {
                        // connection.Close();

                    }
                }
            }
            return isFound;
        }
        public static bool IsClientExsistbyAccountID(string AccountID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {


                string query = "SELECT Found=1 FROM Client WHERE AccountID = @AccountID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", AccountID);

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
                        CLsGlobal.SaveToEventLog("Error in IS Clint Exsist", System.Diagnostics.EventLogEntryType.Error, "Bank.App");
                        isFound = false;
                    }
                    finally
                    {
                        // connection.Close();

                    }
                }
            }
            return isFound;
        }
    }

}
