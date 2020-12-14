using System.ServiceProcess;
using DataManagerDll;

namespace Lab4
{
    public partial class Service1 : ServiceBase
    {
        readonly DataInputOutput infoMessage;

        readonly DataMethods dataMethods;
        public Service1(DataMethods dataMethods, DataInputOutput infoMessage)
        {
            InitializeComponent();

            this.dataMethods = dataMethods;

            this.infoMessage = infoMessage;
        }

        protected override void OnStart(string[] args)
        {
            DataInputOutput reader = new DataInputOutput(dataMethods.ConnectionString);

            DataTransfer fileTransfer = new DataTransfer(dataMethods.OutputFolder, dataMethods.SourcePath);

            string ordersFileName = "orders";

            reader.GetCustomers(dataMethods.OutputFolder, infoMessage, ordersFileName);

            fileTransfer.SendDataToFileManager($"{ordersFileName}.xml");

            infoMessage.InsertLogs("Files were sent to FTP successfully");
        }

        protected override void OnStop()
        {
            infoMessage.InsertLogs("Service was successfully stopped");

            infoMessage.WriteInsightsToXml(dataMethods.OutputFolder);
        }
    }
}
