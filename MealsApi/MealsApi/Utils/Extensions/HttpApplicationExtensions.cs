using System;
using System.Threading.Tasks;
using System.Web;

namespace MealsApi.Utils.Extensions
{
    public static class HttpApplicationExtensions
    {
        public static void EnableMonitoring(this HttpApplication app)
        {
            TaskScheduler.UnobservedTaskException += UnhandledExceptionUtils.TaskSchedulerUnobservedTaskException;
            AppDomain.MonitoringIsEnabled = true;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionUtils.CurrentDomainUnhandledException;
        }
    }
}