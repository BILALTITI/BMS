using DVLD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsesLayer
{
    public class Transactionsdata
    {

        public static bool GetTransactionsbyTransactionID(int? TransactionID, ref int ? ClientID, ref string TransactionType, ref decimal Amount
       , ref DateTime TransactionDate, ref string Describe)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = "SELECT * FROM Transactions WHERE TransactionID = @TransactionID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionID",(object) TransactionID??DBNull.Value);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                ClientID = (reader["ClientID"] != DBNull.Value) ? (int?)reader["ClientID"] : null;
                                TransactionType = (string)reader["TransactionType"];
                                Amount = (decimal)reader["Amount"];
                                TransactionDate = (DateTime)reader["TransactionDate"];
                                Describe = (string)reader["Describe"];

                                

                            }
                        }


                    }


                    catch (Exception ex)
                    {
                        isFound = false;
                        CLsGlobal.SaveToEventLog("Cant Get The Account byAccountNo", System.Diagnostics.EventLogEntryType.Error, "Bank.App");
                    }
                    finally
                    {
                        //connection.Close();
                    }

                }
            }
            return isFound;
        }
        public static bool GetTransactionsbyClientID(int? ClientID, ref int ?TransactionID, ref string TransactionType, ref decimal Amount
     , ref DateTime TransactionDate, ref string Describe)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = "SELECT * FROM Transactions WHERE AccountID = @AccountID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", (object)ClientID??DBNull.Value);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                TransactionID = (reader["TransactionID"] != DBNull.Value) ? (int?)reader["TransactionID"] : null;
                                TransactionType = (string)reader["TransactionType"];
                                Amount = (decimal)reader["Amount"];
                                TransactionDate = (DateTime)reader["TransactionDate"];
                                //Describe = (string)reader["Describe"];
                                if (reader["ThirdName"] != DBNull.Value)
                                {
                                    Describe = (string)reader["Describe"];
                                }
                                else
                                {
                                    Describe = "";

                                }


                            }
                        }


                    }


                    catch (Exception ex)
                    {
                        isFound = false;
                        CLsGlobal.SaveToEventLog("Cant Get The Account byAccountNo", System.Diagnostics.EventLogEntryType.Error, "Bank.App");
                    }
                    finally
                    {
                        //connection.Close();
                    }

                }
            }
            return isFound;
        }
        public static int AddnewTransaction(  int? ClientID,   string TransactionType,   decimal Amount
       ,   DateTime TransactionDate,   string Describe)
        {
            int TransactionID = -1;


            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {


               
                string query = @"INSERT INTO Transactions(ClientID,TransactionType,Amount,TransactionDate,Describe)
                             VALUES (@ClientID,@TransactionType,@Amount,@TransactionDate,@Describe);
                             SELECT SCOPE_IDENTITY();";
               
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", (object)ClientID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TransactionType", TransactionType);
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                    //command.Parameters.AddWithValue("@Describe", Describe);

                    if (Describe != "")
                        command.Parameters.AddWithValue("@Describe", Describe);
                    else
                        command.Parameters.AddWithValue("@Describe", System.DBNull.Value);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            TransactionID = insertedID;
                        }
                    }

                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        CLsGlobal.SaveToEventLog("Cant Add new Account", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                    }

                    finally
                    {
                        //           connection.Close();
                    }
                }
            }
            return TransactionID;


        }


        public static bool UpdateTransaction(int? TransactionID,  int? ClientID,   string TransactionType,   decimal Amount
       ,   DateTime TransactionDate,   string Describe)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                
                string query = @"Update  Transactions  
                            set ClientID=@ClientID,

                              TransactionType = @TransactionType,
                                 Amount = @Amount, 
                                 OpenDate = @OpenDate,
                                    Describe=@Describe,
                                where TransactionID = @TransactionID";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {



                    command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ClientID",     (object)ClientID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TransactionType", TransactionType);
                     command.Parameters.AddWithValue("@Amount", Amount);

                    command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                    if (Describe != "")
                        command.Parameters.AddWithValue("@Describe", Describe);
                    else
                        command.Parameters.AddWithValue("@Describe", System.DBNull.Value);
                    //command.Parameters.AddWithValue("@Describe", Describe);
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
        public static DataTable GetAllTransactions()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))

            {

                string query = @" SELECT * FROM Transactions  ORDER BY TransactionDate DESC";

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

                        CLsGlobal.SaveToEventLog("Cant Get All  Account ", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                    }
                    finally
                    {
                        //  connection.Close();
                    }
                }
            }
            return dt;

        }
        public static DataTable GetAllDeposit()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))

            {
                string query = @"
            SELECT 
                TransactionID, 
                ClientID, 
                Amount, 
                TransactionDate,
                CASE 
                    WHEN TransactionType = 'Deposit' THEN 'DepositTransaction'
                    ELSE TransactionType
                END AS TransactionTypeCaption
            FROM Transactions
            ORDER BY TransactionDate DESC";
                ;

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

                        CLsGlobal.SaveToEventLog("Cant Get All  Account ", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                    }
                    finally
                    {
                        //  connection.Close();
                    }
                }
            }
            return dt;

        }
        public static bool DeleteTransaction(int TransactionID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = @"Delete Transactions 
                                where TransactionID = @TransactionID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TransactionID", TransactionID);

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
        public static bool IsTransactionExsist(int ?TransactionID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {


                string query = "SELECT Found=1 FROM Transactions WHERE TransactionID = @TransactionID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);

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
