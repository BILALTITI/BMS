using DVLD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccsesLayer
{
    public class ClsLogs
    {
        public static bool GetLogsByLogID(int? LogID, ref string UserName, ref DateTime LogDate, ref string Action,ref int Permetions)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Logs WHERE LogID = @LogID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LogID", (object)LogID??DBNull.Value);

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
                                Action = (string)reader["Action"];
                                LogDate = (DateTime)reader["LogDate"];
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
                        CLsGlobal.SaveToEventLog("Cant Get Logs by LogID  ", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                    }
                }
            }
            return isFound;
        }
          
        public static int AddNewLogs(string UserName,DateTime LogDate,string Action,int Permetions)
        {
            int LogID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = @"INSERT INTO Logs(UserName,LogDate,Action,Permetions)
                             VALUES (@UserName,@LogDate,@Action,@Permetions);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserName",UserName);
                    command.Parameters.AddWithValue("@LogDate",LogDate);
                    command.Parameters.AddWithValue("@Action",Action);
                    command.Parameters.AddWithValue("@Permetions",Permetions);
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            LogID = insertedID;
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
            return LogID;


        }

        public static bool UpdateLogs(int? LogID,  string UserName,   DateTime LogDate,   string Action ,int Permetions)

        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {

                string query = @"Update Logs  
                            set UserName=@UserName,
                                LogDate=@LogDate,
                                Action=@Action,
                                  Permetions=@Permetions
                                  Where LogID=@LogID
                             ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@LogDate", LogDate);
                    command.Parameters.AddWithValue("@Action", Action);
                    command.Parameters.AddWithValue("@LogID", (object)LogID ?? DBNull.Value);

                    command.Parameters.AddWithValue("@Permetions", Permetions);


                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        CLsGlobal.SaveToEventLog("error in Update Logs", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

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

        public static DataTable GetAllLogs()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = @"SELECT * from Logs ";

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
                        CLsGlobal.SaveToEventLog("error in Get All Logs", System.Diagnostics.EventLogEntryType.Error, "Bank.App");

                    }
                    finally
                    {
                        //       connection.Close();
                    }
                }
            }
            return dt;

        }
     }
}
