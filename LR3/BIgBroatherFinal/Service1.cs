using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BIgBroatherFinal
{
    public partial class Service1 : ServiceBase
    {
        Logger logger;
        private Settings settings;

        internal void OnDebug()
        {
            OnStart(null);
        }

        public Service1()
        {
            InitializeComponent();
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }
        
        protected override void OnStart(string[] args)
        {

            Manager parser = new Manager("Settings.xml");
            settings = parser.Parse<Settings>();
            logger = new Logger(settings);
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);

        }
       

    }
}
