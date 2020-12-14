using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DataManagerDll
{
    public class DataInputOutput
    {

        readonly string connectionString;

        public DataInputOutput(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ClearLogs()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = new SqlCommand("sp_ClearLogs", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;

                try
                {
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exceptions.txt"), true))
                    {
                        sw.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} Exception: {ex.Message}");
                    }

                    transaction.Rollback();
                }
            }
        }

        public void InsertLogs(string message)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = new SqlCommand("sp_InsertLogs", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;

                try
                {
                    SqlParameter messageParam = new SqlParameter
                    {
                        ParameterName = "@message",
                        Value = message
                    };

                    SqlParameter timeParam = new SqlParameter
                    {
                        ParameterName = "@time",
                        Value = DateTime.Now
                    };

                    command.Parameters.AddRange(new[] { messageParam, timeParam });

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exceptions.txt"), true))
                    {
                        sw.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} Exception: {ex.Message}");
                    }

                    transaction.Rollback();
                }
            }
        }

        public void WriteInsightsToXml(string outputFolder)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = new SqlCommand("sp_GetLogs", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataSet dataSet = new DataSet("LogsSamples");

                    DataTable dataTable = new DataTable("LogsSample");

                    dataSet.Tables.Add(dataTable);

                    adapter.Fill(dataSet.Tables["LogsSample"]);

                    XmlGenerator xmlGenerator = new XmlGenerator(outputFolder);

                    xmlGenerator.WriteToXml(dataSet, "Logs4Sample");

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exceptions.txt"), true))
                    {
                        sw.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} Exception: {ex.Message}");
                    }

                    transaction.Rollback();
                }
            }
        }

        public void GetCustomers(string outputFolder, DataInputOutput appInsights, string customersFileName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = new SqlCommand("sp_GetCustomers", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataSet dataSet = new DataSet("Customers");

                    DataTable dataTable = new DataTable("Customer");

                    dataSet.Tables.Add(dataTable);

                    adapter.Fill(dataSet.Tables["Customer"]);

                    XmlGenerator xmlGenerator = new XmlGenerator(outputFolder);

                    xmlGenerator.WriteToXml(dataSet, customersFileName);

                    appInsights.InsertLogs("Customers were received successfully");

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    appInsights.InsertLogs("EXCEPTION: " + ex.Message);

                    transaction.Rollback();
                }
            }
        }
    }
}


