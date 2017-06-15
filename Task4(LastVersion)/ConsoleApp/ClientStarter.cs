using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task4_LastVersion_;

namespace ConsoleApp
{
    public class ClientStarter
    {
        private LoggerStarter _loggerStarter;

        public void Start()
        {
            _loggerStarter = new LoggerStarter();
            Thread lgThread =new Thread(_loggerStarter.Start);
            lgThread.Start();
        }

        public void Stop()
        {
            _loggerStarter.Stop();
            Thread.Sleep(1000);
        }
    }
}
