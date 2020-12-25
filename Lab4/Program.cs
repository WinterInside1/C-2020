using DataManagerDll;
using ParserDll;
using System;
using System.IO;
using System.ServiceProcess;
using System.Xml.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
    static class Program
    {

        static readonly string xmlPath = Path.Combine("C:\\Users\\dima4\\source\\repos\\Lab4\\Lab4\\dataMethods", "dataMethods.xml");

        static readonly string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataMethods.json");

        static void Main()
        {
            Manager configManager;
            DataMethods dataMethods;
            DataInputOutput logsDBSample;

            try
            {
                //if (File.Exists(xmlPath))
                //{
                configManager = new Manager(xmlPath, typeof(DataMethods));
                //}
                // if (File.Exists(jsonPath))
                // {
                //   configManager = new Manager(jsonPath, typeof(DataMethods));
                //}
                //else
                //{
                //  throw new Exception("File with data options was not found");
                //}

                dataMethods = configManager.Parse<DataMethods>();

                logsDBSample = new DataInputOutput(dataMethods.LoggerConnectionString);

                logsDBSample.ClearLogs();

                logsDBSample.InsertLogs("Connection was successfully established");
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exceptions.txt"), true))
                {
                    sw.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} Exception: {ex.Message}");
                }

                return;
            }

            try
            {
                Service1 service = new Service1(dataMethods, logsDBSample);

                ServiceBase.Run(service);
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex)
            {
                logsDBSample.InsertLogs("EXCEPTION: " + ex.Message);

                logsDBSample.WriteInsightsToXml(dataMethods.OutputFolder);
            }
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (Enum.TryParse("Error", out XmlSeverityType type) && type == XmlSeverityType.Error)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

