using PostSharp.Tutorials.Logging.BusinessLogic;
using PostSharp.Patterns.Diagnostics;
using NLog;
using NLog.Config;
using NLog.Targets;
using PostSharp.Patterns.Diagnostics.Backends.NLog;
using NLog.Layouts;

namespace PostSharp.Tutorials.Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            var nlogConfig = new LoggingConfiguration();

            var traceTarget = new FileTarget("file")
            {
                FileName = "trace.log",
                KeepFileOpen = true,
                ConcurrentWrites = false,
                Header = new SimpleLayout("Time|Level|Class|Method|Info")
            };
            nlogConfig.AddTarget(traceTarget);
            nlogConfig.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Trace, traceTarget));

            var warnTarget = new FileTarget("file")
            {
                FileName = "warn.log",
                KeepFileOpen = true,
                ConcurrentWrites = false,
                Header = new SimpleLayout("Time|Level|Class|Method|Info")
            };
            nlogConfig.AddTarget(warnTarget);
            nlogConfig.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Warn, warnTarget));

            LogManager.EnableLogging();

            LoggingServices.DefaultBackend = new NLogLoggingBackend(new LogFactory(nlogConfig));

            RequestProcessor requestProcessor = new RequestProcessor();
            requestProcessor.ProcessRequests("requestsQueue");
        }
    }
}
