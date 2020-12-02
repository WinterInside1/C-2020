using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Linq;
using System.Threading.Tasks;

namespace BIgBroatherFinal
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        ServiceInstaller installer;
        ServiceProcessInstaller processInstaller;
        public Installer1()
        {
            InitializeComponent();
            installer = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;
            installer.StartType = ServiceStartMode.Manual;
            installer.ServiceName = "Service1";
            Installers.Add(installer);
            Installers.Add(processInstaller);
        }
    }
}
