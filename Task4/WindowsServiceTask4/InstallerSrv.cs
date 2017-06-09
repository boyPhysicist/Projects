using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace WindowsServiceTask4
{
    [RunInstaller(true)]
    public partial class InstallerSrv : System.Configuration.Install.Installer
    {
        public InstallerSrv()
        {
            InitializeComponent();
            var serviceInstaller = new ServiceInstaller();
            var processInstaller = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};

            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "ServiceTask4";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
