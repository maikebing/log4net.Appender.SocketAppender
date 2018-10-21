using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace SocketAppenderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerRepository repository = LogManager.CreateRepository("SocketAppenderTest");
            string log4configfile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            log4net.GlobalContext.Properties["HostIP"] = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()).FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            log4net.GlobalContext.Properties["Version"] = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString(4);
            log4net.GlobalContext.Properties["AppName"] = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            log4net.GlobalContext.Properties["AppFullName"] = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
            XmlConfigurator.Configure(repository, new FileInfo(log4configfile));
            ILog log = LogManager.GetLogger(repository.Name, "SocketAppenderTest");
            log.Info("{NETCorelog4netlog}");
            log.Info("{test log}");
            log.Error("error");
            log.Info("linezero");
            Console.ReadKey();
        }
    }
}
