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

namespace WindowsServiceTask4
{
    public partial class Service1 : ServiceBase
    {
        private Logger _logger;
        public Service1()
        {
            InitializeComponent();
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            _logger = new Logger();
            Thread loggerThread = new Thread(_logger.Start);
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            _logger.Stop();
            Thread.Sleep(1000);
        }
    }
}
