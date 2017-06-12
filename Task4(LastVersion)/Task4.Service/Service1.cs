using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task4_LastVersion_;

namespace Task4.Service
{
    public partial class Service1 : ServiceBase
    {
        private LoggerStarter _ls;
        public Service1()
        {
            InitializeComponent();
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            _ls = new LoggerStarter();
            Thread loggerThread = new Thread(_ls.Start);
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            _ls.Stop();
            Thread.Sleep(1000);
        }
    }
}
