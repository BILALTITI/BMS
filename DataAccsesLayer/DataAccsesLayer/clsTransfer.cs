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
    public class clsTransfer
    {
        public static bool GetTransferByTransferID(int? TransferID, ref string TransferFrom, ref string TransferTo, ref decimal Amount
   , ref DateTime TransferDate,ref int? ClientID, ref string Describe)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = "SELECT * FROM Transfer WHERE TransferID = @TransferID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransferID", (object)TransferID??DBNull.Value);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                TransferFrom = (string)reader["TransferFrom"];
                                TransferTo = (string)reader["TransferTo"];
                                Amount = (decimal)reader["Amount"];
                                TransferDate = (DateTime)reader["TransferDate"];

                                ClientID = (reader["ClientID"] != DBNull.Value) ? (int?)reader["ClientID"] : null;
                                if (reader["Describe"] != DBNull.Value)
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
     //   public static bool GetTransactionsbyClientID(int ClientID, ref int TransactionID, ref string TransactionType, ref decimal Amount
     //, ref DateTime TransactionDate, ref string Describe)
     //   {
     //       bool isFound = false;

     //       using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
     //       {

     //           string query = "SELECT * FROM Transactions WHERE AccountID = @AccountID";
     //           using (SqlCommand command = new SqlCommand(query, connection))
     //           {
     //               command.Parameters.AddWithValue("@ClientID", ClientID);

     //               try
     //               {
     //                   connection.Open();
     //                   using (SqlDataReader reader = command.ExecuteReader())
     //                   {
     //                       if (reader.Read())
     //                       {
     //                           isFound = true;

     //                           TransactionID = (int)reader["TransactionID"];
     //                           TransactionType = (string)reader["TransactionType"];
     //                           Amount = (decimal)reader["Amount"];
     //                           TransactionDate = (DateTime)reader["TransactionDate"];
     //                           //Describe = (string)reader["Describe"];
     //                           if (reader["ThirdName"] != DBNull.Value)
     //                           {
     //                               Describe = (string)reader["Describe"];
     //                           }
     //                           else
     //                           {
     //                               Describe = "";

     //                           }


     //                       }
     //                   }


     //               }


     //               catch (Exception ex)
     //               {
     //                   isFound = false;
     //                   CLsGlobal.SaveToEventLog("Cant Get The Account byAccountNo", System.Diagnostics.EventLogEntryType.Error, "Bank.App");
     //               }
     //               finally
     //               {
     //                   //connection.Close();
     //               }

     //           }
     //       }
     //       return isFound;
     //   }
        public static int AddnewTransfer( string TransferFrom,   string TransferTo,   decimal Amount
   ,   DateTime TransferDate,   int? ClientID,   string Describe)
        {
            int TransferID = -1;


            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {



                string query = @"INSERT INTO Transfer(TransferFrom,TransferTo,Amount,TransferDate,ClientID,Describe)
                             VALUES (@TransferFrom,@TransferTo,@Amount,@TransferDate,@ClientID,@Describe);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransferFrom", TransferFrom);
                    command.Parameters.AddWithValue("@TransferTo", TransferTo);
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@TransferDate", TransferDate);

                    if (Describe != "")
                        command.Parameters.AddWithValue("@Describe", Describe);
                    else
                        command.Parameters.AddWithValue("@Describe", System.DBNull.Value);
                    command.Parameters.AddWithValue("@ClientID", (object)ClientID??DBNull.Value);


                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            TransferID = insertedID;
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
            return TransferID;


        }


        public static bool UpdateTransfer(int ?TransferID,   string TransferFrom,   string TransferTo,   decimal Amount
   ,   DateTime TransferDate,   int? ClientID,   string Describe)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = @"Update  Transfer  
                            set TransferFrom=@TransferFrom,

                              TransferTo = @TransferTo,
                                 Amount = @Amount, 
                                 TransferDate = @TransferDate,
                                  ClientID=@ClientID,
                                    Describe=@Describe,
                                where TransferID = @TransferID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {



                    command.Parameters.AddWithValue("@TransferID",   (object)TransferID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TransferTo", TransferTo);
                    command.Parameters.AddWithValue("@TransferFrom", TransferFrom);
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@ClientID", (object)ClientID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TransferDate", TransferDate);
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
        public static DataTable GetAllTransfer()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))

            {

                string query = @" SELECT * FROM Transfer";

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
        public static bool DeleteTransfer(int? TransferID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = @"Delete Transfer 
                                where TransferID = @TransferID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TransferID", (object)TransferID ?? DBNull.Value);

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
        public static bool IsTransferExsist(int? TransferID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {


                string query = "SELECT Found=1 FROM Transfer WHERE TransferID = @TransferID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransferID", (object)TransferID ?? DBNull.Value);

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

