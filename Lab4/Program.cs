using System;
using System.ServiceProcess;
using System.IO;
using System.Xml.Schema;
using System.Xml.Linq;
using DataManagerDll;
using ParserDll;

namespace Lab4
{
    static class Program
    {

        static readonly string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataMethods", "dataMethods.xml");
        static readonly string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataMethodss", "dataMethods.json");

        static void Main()
        {
            Manager configManager;
            DataMethods dataMethods;

            DataInputOutput appInsights;

            try
            {
                if (File.Exists(xmlPath))
                {
                    XmlSchemaSet schema = new XmlSchemaSet();

                    XDocument xdoc = XDocument.Load(xmlPath);

                    xdoc.Validate(schema, ValidationEventHandler);

                    configManager = new Manager(xmlPath);
                }
                else if (File.Exists(jsonPath))
                {
                    configManager = new Manager(jsonPath);
                }
                else
                {
                    throw new Exception("File with data options was not found");
                }

                dataMethods = configManager.Parse<DataMethods>();

                appInsights = new DataInputOutput(dataMethods.LoggerConnectionString);

                appInsights.ClearInsights();

                appInsights.InsertInsight("Connection was successfully established");
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
                Service1 service = new Service1(dataMethods, appInsights);

                ServiceBase.Run(service);
            }
            catch (Exception ex)
            {
                appInsights.InsertInsight("EXCEPTION: " + ex.Message);

                appInsights.WriteInsightsToXml(dataMethods.OutputFolder);
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

